using System;
using System.Collections.Generic;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core.ObjectResolving {
    /// <summary>
    /// Message parameter provessor
    /// </summary>
    public class MessageParameterProcessor : IMessagePropertyFactory, IShortcutPropertyFactory {
        private readonly MessageTemplateCache _messageTemplateParser = new MessageTemplateCache(new MessageTemplateParser());
        private readonly MessageParameterResolver _messageParameterResolver;
        private readonly PropertyBinder _propertyBinder;

        /// <summary>
        /// Create a new instance of <see cref="MessageParameterProcessor"/>
        /// </summary>
        /// <param name="resolver"></param>
        /// <param name="preheater"></param>
        public MessageParameterProcessor(MessageParameterResolver resolver, MessageTemplateCachePreheater preheater) {
            _messageParameterResolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            _propertyBinder = new PropertyBinder(_messageParameterResolver);
            _messageTemplateParser.FirePreheadedMessageTemplates(preheater);
        }

        /// <summary>
        /// Process
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="messageProperties"></param>
        /// <param name="parsedTemplate"></param>
        /// <param name="namedMessageProperties"></param>
        /// <param name="positionalMessageProperties"></param>
        public void Process(string messageTemplate, object[] messageProperties, out MessageTemplate parsedTemplate,
            out Dictionary<(string name, PropertyResolvingMode mode), MessageProperty> namedMessageProperties,
            out Dictionary<(int position, PropertyResolvingMode mode), MessageProperty> positionalMessageProperties) {
            parsedTemplate = _messageTemplateParser.Parse(messageTemplate);
            _propertyBinder.Bind(parsedTemplate, messageProperties, out namedMessageProperties, out positionalMessageProperties);
        }

        /// <inheritdoc />
        public MessageProperty CreateProperty(string name, object value, PropertyResolvingMode mode, int positionalValue = 0) {
            return _messageParameterResolver.CreateProperty(name, value, mode, positionalValue);
        }

        /// <inheritdoc />
        public MessageProperty CreateProperty(string name, object value, bool destructureObject = false) {
            return CreateProperty(name, value, destructureObject ? PropertyResolvingMode.Destructure : PropertyResolvingMode.Default);
        }
    }
}