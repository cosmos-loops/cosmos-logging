using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class OutputTemplateParser : IOutputTemplateParser {
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
            void Skip(int step = 1) => position_offset += step;
            void Follow() => position = position_offset;
            int Offset() => position_offset - position;

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
                while (position_offset < length) {
                    if (Next() == char.MinValue) break;
                    if (Peek() == '}') {
                        Skip();
                        var start = position;
                        var len = Offset();
                        var rawText = Merge(start, len);
                        Follow();
                        return len == 2
                            ? new TextOutputMessageToken(rawText, index++, start)
                            : new PropertyOutputMessageToken(rawText, formatString, paramsString, index++, start);
                    }

                    Skip();
                }

                return new TextOutputMessageToken(MergeSurplus(position), index++, position);
            }

        }
    }
}