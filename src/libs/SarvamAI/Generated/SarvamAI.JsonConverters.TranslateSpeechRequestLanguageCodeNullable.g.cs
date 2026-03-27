#nullable enable

namespace SarvamAI.JsonConverters
{
    /// <inheritdoc />
    public sealed class TranslateSpeechRequestLanguageCodeNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::SarvamAI.TranslateSpeechRequestLanguageCode?>
    {
        /// <inheritdoc />
        public override global::SarvamAI.TranslateSpeechRequestLanguageCode? Read(
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
                        return global::SarvamAI.TranslateSpeechRequestLanguageCodeExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::SarvamAI.TranslateSpeechRequestLanguageCode)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::SarvamAI.TranslateSpeechRequestLanguageCode?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::SarvamAI.TranslateSpeechRequestLanguageCode? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::SarvamAI.TranslateSpeechRequestLanguageCodeExtensions.ToValueString(value.Value));
            }
        }
    }
}
