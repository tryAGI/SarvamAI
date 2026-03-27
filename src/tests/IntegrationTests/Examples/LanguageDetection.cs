/*
order: 35
title: Language Detection
slug: language-detection

Detect the language and script of input text using the Sarvam AI Language Detection API.
*/

namespace SarvamAI.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_DetectLanguage()
    {
        using var client = GetAuthenticatedClient();

        //// Detect the language and script of Hindi text
        var response = await client.DetectLanguageAsync(
            request: new DetectLanguageRequest
            {
                Input = "नमस्ते, आप कैसे हैं?",
            });

        response.LanguageCode.Should().NotBeNullOrEmpty();
        response.ScriptCode.Should().NotBeNullOrEmpty();

        Console.WriteLine($"Language: {response.LanguageCode}");
        Console.WriteLine($"Script: {response.ScriptCode}");
    }
}
