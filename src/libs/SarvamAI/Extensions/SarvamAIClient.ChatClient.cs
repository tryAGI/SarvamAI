#nullable enable

using Microsoft.Extensions.AI;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace SarvamAI;

public sealed partial class SarvamAIClient : IChatClient
{
    private ChatClientMetadata? _chatMetadata;

    /// <inheritdoc />
    object? IChatClient.GetService(Type serviceType, object? serviceKey) =>
        serviceType is null ? throw new ArgumentNullException(nameof(serviceType)) :
        serviceKey is not null ? null :
        serviceType == typeof(ChatClientMetadata) ? (_chatMetadata ??= new("sarvam-ai", new Uri(DefaultBaseUrl))) :
        serviceType.IsInstanceOfType(this) ? this :
        null;

    /// <inheritdoc />
    async Task<ChatResponse> IChatClient.GetResponseAsync(
        IEnumerable<ChatMessage> chatMessages,
        ChatOptions? options,
        CancellationToken cancellationToken)
    {
        var request = CreateChatCompletionRequest(chatMessages, options);

        var response = await CreateChatCompletionAsync(
            request,
            cancellationToken).ConfigureAwait(false);

        return ToChatResponse(response, options);
    }

    /// <inheritdoc />
    async IAsyncEnumerable<ChatResponseUpdate> IChatClient.GetStreamingResponseAsync(
        IEnumerable<ChatMessage> chatMessages,
        ChatOptions? options,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Sarvam AI supports streaming via SSE, but the generated client
        // doesn't support streaming out of the box. Fall back to non-streaming
        // and yield the full response as a single update.
        var response = await ((IChatClient)this)
            .GetResponseAsync(chatMessages, options, cancellationToken)
            .ConfigureAwait(false);

        foreach (var update in response.ToChatResponseUpdates())
        {
            yield return update;
        }
    }

    private static ChatCompletionRequest CreateChatCompletionRequest(
        IEnumerable<ChatMessage> chatMessages,
        ChatOptions? options)
    {
        var messages = new List<ChatCompletionMessage>();
        foreach (var msg in chatMessages)
        {
            if (msg.Role == ChatRole.Tool)
            {
                // Each FunctionResultContent becomes a separate tool message
                foreach (var content in msg.Contents)
                {
                    if (content is FunctionResultContent frc)
                    {
                        messages.Add(new ChatCompletionMessage
                        {
                            Role = ChatCompletionMessageRole.Tool,
                            Content = frc.Result is string s ? s : JsonSerializer.Serialize(frc.Result),
                            ToolCallId = frc.CallId,
                        });
                    }
                }
                continue;
            }

            var role = msg.Role == ChatRole.System ? ChatCompletionMessageRole.System :
                       msg.Role == ChatRole.Assistant ? ChatCompletionMessageRole.Assistant :
                       ChatCompletionMessageRole.User;

            var chatMsg = new ChatCompletionMessage
            {
                Role = role,
                Content = msg.Text,
            };

            // Handle tool calls from assistant messages
            if (msg.Role == ChatRole.Assistant)
            {
                var toolCalls = new List<ChatCompletionToolCall>();
                foreach (var content in msg.Contents)
                {
                    if (content is FunctionCallContent fcc)
                    {
                        toolCalls.Add(new ChatCompletionToolCall
                        {
                            Id = fcc.CallId ?? string.Empty,
                            Type = ChatCompletionToolCallType.Function,
                            Function = new ChatCompletionToolCallFunction
                            {
                                Name = fcc.Name,
                                Arguments = JsonSerializer.Serialize(fcc.Arguments),
                            },
                        });
                    }
                }
                if (toolCalls.Count > 0)
                {
                    chatMsg.ToolCalls = toolCalls;
                }
            }

            messages.Add(chatMsg);
        }

        var request = new ChatCompletionRequest
        {
            Messages = messages,
            Model = ChatCompletionRequestModelExtensions.ToEnum(options?.ModelId ?? "sarvam-30b")
                ?? ChatCompletionRequestModel.Sarvam30b,
        };

        if (options is not null)
        {
            request.Temperature = options.Temperature;
            request.TopP = options.TopP;
            request.MaxTokens = options.MaxOutputTokens;
            request.FrequencyPenalty = options.FrequencyPenalty;
            request.PresencePenalty = options.PresencePenalty;
            request.Seed = (int?)options.Seed;
            request.Stop = options.StopSequences?.ToList();

            // Map tools
            if (options.Tools is { Count: > 0 })
            {
                var tools = new List<ChatCompletionTool>();
                foreach (var tool in options.Tools)
                {
                    if (tool is AIFunction func)
                    {
                        tools.Add(new ChatCompletionTool
                        {
                            Type = ChatCompletionToolType.Function,
                            Function = new ChatCompletionToolFunction
                            {
                                Name = func.Name,
                                Description = func.Description,
                                Parameters = func.JsonSchema is { } schema
                                    ? JsonSerializer.Deserialize<ChatCompletionToolFunctionParameters>(
                                        JsonSerializer.Serialize(schema))
                                    : null,
                            },
                        });
                    }
                }
                if (tools.Count > 0)
                {
                    request.Tools = tools;
                    request.ToolChoice = options.ToolMode switch
                    {
                        AutoChatToolMode => ChatCompletionRequestToolChoice.Auto,
                        RequiredChatToolMode => ChatCompletionRequestToolChoice.Required,
                        _ => null,
                    };
                }
            }

            // Map additional properties
            if (options.AdditionalProperties is { } props)
            {
                if (props.TryGetValue("reasoning_effort", out var re) && re is string reStr)
                {
                    request.ReasoningEffort = ChatCompletionRequestReasoningEffortExtensions.ToEnum(reStr);
                }
                if (props.TryGetValue("wiki_grounding", out var wg) && wg is bool wgBool)
                {
                    request.WikiGrounding = wgBool;
                }
            }
        }

        return request;
    }

    private static ChatResponse ToChatResponse(
        ChatCompletionResponse response,
        ChatOptions? options)
    {
        var chatMessage = new ChatMessage { Role = ChatRole.Assistant };
        ChatFinishReason? finishReason = null;

        if (response.Choices is { Count: > 0 })
        {
            var choice = response.Choices[0];
            if (choice.Message?.Content is { Length: > 0 } content)
            {
                chatMessage.Contents.Add(new TextContent(content));
            }

            // Handle tool calls
            if (choice.Message?.ToolCalls is { Count: > 0 } toolCalls)
            {
                foreach (var tc in toolCalls)
                {
                    IDictionary<string, object?>? args = null;
                    if (tc.Function?.Arguments is { Length: > 0 } argsJson)
                    {
                        args = JsonSerializer.Deserialize<Dictionary<string, object?>>(argsJson);
                    }
                    chatMessage.Contents.Add(new FunctionCallContent(
                        tc.Id ?? string.Empty,
                        tc.Function?.Name ?? string.Empty,
                        args));
                }
            }

            finishReason = choice.FinishReason switch
            {
                ChatCompletionChoiceFinishReason.Stop => ChatFinishReason.Stop,
                ChatCompletionChoiceFinishReason.Length => ChatFinishReason.Length,
                ChatCompletionChoiceFinishReason.ToolCalls => ChatFinishReason.ToolCalls,
                ChatCompletionChoiceFinishReason.ContentFilter => ChatFinishReason.ContentFilter,
                _ => null,
            };
        }

        var chatResponse = new ChatResponse(chatMessage)
        {
            RawRepresentation = response,
            ModelId = response.Model ?? options?.ModelId,
            FinishReason = finishReason,
            ResponseId = response.Id,
            CreatedAt = response.Created,
        };

        if (response.Usage is { } usage)
        {
            chatResponse.Usage = new UsageDetails
            {
                InputTokenCount = usage.PromptTokens,
                OutputTokenCount = usage.CompletionTokens,
                TotalTokenCount = usage.TotalTokens,
            };
        }

        return chatResponse;
    }
}
