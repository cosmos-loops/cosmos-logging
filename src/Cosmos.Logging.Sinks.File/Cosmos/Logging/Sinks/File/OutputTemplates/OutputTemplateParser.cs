using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    /// <summary>
    /// Output template parser
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class OutputTemplateParser : IOutputTemplateParser {
        /// <inheritdoc />
        public OutputTemplate Parse(string outputTemplate) {
            if (string.IsNullOrWhiteSpace(outputTemplate)) throw new ArgumentNullException(nameof(outputTemplate));
            return new OutputTemplate(outputTemplate, Tokenize(outputTemplate));
        }

        static IEnumerable<OutputMessageToken> Tokenize(string outputTemplate) {
            var index = 0;
            var position = 0;
            var position_offset = 0;
            var length = outputTemplate.Length;
            var outputTemplate_chars = outputTemplate.ToCharArray();

            while (position_offset < length) {
                var c = Take();

                if (c == '{') {
                    yield return ParseToken();
                } else {
                    Follow();
                }
            }

            char Peek() => position_offset >= length ? char.MinValue : outputTemplate_chars[position_offset];
            char Take() => position_offset > length ? char.MinValue : outputTemplate_chars[position_offset++];
            char Next(int next = 1) => position_offset + next >= length ? char.MinValue : outputTemplate_chars[position_offset + next];
            char Before(int before = 1) => position_offset - before == -1 ? char.MinValue : outputTemplate_chars[position_offset - before];
            void Back(int back = 1) => position_offset -= back;
            void Skip(int step = 1) => position_offset += step;
            void Follow() => position = position_offset;
            int Offset() => position_offset - position;
            bool End() => position_offset >= length;

            bool EndWithCloseIdentifier() {
                var e = outputTemplate_chars[length - 1];
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
                    ret[i] = outputTemplate_chars[_start + i];
                return new string(ret);
            }

            string MergeSurplus(int _start) => Merge(_start, length - _start);

            OutputMessageToken ParseToken() {
                var colon_counter = 0;
                var formatString = string.Empty;
                var paramsString = string.Empty;
                var params_flag_mode = 0;
                var fixOriginTextLength = 2;
                while (position_offset < length) {
                    if (Next() == char.MinValue) break;
                    if (Peek() == '}' || Peek() == ' ') {
                        Skip();
                        var start = position;
                        var len = Offset();
                        var rawText = Merge(start, len);
                        Follow();

                        return Touch(len, rawText, start);
                    }

                    if (Peek() == ':') {
                        if (Next() == '}' || Next() == ' ') {
                            Skip(2);
                            var start = position;
                            var len = Offset();
                            var rawText = Merge(start, len);
                            Follow();

                            return Touch(len, rawText, start);
                        }

                        switch (++colon_counter) {
                            case 1: {
                                Skip();
                                formatString = SeparatePropertyRawFormatText(out params_flag_mode, out fixOriginTextLength, 1, 0);
                                if (End()) {
                                    return Touch(Offset(), Merge(position, Offset()), position);
                                }

                                BackIfNecessary(1, 0, 1);
                                break;
                            }

                            case 2: {
                                Skip();
                                paramsString = SeparatePropertyRawParamsText(out fixOriginTextLength, 1, 0);
                                if (End()) {
                                    return Touch(Offset(), Merge(position, Offset()), position);
                                }

                                BackIfNecessary(1, 0, 1);
                                break;
                            }
                        }
                    }

                    Skip();
                }

                fixOriginTextLength = EndWithCloseIdentifier() ? 2 : 1;
                return Touch(length - position, MergeSurplus(position), position);

                OutputMessageToken Touch(int len, string raw, int start) {
                    if (len == 2) {
                        return new TextOutputMessageToken(raw, index++, start);
                    }

                    return new PropertyOutputMessageToken(raw, formatString, paramsString, index++, start, params_flag_mode, fixOriginTextLength);
                }
            }

            string SeparatePropertyRawFormatText(out int paramsFlagMode, out int fixOriginTextLength, int df1 = 2, int df2 = 1) {
                var start = position_offset;
                paramsFlagMode = 0;
                fixOriginTextLength = df1;
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

                fixOriginTextLength = df2;
                return Merge(start, position_offset - start);
            }

            string SeparatePropertyRawParamsText(out int fixOriginTextLength, int df1 = 2, int df2 = 1) {
                var start = position_offset;
                fixOriginTextLength = df1;
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

                fixOriginTextLength = df2;
                return Merge(start, position_offset - start);
            }
        }
    }
}