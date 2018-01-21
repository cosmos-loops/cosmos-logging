using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Core;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Events {
    public class LogEvent {
        private readonly AdditionalOptContext _additionalOptContext;

        private readonly Dictionary<string, MessagePropertyValue> _namedProperties = new Dictionary<string, MessagePropertyValue>();
        private readonly Dictionary<int, MessagePropertyValue> _positionalProperties = new Dictionary<int, MessagePropertyValue>();
        private readonly Dictionary<string, ExtraMessageProperty> _extraMessageProperties = new Dictionary<string, ExtraMessageProperty>();

        public LogEvent(
            DateTimeOffset timestamp,
            LogEventLevel level,
            MessageTemplate messageTemplate,
            Exception exception,
            LogEventSendMode sendMode,
            IEnumerable<MessageProperty> messageProperties,
            AdditionalOptContext additionalOptContext) {
            Timestamp = timestamp;
            Level = level;
            Exception = exception;
            SendMode = sendMode;
            MessageTemplate = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));
            _additionalOptContext = additionalOptContext ?? new AdditionalOptContext();
            UpdateProperty(messageProperties);
        }

        public DateTimeOffset Timestamp { get; }
        public LogEventLevel Level { get; }
        public LogEventSendMode SendMode { get; }
        public Exception Exception { get; }
        public MessageTemplate MessageTemplate { get; }

        #region Reder Message

        public void RenderMessage(TextWriter output, IFormatProvider provider = null) {
            MessageTemplate.Render(NamedProperties, output, provider);
        }

        public string RenderMessage(IFormatProvider provider = null) {
            return MessageTemplate.Render(NamedProperties, provider);
        }

        #endregion

        #region Additional Operations

        public IEnumerable<IAdditionalOperation> GetAdditionalOperations(Type flagType, AdditionalOperationTypes optType)
            => LogAdditionalOperationFilter.Filter(_additionalOptContext, flagType, optType);

        #endregion

        #region Normal Message Properties

        public IReadOnlyDictionary<string, MessagePropertyValue> NamedProperties => _namedProperties;

        private void UpdateProperty(IEnumerable<MessageProperty> properties) {
            Console.WriteLine("开始处理 Message properties，但目前尚在开发中...");
            if (properties == null) return;
            
            //todo
        }

        public void AddOrUpdateProperty(MessageProperty property) {
            if (property == null) throw new ArgumentNullException(nameof(property));
            _namedProperties[property.Name] = property.Value;
        }

        public void AddPropertyIfAbsent(MessageProperty property) {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (!_namedProperties.ContainsKey(property.Name))
                _namedProperties.Add(property.Name, property.Value);
        }

        public void RemoveProperty(string propertyName) {
            _namedProperties.Remove(propertyName);
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