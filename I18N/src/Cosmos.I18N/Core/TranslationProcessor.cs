using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.Core {
    public class TranslationProcessor {
        private readonly Dictionary<string, ILanguagePackage> _languagePackages;

        public TranslationProcessor(Dictionary<string, ILanguagePackage> dictionary) {
            _languagePackages = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
        }

        public virtual string Translate(string resourceKey, string originText) {
            var cluture = CultureInfo.CurrentCulture;
            return Translate(cluture.Name, resourceKey, originText);
        }

        public virtual string Translate(string langName, string resourceKey, string originText) {
            return _languagePackages.TryGetValue(langName, out var __pkg) ? __pkg.Translate(resourceKey, originText) : string.Empty;
        }

        public virtual string Translate(ILanguage language, string resourceKey, string originText) {
            return Translate(language.Name, resourceKey, originText);
        }
    }
}