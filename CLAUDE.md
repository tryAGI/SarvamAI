# CLAUDE.md -- SarvamAI SDK

## Overview

Auto-generated C# SDK for [Sarvam AI](https://sarvam.ai/) -- Indian language AI platform providing chat completions, speech-to-text, text-to-speech, translation, transliteration, and language detection for 22+ Indian languages.
**No public OpenAPI spec exists** -- `openapi.yaml` was manually created from Sarvam AI API documentation.

## Build & Test

```bash
dotnet build SarvamAI.slnx
dotnet test src/tests/IntegrationTests/
```

## Auth

Bearer token auth with API subscription key:

```csharp
var client = new SarvamAIClient(apiKey); // SARVAMAI_API_KEY env var
```

Sarvam AI uses dual auth:
- `/v1/chat/completions` uses standard `Authorization: Bearer` header
- All other endpoints use `api-subscription-key` header
- The `PrepareRequest` hook in `SarvamAIClient.Auth.cs` handles this automatically

## Key Files

- `src/libs/SarvamAI/openapi.yaml` -- **Manually maintained** OpenAPI spec (no public spec from Sarvam AI)
- `src/libs/SarvamAI/generate.sh` -- Runs autosdk generation (no download step)
- `src/libs/SarvamAI/Generated/` -- **Never edit** -- auto-generated code
- `src/libs/SarvamAI/Extensions/SarvamAIClient.Auth.cs` -- Dual auth handler (Bearer for chat, api-subscription-key for rest)
- `src/libs/SarvamAI/Extensions/SarvamAIClient.ChatClient.cs` -- MEAI `IChatClient` implementation
- `src/libs/SarvamAI/Extensions/SarvamAIClient.SpeechToTextClient.cs` -- MEAI `ISpeechToTextClient` implementation
- `src/libs/SarvamAI/Extensions/SarvamAIClient.Tools.cs` -- MEAI `AIFunction` tools (translate, transliterate, detect language)
- `src/tests/IntegrationTests/Tests.cs` -- Test helper with bearer auth
- `src/tests/IntegrationTests/Examples/` -- Example tests (also generate docs)

## API Endpoints

| Path | Method | Description |
|------|--------|-------------|
| `/v1/chat/completions` | POST | Chat completions (Sarvam-105B, Sarvam-30B, Sarvam-M) |
| `/translate` | POST | Text translation (22+ languages) |
| `/transliterate` | POST | Script transliteration |
| `/text-lid` | POST | Language and script detection |
| `/text-to-speech` | POST | TTS with Bulbul v3 (30+ voices) |
| `/speech-to-text` | POST | STT with Saaras v3 (23 languages) |
| `/speech-to-text-translate` | POST | STT + translation to English |

## MEAI Integrations

- **IChatClient**: Full (text, tool calling, token usage, reasoning effort)
- **ISpeechToTextClient**: Full (synchronous transcription, language detection)
- **AIFunction tools**: `AsTranslateTool()`, `AsTransliterateTool()`, `AsDetectLanguageTool()`

Uses `Meai` alias pattern for `ISpeechToTextClient` (namespace conflict with generated `SpeechToTextResponse`).

## Supported Languages

Bengali (bn-IN), English (en-IN), Gujarati (gu-IN), Hindi (hi-IN), Kannada (kn-IN), Malayalam (ml-IN), Marathi (mr-IN), Odia (od-IN), Punjabi (pa-IN), Tamil (ta-IN), Telugu (te-IN), Assamese (as-IN), Bodo (brx-IN), Dogri (doi-IN), Konkani (kok-IN), Kashmiri (ks-IN), Maithili (mai-IN), Manipuri (mni-IN), Nepali (ne-IN), Sanskrit (sa-IN), Santali (sat-IN), Sindhi (sd-IN), Urdu (ur-IN)
