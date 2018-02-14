using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Cosmos.I18N.Adapters.Formats;
using Cosmos.I18N.Templates;

namespace Cosmos.I18N.Adapters.Xml {
    public class XmlFileAdapter : IFileAdapter, ISpeakAsXml<StandardLocalizationTemplate>, IDisposable {
        public XmlFileAdapter(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            Path = path;
        }

        public string Path { get; private set; }

        public bool Process() {
            try {
                if (!File.Exists(Path)) throw new InvalidOperationException($"Failed to read file '{Path}'.");
                using (var reader = XmlReader.Create(Path)) {
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
            return SpeakCache ?? throw new InvalidOperationException($"Failed to read file '{Path}'.");
        }

        private bool _disposed;

        public void Dispose() {
            if (_disposed) return;

            Path = null;
            SpeakCache = null;

            _disposed = true;
        }
    }
}