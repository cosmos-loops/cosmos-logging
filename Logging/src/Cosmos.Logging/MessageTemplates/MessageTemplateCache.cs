using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.MessageTemplates {
    internal class MessageTemplateCache : IMessageTemplateParser {
        private readonly IMessageTemplateParser _messageTemplateParser;
        private readonly Hashtable _messageTemplateCache = new Hashtable();
        private readonly object _messageTemplateLock = new object();
        private const int MaxCacheItems = 1000;
        private const int MaxLengthOfTemplateToBeCached = 1024;

        public MessageTemplateCache(IMessageTemplateParser parser) {
            _messageTemplateParser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        internal void FirePreheadedMessageTemplates(MessageTemplateCachePreheater preheater) {
            if (preheater == null) return;
            FirePreheadedMessageTemplatesInternal(preheater.GetPreheatedMessageTemplates());
            FirePreheadedMessageTemplateInternal(preheater.GetNeedToBePreheadedMessageTemplates());
        }

        public MessageTemplate Parse(string messageTemplate) {
            if (messageTemplate == null) throw new ArgumentNullException(nameof(messageTemplate));
            if (messageTemplate.Length > MaxLengthOfTemplateToBeCached) return _messageTemplateParser.Parse(messageTemplate);
            if (_messageTemplateCache[messageTemplate.GetHashCode()] is MessageTemplate result) return result;

            result = _messageTemplateParser.Parse(messageTemplate);
            lock (_messageTemplateLock) {
                if (_messageTemplateCache.Count >= MaxCacheItems) _messageTemplateCache.Clear();
                _messageTemplateCache[messageTemplate.GetHashCode()] = result;
            }

            return result;
        }

        private void FirePreheadedMessageTemplatesInternal(Hashtable preheadedTemplates) {
            if (preheadedTemplates == null) return;
            var indexer = 0;
            foreach (var item in preheadedTemplates) {
                if (item is MessageTemplate template) {
                    if (template.Text.Length > MaxLengthOfTemplateToBeCached) continue;
                    if (_messageTemplateCache.ContainsKey(template.Text.GetHashCode())) continue;
                    if (indexer++ >= MaxCacheItems) break;
                    _messageTemplateCache[template.Text.GetHashCode()] = template;
                }

            }
        }

        private void FirePreheadedMessageTemplateInternal(Dictionary<int, string> preheadedTemplates) {
            if (preheadedTemplates == null) return;
            if (!preheadedTemplates.Any()) return;
            var indexer = 0;
            foreach (var item in preheadedTemplates) {
                if (string.IsNullOrWhiteSpace(item.Value)) continue;
                if (item.Value.Length > MaxLengthOfTemplateToBeCached) continue;
                if (_messageTemplateCache.ContainsKey(item.Key)) continue;
                if (indexer++ >= MaxCacheItems) break;
                _messageTemplateCache[item.Key] = _messageTemplateParser.Parse(item.Value);
            }
        }
    }
}