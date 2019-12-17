using System.Text;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.MessageTemplates {
    /// <summary>
    /// Message template token
    /// </summary>
    public abstract class MessageTemplateToken {
        /// <summary>
        /// RawText
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
        
        /// <summary>
        /// Create a new instance of <see cref="MessageTemplateToken"/>
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="index"></param>
        /// <param name="position"></param>
        /// <param name="fixOriginTextLength"></param>
        protected MessageTemplateToken(string originText, int index, int position, int fixOriginTextLength)
            : this(originText, originText.Substring(2, originText.Length - fixOriginTextLength), index, position) { }

        /// <summary>
        /// Create a new instance of <see cref="MessageTemplateToken"/>
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="index"></param>
        /// <param name="position"></param>
        /// <param name="fixStartPosition"></param>
        /// <param name="fixOriginTextLength"></param>
        protected MessageTemplateToken(string originText, int index, int position, int fixStartPosition, int fixOriginTextLength)
            : this(originText, originText.Substring(fixStartPosition, originText.Length - fixOriginTextLength), index, position) { }

        /// <summary>
        /// Create a new instance of <see cref="MessageTemplateToken"/>
        /// </summary>
        /// <param name="originText"></param>
        /// <param name="tokenString"></param>
        /// <param name="index"></param>
        /// <param name="position"></param>
        protected MessageTemplateToken(string originText, string tokenString, int index, int position) {
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
        /// Get string builder
        /// </summary>
        /// <returns></returns>
        public virtual StringBuilder GetStringBuilder() => StringBuilder;

        /// <summary>
        /// Gets chars
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
        /// Gets property resolving mode
        /// </summary>
        public abstract PropertyResolvingMode PropertyResolvingMode { get; }

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