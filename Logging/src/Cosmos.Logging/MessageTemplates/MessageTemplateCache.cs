using System;
using System.Collections;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.MessageTemplates {
    internal class MessageTemplateCache : IMessageTemplateParser {
        private readonly IMessageTemplateParser _messageTemplateParser;
        private readonly Hashtable _messageTemplateCache = new Hashtable();
        private readonly object _messageTemplateLock = new object();
        private const int MaxCacheItems = 1000;
        private const int MaxLengthOfTemplateToBeCached = 2 ^ 10;

        public MessageTemplateCache(IMessageTemplateParser parser) {
            _messageTemplateParser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public MessageTemplate Parse(string messageTemplate) {
            if (messageTemplate == null) throw new ArgumentNullException(nameof(messageTemplate));
            if (messageTemplate.Length > MaxLengthOfTemplateToBeCached) return _messageTemplateParser.Parse(messageTemplate);
            if (_messageTemplateCache[messageTemplate] is MessageTemplate result) return result;

            result = _messageTemplateParser.Parse(messageTemplate);
            lock (_messageTemplateLock) {
                if (_messageTemplateCache.Count >= MaxCacheItems) _messageTemplateCache.Clear();
                _messageTemplateCache[messageTemplate] = result;
            }

            return result;
        }

    }
}