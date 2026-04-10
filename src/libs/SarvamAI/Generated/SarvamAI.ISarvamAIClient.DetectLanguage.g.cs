#nullable enable

namespace SarvamAI
{
    public partial interface ISarvamAIClient
    {
        /// <summary>
        /// Detect language and script<br/>
        /// Identifies the language and script of input text.<br/>
        /// Max 1000 characters per request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::SarvamAI.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::SarvamAI.DetectLanguageResponse> DetectLanguageAsync(

            global::SarvamAI.DetectLanguageRequest request,
            global::SarvamAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Detect language and script<br/>
        /// Identifies the language and script of input text.<br/>
        /// Max 1000 characters per request.
        /// </summary>
        /// <param name="input">
        /// Text for language and script identification (max 1000 characters)
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::SarvamAI.DetectLanguageResponse> DetectLanguageAsync(
            string input,
            global::SarvamAI.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}