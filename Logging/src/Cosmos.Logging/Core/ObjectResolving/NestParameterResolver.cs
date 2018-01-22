using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core.ObjectResolving {
    internal class NestParameterResolver : IMessagePropertyValueFactory {
        [ThreadStatic] static int _currentNestLevel;
        private readonly int _maxLevelOfNestLimitedSelf;
        private MessageParameterResolver _root;

        public NestParameterResolver(int maxLevelOfNestLimited, MessageParameterResolver root) {
            _maxLevelOfNestLimitedSelf = maxLevelOfNestLimited;
            _root = root ?? throw new ArgumentNullException(nameof(root));
        }

        public void SetNestLevel(int nestLevel) => _currentNestLevel = nestLevel;

        public MessagePropertyValue CreatePropertyValue(object value, PropertyResolvingMode mode, int positionalValue = -1) {
            var level = _currentNestLevel;
            var ret = ReturnDefaultIfMaxNestLevel(level) ?? _root.CreatePropertyValue(value, mode, level + 1, positionalValue);
            _currentNestLevel = level;
            return ret;
        }

        MessagePropertyValue IMessagePropertyValueFactory.CreatePropertyValue(object value, PropertyResolvingMode mode, int positionalValue) {
            var level = _currentNestLevel;
            var ret = ReturnDefaultIfMaxNestLevel(level) ?? _root.CreatePropertyValue(value, mode, level + 1, positionalValue);
            _currentNestLevel = level;
            return ret;
        }

        private MessagePropertyValue ReturnDefaultIfMaxNestLevel(int deep) => deep == _maxLevelOfNestLimitedSelf ? ReturnNullValue() : null;
        private MessagePropertyValue ReturnNullValue() => new ScalarValue(null);
    }
}