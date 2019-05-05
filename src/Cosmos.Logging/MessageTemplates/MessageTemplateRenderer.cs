using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.MessageTemplates {
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedParameter.Local")]
    internal static class MessageTemplateRenderer {
        public static void Render(MessageTemplate messageTemplate,
            IReadOnlyDictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> namedProperties,
            IReadOnlyDictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> positionalProperties,
            TextWriter output, ILogEventInfo logEventInfo, IContextualLogEvent contextualLogEvent,
            string format = null, RendingConfiguration renderingOptions = null,
            IFormatProvider formatProvider = null) {
            var stringBuilder = RenderEngine(
                messageTemplate.TextArray,
                messageTemplate.TokenArray,
                namedProperties,
                positionalProperties,
                logEventInfo,
                contextualLogEvent,
                renderingOptions,
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
            ILogEventInfo logEventInfo, IContextualLogEvent contextualLogEvent,
            RendingConfiguration renderingOptions, IFormatProvider formatProvider) {
            var stringBuilder = Som(logEventInfo, renderingOptions);
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

            RenderTags(contextualLogEvent, stringBuilder);

            Eom(stringBuilder, renderingOptions);

            return stringBuilder;
        }

        /// <summary>
        /// Start of message
        /// </summary>
        /// <param name="logEventInfo"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        private static StringBuilder Som(ILogEventInfo logEventInfo, RendingConfiguration renderingOptions) {
            var now = DateTime.UtcNow.ToLocalTime();
            var stringBuilder = new StringBuilder();

            if (renderingOptions?.DisplayingCallerInfoEnabled ?? false) {
                var caller = logEventInfo.CallerInfo;
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
            }

            if (renderingOptions?.DisplayingEventIdInfoEnabled ?? false) {
                var eventId = logEventInfo.EventId;
                stringBuilder.Append($"[{_0(eventId.Id)} {_1(eventId.Name)}] ");

                string _0(string _id) => string.IsNullOrWhiteSpace(_id) ? "no_id" : _id;

                string _1(string _name) => string.IsNullOrWhiteSpace(_name) ? "null" : _name;
            }

            return stringBuilder;
        }

        /// <summary>
        /// End of message
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        private static StringBuilder Eom(StringBuilder stringBuilder, RendingConfiguration renderingOptions) {
            if (renderingOptions?.DisplayingNewLineEomEnabled ?? false) {
                stringBuilder.Append(Environment.NewLine);
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
                ? PreferencesRenderersManager.GetRender(token.Name)
                : PreferencesRenderersManager.GetRender(token.Prefix, token.Name);
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

        private static void RenderTags(IContextualLogEvent contextualLogEvent, StringBuilder stringBuilder) {
            if (contextualLogEvent.Tags != null && contextualLogEvent.Tags.Any()) {
                if (stringBuilder[stringBuilder.Length - 1] != ' ')
                    stringBuilder.Append(' ');
                stringBuilder.Append($"Tags: {string.Join(", ", contextualLogEvent.Tags)} ");
            }
        }
    }
}