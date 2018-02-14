using System;
using System.Threading.Tasks;
using Cosmos.I18N.Adapters.Formats;
using Cosmos.I18N.Templates;
using Newtonsoft.Json;

namespace Cosmos.I18N.Adapters.Json {
    public class JsonContentAdapter : IContentAdapter<string>, ISpeakAsJson<StandardLocalizationTemplate>, IDisposable {
        public JsonContentAdapter(string content) {
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
            OriginContent = content;
        }

        public string OriginContent { get; private set; }

        public bool Process() {
            try {
                SpeakCache = JsonConvert.DeserializeObject<StandardLocalizationTemplate>(OriginContent);
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