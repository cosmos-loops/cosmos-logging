using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EnumsNET;

namespace Cosmos.I18N.Languages {
    public class LanguageManager {
        private readonly IList<Locale> _usedLanguages = new List<Locale>();
        private readonly object _langObject = new object();

        public LanguageManager() { }

        #region Contains

        public bool Contains(string langName) {
            return !string.IsNullOrWhiteSpace(langName) && Contains(langName.ToLocale());
        }

        public bool Contains(Locale locale) {
            return _usedLanguages.Contains(locale);
        }

        #endregion

        #region Get language

        public Locale GetLanguage(string langName) {
            if (string.IsNullOrWhiteSpace(langName)) return GetCurrentCultureLanguage();
            if (!Contains(langName)) return GetCurrentCultureLanguage();
            return langName.ToLocale();
        }

        public Locale GetCurrentCultureLanguage() {
            return CultureInfo.CurrentCulture.Name.ToLocale();
        }

        #endregion

        #region Register used language

        public void RegisterUsedLangage(string lang) {
            if (string.IsNullOrWhiteSpace(lang)) throw new ArgumentNullException(nameof(lang));
            RegisterUsedLangage(lang.ToLocale());
        }

        public void RegisterUsedLangage(Locale locale) {
            lock (_langObject) {
                if (!Contains(locale)) {
                    _usedLanguages.Add(locale);
                }
            }
        }

        #endregion

        public override string ToString() {
            return string.Join(",", _usedLanguages.Select(x => x.GetName()));
        }
    }
}