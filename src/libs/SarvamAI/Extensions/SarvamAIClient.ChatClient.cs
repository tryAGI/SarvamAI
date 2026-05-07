#nullable enable

using Microsoft.Extensions.AI;
using System.Runtime.CompilerServices;
using System.Text;
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
            request: request,
            cancellationToken: cancellationToken).ConfigureAwait(false);

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
                            Content = frc.Result is string s ? s : SerializeValue(frc.Result),
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
                                Arguments = SerializeArguments(fcc.Arguments),
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
                                Parameters = func.JsonSchema.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined
                                    ? null
                                    : func.JsonSchema,
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
                        args = ParseArguments(argsJson);
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

    private static Dictionary<string, object?>? ParseArguments(string argumentsJson)
    {
        try
        {
            using var document = JsonDocument.Parse(argumentsJson);
            if (document.RootElement.ValueKind != JsonValueKind.Object)
            {
                return null;
            }

            var arguments = new Dictionary<string, object?>(StringComparer.Ordinal);
            foreach (var property in document.RootElement.EnumerateObject())
            {
                arguments[property.Name] = property.Value.Clone();
            }

            return arguments;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private static string SerializeArguments(IEnumerable<KeyValuePair<string, object?>>? arguments)
    {
        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream))
        {
            if (arguments is null)
            {
                writer.WriteStartObject();
                writer.WriteEndObject();
            }
            else
            {
                WriteObject(writer, arguments);
            }
        }

        return Encoding.UTF8.GetString(stream.ToArray());
    }

    private static string SerializeValue(object? value)
    {
        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream))
        {
            WriteValue(writer, value);
        }

        return Encoding.UTF8.GetString(stream.ToArray());
    }

    private static void WriteObject(Utf8JsonWriter writer, IEnumerable<KeyValuePair<string, object?>> values)
    {
        writer.WriteStartObject();
        foreach (var (key, value) in values)
        {
            writer.WritePropertyName(key);
            WriteValue(writer, value);
        }
        writer.WriteEndObject();
    }

    private static void WriteValue(Utf8JsonWriter writer, object? value)
    {
        switch (value)
        {
            case null:
                writer.WriteNullValue();
                break;
            case JsonElement element:
                element.WriteTo(writer);
                break;
            case string text:
                writer.WriteStringValue(text);
                break;
            case bool boolean:
                writer.WriteBooleanValue(boolean);
                break;
            case int number:
                writer.WriteNumberValue(number);
                break;
            case long number:
                writer.WriteNumberValue(number);
                break;
            case float number:
                writer.WriteNumberValue(number);
                break;
            case double number:
                writer.WriteNumberValue(number);
                break;
            case decimal number:
                writer.WriteNumberValue(number);
                break;
            case IReadOnlyDictionary<string, object?> dictionary:
                WriteObject(writer, dictionary);
                break;
            case IDictionary<string, object?> dictionary:
                WriteObject(writer, dictionary);
                break;
            case IEnumerable<object?> items:
                writer.WriteStartArray();
                foreach (var item in items)
                {
                    WriteValue(writer, item);
                }
                writer.WriteEndArray();
                break;
            default:
                writer.WriteStringValue(value.ToString());
                break;
        }
    }
}
