using System;
using System.Collections.Generic;

namespace Cosmos.I18N.Languages {
    public sealed class FutureFillingPackage : ILanguagePackage {
        private readonly Dictionary<string, ILanguageResource> _resources = new Dictionary<string, ILanguageResource>();
        private readonly object _lock = new object();

        public FutureFillingPackage(ILanguage language) {
            Language = language ?? throw new ArgumentNullException(nameof(language));
        }

        public ILanguage Language { get; }

        public IReadOnlyDictionary<string, ILanguageResource> Resources => _resources;

        public void AddResource(ILanguageResource resource) {
            if (resource == null) return;
            lock (_lock) {
                if (_resources.ContainsKey(resource.Name)) return;
                _resources.Add(resource.Name, resource);
            }
        }
        
        public bool CanTranslate(string resourceKey, string text) => false;

        public string Translate(string resourceKey, string text) => string.Empty;

        private bool _disposed;

        public void Dispose() {
            if (_disposed) return;

            _resources.Clear();

            _disposed = true;
        }
    }
}