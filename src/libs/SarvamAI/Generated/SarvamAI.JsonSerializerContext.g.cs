
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
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ErrorDetailCode), TypeInfoPropertyName = "ErrorDetailCode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ErrorResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestSourceLanguageCode), TypeInfoPropertyName = "TranslateRequestSourceLanguageCode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestTargetLanguageCode), TypeInfoPropertyName = "TranslateRequestTargetLanguageCode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestSpeakerGender), TypeInfoPropertyName = "TranslateRequestSpeakerGender2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestMode), TypeInfoPropertyName = "TranslateRequestMode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestModel), TypeInfoPropertyName = "TranslateRequestModel2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestOutputScript), TypeInfoPropertyName = "TranslateRequestOutputScript2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateRequestNumeralsFormat), TypeInfoPropertyName = "TranslateRequestNumeralsFormat2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateRequestSourceLanguageCode), TypeInfoPropertyName = "TransliterateRequestSourceLanguageCode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateRequestTargetLanguageCode), TypeInfoPropertyName = "TransliterateRequestTargetLanguageCode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateRequestNumeralsFormat), TypeInfoPropertyName = "TransliterateRequestNumeralsFormat2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateRequestSpokenFormNumeralsLanguage), TypeInfoPropertyName = "TransliterateRequestSpokenFormNumeralsLanguage2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TransliterateResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.DetectLanguageRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.DetectLanguageResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequestTargetLanguageCode), TypeInfoPropertyName = "TextToSpeechRequestTargetLanguageCode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequestModel), TypeInfoPropertyName = "TextToSpeechRequestModel2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequestSpeaker), TypeInfoPropertyName = "TextToSpeechRequestSpeaker2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(double))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequestSpeechSampleRate), TypeInfoPropertyName = "TextToSpeechRequestSpeechSampleRate2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechRequestOutputAudioCodec), TypeInfoPropertyName = "TextToSpeechRequestOutputAudioCodec2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TextToSpeechResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.SpeechToTextResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(object))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionMessage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionMessageRole), TypeInfoPropertyName = "ChatCompletionMessageRole2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::SarvamAI.ChatCompletionToolCall>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionToolCall))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionToolCallType), TypeInfoPropertyName = "ChatCompletionToolCallType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionToolCallFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionTool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionToolType), TypeInfoPropertyName = "ChatCompletionToolType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionToolFunction))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionRequestModel), TypeInfoPropertyName = "ChatCompletionRequestModel2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::SarvamAI.ChatCompletionMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionRequestReasoningEffort), TypeInfoPropertyName = "ChatCompletionRequestReasoningEffort2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::SarvamAI.ChatCompletionTool>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionRequestToolChoice), TypeInfoPropertyName = "ChatCompletionRequestToolChoice2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionChoice))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionChoiceFinishReason), TypeInfoPropertyName = "ChatCompletionChoiceFinishReason2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionUsage))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.ChatCompletionResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTimeOffset))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::SarvamAI.ChatCompletionChoice>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.SpeechToTextTranslateResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranscribeSpeechRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(byte[]))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranscribeSpeechRequestModel), TypeInfoPropertyName = "TranscribeSpeechRequestModel2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranscribeSpeechRequestMode), TypeInfoPropertyName = "TranscribeSpeechRequestMode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranscribeSpeechRequestLanguageCode), TypeInfoPropertyName = "TranscribeSpeechRequestLanguageCode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranscribeSpeechRequestInputAudioCodec), TypeInfoPropertyName = "TranscribeSpeechRequestInputAudioCodec2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateSpeechRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateSpeechRequestModel), TypeInfoPropertyName = "TranslateSpeechRequestModel2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateSpeechRequestLanguageCode), TypeInfoPropertyName = "TranslateSpeechRequestLanguageCode2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::SarvamAI.TranslateSpeechRequestInputAudioCodec), TypeInfoPropertyName = "TranslateSpeechRequestInputAudioCodec2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<string>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::SarvamAI.ChatCompletionToolCall>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::SarvamAI.ChatCompletionMessage>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::SarvamAI.ChatCompletionTool>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::SarvamAI.ChatCompletionChoice>))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}