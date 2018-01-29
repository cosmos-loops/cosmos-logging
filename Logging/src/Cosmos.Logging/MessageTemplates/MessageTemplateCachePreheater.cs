using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.MessageTemplates {
    public class MessageTemplateCachePreheater {
        private readonly Hashtable _preheatedMessageTemplates = new Hashtable();
        private readonly Dictionary<int, string> _needToBePreheadedTemplates = new Dictionary<int, string>();
        private readonly Dictionary<int, string> _templateStandards = new Dictionary<int, string>();
        private const int MaxCacheItemsForObject = 500;
        private const int MaxCacheItemsForString = 500;
        private const int MaxLengthOfTemplateToBeCached = 1024;

        internal Hashtable GetPreheatedMessageTemplates() {
            return _preheatedMessageTemplates;
        }

        internal Dictionary<int, string> GetNeedToBePreheadedMessageTemplates() {
            return _needToBePreheadedTemplates;
        }

        internal Dictionary<int, string> GetTemplateStandards() {
            return _templateStandards;
        }

        internal void AddStandardsInternal(string messageTemplate) {
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            if (_templateStandards.ContainsKey(messageTemplate.GetHashCode())) return;
            _templateStandards.Add(messageTemplate.GetHashCode(), messageTemplate);
        }

        private void AddInternal(IEnumerable<MessageTemplate> templates) {
            if (templates == null || !templates.Any()) return;
            var indexer = 0;
            foreach (var template in templates) {
                if (indexer++ >= MaxCacheItemsForObject) break;
                AddInternal(template);
            }
        }

        private void AddInternal(MessageTemplate template) {
            if (template == null) return;
            if (template.Text.Length > MaxLengthOfTemplateToBeCached) return;
            if (_preheatedMessageTemplates.Count >= MaxCacheItemsForObject) return;
            if (_preheatedMessageTemplates.ContainsKey(template.Text.GetHashCode())) return;
            _preheatedMessageTemplates[template.Text.GetHashCode()] = template;
        }

        private void AddInternal(IEnumerable<string> messageTemplates) {
            if (messageTemplates == null || !messageTemplates.Any()) return;
            var indexer = 0;
            foreach (var template in messageTemplates) {
                if (indexer++ >= MaxCacheItemsForString) break;
                AddInternal(template);
            }
        }

        private void AddInternal(string messageTemplate) {
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            if (messageTemplate.Length > MaxLengthOfTemplateToBeCached) return;
            if (_needToBePreheadedTemplates.Count > MaxCacheItemsForString) return;
            if (_needToBePreheadedTemplates.ContainsKey(messageTemplate.GetHashCode())) return;
            _needToBePreheadedTemplates.Add(messageTemplate.GetHashCode(), messageTemplate);
        }

        public void Add(string messageTemplate) {
            AddInternal(messageTemplate);
        }

        public void AddRange(IEnumerable<string> messageTemplates) {
            AddInternal(messageTemplates);
        }

        public void Add(MessageTemplate template) {
            AddInternal(template);
        }

        public void AddRange(IEnumerable<MessageTemplate> templates) {
            AddInternal(templates);
        }

        public void AddFromFile(string fileName, PreheaterFileTypes type) {
            if (!File.Exists(fileName)) return;
            using (var fs = new FileStream(fileName, FileMode.Open)) {
                switch (type) {
                    case PreheaterFileTypes.AsSerializeInstance: {
                        AddFromStream(fs);
                        break;
                    }

                    case PreheaterFileTypes.AsText: {
                        using (var reader = new StreamReader(fs, Encoding.UTF8)) {
                            string buffer;
                            while ((buffer = reader.ReadLine()) != null) {
                                Add(buffer);
                            }
                        }

                        break;
                    }
                }
            }
        }

        public void AddFromStream(Stream stream) {
            try {
                var bf = new BinaryFormatter();
                if (bf.Deserialize(stream) is List<MessageTemplate> buffer) {
                    AddInternal(buffer);
                }
            }
            catch {
                InternalLogger.WriteLine("Throw exception when deserialize stream to List<MessageTemplate>.");
            }
        }
    }
}