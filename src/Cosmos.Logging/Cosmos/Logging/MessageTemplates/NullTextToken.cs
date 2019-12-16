namespace Cosmos.Logging.MessageTemplates {
    /// <summary>
    /// Null text token
    /// </summary>
    public sealed class NullTextToken : TextToken {
        /// <summary>
        /// Create a new instance of <see cref="NullTextToken"/>
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="index"></param>
        /// <param name="position"></param>
        public NullTextToken(string originText, int index, int position) : base(originText, originText, index, position) { }

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