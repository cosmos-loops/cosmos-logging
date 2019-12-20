using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.MessageTemplates {
    /// <summary>
    /// Message template cache
    /// </summary>
    internal class MessageTemplateCache : IMessageTemplateParser {
        private readonly IMessageTemplateParser _messageTemplateParser;
        private readonly Hashtable _messageTemplateCache = new Hashtable();
        private readonly Hashtable _preheatedTemplateCache = new Hashtable();
        private readonly Hashtable _cosmosOwnTemplateCache = new Hashtable();
        private readonly object _messageTemplateLock = new object();
        private const int MaxCacheItems = 1000;
        private const int MaxLengthOfTemplateToBeCached = 1024;

        /// <summary>
        /// Create a new instance of <see cref="MessageTemplateCache"/>
        /// </summary>
        /// <param name="parser"></param>
        public MessageTemplateCache(IMessageTemplateParser parser) {
            _messageTemplateParser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        internal void FirePreheadedMessageTemplates(MessageTemplateCachePreheater preheater) {
            if (preheater is null) return;
            FirePreheadedMessageTemplatesInternal(preheater.GetPreheatedMessageTemplates(), false);
            FirePreheadedMessageTemplatesInternal(preheater.GetNeedToBePreheadedMessageTemplates(), false);
            FirePreheadedMessageTemplatesInternal(preheater.GetTemplateStandards(), true);
        }

        public MessageTemplate Parse(string messageTemplate) {
            if (messageTemplate is null) throw new ArgumentNullException(nameof(messageTemplate));
            if (messageTemplate.Length > MaxLengthOfTemplateToBeCached) return _messageTemplateParser.Parse(messageTemplate);
            if (_messageTemplateCache[messageTemplate.GetHashCode()] is MessageTemplate result) return result;

            result = _messageTemplateParser.Parse(messageTemplate);
            lock (_messageTemplateLock) {
                if (_messageTemplateCache.Count >= MaxCacheItems) ClearAndSyncMessageTemplateCache();
                _messageTemplateCache[messageTemplate.GetHashCode()] = result;
            }

            return result;
        }

        private void ClearAndSyncMessageTemplateCache() {
            _messageTemplateCache.Clear();
            foreach (var k in _cosmosOwnTemplateCache.Keys) {
                if (!_messageTemplateCache.ContainsKey(k))
                    _messageTemplateCache.Add(k, _cosmosOwnTemplateCache[k]);
            }

            foreach (var k in _preheatedTemplateCache.Keys) {
                if (!_messageTemplateCache.ContainsKey(k))
                    _messageTemplateCache.Add(k, _preheatedTemplateCache[k]);
            }
        }

        private void FirePreheadedMessageTemplatesInternal(Hashtable preheadedTemplates, bool cosmosOwn) {
            if (preheadedTemplates is null) return;
            var indexer = 0;
            foreach (var item in preheadedTemplates) {
                if (item is MessageTemplate template) {
                    if (template.Text.Length > MaxLengthOfTemplateToBeCached) continue;
                    if (_messageTemplateCache.ContainsKey(template.Text.GetHashCode())) continue;
                    if (cosmosOwn) {
                        if (_cosmosOwnTemplateCache.ContainsKey(template.Text.GetHashCode())) continue;
                    } else {
                        if (_preheatedTemplateCache.ContainsKey(template.Text.GetHashCode())) continue;
                    }

                    if (indexer++ >= MaxCacheItems) break;

                    _messageTemplateCache[template.Text.GetHashCode()] = template;
                    if (cosmosOwn) {
                        _cosmosOwnTemplateCache[template.Text.GetHashCode()] = template;
                    } else {
                        _preheatedTemplateCache[template.Text.GetHashCode()] = template;
                    }
                }
            }
        }

        private void FirePreheadedMessageTemplatesInternal(Dictionary<int, string> preheadedTemplates, bool cosmosOwn) {
            if (preheadedTemplates is null) return;
            if (!preheadedTemplates.Any()) return;
            var indexer = 0;
            foreach (var item in preheadedTemplates) {
                if (string.IsNullOrWhiteSpace(item.Value)) continue;
                if (item.Value.Length > MaxLengthOfTemplateToBeCached) continue;
                if (_messageTemplateCache.ContainsKey(item.Key)) continue;
                if (cosmosOwn) {
                    if (_cosmosOwnTemplateCache.ContainsKey(item.Key)) continue;
                } else {
                    if (_preheatedTemplateCache.ContainsKey(item.Key)) continue;
                }

                if (indexer++ >= MaxCacheItems) break;

                _messageTemplateCache[item.Key] = _messageTemplateParser.Parse(item.Value);

                if (cosmosOwn) {
                    _cosmosOwnTemplateCache[item.Key] = _messageTemplateParser.Parse(item.Value);
                } else {
                    _preheatedTemplateCache[item.Key] = _messageTemplateParser.Parse(item.Value);
                }
            }
        }
    }
}