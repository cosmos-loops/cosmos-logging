using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.ExtraSupports;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Events {
    public class LogEvent : ILogEventInfo, IContextualLogEvent {
        private readonly LogEventContext _logEventContext;
        private readonly ContextData _contextData;

        private readonly Dictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> _namedProperties;
        private readonly Dictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> _positionalProperties;
        private readonly Dictionary<string, ExtraMessageProperty> _extraMessageProperties;

        internal LogEvent() {
            _logEventContext = null;
            _namedProperties = null;
            _positionalProperties = null;
            _extraMessageProperties = null;
            CallerInfo = NullLogCallerInfo.Instance;
        }

        public LogEvent(
            string stateNamespace,
            LogEventId eventId,
            LogEventLevel level,
            MessageTemplate messageTemplate,
            Exception exception,
            LogEventSendMode sendMode,
            ILogCallerInfo callerInfo,
            RendingConfiguration upstreamRenderingOptions,
            Dictionary<(string name, PropertyResolvingMode mode), MessageProperty> namedMessageProperties,
            Dictionary<(int position, PropertyResolvingMode mode), MessageProperty> positionalMessageProperties,
            LogEventContext logEventContext,
            ContextData contextData = null) {

            if (namedMessageProperties == null) throw new ArgumentNullException(nameof(namedMessageProperties));
            if (positionalMessageProperties == null) throw new ArgumentNullException(nameof(positionalMessageProperties));

            StateNamespace = stateNamespace;
            EventId = eventId;
            Level = level;
            Exception = exception;
            SendMode = sendMode;
            CallerInfo = callerInfo;
            MessageTemplate = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));
            _logEventContext = logEventContext ?? new LogEventContext();

            _namedProperties = new Dictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue>();
            _positionalProperties = new Dictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue>();
            _extraMessageProperties = new Dictionary<string, ExtraMessageProperty>();

            _contextData = contextData == null ? new ContextData() : new ContextData(contextData);
            if (exception != null && !_contextData.HasException()) _contextData.SetException(exception);
            _contextData.ImportUpstreamContextData(_logEventContext.ExposeContextData());

            UpdateProperty(namedMessageProperties, positionalMessageProperties);

            UpstreamRenderingOptions = upstreamRenderingOptions.ToCalc(logEventContext?.RenderingOptions);
        }

        public string StateNamespace { get; }
        public LogEventId EventId { get; }
        public DateTimeOffset Timestamp => EventId.Timestamp;
        public LogEventLevel Level { get; }
        public LogEventSendMode SendMode { get; }
        public Exception Exception { get; }
        public MessageTemplate MessageTemplate { get; }
        public ILogCallerInfo CallerInfo { get; }

        public ContextData ContextData => _contextData;

        public RendingConfiguration UpstreamRenderingOptions { get; }

        #region Reder Message

        public void RenderMessage(TextWriter output, RendingConfiguration renderingOptions = null, IFormatProvider provider = null) {
            MessageTemplate.Render(NamedProperties, PositionalProperties, output, this, this, UpstreamRenderingOptions.ToCalc(renderingOptions), provider);
        }

        public string RenderMessage(RendingConfiguration renderingOptions = null, IFormatProvider provider = null) {
            return MessageTemplate.Render(NamedProperties, PositionalProperties, this, this, UpstreamRenderingOptions.ToCalc(renderingOptions), provider);
        }

        #endregion

        #region Additional Operations

        public IEnumerable<IAdditionalOperation> GetAdditionalOperations(Type flagType, AdditionalOperationTypes optType)
            => LogAdditionalOperationFilter.Filter(_logEventContext, flagType, optType);

        #endregion

        #region Tags

        public IReadOnlyList<string> Tags => _logEventContext.Tags;

        #endregion

        #region Normal Message Properties

        public IReadOnlyDictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> NamedProperties => _namedProperties;

        public IReadOnlyDictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> PositionalProperties => _positionalProperties;

        private void UpdateProperty(
            Dictionary<(string name, PropertyResolvingMode mode), MessageProperty> namedMessageProperties,
            Dictionary<(int position, PropertyResolvingMode mode), MessageProperty> positionalMessageProperties) {
            foreach (var prop in namedMessageProperties) _namedProperties.Add(prop.Key, prop.Value.Value);
            foreach (var prop in positionalMessageProperties) _positionalProperties.Add(prop.Key, prop.Value.Value);
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