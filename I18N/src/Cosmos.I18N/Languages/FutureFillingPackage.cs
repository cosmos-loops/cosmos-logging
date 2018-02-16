using System;
using System.Collections.Generic;

namespace Cosmos.I18N.Languages {
    public sealed class FutureFillingPackage : ILanguagePackage {
        private readonly Dictionary<string, ILanguageResource> _resources = new Dictionary<string, ILanguageResource>();
        private readonly object _lock = new object();

        public FutureFillingPackage(string language) {
            if (string.IsNullOrWhiteSpace(language)) throw new ArgumentNullException(nameof(language));
            Language = language.ToLocale();
        }

        public FutureFillingPackage(Locale locale) {
            Language = locale;
        }

        public Locale Language { get; }

        public IReadOnlyDictionary<string, ILanguageResource> Resources => _resources;

        public void AddResource(ILanguageResource resource) {
            if (resource == null) return;
            lock (_lock) {
                if (_resources.ContainsKey(resource.Name)) return;
                _resources.Add(resource.Name, resource);
            }
        }

        public bool CanTranslate(string resourceKey, string text) {
            if (string.IsNullOrWhiteSpace(resourceKey) || string.IsNullOrWhiteSpace(text)) return false;
            return _resources.TryGetValue(resourceKey, out var resource) && resource.CanTranslate(text);
        }

        public string Translate(string resourceKey, string text) {
            return _resources.TryGetValue(resourceKey, out var resource) ? resource.Translate(text) : string.Empty;
        }

        #region dispose

        private bool _disposed;

        public void Dispose() {
            if (_disposed) return;

            _resources.Clear();

            _disposed = true;
        }

        #endregion

    }
}