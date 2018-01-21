using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core.ObjectResolving {
    internal class PropertyBinder {
        private readonly MessageParameterResolver _messageParameterResolver;
        private static readonly MessageProperty[] _emptyMessageProperties = new MessageProperty[0];

        public PropertyBinder(MessageParameterResolver resolver) {
            _messageParameterResolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public IEnumerable<MessageProperty> Bind(MessageTemplate messageTemplate, object[] messageParameters) {
            if (messageParameters == null || messageParameters.Length == 0) {
                if (messageTemplate.PropertyClassTokenCount > 0)
                    InternalLogger.WriteLine("No message parameters can be used for '{0}'.", messageTemplate);
                return _emptyMessageProperties;
            }

            PrepareForPropertyToken(messageTemplate.Tokens, out var positionalPropertyMetaList, out var namedPropertyMetaList);
            positionalPropertyMetaList = positionalPropertyMetaList.Where(x => x.position < messageParameters.Length).ToList();
            var realLargestPosition = Math.Min(positionalPropertyMetaList.Select(x => x.position).Max(), messageParameters.Length);
            
            

            var tokens = messageTemplate.TokenArray;

            for (var index = 0; index < tokens.Length; index++) {
                var token = tokens[index];
                if (token is TextToken) continue;
                if (token is NullPositionalPropertyToken) continue;

                //todo
            }

            Console.WriteLine("执行到 PropertyBinder.Bind，但目前尚在开发中...");
            return Enumerable.Empty<MessageProperty>();
        }

        void PrepareForPropertyToken(IEnumerable<MessageTemplateToken> tokens,
            out List<(int position, PropertyResolvingMode mode)> positionalPropertyInfoList,
            out List<(string name, PropertyResolvingMode mode)> namedPropertyInfoList) {

            positionalPropertyInfoList = new List<(int, PropertyResolvingMode)>();
            namedPropertyInfoList = new List<(string name, PropertyResolvingMode mode)>();

            foreach (var token in tokens) {
                if (token is PositionalPropertyToken propertyToken0 && propertyToken0.TokenRenderType == TokenRenderTypes.AsPositionalProperty) {
                    var positionalValue = propertyToken0.PositionalParameterValue;
                    var resolvingMode = propertyToken0.PropertyResolvingMode;
                    if (!Exists0(positionalPropertyInfoList, positionalValue, resolvingMode)) {
                        positionalPropertyInfoList.Add((positionalValue, resolvingMode));
                    }
                } else if (token is PropertyToken propertyToken1 && propertyToken1.TokenType == PropertyTokenTypes.UserDefinedParameter) {
                    var name = propertyToken1.Name;
                    var resolvingMode = propertyToken1.PropertyResolvingMode;
                    if (!Exists1(namedPropertyInfoList, name, resolvingMode)) {
                        namedPropertyInfoList.Add((name, resolvingMode));
                    }
                }
            }

            bool Exists0(IEnumerable<(int position, PropertyResolvingMode mode)> __infos, int position, PropertyResolvingMode mode) {
                return __infos.Any(x => x.position == position && x.mode == mode);
            }

            bool Exists1(IEnumerable<(string name, PropertyResolvingMode mode)> __infos, string name, PropertyResolvingMode mode) {
                return __infos.Any(x => x.name == name && x.mode == mode);
            }
        }
    }
}