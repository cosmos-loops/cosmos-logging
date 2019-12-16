using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.ExtraSupports;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Log event
    /// </summary>
    public class LogEvent : ILogEventInfo, IContextualLogEvent {
        private readonly LogEventContext _logEventContext;
        private readonly ContextData _contextData;

        private readonly Dictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> _namedProperties;
        private readonly Dictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> _positionalProperties;
        private readonly Dictionary<string, ExtraMessageProperty> _extraMessageProperties;

        private readonly IShortcutPropertyFactory _messageParameterProcessorShortcut;

        internal LogEvent() {
            _logEventContext = null;
            _namedProperties = null;
            _positionalProperties = null;
            _extraMessageProperties = null;
            CallerInfo = NullLogCallerInfo.Instance;
        }

        /// <summary>
        /// Create a new instance of <see cref="LogEvent"/>.
        /// </summary>
        /// <param name="stateNamespace"></param>
        /// <param name="eventId"></param>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="exception"></param>
        /// <param name="sendMode"></param>
        /// <param name="callerInfo"></param>
        /// <param name="upstreamRenderingOptions"></param>
        /// <param name="namedMessageProperties"></param>
        /// <param name="positionalMessageProperties"></param>
        /// <param name="logEventContext"></param>
        /// <param name="contextData"></param>
        /// <param name="messageProcessorShortcut"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LogEvent(
            string stateNamespace,
            LogEventId eventId,
            LogEventLevel level,
            MessageTemplate messageTemplate,
            Exception exception,
            LogEventSendMode sendMode,
            ILogCallerInfo callerInfo,
            RenderingConfiguration upstreamRenderingOptions,
            Dictionary<(string name, PropertyResolvingMode mode), MessageProperty> namedMessageProperties,
            Dictionary<(int position, PropertyResolvingMode mode), MessageProperty> positionalMessageProperties,
            LogEventContext logEventContext,
            ContextData contextData = null,
            IShortcutPropertyFactory messageProcessorShortcut = null) {

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

            _messageParameterProcessorShortcut = messageProcessorShortcut;

            UpdateProperty(namedMessageProperties, positionalMessageProperties);

            UpstreamRenderingOptions = upstreamRenderingOptions.ToCalc(logEventContext?.RenderingOptions);
        }

        /// <inheritdoc />
        public string StateNamespace { get; }

        /// <inheritdoc />
        public LogEventId EventId { get; }

        /// <inheritdoc />
        public DateTimeOffset Timestamp => EventId.Timestamp;

        /// <inheritdoc />
        public LogEventLevel Level { get; }

        /// <inheritdoc />
        public LogEventSendMode SendMode { get; }

        /// <inheritdoc />
        public Exception Exception { get; }

        /// <summary>
        /// Gets message template
        /// </summary>
        public MessageTemplate MessageTemplate { get; }

        /// <inheritdoc />
        public ILogCallerInfo CallerInfo { get; }

        /// <summary>
        /// Gets context data
        /// </summary>
        public ContextData ContextData => _contextData;

        /// <summary>
        /// Gets upstream rendering options
        /// </summary>
        public RenderingConfiguration UpstreamRenderingOptions { get; }

        #region Reder Message

        /// <summary>
        /// Render message
        /// </summary>
        /// <param name="output"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="provider"></param>
        public void RenderMessage(TextWriter output, RenderingConfiguration renderingOptions = null, IFormatProvider provider = null) {
            MessageTemplate.Render(NamedProperties, PositionalProperties, output, this, this, UpstreamRenderingOptions.ToCalc(renderingOptions), provider);
        }

        /// <summary>
        /// Render message
        /// </summary>
        /// <param name="renderingOptions"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string RenderMessage(RenderingConfiguration renderingOptions = null, IFormatProvider provider = null) {
            return MessageTemplate.Render(NamedProperties, PositionalProperties, this, this, UpstreamRenderingOptions.ToCalc(renderingOptions), provider);
        }

        #endregion

        #region Additional Operations

        /// <summary>
        /// Get additional operations
        /// </summary>
        /// <param name="flagType"></param>
        /// <param name="optType"></param>
        /// <returns></returns>
        public IEnumerable<IAdditionalOperation> GetAdditionalOperations(Type flagType, AdditionalOperationTypes optType)
            => LogAdditionalOperationFilter.Filter(_logEventContext, flagType, optType);

        #endregion

        #region Tags

        /// <inheritdoc />
        public IReadOnlyList<string> Tags => _logEventContext.Tags;

        #endregion

        #region Normal Message Properties

        /// <summary>
        /// Gets named properties
        /// </summary>
        public IReadOnlyDictionary<(string name, PropertyResolvingMode mode), MessagePropertyValue> NamedProperties => _namedProperties;

        /// <summary>
        /// Gets positional properties
        /// </summary>
        public IReadOnlyDictionary<(int position, PropertyResolvingMode mode), MessagePropertyValue> PositionalProperties => _positionalProperties;

        private void UpdateProperty(
            Dictionary<(string name, PropertyResolvingMode mode), MessageProperty> namedMessageProperties,
            Dictionary<(int position, PropertyResolvingMode mode), MessageProperty> positionalMessageProperties) {
            foreach (var prop in namedMessageProperties) _namedProperties.Add(prop.Key, prop.Value.Value);
            foreach (var prop in positionalMessageProperties) _positionalProperties.Add(prop.Key, prop.Value.Value);
        }

        #endregion

        #region Extra Message Properties

        /// <summary>
        /// Add extra property
        /// </summary>
        /// <param name="property"></param>
        public void AddExtraProperty(ExtraMessageProperty property) {
            if (property != null && !string.IsNullOrWhiteSpace(property.Name))
                _extraMessageProperties[property.Name] = property;
        }

        /// <summary>
        /// Add extra property if absent
        /// </summary>
        /// <param name="property"></param>
        public void AddExtraPropertyIfAbsent(ExtraMessageProperty property) {
            if (property != null && !string.IsNullOrWhiteSpace(property.Name) && !_extraMessageProperties.ContainsKey(property.Name))
                _extraMessageProperties[property.Name] = property;
        }

        /// <summary>
        /// Add extra property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="destructureObject"></param>
        public void AddExtraProperty(string name, object value, bool destructureObject = false) {
            if (!string.IsNullOrWhiteSpace(name)) {
                var property = _messageParameterProcessorShortcut.CreateProperty(name, value, destructureObject);
                AddExtraProperty(new ExtraMessageProperty(property));
            }
        }

        /// <summary>
        /// Add extra property if absent
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="destructureObject"></param>
        public void AddExtraPropertyIfAbsent(string name, object value, bool destructureObject = false) {
            if (!string.IsNullOrWhiteSpace(name)) {
                var property = _messageParameterProcessorShortcut.CreateProperty(name, value, destructureObject);
                AddExtraPropertyIfAbsent(new ExtraMessageProperty(property));
            }
        }

        /// <summary>
        /// Remove extra property by the given name
        /// </summary>
        /// <param name="name"></param>
        public void RemoveExtraProperty(string name) {
            if (_extraMessageProperties.ContainsKey(name))
                _extraMessageProperties.Remove(name);
        }

        /// <summary>
        /// Remove all extra properties
        /// </summary>
        public void RemoveAllExtraProperties() {
            _extraMessageProperties.Clear();
        }

        /// <summary>
        /// Gets all extra properties
        /// </summary>
        public IReadOnlyDictionary<string, ExtraMessageProperty> ExtraProperties => _extraMessageProperties;

        #endregion

        /// <inheritdoc />
        public LogEvent ToLogEvent() => this;

        /// <inheritdoc />
        public IContextualLogEvent ToContextualLogEvent() => this;
    }
}