/*
order: 30
title: Transliteration
slug: transliteration

Convert text between scripts (e.g., Devanagari to Roman) without changing the language.
*/

namespace SarvamAI.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_TransliterateText()
    {
        using var client = GetAuthenticatedClient();

        //// Transliterate Hindi text from Devanagari to Roman script
        var response = await client.TransliterateTextAsync(
            request: new TransliterateRequest
            {
                Input = "namaste, aap kaise hain?",
                SourceLanguageCode = TransliterateRequestSourceLanguageCode.EnIn,
                TargetLanguageCode = TransliterateRequestTargetLanguageCode.HiIn,
            });

        response.TransliteratedText.Should().NotBeNullOrEmpty();

        Console.WriteLine($"Transliterated text: {response.TransliteratedText}");
    }
}
