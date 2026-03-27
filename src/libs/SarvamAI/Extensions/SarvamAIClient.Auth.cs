#nullable enable

namespace SarvamAI;

public partial class SarvamAIClient
{
    /// <summary>
    /// Sarvam AI uses dual auth:
    /// - /v1/chat/completions uses standard "Authorization: Bearer" header
    /// - All other endpoints use "api-subscription-key" header
    /// The generated code always sends Bearer auth, so we convert it for non-chat endpoints.
    /// </summary>
    partial void PrepareRequest(
        global::System.Net.Http.HttpClient client,
        global::System.Net.Http.HttpRequestMessage request)
    {
        if (request.Headers.Authorization is { Scheme: "Bearer", Parameter: { } apiKey })
        {
            var path = request.RequestUri?.AbsolutePath ?? string.Empty;
            if (!path.StartsWith("/v1/", global::System.StringComparison.OrdinalIgnoreCase))
            {
                request.Headers.Authorization = null;
                request.Headers.TryAddWithoutValidation("api-subscription-key", apiKey);
            }
        }
    }
}
