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
                            yield return ParseUserDefinedParameter();
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

            char Peek() => position_offset >= length ? char.MinValue : messageTemplate_chars[position_offset];
            char Take() => position_offset >= length ? char.MinValue : messageTemplate_chars[position_offset++];
            char Next(int next = 1) => position_offset + next >= length ? char.MinValue : messageTemplate_chars[position_offset + next];
            char Before(int before = 1) => position_offset - before == -1 ? char.MinValue : messageTemplate_chars[position_offset - before];
            void Back(int back = 1) => position_offset -= back;
            void Skip(int step = 1) => position_offset += step;
            void Follow() => position = position_offset;
            int Offset() => position_offset - position;
            bool End() => position_offset >= length;

            bool EndWithCloseIdentifier() {
                var e = messageTemplate_chars[length - 1];
                return e == '}' || e == ' ';
            }

            bool CheckCloseIdentity(int next) => Next(next) == '}' || Next(next) == ' ' || Next(next) == char.MinValue;

            void BackIfNecessary(int back, int one, int afterOne) {
                if (CheckCloseIdentity(one) && !CheckCloseIdentity(afterOne)) {
                    Back(back);
                }
            }

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
                    if (Next() == char.MinValue) break;
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
                var colon_counter = 0;
                var formatString = string.Empty;
                var paramsString = string.Empty;
                var params_flag_mode = 0;
                var fixOriginTextLength = 3;
                while (position_offset < length) {
                    if (Next() == char.MinValue) break;
                    if (Before() == '[' && Next() == ']') {
                        Skip(2);
                        continue;
                    }

                    if (Peek() == '}' || Peek() == ' ') {
                        Skip();
                        var start = position;
                        var len = Offset();
                        var rawText = Merge(start, len);
                        Follow();
                        return Touch(rawText, start);
                    }

                    if (Peek() == ':') {
                        if (Next() == '}' || Next() == ' ') {
                            Skip(2);
                            var start = position;
                            var len = Offset();
                            var rawText = Merge(start, len);
                            Follow();
                            return Touch(rawText, start);
                        }

                        switch (++colon_counter) {
                            case 1: {
                                Skip();
                                formatString = SeparatePropertyRawFormatText(out params_flag_mode, out fixOriginTextLength);
                                if (End()) {
                                    return Touch(Merge(position, Offset()), position);
                                }

                                BackIfNecessary(1, 0, 1);
                                break;
                            }
                            case 2: {
                                Skip();
                                paramsString = SeparatePropertyRawParamsText(out fixOriginTextLength);
                                if (End()) {
                                    return Touch(Merge(position, Offset()), position);
                                }

                                BackIfNecessary(1, 0, 1);
                                break;
                            }
                        }

                        continue;
                    }

                    Skip();
                }

                fixOriginTextLength = EndWithCloseIdentifier() ? 3 : 2;
                return Touch(MergeSurplus(position), position);

                PropertyToken Touch(string raw, int start) {
                    return new PropertyToken(raw, formatString, paramsString, index++, start, PropertyTokenTypes.PreferencesRender, params_flag_mode, fixOriginTextLength);
                }
            }

            PropertyToken ParseUserDefinedParameter() {
                var colon_counter = 0;
                var formatString = string.Empty;
                var paramsString = string.Empty;
                var params_flag_mode = 0;
                var fixOriginTextLength = 3;
                while (position_offset < length) {
                    if (Next() == char.MinValue) break;
                    if (Before() == '[' && Next() == ']') {
                        Skip(2);
                        continue;
                    }

                    if (Peek() == '}' || Peek() == ' ') {
                        Skip();
                        var start = position;
                        var len = Offset();
                        var rawText = Merge(start, len);
                        Follow();
                        return Touch(rawText, start);
                    }

                    if (Peek() == ':') {
                        if (Next() == '}' || Next() == ' ') {
                            Skip(2);
                            var start = position;
                            var len = Offset();
                            var rawText = Merge(start, len);
                            Follow();
                            return Touch(rawText, start);
                        }

                        switch (++colon_counter) {
                            case 1: {
                                Skip();
                                formatString = SeparatePropertyRawFormatText(out params_flag_mode, out fixOriginTextLength);
                                if (End()) {
                                    return Touch(Merge(position, Offset()), position);
                                }

                                BackIfNecessary(1, 0, 1);
                                break;
                            }
                            case 2: {
                                Skip();
                                paramsString = SeparatePropertyRawParamsText(out fixOriginTextLength);
                                if (End()) {
                                    return Touch(Merge(position, Offset()), position);
                                }

                                BackIfNecessary(1, 0, 1);
                                break;
                            }
                        }

                        continue;
                    }

                    Skip();

                }

                fixOriginTextLength = EndWithCloseIdentifier() ? 3 : 2;
                return Touch(MergeSurplus(position), position);

                PropertyToken Touch(string raw, int start) {
                    return new PropertyToken(raw, formatString, paramsString, index++, start, PropertyTokenTypes.UserDefinedParameter, params_flag_mode, fixOriginTextLength);
                }
            }

            string SeparatePropertyRawFormatText(out int paramsFlagMode, out int fixOriginTextLength) {
                var start = position_offset;
                paramsFlagMode = 0;
                fixOriginTextLength = 3;
                while (position_offset < length) {
                    if (Before() == '[' && Next() == ']') {
                        Skip(2);
                        continue;
                    }

                    var c = Peek();
                    if (c == char.MinValue) break;
                    if (c == ':' || c == '}' || c == '(' || c == ' ') {
                        paramsFlagMode = c == '(' ? 1 : 0;
                        return Merge(start, position_offset - start);
                    }

                    Skip();
                }

                fixOriginTextLength = 2;
                return Merge(start, position_offset - start);
            }

            string SeparatePropertyRawParamsText(out int fixOriginTextLength) {
                var start = position_offset;
                fixOriginTextLength = 3;
                while (position_offset < length) {
                    if (Before() == '[' && Next() == ']') {
                        Skip(2);
                        continue;
                    }

                    var c = Peek();
                    if (c == char.MinValue) break;
                    if (c == ':' || c == '}' || c == ' ') {
                        return Merge(start, position_offset - start);
                    }

                    Skip();
                }

                fixOriginTextLength = 2;
                return Merge(start, position_offset - start);
            }
        }
    }
}