using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

// ReSharper disable InconsistentNaming
namespace Cosmos.Logging.Core.ObjectResolving {
    internal class PropertyBinder {
        private readonly MessageParameterResolver _messageParameterResolver;

        private static readonly MessageProperty[] _emptyMessageProperties;
        private static readonly Dictionary<(string name, PropertyResolvingMode mode), MessageProperty> _emptyNamedMessageProperties;
        private static readonly Dictionary<(int position, PropertyResolvingMode mode), MessageProperty> _emptyPositionalMessageProperties;

        static PropertyBinder() {
            _emptyMessageProperties = new MessageProperty[0];
            _emptyNamedMessageProperties = new Dictionary<(string name, PropertyResolvingMode mode), MessageProperty>();
            _emptyPositionalMessageProperties = new Dictionary<(int position, PropertyResolvingMode mode), MessageProperty>();
        }

        public PropertyBinder(MessageParameterResolver resolver) {
            _messageParameterResolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public IEnumerable<MessageProperty> Bind(MessageTemplate messageTemplate, object[] messageParameters,
            out Dictionary<(string name, PropertyResolvingMode mode), MessageProperty> namedMessageProperties,
            out Dictionary<(int position, PropertyResolvingMode mode), MessageProperty> positionalMessageProperties) {

            if (messageParameters == null || messageParameters.Length == 0) {
                if (messageTemplate.PropertyClassTokenCount > 0)
                    InternalLogger.WriteLine("No message parameters can be used for '{0}'.", messageTemplate);
                namedMessageProperties = _emptyNamedMessageProperties;
                positionalMessageProperties = _emptyPositionalMessageProperties;
                return _emptyMessageProperties;
            }

            var __result = new List<MessageProperty>();
            var __named_cache = new Dictionary<(string name, PropertyResolvingMode mode), MessageProperty>();
            var __positional_cache = new Dictionary<(int position, PropertyResolvingMode mode), MessageProperty>();

            PrepareForPropertyToken(messageTemplate.Tokens, out var positionalPropMetaList, out var namedPropMetaList, out var namedPropOffsetInfoDict);

            var anonymousParamObjects = messageParameters.Where(x => x.GetType().Name.StartsWith("<>"));
            foreach (var __anonymous in anonymousParamObjects) {
                var propertiesInAnonymus = __anonymous.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField | BindingFlags.GetProperty);
                foreach (var propertyInAnonymus in propertiesInAnonymus) {
                    var __anonymous_name = propertyInAnonymus.Name;
                    if (string.IsNullOrWhiteSpace(__anonymous_name) || __anonymous_name.StartsWith("<>")) continue;
                    if (__named_cache.Any(x => x.Key.name == __anonymous_name)) continue;
                    if (namedPropMetaList.Any(x => string.Compare(x.name, __anonymous_name, StringComparison.OrdinalIgnoreCase) == 0)) {
                        var __matched_keys = namedPropMetaList.Where(x => string.Compare(x.name, __anonymous_name, StringComparison.OrdinalIgnoreCase) == 0);
                        var __object = propertyInAnonymus.GetValue(__anonymous);
                        foreach (var __key in __matched_keys) {
                            __update0(__key, __object);
                        }
                    }
                }
            }

            var legalPositionalPropMetaList = positionalPropMetaList.Where(x => x.position < messageParameters.Length).ToList();
            var namesHaveBeenCached = __named_cache.Select(x => x.Key.name).Distinct().ToList();
            var namesHaveNotBeenCached = namedPropOffsetInfoDict.Where(o => !namesHaveBeenCached.Contains(o.Key) && o.Value < messageParameters.Length)
                .Select(s => new {PositionalOffset = s.Value, Name = s.Key}).ToList();

            var keysOfOutOfCachhed = namesHaveNotBeenCached.Select(x => x.Name);
            var namedPropMetaList2 = namedPropMetaList.Where(x => keysOfOutOfCachhed.Contains(x.name) && !namesHaveBeenCached.Contains(x.name)).ToList();

            var __real_max_positional_offset = Math.Min(
                Math.Max(
                    namesHaveNotBeenCached.Any() ? namesHaveNotBeenCached.Max(m => m.PositionalOffset) : 0,
                    legalPositionalPropMetaList.Any() ? legalPositionalPropMetaList.Select(x => x.position).Max() : 0),
                messageParameters.Length);

            for (var __i = 0; __i <= __real_max_positional_offset; __i++) {
                var __object = messageParameters[__i];
                var ____i = __i;

                foreach (var item in namesHaveNotBeenCached.Where(x => x.PositionalOffset == ____i)) {
                    var __keys = namedPropMetaList2.Where(x => x.name == item.Name);
                    foreach (var __key in __keys) {
                        __update1(__key, __object, ____i);
                    }
                }

                foreach (var __key in legalPositionalPropMetaList.Where(x => x.position == ____i)) {
                    __update2(__key, __object);
                }
            }

            namedMessageProperties = __named_cache;
            positionalMessageProperties = __positional_cache;
            return __result;

            void __update0((string name, PropertyResolvingMode mode) __key, object __object) {
                if (!__named_cache.ContainsKey(__key)) {
                    var __compiled = _messageParameterResolver.CreateProperty(__key.name, __object, __key.mode);
                    __named_cache.Add(__key, __compiled);
                    __result.Add(__compiled);
                }
            }

            void __update1((string name, PropertyResolvingMode mode) __key, object __object, int __position) {
                if (!__named_cache.ContainsKey(__key)) {
                    var __key_alias_0 = ($"__cosmos_<>position_{__position}", __key.mode);
                    var __key_alias_1 = (__position, __key.mode);
                    var __compiled = _messageParameterResolver.CreateProperty(__key.name, __object, __key.mode, __position);
                    __named_cache.Add(__key, __compiled);
                    __named_cache.Add(__key_alias_0, __compiled);
                    __positional_cache.Add(__key_alias_1, __compiled);
                    __result.Add(__compiled);
                }
            }

            void __update2((int position, PropertyResolvingMode mode) __key, object __object) {
                var __key_alias_0 = $"__cosmos_<>position_{__key.position}";
                var __key_alias_1 = (__key_alias_0, __key.mode);
                if (!__named_cache.ContainsKey(__key_alias_1)) {
                    var __compiled = _messageParameterResolver.CreateProperty(__key_alias_0, __object, __key.mode, __key.position);
                    __named_cache.Add(__key_alias_1, __compiled);
                    __positional_cache.Add(__key, __compiled);
                    __result.Add(__compiled);
                }
            }
        }

        void PrepareForPropertyToken(IEnumerable<MessageTemplateToken> tokens,
            out List<(int position, PropertyResolvingMode mode)> positionalPropertyInfoList,
            out List<(string name, PropertyResolvingMode mode)> namedPropertyInfoList,
            out Dictionary<string, int> namedPropertyOffsetInfoDict) {

            positionalPropertyInfoList = new List<(int, PropertyResolvingMode)>();
            namedPropertyInfoList = new List<(string name, PropertyResolvingMode mode)>();
            namedPropertyOffsetInfoDict = new Dictionary<string, int>();
            var propertyIndex = 0;

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

                    propertyIndex = Next(namedPropertyOffsetInfoDict, name, propertyIndex);
                }
            }

            bool Exists0(IEnumerable<(int position, PropertyResolvingMode mode)> __infos, int position, PropertyResolvingMode mode) {
                return __infos.Any(x => x.position == position && x.mode == mode);
            }

            bool Exists1(IEnumerable<(string name, PropertyResolvingMode mode)> __infos, string name, PropertyResolvingMode mode) {
                return __infos.Any(x => x.name == name && x.mode == mode);
            }

            int Next(Dictionary<string, int> __infos, string name, int offset) {
                if (!__infos.ContainsKey(name)) __infos.Add(name, offset++);
                return offset;
            }
        }
    }
}