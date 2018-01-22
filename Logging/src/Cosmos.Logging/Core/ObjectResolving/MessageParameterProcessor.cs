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

        public void Process(string messageTemplate, object[] messageProperties, out MessageTemplate parsedTemplate,
            out IEnumerable<MessageProperty> parsedProperties,
            out Dictionary<(string name, PropertyResolvingMode mode), MessageProperty> namedMessageProperties,
            out Dictionary<(int position, PropertyResolvingMode mode), MessageProperty> positionalMessageProperties) {
            parsedTemplate = _messageTemplateParser.Parse(messageTemplate);
            parsedProperties = _propertyBinder.Bind(parsedTemplate, messageProperties, out namedMessageProperties, out positionalMessageProperties);
        }

        public MessageProperty CreateProperty(string name, object value, PropertyResolvingMode mode, int positionalValue = 0) {
            return _messageParameterResolver.CreateProperty(name, value, mode, positionalValue);
        }
    }
}