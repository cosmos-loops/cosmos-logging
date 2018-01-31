using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Core.ObjectResolving.Extensions;
using Cosmos.Logging.Core.ObjectResolving.Rules;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving {
    public class MessageParameterResolver : IMessagePropertyFactory, IMessagePropertyValueFactory {
        private readonly int _maxLengthOfString;
        private readonly int _maxLevelOfNestLevelLimited;
        private readonly int _maxLoopCountForCollection;
        private readonly bool _raiseExceptions;
        private readonly IScalarResolveRule[] _scalarResolveRules;
        private readonly IDestructureResolveRule[] _destructureResolveRules;
        private readonly NestParameterResolver _nestParameterResolver;

        public MessageParameterResolver(
            int maxLengthOfString,
            int maxLevelOfNestLevelLimited,
            int maxLoopCountForCollection,
            IEnumerable<Type> additionalScalarTypes,
            IEnumerable<IDestructureResolveRule> additionalDestructureResolveRules,
            bool raiseExceptions) {
            if (maxLengthOfString < 2) throw new ArgumentOutOfRangeException(nameof(maxLengthOfString));
            if (maxLevelOfNestLevelLimited < 0) throw new ArgumentOutOfRangeException(nameof(maxLevelOfNestLevelLimited));
            if (maxLoopCountForCollection < 1) throw new ArgumentOutOfRangeException(nameof(maxLoopCountForCollection));
            if (additionalScalarTypes == null) throw new ArgumentNullException(nameof(additionalScalarTypes));
            if (additionalDestructureResolveRules == null) throw new ArgumentNullException(nameof(additionalDestructureResolveRules));

            _maxLengthOfString = maxLengthOfString;
            _maxLevelOfNestLevelLimited = maxLevelOfNestLevelLimited;
            _maxLoopCountForCollection = maxLoopCountForCollection;
            _raiseExceptions = raiseExceptions;
            _scalarResolveRules = new IScalarResolveRule[] {
                new SimpleResolveRule(additionalScalarTypes.GetAllScalarTypes()),
                new EnumResolveRule(), new ByteArrayResolveRule()
            };
            _destructureResolveRules = additionalDestructureResolveRules
                .Concat(new IDestructureResolveRule[] {new DelegateResolveRule(), new ReflectionTypesResolveRule()})
                .ToArray();
            _nestParameterResolver = new NestParameterResolver(_maxLevelOfNestLevelLimited, this);
        }

        public MessageProperty CreateProperty(string name, object value, PropertyResolvingMode mode, int positionalValue = -1) {
            return new MessageProperty(name, positionalValue, CreatePropertyValue(value, mode, positionalValue));
        }

        public MessagePropertyValue CreatePropertyValue(object value, PropertyResolvingMode mode, int positionalValue = -1) {
            return CreatePropertyValue(value, mode, 1, positionalValue);
        }

        internal MessagePropertyValue CreatePropertyValue(object value, PropertyResolvingMode mode, int level, int positionalValue) {
            if (value == null) return ReturnNullValue();
            if (mode == PropertyResolvingMode.Stringify) return ReturnStringifyValue(value);
            if (mode == PropertyResolvingMode.Destructure && value is string str) {
                value = FixStringifyValueForMaxLength(str);
            }

            var typeOfValue = value.GetType();
            _nestParameterResolver.SetNestLevel(level);

            if (_scalarResolveRules.TryResolve(value, out var result0)) return result0;
            if (_destructureResolveRules.TryResolve(value, mode, _nestParameterResolver, out var result1)) return result1;
            if (TypeFeeler.TryResolveToEnumerable(value, mode, _nestParameterResolver, typeOfValue, _maxLoopCountForCollection, out var result2)) return result2;
            if (TypeFeeler.TryResolveToValueTuple(value, mode, _nestParameterResolver, typeOfValue, out var result3)) return result3;
            if (TypeFeeler.TryResolveCompilerGeneratedType(value, mode, _nestParameterResolver, typeOfValue, _raiseExceptions, positionalValue, out var result4)) return result4;

            return ReturnDefaultValue(value);
        }

        private MessagePropertyValue ReturnNullValue() => new ScalarValue(null);
        private MessagePropertyValue ReturnStringifyValue(object value) => new ScalarValue(FixStringifyValueForMaxLength(value.ToString()));
        private MessagePropertyValue ReturnDefaultValue(object value) => new ScalarValue(value.ToString());

        private string FixStringifyValueForMaxLength(string str) => str.Length > _maxLengthOfString ? $"{str.Substring(0, _maxLengthOfString - 1)}..." : str;
    }
}