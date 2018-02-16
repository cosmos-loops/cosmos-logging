using System;
using System.IO;
using System.Threading.Tasks;
using Cosmos.I18N.Adapters.Formats;
using Cosmos.I18N.Templates;
using Newtonsoft.Json;

namespace Cosmos.I18N.Adapters.Json {
    public class JsonFileAdapter : IFileAdapter, ISpeakAsJson<StandardLocalizationTemplate>, IDisposable {
        public JsonFileAdapter(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            Path = path;
        }

        public string Path { get; private set; }

        public bool Process() {
            try {
                if (!File.Exists(Path)) throw new InvalidOperationException($"Failed to read file '{Path}'.");
                var text = File.ReadAllText(Path);
                SpeakCache = JsonConvert.DeserializeObject<StandardLocalizationTemplate>(text);
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