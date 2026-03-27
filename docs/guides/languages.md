# Supported Languages

Sarvam AI supports 22+ Indian languages across all its APIs.

## Language Codes

Use BCP-47 language codes when calling translation, transliteration, STT, and TTS endpoints:

| Language | Code | Script |
|----------|------|--------|
| Assamese | `as-IN` | Bengali |
| Bengali | `bn-IN` | Bengali |
| Bodo | `brx-IN` | Devanagari |
| Dogri | `doi-IN` | Devanagari |
| English | `en-IN` | Latin |
| Gujarati | `gu-IN` | Gujarati |
| Hindi | `hi-IN` | Devanagari |
| Kannada | `kn-IN` | Kannada |
| Kashmiri | `ks-IN` | Arabic/Devanagari |
| Konkani | `kok-IN` | Devanagari |
| Maithili | `mai-IN` | Devanagari |
| Malayalam | `ml-IN` | Malayalam |
| Manipuri | `mni-IN` | Bengali/Meetei Mayek |
| Marathi | `mr-IN` | Devanagari |
| Nepali | `ne-IN` | Devanagari |
| Odia | `od-IN` | Odia |
| Punjabi | `pa-IN` | Gurmukhi |
| Sanskrit | `sa-IN` | Devanagari |
| Santali | `sat-IN` | Ol Chiki |
| Sindhi | `sd-IN` | Arabic/Devanagari |
| Tamil | `ta-IN` | Tamil |
| Telugu | `te-IN` | Telugu |
| Urdu | `ur-IN` | Arabic |

## Auto-Detection

The translation and transliteration APIs support automatic source language
detection by using `auto` as the source language code:

```csharp
var response = await client.TranslateTextAsync(
    request: new TranslateRequest
    {
        Input = "नमस्ते, आप कैसे हैं?",
        SourceLanguageCode = TranslateRequestSourceLanguageCode.Auto,
        TargetLanguageCode = TranslateRequestTargetLanguageCode.EnIn,
    });
```

## Language Detection

Use the dedicated language detection endpoint to identify the language and
script of input text:

```csharp
var response = await client.DetectLanguageAsync(
    request: new DetectLanguageRequest
    {
        Input = "నమస్కారం",
    });

Console.WriteLine($"Language: {response.LanguageCode}");  // te-IN
Console.WriteLine($"Script: {response.ScriptCode}");      // Telu
```
