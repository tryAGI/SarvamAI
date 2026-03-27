# Authentication

Sarvam AI uses a dual authentication pattern depending on the endpoint.

## Getting an API Key

1. Sign up at [sarvam.ai](https://sarvam.ai)
2. Navigate to your dashboard to obtain your **API subscription key**
3. The same key works for all endpoints — the SDK handles the dual auth automatically

## Usage

```csharp
using SarvamAI;

using var client = new SarvamAIClient(apiKey);
```

## Dual Auth Pattern

Sarvam AI uses two different auth headers depending on the endpoint:

| Endpoint | Auth Header |
|----------|-------------|
| `/v1/chat/completions` | `Authorization: Bearer <key>` |
| All other endpoints | `api-subscription-key: <key>` |

The SDK's `PrepareRequest` hook in `SarvamAIClient.Auth.cs` handles this
automatically — you don't need to manage it.

## Environment Variables

For integration tests, set the `SARVAMAI_API_KEY` environment variable:

```bash
export SARVAMAI_API_KEY="your-api-key"
```
