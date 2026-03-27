namespace SarvamAI.IntegrationTests;

[TestClass]
public partial class Tests
{
    private static SarvamAIClient GetAuthenticatedClient()
    {
        var apiKey =
            Environment.GetEnvironmentVariable("SARVAMAI_API_KEY") is { Length: > 0 } apiKeyValue
                ? apiKeyValue
                : throw new AssertInconclusiveException("SARVAMAI_API_KEY environment variable is not found.");

        var client = new SarvamAIClient(apiKey);
        
        return client;
    }
}
