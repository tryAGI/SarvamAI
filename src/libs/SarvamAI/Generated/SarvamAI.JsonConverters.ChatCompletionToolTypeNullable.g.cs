#nullable enable

namespace SarvamAI.JsonConverters
{
    /// <inheritdoc />
    public sealed class ChatCompletionToolTypeNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::SarvamAI.ChatCompletionToolType?>
    {
        /// <inheritdoc />
        public override global::SarvamAI.ChatCompletionToolType? Read(
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
                        return global::SarvamAI.ChatCompletionToolTypeExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::SarvamAI.ChatCompletionToolType)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::SarvamAI.ChatCompletionToolType?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::SarvamAI.ChatCompletionToolType? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::SarvamAI.ChatCompletionToolTypeExtensions.ToValueString(value.Value));
            }
        }
    }
}
