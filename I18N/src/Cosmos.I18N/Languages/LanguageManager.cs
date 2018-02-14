using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Cosmos.I18N.Languages {
    public class LanguageManager {
        private readonly IList<ILanguage> _languages = new List<ILanguage>();

        public LanguageManager() { }

        public bool Contains(string langName) {
            if (string.IsNullOrWhiteSpace(langName)) return false;
            return _languages.Any(x => x.Name == langName);
        }

        public bool Contains(ILanguage language) {
            if (language == null) return false;
            return _languages.Any(x => x.Name == language.Name);
        }

        public ILanguage GetLanguage(string langName) {
            if (string.IsNullOrWhiteSpace(langName)) return default(ILanguage);
            return _languages.FirstOrDefault(l => l.Name == langName);
        }

        public ILanguage GetCurrentCultureLanguage() {
            var cluture = CultureInfo.CurrentCulture;
            return _languages.FirstOrDefault(l => l.Name == cluture.Name);
        }

        public ILanguage GetFirstLanguage() {
            return _languages.FirstOrDefault();
        }

        public void RegisterUsedLangage(ILanguage language) {
            if (language == null) throw new ArgumentNullException(nameof(language));
            if (_languages.Any(x => x.Name == language.Name)) return;
            _languages.Add(language);
        }
    }
}