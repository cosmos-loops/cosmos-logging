using System;
using System.Collections.Generic;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core.ObjectResolving {
    public class MessageParameterProcessor : IMessagePropertyFactory {
        private readonly MessageTemplateCache _messageTemplateParser = new MessageTemplateCache(new MessageTemplateParser());
        private readonly MessageParameterResolver _messageParameterResolver;
        private readonly PropertyBinder _propertyBinder;

        public MessageParameterProcessor(MessageParameterResolver resolver) {
            _messageParameterResolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            _propertyBinder = new PropertyBinder(_messageParameterResolver);
        }

        public void Process(string messageTemplate, object[] messageProperties, out MessageTemplate parsedTemplate, out IEnumerable<MessageProperty> parsedProperties) {
            parsedTemplate = _messageTemplateParser.Parse(messageTemplate);
            parsedProperties = _propertyBinder.Bind(parsedTemplate, messageProperties);
        }

        public MessageProperty CreateProperty(string name, object value, PropertyResolvingMode mode, int positionalIndex = 0) {
            return _messageParameterResolver.CreateProperty(name, value, mode, positionalIndex);
        }
    }
}