
#nullable enable

namespace SarvamAI
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ChatCompletionTool
    {
        /// <summary>
        /// The type of tool
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("type")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::SarvamAI.JsonConverters.ChatCompletionToolTypeJsonConverter))]
        public global::SarvamAI.ChatCompletionToolType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("function")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::SarvamAI.ChatCompletionToolFunction Function { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatCompletionTool" /> class.
        /// </summary>
        /// <param name="type">
        /// The type of tool
        /// </param>
        /// <param name="function"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ChatCompletionTool(
            global::SarvamAI.ChatCompletionToolFunction function,
            global::SarvamAI.ChatCompletionToolType type)
        {
            this.Function = function ?? throw new global::System.ArgumentNullException(nameof(function));
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatCompletionTool" /> class.
        /// </summary>
        public ChatCompletionTool()
        {
        }
    }
}