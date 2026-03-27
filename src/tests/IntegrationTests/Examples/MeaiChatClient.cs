/*
order: 40
title: MEAI Chat Client
slug: meai-chat-client

Use SarvamAIClient as a Microsoft.Extensions.AI IChatClient for unified .NET AI abstractions.
*/

using Microsoft.Extensions.AI;

namespace SarvamAI.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_MeaiGetResponse()
    {
        using var client = GetAuthenticatedClient();

        //// Use SarvamAIClient as an IChatClient
        IChatClient chatClient = client;

        var response = await chatClient.GetResponseAsync(
            "Say hello in Hindi.",
            new ChatOptions
            {
                ModelId = "sarvam-30b",
                MaxOutputTokens = 128,
            });

        response.Text.Should().NotBeNullOrEmpty();
        response.ModelId.Should().NotBeNullOrEmpty();

        Console.WriteLine($"Response: {response.Text}");
    }

    [TestMethod]
    public async Task Example_MeaiGetServiceMetadata()
    {
        using var client = GetAuthenticatedClient();

        //// Get service metadata from the IChatClient
        IChatClient chatClient = client;

        var metadata = chatClient.GetService<ChatClientMetadata>();
        metadata.Should().NotBeNull();
        metadata!.ProviderName.Should().Be("sarvam-ai");

        var self = chatClient.GetService<SarvamAIClient>();
        self.Should().NotBeNull();
        self.Should().BeSameAs(client);
    }
}
