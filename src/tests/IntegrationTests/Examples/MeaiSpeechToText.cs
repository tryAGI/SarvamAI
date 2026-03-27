/*
order: 50
title: MEAI Speech-to-Text
slug: meai-speech-to-text

Use SarvamAIClient as a Microsoft.Extensions.AI ISpeechToTextClient for unified speech transcription.
*/

using Meai = Microsoft.Extensions.AI;

namespace SarvamAI.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_MeaiSpeechToTextGetServiceMetadata()
    {
        using var client = GetAuthenticatedClient();

        //// Get service metadata from the ISpeechToTextClient
        Meai.ISpeechToTextClient sttClient = client;

        var metadata = Meai.SpeechToTextClientExtensions.GetService<Meai.SpeechToTextClientMetadata>(sttClient);
        metadata.Should().NotBeNull();
        metadata!.ProviderName.Should().Be("sarvam-ai");

        var self = Meai.SpeechToTextClientExtensions.GetService<SarvamAIClient>(sttClient);
        self.Should().NotBeNull();
        self.Should().BeSameAs(client);
    }
}
