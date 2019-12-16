namespace Cosmos.Logging.MessageTemplates {
    /// <summary>
    /// Null positional property token
    /// </summary>
    public class NullPositionalPropertyToken : PositionalPropertyToken {

        /// <summary>
        /// Create a new instance of <see cref="NullPositionalPropertyToken"/>
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="formatOriginText"></param>
        /// <param name="paramsOriginText"></param>
        /// <param name="index"></param>
        /// <param name="position"></param>
        /// <param name="paramsFlagMode"></param>
        /// <param name="fixOriginTextLength"></param>
        public NullPositionalPropertyToken(string originText, string formatOriginText, string paramsOriginText,
            int index, int position, int paramsFlagMode, int fixOriginTextLength = 2)
            : base(originText, formatOriginText, paramsOriginText, index, position, paramsFlagMode, fixOriginTextLength) { }

        /// <inheritdoc />
        public override TokenRendererTypes TokenRendererType { get; } = TokenRendererTypes.AsRawText;

        /// <inheritdoc />
        public override string ToString() => RawText;

        /// <inheritdoc />
        public override string ToText() => ToString();

        /// <inheritdoc />
        public override string Render() => ToString();
    }
}