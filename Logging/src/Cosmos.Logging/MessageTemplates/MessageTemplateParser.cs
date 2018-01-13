using System;
using System.Collections.Generic;

namespace Cosmos.Logging.MessageTemplates {
    internal class MessageTemplateParser {
        private readonly string _messageTemplate;

        public MessageTemplateParser(string messageTemplate) {
            _messageTemplate = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));
        }

        public MessageTemplate Parse() {
            return new MessageTemplate(_messageTemplate, Tokenize(_messageTemplate));
        }

        static IEnumerable<MessageTemplateToken> Tokenize(string messageTemplate) {
            var index = 0;
            var position = 0;
            var position_offset = 0;
            var length = messageTemplate.Length;
            var messageTemplate_chars = messageTemplate.ToCharArray();

            while (position_offset < length) {

                var c = Take();

                if (c == '{') {
                    var n = Peek();
                    switch (n) {
                        case '{': {
                            Skip();
                            yield return ParseText();
                            break;
                        }
                        case '@': {
                            Skip();
                            yield return PaeseUserDefinedParameter();
                            break;
                        }
                        case '$': {
                            Skip();
                            yield return ParsePreferencesRender();
                            break;
                        }
                        default: {
                            Follow();
                            break;
                        }
                    }
                } else {
                    Follow();
                }
            }

            char Peek() => messageTemplate_chars[position_offset];
            char Take() => messageTemplate_chars[position_offset++];
            char Next() => position_offset + 1 == length ? char.MinValue : messageTemplate_chars[position_offset + 1];
            void Skip(int step = 1) => position_offset += step;
            void Follow() => position = position_offset;
            int Offset() => position_offset - position;

            string Merge(int _start, int _len) {
                if (_len == 0) return string.Empty;
                var ret = new char[_len];
                for (var i = 0; i < _len; i++)
                    ret[i] = messageTemplate_chars[_start + i];
                return new string(ret);
            }

            string MergeSurplus(int _start) => Merge(_start, length - _start);

            TextToken ParseText() {
                while (position_offset < length) {
                    if (Next() == char.MinValue) {
                        break;
                    }

                    if (Peek() == '}' && Next() == '}') {
                        Skip(2);
                        var start = position;
                        var len = Offset();
                        var rawText = Merge(start, len);
                        Follow();
                        return len == 4
                            ? new NullTextToken(string.Empty, index++, start)
                            : new TextToken(rawText, index++, start);
                    }

                    Skip();
                }

                return new NullTextToken(MergeSurplus(position), index++, position);
            }

            PropertyToken ParsePreferencesRender() {
                return new PropertyToken("", index++, position, PropertyTokenTypes.PreferencesRender);
            }

            PropertyToken PaeseUserDefinedParameter() {
                return new PropertyToken("", index++, position, PropertyTokenTypes.UserDefinedParameter);
            }
        }
    }
}