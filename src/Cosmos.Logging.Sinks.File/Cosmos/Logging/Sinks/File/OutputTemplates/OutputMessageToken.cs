using System.Text;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    /// <summary>
    /// Output message token
    /// </summary>
    public abstract class OutputMessageToken {
        /// <summary>
        /// Raw text
        /// </summary>
        public readonly string RawText;

        /// <summary>
        /// Index
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// Raw token length
        /// </summary>
        public readonly int RawTokenLength;

        /// <summary>
        /// Token length
        /// </summary>
        public readonly int TokenLength;

        /// <summary>
        /// Start position
        /// </summary>
        public readonly int StartPosition;

        /// <summary>
        /// Token string
        /// </summary>
        protected readonly string TokenString;

        /// <inheritdoc />
        protected OutputMessageToken(string originText, int index, int position, int fixOriginTextLength)
            : this(originText, originText.Substring(1, originText.Length - fixOriginTextLength), index, position) { }

        /// <summary>
        /// Create a new instance of <see cref="OutputMessageToken"/>.
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="tokenString"></param>
        /// <param name="index"></param>
        /// <param name="position"></param>
        protected OutputMessageToken(string originText, string tokenString, int index, int position) {
            Index = index;
            RawText = originText;
            TokenString = tokenString;
            TokenLength = tokenString.Length;
            RawTokenLength = originText.Length;
            StringBuilder = new StringBuilder(tokenString);
            StartPosition = position;
        }


        /// <summary>
        /// Gets string builder
        /// </summary>
        protected StringBuilder StringBuilder { get; }

        /// <summary>
        /// Gets string builder
        /// </summary>
        /// <returns></returns>
        public virtual StringBuilder GetStringBuilder() => StringBuilder;

        /// <summary>
        /// Get chars
        /// </summary>
        /// <returns></returns>
        public virtual char[] GetChars() {
            var count = StringBuilder.Length;
            var ret = new char[count];
            StringBuilder.CopyTo(0, ret, 0, count);
            return ret;
        }

        /// <summary>
        /// Gets token renderer type
        /// </summary>
        public abstract TokenRendererTypes TokenRendererType { get; }

        /// <summary>
        /// To text
        /// </summary>
        /// <returns></returns>
        public abstract string ToText();

        /// <summary>
        /// To raw text
        /// </summary>
        /// <returns></returns>
        public virtual string ToRawText() => RawText;

        /// <summary>
        /// Render
        /// </summary>
        /// <returns></returns>
        public abstract string Render();
    }
}