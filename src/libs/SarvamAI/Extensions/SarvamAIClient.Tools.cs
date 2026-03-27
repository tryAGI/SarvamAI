#pragma warning disable CS3002 // Return type is not CLS-compliant
using Microsoft.Extensions.AI;

namespace SarvamAI;

/// <summary>
/// Extensions for using SarvamAIClient as MEAI tools with any IChatClient.
/// </summary>
public static class SarvamAIToolExtensions
{
    /// <summary>
    /// Creates an <see cref="AIFunction"/> that wraps Sarvam AI text translation,
    /// suitable for use as a tool with any IChatClient.
    /// Translates text between 22+ Indian languages and English.
    /// </summary>
    /// <param name="client">The Sarvam AI client to use for translation.</param>
    /// <param name="mode">Translation mode: formal, modern-colloquial, classic-colloquial, or code-mixed. Default: formal.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsTranslateTool(
        this SarvamAIClient client,
        string mode = "formal")
    {
        ArgumentNullException.ThrowIfNull(client);

        var translationMode = TranslateRequestModeExtensions.ToEnum(mode)
            ?? TranslateRequestMode.Formal;

        return AIFunctionFactory.Create(
            async (
                string text,
                string sourceLanguageCode,
                string targetLanguageCode,
                CancellationToken cancellationToken) =>
            {
                var sourceLang = TranslateRequestSourceLanguageCodeExtensions.ToEnum(sourceLanguageCode)
                    ?? TranslateRequestSourceLanguageCode.Auto;
                var targetLang = TranslateRequestTargetLanguageCodeExtensions.ToEnum(targetLanguageCode)
                    ?? TranslateRequestTargetLanguageCode.EnIn;

                var response = await client.TranslateTextAsync(
                    request: new TranslateRequest
                    {
                        Input = text,
                        SourceLanguageCode = sourceLang,
                        TargetLanguageCode = targetLang,
                        Mode = translationMode,
                    },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return response.TranslatedText ?? string.Empty;
            },
            name: "TranslateText",
            description:
                "Translates text between Indian languages (Hindi, Bengali, Tamil, Telugu, Kannada, Malayalam, " +
                "Marathi, Gujarati, Punjabi, Odia, Assamese, Urdu, Nepali, and more) and English. " +
                "Use BCP-47 language codes: hi-IN (Hindi), bn-IN (Bengali), ta-IN (Tamil), te-IN (Telugu), " +
                "kn-IN (Kannada), ml-IN (Malayalam), mr-IN (Marathi), gu-IN (Gujarati), pa-IN (Punjabi), " +
                "od-IN (Odia), en-IN (English), or 'auto' for auto-detection of source language.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that wraps Sarvam AI text transliteration,
    /// suitable for use as a tool with any IChatClient.
    /// Converts text between Indic scripts and Roman script.
    /// </summary>
    /// <param name="client">The Sarvam AI client to use for transliteration.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsTransliterateTool(
        this SarvamAIClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (
                string text,
                string sourceLanguageCode,
                string targetLanguageCode,
                CancellationToken cancellationToken) =>
            {
                var sourceLang = TransliterateRequestSourceLanguageCodeExtensions.ToEnum(sourceLanguageCode)
                    ?? TransliterateRequestSourceLanguageCode.Auto;
                var targetLang = TransliterateRequestTargetLanguageCodeExtensions.ToEnum(targetLanguageCode)
                    ?? TransliterateRequestTargetLanguageCode.EnIn;

                var response = await client.TransliterateTextAsync(
                    request: new TransliterateRequest
                    {
                        Input = text,
                        SourceLanguageCode = sourceLang,
                        TargetLanguageCode = targetLang,
                    },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return response.TransliteratedText ?? string.Empty;
            },
            name: "TransliterateText",
            description:
                "Transliterates text from one script to another without changing the language. " +
                "For example, converts Hindi written in Latin script (Devanagari) to Hindi written in Roman script, or vice versa. " +
                "Use BCP-47 language codes: hi-IN, bn-IN, ta-IN, te-IN, kn-IN, ml-IN, mr-IN, gu-IN, pa-IN, od-IN, en-IN, " +
                "or 'auto' for auto-detection of source script.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that wraps Sarvam AI language detection,
    /// suitable for use as a tool with any IChatClient.
    /// Detects the language and script of input text.
    /// </summary>
    /// <param name="client">The Sarvam AI client to use for language detection.</param>
    /// <returns>An AIFunction that can be passed to ChatOptions.Tools.</returns>
    public static AIFunction AsDetectLanguageTool(
        this SarvamAIClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string text, CancellationToken cancellationToken) =>
            {
                var response = await client.DetectLanguageAsync(
                    request: new DetectLanguageRequest
                    {
                        Input = text,
                    },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return $"Language: {response.LanguageCode ?? "unknown"}, Script: {response.ScriptCode ?? "unknown"}";
            },
            name: "DetectLanguage",
            description:
                "Detects the language and script of input text. Returns the BCP-47 language code " +
                "(e.g., hi-IN for Hindi, bn-IN for Bengali) and the script code " +
                "(e.g., Deva for Devanagari, Latn for Latin, Beng for Bengali).");
    }
}
