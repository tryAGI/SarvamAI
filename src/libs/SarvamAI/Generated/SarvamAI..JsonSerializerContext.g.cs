
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace SarvamAI
{
    /// <summary>
    /// 
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[]
        {
            typeof(global::SarvamAI.JsonConverters.ErrorDetailCodeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ErrorDetailCodeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestSourceLanguageCodeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestSourceLanguageCodeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestTargetLanguageCodeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestTargetLanguageCodeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestSpeakerGenderJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestSpeakerGenderNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestModeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestModeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestModelJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestModelNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestOutputScriptJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestOutputScriptNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestNumeralsFormatJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateRequestNumeralsFormatNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TransliterateRequestSourceLanguageCodeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TransliterateRequestSourceLanguageCodeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TransliterateRequestTargetLanguageCodeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TransliterateRequestTargetLanguageCodeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TransliterateRequestNumeralsFormatJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TransliterateRequestNumeralsFormatNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TransliterateRequestSpokenFormNumeralsLanguageJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TransliterateRequestSpokenFormNumeralsLanguageNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TextToSpeechRequestTargetLanguageCodeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TextToSpeechRequestTargetLanguageCodeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TextToSpeechRequestModelJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TextToSpeechRequestModelNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TextToSpeechRequestSpeakerJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TextToSpeechRequestSpeakerNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TextToSpeechRequestSpeechSampleRateJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TextToSpeechRequestSpeechSampleRateNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TextToSpeechRequestOutputAudioCodecJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TextToSpeechRequestOutputAudioCodecNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionMessageRoleJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionMessageRoleNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionToolCallTypeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionToolCallTypeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionToolTypeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionToolTypeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionRequestModelJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionRequestModelNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionRequestReasoningEffortJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionRequestReasoningEffortNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionRequestToolChoiceJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionRequestToolChoiceNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionChoiceFinishReasonJsonConverter),

            typeof(global::SarvamAI.JsonConverters.ChatCompletionChoiceFinishReasonNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranscribeSpeechRequestModelJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranscribeSpeechRequestModelNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranscribeSpeechRequestModeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranscribeSpeechRequestModeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranscribeSpeechRequestLanguageCodeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranscribeSpeechRequestLanguageCodeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranscribeSpeechRequestInputAudioCodecJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranscribeSpeechRequestInputAudioCodecNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateSpeechRequestModelJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateSpeechRequestModelNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateSpeechRequestLanguageCodeJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateSpeechRequestLanguageCodeNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateSpeechRequestInputAudioCodecJsonConverter),

            typeof(global::SarvamAI.JsonConverters.TranslateSpeechRequestInputAudioCodecNullableJsonConverter),

            typeof(global::SarvamAI.JsonConverters.UnixTimestampJsonConverter),
        })]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.JsonSerializerContextTypes))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ErrorDetail))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ErrorDetailCode))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ErrorResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestSourceLanguageCode))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestTargetLanguageCode))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestSpeakerGender))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestMode))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestModel))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestOutputScript))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestNumeralsFormat))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateRequestSourceLanguageCode))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateRequestTargetLanguageCode))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateRequestNumeralsFormat))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateRequestSpokenFormNumeralsLanguage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.DetectLanguageRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.DetectLanguageResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequestTargetLanguageCode))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequestModel))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequestSpeaker))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(double))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequestSpeechSampleRate))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequestOutputAudioCodec))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.SpeechToTextResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(object))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionMessageRole))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::SarvamAI.ChatCompletionToolCall>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionToolCall))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionToolCallType))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionToolCallFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionTool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionToolType))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionToolFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionRequestModel))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::SarvamAI.ChatCompletionMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionRequestReasoningEffort))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::SarvamAI.ChatCompletionTool>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionRequestToolChoice))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionChoice))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionChoiceFinishReason))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionUsage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTimeOffset))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::SarvamAI.ChatCompletionChoice>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.SpeechToTextTranslateResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranscribeSpeechRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(byte[]))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranscribeSpeechRequestModel))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranscribeSpeechRequestMode))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranscribeSpeechRequestLanguageCode))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranscribeSpeechRequestInputAudioCodec))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateSpeechRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateSpeechRequestModel))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateSpeechRequestLanguageCode))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateSpeechRequestInputAudioCodec))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::SarvamAI.ChatCompletionToolCall>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::SarvamAI.ChatCompletionMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::SarvamAI.ChatCompletionTool>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::SarvamAI.ChatCompletionChoice>))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}