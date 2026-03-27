/*
order: 20
title: Chat Completion
slug: chat-completion

Generate chat completions using Sarvam AI's Indian language LLMs (Sarvam-105B, Sarvam-30B).
*/

namespace SarvamAI.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_ChatCompletion()
    {
        using var client = GetAuthenticatedClient();

        //// Create a chat completion with Sarvam-30B
        var response = await client.CreateChatCompletionAsync(
            request: new ChatCompletionRequest
            {
                Model = ChatCompletionRequestModel.Sarvam30b,
                Messages =
                [
                    new ChatCompletionMessage
                    {
                        Role = ChatCompletionMessageRole.System,
                        Content = "You are a helpful assistant that speaks Hindi.",
                    },
                    new ChatCompletionMessage
                    {
                        Role = ChatCompletionMessageRole.User,
                        Content = "Tell me about India in 2 sentences.",
                    },
                ],
                Temperature = 0.7,
                MaxTokens = 256,
            });

        response.Choices.Should().NotBeNullOrEmpty();
        response.Choices![0].Message?.Content.Should().NotBeNullOrEmpty();
        response.Usage.Should().NotBeNull();

        Console.WriteLine($"Response: {response.Choices[0].Message?.Content}");
        Console.WriteLine($"Tokens used: {response.Usage?.TotalTokens}");
    }
}
