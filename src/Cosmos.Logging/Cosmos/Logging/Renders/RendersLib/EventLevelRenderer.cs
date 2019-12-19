using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Renders.RendersLib {
    /// <summary>
    /// EventLevelRenderer
    /// </summary>
    [Renderer("Level")]
    public class EventLevelRenderer : BasicPreferencesRenderer {
        /// <inheritdoc />
        public override string Name => "Level";

        private static string FixedEventLevel(ILogEventInfo logEventInfo, int aliasLength) {
            return aliasLength <= 0
                ? LogEventLevelConverter.Convert(logEventInfo?.Level)
                : LogEventLevelConverter.Convert(logEventInfo?.Level, aliasLength);
        }

        private static string FixedEventLevel(LogEventLevel level, int aliasLength) {
            return aliasLength <= 0
                ? LogEventLevelConverter.Convert(level)
                : LogEventLevelConverter.Convert(level, aliasLength);
        }

        private static int GetLength(string format, string paramsText) {

            if (!string.IsNullOrWhiteSpace(format)) {
                return InternalFormatProvider.PoundFindingIndexAlgorithm(new ReadOnlySpan<char>(format.ToCharArray()));
            }

            if (!string.IsNullOrWhiteSpace(paramsText)) {
                var @params = paramsText.ToLower();
                var index = @params.IndexOf("length=", StringComparison.Ordinal);

                if (index < 0)
                    return 0;

                var start = index + 7;
                var position = start;
                var span = new ReadOnlySpan<char>(@params.ToCharArray(), index + 7, @params.Length - 7);

                foreach (var @char in span) {
                    if (!@char.IsNumber())
                        break;
                    position++;
                }

                if (start == position)
                    return 0;
                
                return int.TryParse(span.Slice(0, position - start).ToString(), out var number) ? number : 0;
            }

            return 0;
        }

        #region ToString

        /// <inheritdoc />
        public override string ToString(string format, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return FixedEventLevel(logEventInfo, GetLength(format, paramsText));
        }

        /// <inheritdoc />
        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return ContainsCommand(formattingEvents, InternalFormatProvider.POUND_FORMAT_COMMAND)
                ? formattingEvents.ToFormat(logEventInfo, formatProvider)
                : formattingEvents.ToFormat(FixedEventLevel(logEventInfo, GetLength(null, paramsText)), formatProvider);
        }

        /// <inheritdoc />
        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            return formattingFuncs.ToFormat(FixedEventLevel(logEventInfo, GetLength(null, paramsText)), formatProvider);
        }

        #endregion

        #region Render

        /// <inheritdoc />
        public override void Render(string format, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(format, paramsText, logEventInfo, formatProvider));
        }

        /// <inheritdoc />
        public override void Render(IList<FormatEvent> formattingEvents, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingEvents, paramsText, logEventInfo, formatProvider));
        }

        /// <inheritdoc />
        public override void Render(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(ToString(formattingFuncs, paramsText, logEventInfo, formatProvider));
        }

        #endregion

        /// <inheritdoc />
        public override CustomFormatProvider CustomFormatProvider => InternalFormatProvider.InternalCache;

        /// <summary>
        /// Log event level format provider
        /// </summary>
        private class InternalFormatProvider : CustomFormatProvider {
            public static CustomFormatProvider InternalCache { get; } = new InternalFormatProvider();

            // ReSharper disable once InconsistentNaming
            public const string POUND_FORMAT_COMMAND = "PoundFormat";

            /// <inheritdoc />
            public override IEnumerable<FormatEvent> CreateCommandEvent(string format = null) {

                if (string.IsNullOrWhiteSpace(format))
                    return EmptyCommandEvents;

                var span = new ReadOnlySpan<char>(format.ToCharArray());

                return Merge(NewPoundCommandEvent(span));
            }

            private FormatEvent? NewPoundCommandEvent(ReadOnlySpan<char> span) {
                var counter = PoundFindingIndexAlgorithm(span);

                var poundCommandEvent = new FormatEvent(POUND_FORMAT_COMMAND, 10, (objectContent, formatProvider) => {
                    return objectContent switch {
                        ILogEventInfo logEventInfo  => FixedEventLevel(logEventInfo, counter),
                        LogEventLevel logEventLevel => FixedEventLevel(logEventLevel, counter),
                        _                           => objectContent
                    };
                });

                return poundCommandEvent;
            }

            public static int PoundFindingIndexAlgorithm(ReadOnlySpan<char> span) {
                var start = span.IndexOf('#');
                if (start < 0)
                    return 0;
                var counter = 0;
                for (var i = start; i < span.Length - start; ++i) {
                    if (span[i] != '#')
                        break;
                    counter++;
                }

                return counter;
            }
        }
    }
}