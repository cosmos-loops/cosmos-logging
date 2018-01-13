using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Core;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Events {
    public class LogEvent {
        private readonly AdditionalOptContext _additionalOptContext;
        private readonly LogEventContext _eventContext;

        private readonly Dictionary<string, MessagePropertyValue> _properties;
        private readonly Dictionary<string, ExtraMessageProperty> _extraMessageProperties;

        public LogEvent(
            DateTimeOffset timestamp,
            LogEventLevel level,
            MessageTemplate messageTemplate,
            Exception exception,
            LogEventSendMode sendMode,
            LogEventContext context = null) {

            _eventContext = context ?? throw new ArgumentNullException(nameof(context));

            Timestamp = timestamp;
            Level = level;
            Exception = exception;
            MessageTemplate = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));
            SendMode = sendMode;

            _additionalOptContext = context.AdditionalOptContext ?? new AdditionalOptContext();
            _properties = new Dictionary<string, MessagePropertyValue>();
            _extraMessageProperties = new Dictionary<string, ExtraMessageProperty>();
            UpdateProperty();
        }

        public DateTimeOffset Timestamp { get; }
        public LogEventLevel Level { get; }
        public LogEventSendMode SendMode { get; }
        public Exception Exception { get; }
        public MessageTemplate MessageTemplate { get; }

        #region Reder Message

        public void RenderMessage(TextWriter output, IFormatProvider provider = null) {
            MessageTemplate.Render(Properties, output, provider);
        }

        public string RenderMessage(IFormatProvider provider = null) {
            return MessageTemplate.Render(Properties, provider);
        }

        #endregion

        #region Additional Operations

        public IEnumerable<IAdditionalOperation> GetAdditionalOperations(Type flagType, AdditionalOperationTypes optType)
            => LogAdditionalOperationFilter.Filter(_additionalOptContext, flagType, optType);

        #endregion

        #region Normal Message Properties

        public IReadOnlyDictionary<string, MessagePropertyValue> Properties => _properties;

        private void UpdateProperty() {
            if (_eventContext.MessageProperties != null)
                foreach (var p in _eventContext.MessageProperties)
                    if (p != null)
                        _properties[p.Name] = p.Value;
        }

        public void AddOrUpdateProperty(MessageProperty property) {
            if (property == null) throw new ArgumentNullException(nameof(property));
            _properties[property.Name] = property.Value;
        }

        public void AddPropertyIfAbsent(MessageProperty property) {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (!_properties.ContainsKey(property.Name))
                _properties.Add(property.Name, property.Value);
        }

        public void RemoveProperty(string propertyName) {
            _properties.Remove(propertyName);
        }

        #endregion

        #region Extra Message Properties

        public void AddExtraProperty(ExtraMessageProperty property) {
            if (property != null && !string.IsNullOrWhiteSpace(property.Name))
                _extraMessageProperties[property.Name] = property;
        }

        public void RemoveExtraProperty(string name) {
            if (_extraMessageProperties.ContainsKey(name))
                _extraMessageProperties.Remove(name);
        }

        public void RemoveAllExtraProperties() {
            _extraMessageProperties.Clear();
        }

        public IReadOnlyDictionary<string, ExtraMessageProperty> ExtraProperties => _extraMessageProperties;

        #endregion

    }
}