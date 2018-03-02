using System.Text;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    public abstract class OutputMessageToken {
        public readonly string RawText;
        public readonly int Index;
        public readonly int RawTokenLength;
        public readonly int TokenLength;
        public readonly int StartPosition;
        protected readonly string TokenString;

        protected OutputMessageToken(string originText, int index, int position, int fixOriginTextLength)
            : this(originText, originText.Substring(1, originText.Length - fixOriginTextLength), index, position) { }

        protected OutputMessageToken(string originText, string tokenString, int index, int position) {
            Index = index;
            RawText = originText;
            TokenString = tokenString;
            TokenLength = tokenString.Length;
            RawTokenLength = originText.Length;
            StringBuilder = new StringBuilder(tokenString);
            StartPosition = position;
        }


        protected StringBuilder StringBuilder { get; }

        public virtual StringBuilder GetStringBuilder() => StringBuilder;

        public virtual char[] GetChars() {
            var count = StringBuilder.Length;
            var ret = new char[count];
            StringBuilder.CopyTo(0, ret, 0, count);
            return ret;
        }

        public abstract TokenRenderTypes TokenRenderType { get; }

        public abstract string ToText();

        public virtual string ToRawText() => RawText;

        public abstract string Render();
    }
}