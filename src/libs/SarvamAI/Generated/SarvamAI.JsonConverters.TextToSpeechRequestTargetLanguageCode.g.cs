#nullable enable

namespace SarvamAI.JsonConverters
{
    /// <inheritdoc />
    public sealed class TextToSpeechRequestTargetLanguageCodeJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::SarvamAI.TextToSpeechRequestTargetLanguageCode>
    {
        /// <inheritdoc />
        public override global::SarvamAI.TextToSpeechRequestTargetLanguageCode Read(
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
                        return global::SarvamAI.TextToSpeechRequestTargetLanguageCodeExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::SarvamAI.TextToSpeechRequestTargetLanguageCode)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::SarvamAI.TextToSpeechRequestTargetLanguageCode);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::SarvamAI.TextToSpeechRequestTargetLanguageCode value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::SarvamAI.TextToSpeechRequestTargetLanguageCodeExtensions.ToValueString(value));
        }
    }
}
