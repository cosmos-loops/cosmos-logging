using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Cosmos.I18N.Adapters.Formats;
using Cosmos.I18N.Templates;

namespace Cosmos.I18N.Adapters.Xml {
    public class XmlContentAdapter : IContentAdapter<string>, ISpeakAsXml<StandardLocalizationTemplate>, IDisposable {
        public XmlContentAdapter(string content) {
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
            OriginContent = content;
        }

        public string OriginContent { get; private set; }

        public bool Process() {
            try {
                using (var reader = new StringReader(OriginContent)) {
                    var xs = new XmlSerializer(typeof(StandardLocalizationTemplate));
                    SpeakCache = (StandardLocalizationTemplate) xs.Deserialize(reader);
                }
            }
            catch {
                return false;
            }

            return true;
        }

        public Task<bool> ProcessAsync() {
            return Task.FromResult(Process());
        }

        private StandardLocalizationTemplate SpeakCache { get; set; }

        public StandardLocalizationTemplate Speak() {
            return SpeakCache ?? throw new InvalidOperationException("Failed to deserialize origin context.");
        }


        private bool _disposed;

        public void Dispose() {
            if (_disposed) return;

            OriginContent = null;
            SpeakCache = null;

            _disposed = true;
        }
    }
}