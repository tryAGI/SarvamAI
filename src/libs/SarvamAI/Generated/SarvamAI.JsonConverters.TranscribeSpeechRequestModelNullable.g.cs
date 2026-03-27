#nullable enable

namespace SarvamAI.JsonConverters
{
    /// <inheritdoc />
    public sealed class TranscribeSpeechRequestModelNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::SarvamAI.TranscribeSpeechRequestModel?>
    {
        /// <inheritdoc />
        public override global::SarvamAI.TranscribeSpeechRequestModel? Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case global::System.Text.Json.JsonTokenType.String:
                {
                    var stringValue = reader.GetString();
                    if (stringValue != null)
                    {
                        return global::SarvamAI.TranscribeSpeechRequestModelExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::SarvamAI.TranscribeSpeechRequestModel)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::SarvamAI.TranscribeSpeechRequestModel?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::SarvamAI.TranscribeSpeechRequestModel? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::SarvamAI.TranscribeSpeechRequestModelExtensions.ToValueString(value.Value));
            }
        }
    }
}
