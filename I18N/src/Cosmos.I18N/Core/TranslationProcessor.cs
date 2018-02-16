using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.Core {
    public class TranslationProcessor {
        private readonly Dictionary<Locale, ILanguagePackage> _languagePackages;

        public TranslationProcessor(Dictionary<Locale, ILanguagePackage> dictionary) {
            _languagePackages = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
        }

        public virtual string Translate(string resourceKey, string originText) {
            var cluture = CultureInfo.CurrentCulture;
            return Translate(cluture.Name, resourceKey, originText);
        }

        public virtual string Translate(string langName, string resourceKey, string originText) {
            return Translate(langName.ToLocale(), resourceKey, originText);
        }

        public virtual string Translate(Locale language, string resourceKey, string originText) {
            return _languagePackages.TryGetValue(language, out var __pkg) ? __pkg.Translate(resourceKey, originText) : string.Empty;
        }
    }
}