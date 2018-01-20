using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Events;
using Cosmos.Logging.Renders;

namespace Cosmos.Logging.MessageTemplates {
    internal static class MessageTemplateRenderer {
        public static void Render(MessageTemplate messageTemplate, IReadOnlyDictionary<string, MessagePropertyValue> properties,
            TextWriter output, string format = null, IFormatProvider formatProvider = null) {
            var stringBuilder = RenderEngine(messageTemplate.TextArray, messageTemplate.TokenArray, properties, formatProvider);
            output.Write(ToBuffer(stringBuilder));
        }

        private static char[] ToBuffer(StringBuilder stringBuilder) {
            var buffer = new char[stringBuilder.Length];
            stringBuilder.CopyTo(0, buffer, 0, stringBuilder.Length);
            return buffer;
        }

        private static StringBuilder RenderEngine(char[] chars, MessageTemplateToken[] tokens,
            IReadOnlyDictionary<string, MessagePropertyValue> properties, IFormatProvider formatProvider) {
            var stringBuilder = new StringBuilder();
            var position = 0;

            for (var current = 0; current < tokens.Length; current++) {
                var token = tokens[current];
                if (token.StartPosition > position) {
                    stringBuilder.Append(chars.Read(position, token.StartPosition - position));
                }

                if (token.TokenRenderType == TokenRenderTypes.AsProperty && token is PropertyToken propertyToken) {
                    if (propertyToken.TokenType == PropertyTokenTypes.UserDefinedParameter &&
                        properties.TryGetValue(propertyToken.Name, out var property)) {
                        RenderPropertyTokenForUserDefinedParameter(propertyToken, property, stringBuilder, formatProvider);
                    } else if (propertyToken.TokenType == PropertyTokenTypes.PreferencesRender) {
                        var render = GetPreferencesRender(propertyToken);
                        RenderPropertyTokenForPreferencesRender(propertyToken, render, stringBuilder, formatProvider);
                    } else {
                        RenderTextTokenSlim(propertyToken, stringBuilder, formatProvider);
                    }
                } else if (token is PositionalPropertyToken positionalPropertyToken) {
                    var propertyPosition = positionalPropertyToken.PositionalParameterValue;
                    if (positionalPropertyToken.TokenRenderType == TokenRenderTypes.AsPositionalProperty &&
                        TryGetMessageProperty(properties, propertyPosition, out var property)) {
                        RenderPositionalPropertyTokenForUserDefinedParameter(positionalPropertyToken, property, stringBuilder, formatProvider);
                    } else {
                        RenderTextTokenSlim(positionalPropertyToken, stringBuilder, formatProvider);
                    }
                } else if (token is TextToken textToken) {
                    RenderTextToken(textToken, stringBuilder, formatProvider);
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

        private static void RenderTextToken(TextToken token, StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(token.Render());
        }

        private static void RenderTextTokenSlim(PropertyToken token, StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(token.RawText);
        }

        private static void RenderTextTokenSlim(PositionalPropertyToken token, StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(token.RawText);
        }

        private static void RenderPropertyTokenForUserDefinedParameter(PropertyToken token, MessagePropertyValue property,
            StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(property.ToString(token.FormatEvents, token.Params, formatProvider));
        }

        private static void RenderPositionalPropertyTokenForUserDefinedParameter(PositionalPropertyToken token, MessagePropertyValue property,
            StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            stringBuilder.Append(property.ToString(token.FormatEvents, token.Params, formatProvider));
        }

        private static void RenderPropertyTokenForPreferencesRender(PropertyToken token, IPreferencesRender render,
            StringBuilder stringBuilder, IFormatProvider formatProvider = null) {
            if (token == null || render == null || render.IsNull) return;
            render.Render(token.FormatEvents, token.Params, stringBuilder, formatProvider);
        }

        private static IPreferencesRender GetPreferencesRender(PropertyToken token) {
            if (token == null) return NullPreferencesRender.Instance;
            var render = string.IsNullOrWhiteSpace(token.Prefix)
                ? PreferencesRenderManager.GetRender(token.Name)
                : PreferencesRenderManager.GetRender(token.Prefix, token.Name);
            return render;
        }

        private static bool TryGetMessageProperty(IReadOnlyDictionary<string, MessagePropertyValue> properties, int position, out MessagePropertyValue property) {
            property = null;
            if (properties == null || position < 0 || position >= properties.Count) return false;
            return properties.TryGetValue(properties.Keys.ToArray()[position], out property);
        }
    }
}