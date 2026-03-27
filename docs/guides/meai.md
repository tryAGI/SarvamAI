# Microsoft.Extensions.AI Integration

SarvamAI implements
[Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI)
interfaces for chat completions (`IChatClient`) and speech-to-text transcription
(`ISpeechToTextClient`), plus `AIFunction` tools for translation, transliteration,
and language detection.

## IChatClient

SarvamAI implements `IChatClient` for chat completions using the
`/v1/chat/completions` endpoint with Sarvam-30B and Sarvam-105B models.

```csharp
using SarvamAI;
using Microsoft.Extensions.AI;

IChatClient client = new SarvamAIClient(apiKey);

var response = await client.GetResponseAsync(
    "Say hello in Hindi.",
    new ChatOptions
    {
        ModelId = "sarvam-30b",
        MaxOutputTokens = 128,
    });

Console.WriteLine(response.Text);
```

### Chat Options

- **ModelId**: `"sarvam-30b"` or `"sarvam-105b"`
- **Temperature**, **TopP**, **MaxOutputTokens**: Standard generation parameters
- **Tools**: Function calling support via `AIFunction` tools
- **StopSequences**: Custom stop sequences
- **AdditionalProperties**:
  - `"reasoning_effort"`: Controls reasoning depth (`"low"`, `"medium"`, `"high"`)
  - `"wiki_grounding"`: Enable Wikipedia grounding (`true`/`false`)

```csharp
var response = await client.GetResponseAsync(
    "Explain quantum computing in Hindi",
    new ChatOptions
    {
        ModelId = "sarvam-105b",
        Temperature = 0.7f,
        AdditionalProperties = new()
        {
            ["wiki_grounding"] = true,
        },
    });
```

## ISpeechToTextClient

SarvamAI implements `ISpeechToTextClient` for speech-to-text transcription
supporting 22+ Indian languages using Saaras v3 and Saarika v2.5 models.

```csharp
using SarvamAI;
using Microsoft.Extensions.AI;

ISpeechToTextClient client = new SarvamAIClient(apiKey);

await using var audioStream = File.OpenRead("audio.wav");
var response = await client.GetTextAsync(audioStream);

Console.WriteLine(response.Text);
```

### Options

- **SpeechLanguage**: Set the transcription language using BCP-47 codes (e.g., `"hi-IN"`, `"bn-IN"`, `"ta-IN"`)
- **ModelId**: Choose the STT model (e.g., `"saaras:v3"`, `"saarika:v2.5"`)

```csharp
var options = new SpeechToTextOptions
{
    SpeechLanguage = "hi-IN",
    ModelId = "saaras:v3",
};
var response = await client.GetTextAsync(audioStream, options);
```

## Available Tools

| Method | Tool Name | Description |
|--------|-----------|-------------|
| `AsTranslateTool()` | `TranslateText` | Translates text between 22+ Indian languages and English. |
| `AsTransliterateTool()` | `TransliterateText` | Converts text between Indic scripts and Roman script. |
| `AsDetectLanguageTool()` | `DetectLanguage` | Detects the language and script of input text. |

## Usage

```csharp
using SarvamAI;
using Microsoft.Extensions.AI;

var sarvam = new SarvamAIClient(apiKey);

// Create tools
var tools = new[]
{
    sarvam.AsTranslateTool(mode: "formal"),
    sarvam.AsTransliterateTool(),
    sarvam.AsDetectLanguageTool(),
};

// Use with any IChatClient
var response = await chatClient.GetResponseAsync(
    "Translate 'Hello, how are you?' to Hindi and then transliterate it to Roman script",
    new ChatOptions { Tools = tools });
```

## Tool Details

### TranslateText

Translates text between Indian languages (Hindi, Bengali, Tamil, Telugu, Kannada,
Malayalam, Marathi, Gujarati, Punjabi, Odia, and more) and English. Uses BCP-47
language codes. Accepts a `mode` parameter: `"formal"` (default), `"modern-colloquial"`,
`"classic-colloquial"`, or `"code-mixed"`.

```csharp
var tool = sarvam.AsTranslateTool(mode: "modern-colloquial");
```

### TransliterateText

Converts text from one script to another without changing the language. For example,
converts Hindi written in Devanagari to Roman script, or vice versa. Supports
auto-detection of source script.

```csharp
var tool = sarvam.AsTransliterateTool();
```

### DetectLanguage

Detects the language and script of input text. Returns the BCP-47 language code
(e.g., `hi-IN` for Hindi) and the script code (e.g., `Deva` for Devanagari,
`Latn` for Latin).

```csharp
var tool = sarvam.AsDetectLanguageTool();
```
