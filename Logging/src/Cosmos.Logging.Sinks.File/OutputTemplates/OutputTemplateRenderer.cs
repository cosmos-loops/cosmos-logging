using System;
using System.IO;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.MessageTemplates;
using Cosmos.Logging.Sinks.File.Core.Extensions;
using Cosmos.Logging.Sinks.File.Renderers;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    public static class OutputTemplateRenderer {
        public static void Render(OutputTemplate outputTemplate,
            TextWriter output, ILogEventInfo logEventInfo, IContextualLogEvent contextualLogEvent,
            string format = null, IFormatProvider formatProvider = null) {
            var stringBuilder = RenderEngine(
                outputTemplate.TextArray,
                outputTemplate.TokenArray,
                logEventInfo,
                contextualLogEvent,
                formatProvider);
            output.Write(ToBuffer(stringBuilder));
        }

        private static char[] ToBuffer(StringBuilder stringBuilder) {
            var buffer = new char[stringBuilder.Length];
            stringBuilder.CopyTo(0, buffer, 0, stringBuilder.Length);
            return buffer;
        }

        private static StringBuilder RenderEngine(char[] chars, OutputMessageToken[] tokens,
            ILogEventInfo logEventInfo, IContextualLogEvent contextualLogEvent,
            IFormatProvider formatProvider) {
            var stringBuilder = new StringBuilder();
            var position = 0;

            for (var current = 0; current < tokens.Length; current++) {
                var token = tokens[current];
                if (token.StartPosition > position) {
                    stringBuilder.Append(chars.Read(position, token.StartPosition - position));
                }

                if (token.TokenRenderType == TokenRenderTypes.AsProperty && token is PropertyOutputMessageToken propertyToken) {
                    var render = GetPreferencesRenderer(propertyToken);
                    RenderPropertyTokenForPreferencesRenderer(propertyToken, render, stringBuilder, logEventInfo, formatProvider);
                } else if (token is TextOutputMessageToken textToken) {
                    RenderTextToken(textToken, stringBuilder, logEventInfo, formatProvider);
                } else {
                    throw new ArgumentException("Current token render type is undefined.");
                }

                position = token.StartPosition + token.RawTokenLength;
            }

            if (position < chars.Length) {
                stringBuilder.Append(chars.Read(position, chars.Length - position));
            }

            return stringBuilder;
        }

        private static void RenderTextToken(TextOutputMessageToken token, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(token.Render());
        }

        private static void RenderPropertyTokenForPreferencesRenderer(PropertyOutputMessageToken token, IOutputPreferencesRenderer renderer,
            StringBuilder stringBuilder, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            if (token == null || renderer == null || renderer.IsNull) return;
            renderer.Render(token.FormatEvents, token.Params, stringBuilder, logEventInfo, formatProvider);
        }

        private static IOutputPreferencesRenderer GetPreferencesRenderer(PropertyOutputMessageToken token) {
            return token == null ? NullOutputPreferencesRenderer.Instance : OutputPreferencesRenderManager.GetRender(token.Name);
        }
    }
}