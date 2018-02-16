using System;
using System.Collections.Generic;

namespace Cosmos.I18N.Languages {
    public class LanguageResource : ILanguageResource {
        private readonly Dictionary<int, string> _l;
        private readonly object _l_lock = new object();

        public LanguageResource(Locale locale, string resourceKey) : this(locale, resourceKey, new Dictionary<int, string>()) { }

        public LanguageResource(Locale locale, string resourceKey, Dictionary<int, string> dictionary) {
            if (string.IsNullOrWhiteSpace(resourceKey)) throw new ArgumentNullException(nameof(resourceKey));
            BindingTo = locale;
            Name = resourceKey;
            _l = dictionary;
        }

        public Locale BindingTo { get; set; }

        public string Name { get; }

        public string ResourceKey => Name;

        #region internal dictionary opts

        protected internal void Add(string referenceKey, string targetValue) {
            lock (_l_lock) {
                var k = referenceKey.GetHashCode();
                if (_l.ContainsKey(k)) {
                    _l[k] = targetValue;
                } else {
                    _l.Add(k, targetValue);
                }
            }
        }

        protected internal void Remove(string referenceKey) {
            lock (_l_lock) {
                var k = referenceKey.GetHashCode();
                if (_l.ContainsKey(k))
                    _l.Remove(k);
            }
        }

        #endregion

        public bool CanTranslate(string referenceKey) {
            return _l.ContainsKey(referenceKey.GetHashCode());
        }

        public string Translate(string referenceKey) {
            return _l.TryGetValue(referenceKey.GetHashCode(), out var targetValue) ? targetValue : string.Empty;
        }
    }
}