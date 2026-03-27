#nullable enable

using Meai = Microsoft.Extensions.AI;
using System.Runtime.CompilerServices;

namespace SarvamAI;

public sealed partial class SarvamAIClient : Meai.ISpeechToTextClient
{
    private Meai.SpeechToTextClientMetadata? _speechMetadata;

    /// <inheritdoc />
    object? Meai.ISpeechToTextClient.GetService(Type serviceType, object? serviceKey) =>
        serviceType is null ? throw new ArgumentNullException(nameof(serviceType)) :
        serviceKey is not null ? null :
        serviceType == typeof(Meai.SpeechToTextClientMetadata) ? (_speechMetadata ??= new("sarvam-ai", new Uri(DefaultBaseUrl))) :
        serviceType.IsInstanceOfType(this) ? this :
        null;

    /// <inheritdoc />
    async Task<Meai.SpeechToTextResponse> Meai.ISpeechToTextClient.GetTextAsync(
        Stream audioSpeechStream,
        Meai.SpeechToTextOptions? options,
        CancellationToken cancellationToken)
    {
        _ = audioSpeechStream ?? throw new ArgumentNullException(nameof(audioSpeechStream));

        // Read audio data into byte array
        MemoryStream? ms = audioSpeechStream as MemoryStream;
        if (ms is null || ms.Position != 0)
        {
            ms = new MemoryStream();
            await audioSpeechStream.CopyToAsync(ms, 81920, cancellationToken).ConfigureAwait(false);
        }

        var audioData = ms.TryGetBuffer(out ArraySegment<byte> buffer)
            && buffer.Array is not null && buffer.Offset == 0 && buffer.Count == ms.Length
                ? buffer.Array
                : ms.ToArray();

        // Map MEAI language to SarvamAI language code
        TranscribeSpeechRequestLanguageCode? languageCode = null;
        if (options?.SpeechLanguage is { Length: > 0 } language)
        {
            languageCode = TranscribeSpeechRequestLanguageCodeExtensions.ToEnum(language);
        }

        // Default to saaras:v3 model for best quality
        var model = TranscribeSpeechRequestModel.Saaras_v3;
        if (options?.ModelId is { Length: > 0 } modelId)
        {
            model = TranscribeSpeechRequestModelExtensions.ToEnum(modelId) ?? TranscribeSpeechRequestModel.Saaras_v3;
        }

        var response = await TranscribeSpeechAsync(
            file: audioData,
            filename: "audio.wav",
            model: model,
            mode: TranscribeSpeechRequestMode.Transcribe,
            languageCode: languageCode,
            cancellationToken: cancellationToken).ConfigureAwait(false);

        return new Meai.SpeechToTextResponse(response.Transcript ?? string.Empty)
        {
            RawRepresentation = response,
            ModelId = model.ToValueString(),
            AdditionalProperties = CreateSttAdditionalProperties(response),
        };
    }

    /// <inheritdoc />
    async IAsyncEnumerable<Meai.SpeechToTextResponseUpdate> Meai.ISpeechToTextClient.GetStreamingTextAsync(
        Stream audioSpeechStream,
        Meai.SpeechToTextOptions? options,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Sarvam AI REST STT is synchronous -- fall back to non-streaming
        var response = await ((Meai.ISpeechToTextClient)this)
            .GetTextAsync(audioSpeechStream, options, cancellationToken)
            .ConfigureAwait(false);

        foreach (var update in response.ToSpeechToTextResponseUpdates())
        {
            yield return update;
        }
    }

    private static Meai.AdditionalPropertiesDictionary? CreateSttAdditionalProperties(SpeechToTextResponse response)
    {
        var props = new Meai.AdditionalPropertiesDictionary();

        if (response.LanguageCode is { Length: > 0 } langCode)
        {
            props["language_code"] = langCode;
        }
        if (response.LanguageProbability is { } prob)
        {
            props["language_probability"] = prob;
        }
        if (response.RequestId is { Length: > 0 } reqId)
        {
            props["request_id"] = reqId;
        }

        return props.Count > 0 ? props : null;
    }
}
