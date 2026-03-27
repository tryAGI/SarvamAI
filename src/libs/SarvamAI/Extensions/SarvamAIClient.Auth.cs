#nullable enable

namespace SarvamAI;

public partial class SarvamAIClient
{
    // Sarvam AI uses "api-subscription-key" header instead of "Authorization: Bearer".
    // The generated code sends "Authorization: Bearer <key>" but Sarvam AI
    // expects the API key in the "api-subscription-key" header.
    partial void PrepareRequest(
        global::System.Net.Http.HttpClient client,
        global::System.Net.Http.HttpRequestMessage request)
    {
        if (request.Headers.Authorization is { Scheme: "Bearer", Parameter: { } apiKey })
        {
            request.Headers.Authorization = null;
            request.Headers.TryAddWithoutValidation("api-subscription-key", apiKey);
        }
    }
}
