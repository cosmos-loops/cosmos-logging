using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.MessageTemplates {
    internal static class MessageTemplateRenderer {
        public static void Render(MessageTemplate messageTemplate,
            IReadOnlyDictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> namedProperties,
            IReadOnlyDictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> positionalProperties,
            TextWriter output, string format = null, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            var stringBuilder = RenderEngine(
                messageTemplate.TextArray,
                messageTemplate.TokenArray,
                namedProperties,
                positionalProperties,
                logEventInfo,
                formatProvider);
            output.Write(ToBuffer(stringBuilder));
        }

        private static char[] ToBuffer(StringBuilder stringBuilder) {
            var buffer = new char[stringBuilder.Length];
            stringBuilder.CopyTo(0, buffer, 0, stringBuilder.Length);
            return buffer;
        }

        private static StringBuilder RenderEngine(char[] chars, MessageTemplateToken[] tokens,
            IReadOnlyDictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> namedProperties,
            IReadOnlyDictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> positionalProperties,
            ILogEventInfo logEventInfo, IFormatProvider formatProvider) {
            var stringBuilder = CreateStringBuilder(logEventInfo);
            var position = 0;

            for (var current = 0; current < tokens.Length; current++) {
                var token = tokens[current];
                if (token.StartPosition > position) {
                    stringBuilder.Append(chars.Read(position, token.StartPosition - position));
                }

                if (token.TokenRenderType == TokenRenderTypes.AsProperty && token is PropertyToken propertyToken) {
                    if (propertyToken.TokenType == PropertyTokenTypes.UserDefinedParameter &&
                        TryGetMessageProperty(namedProperties, propertyToken, out var property)) {
                        RenderPropertyTokenForUserDefinedParameter(propertyToken, property, stringBuilder, logEventInfo, formatProvider);
                    } else if (propertyToken.TokenType == PropertyTokenTypes.PreferencesRender) {
                        var render = GetPreferencesRender(propertyToken);
                        RenderPropertyTokenForPreferencesRender(propertyToken, render, stringBuilder, logEventInfo, formatProvider);
                    } else {
                        RenderTextTokenSlim(propertyToken, stringBuilder, logEventInfo, formatProvider);
                    }
                } else if (token is PositionalPropertyToken positionalPropertyToken) {
                    if (positionalPropertyToken.TokenRenderType == TokenRenderTypes.AsPositionalProperty &&
                        TryGetMessageProperty(positionalProperties, positionalPropertyToken, out var property)) {
                        RenderPositionalPropertyTokenForUserDefinedParameter(positionalPropertyToken, property, stringBuilder, logEventInfo, formatProvider);
                    } else {
                        RenderTextTokenSlim(positionalPropertyToken, stringBuilder, logEventInfo, formatProvider);
                    }
                } else if (token is TextToken textToken) {
                    RenderTextToken(textToken, stringBuilder, logEventInfo, formatProvider);
                } else {
                    throw new ArgumentException("Current token render type is undefined.");
                }

                position = token.StartPosition + token.RawTokenLength;
            }

            if (position < chars.Length) {
                stringBuilder.Append(chars.Read(position, chars.Length - position));
            }

            stringBuilder.Append(Environment.NewLine);
            return stringBuilder;
        }

        private static StringBuilder CreateStringBuilder(ILogEventInfo logEventInfo) {
            var now = DateTime.UtcNow.ToLocalTime();
            var caller = logEventInfo.CallerInfo;
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"{now:yyyy/MM/dd HH:mm:ss} ");

            switch (logEventInfo.Level) {
                case LogEventLevel.Verbose:
                case LogEventLevel.Debug:
                case LogEventLevel.Information:
                    if (!string.IsNullOrWhiteSpace(caller.MemberName))
                        stringBuilder.Append($"({caller.MemberName}) ");
                    break;

                case LogEventLevel.Warning:
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    stringBuilder.Append($"({caller.FilePath}:{caller.LineNumber} {caller.MemberName}) ");
                    break;
            }

            return stringBuilder;
        }

        private static void RenderTextToken(TextToken token, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(token.Render());
        }

        private static void RenderTextTokenSlim(PropertyToken token, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(token.RawText);
        }

        private static void RenderTextTokenSlim(PositionalPropertyToken token, StringBuilder stringBuilder,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(token.RawText);
        }

        private static void RenderPropertyTokenForUserDefinedParameter(PropertyToken token, MessagePropertyValue property,
            StringBuilder stringBuilder, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(property.ToString(token.FormatEvents, token.Params, formatProvider));
        }

        private static void RenderPositionalPropertyTokenForUserDefinedParameter(PositionalPropertyToken token, MessagePropertyValue property,
            StringBuilder stringBuilder, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            stringBuilder.Append(property.ToString(token.FormatEvents, token.Params, formatProvider));
        }

        private static void RenderPropertyTokenForPreferencesRender(PropertyToken token, IPreferencesRenderer renderer,
            StringBuilder stringBuilder, ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null) {
            if (token == null || renderer == null || renderer.IsNull) return;
            renderer.Render(token.FormatEvents, token.Params, stringBuilder, logEventInfo, formatProvider);
        }

        private static IPreferencesRenderer GetPreferencesRender(PropertyToken token) {
            if (token == null) return NullPreferencesRenderer.Instance;
            var render = string.IsNullOrWhiteSpace(token.Prefix)
                ? PreferencesRenderManager.GetRender(token.Name)
                : PreferencesRenderManager.GetRender(token.Prefix, token.Name);
            return render;
        }

        private static bool TryGetMessageProperty(IReadOnlyDictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> namedProperties,
            PropertyToken token, out MessagePropertyValue property) {
            return namedProperties.TryGetValue((token.Name, token.PropertyResolvingMode), out property);
        }

        private static bool TryGetMessageProperty(IReadOnlyDictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> positionalProperties,
            PositionalPropertyToken token, out MessagePropertyValue property) {
            return positionalProperties.TryGetValue((token.PositionalParameterValue, token.PropertyResolvingMode), out property);
        }
    }
}