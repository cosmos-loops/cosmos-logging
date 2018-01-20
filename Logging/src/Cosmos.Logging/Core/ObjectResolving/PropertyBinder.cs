using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core.ObjectResolving {
    internal class PropertyBinder {
        private readonly MessageParameterResolver _messageParameterResolver;

        public PropertyBinder(MessageParameterResolver resolver) {
            _messageParameterResolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public IEnumerable<MessageProperty> Bind(MessageTemplate messageTemplate, object[] messageParameters) {
            Console.WriteLine("执行到 PropertyBinder.Bind，但目前尚在开发中...");
            return Enumerable.Empty<MessageProperty>();
        }
    }
}