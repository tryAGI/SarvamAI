/*
order: 15
title: Translation
slug: translation

Translate text between Indian languages and English using the Sarvam AI Translation API.
*/

namespace SarvamAI.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_TranslateText()
    {
        using var client = GetAuthenticatedClient();

        //// Translate text from English to Hindi
        var response = await client.TranslateTextAsync(
            request: new TranslateRequest
            {
                Input = "Hello, how are you?",
                SourceLanguageCode = TranslateRequestSourceLanguageCode.EnIn,
                TargetLanguageCode = TranslateRequestTargetLanguageCode.HiIn,
                Mode = TranslateRequestMode.Formal,
            });

        response.TranslatedText.Should().NotBeNullOrEmpty();

        Console.WriteLine($"Translated text: {response.TranslatedText}");
    }
}
