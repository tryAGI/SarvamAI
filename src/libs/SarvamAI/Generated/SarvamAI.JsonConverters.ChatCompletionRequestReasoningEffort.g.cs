#nullable enable

namespace SarvamAI.JsonConverters
{
    /// <inheritdoc />
    public sealed class ChatCompletionRequestReasoningEffortJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::SarvamAI.ChatCompletionRequestReasoningEffort>
    {
        /// <inheritdoc />
        public override global::SarvamAI.ChatCompletionRequestReasoningEffort Read(
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
                        return global::SarvamAI.ChatCompletionRequestReasoningEffortExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::SarvamAI.ChatCompletionRequestReasoningEffort)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::SarvamAI.ChatCompletionRequestReasoningEffort);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::SarvamAI.ChatCompletionRequestReasoningEffort value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::SarvamAI.ChatCompletionRequestReasoningEffortExtensions.ToValueString(value));
        }
    }
}
