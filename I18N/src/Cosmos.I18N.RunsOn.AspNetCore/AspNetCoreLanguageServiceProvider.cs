using System;
using System.Collections.Generic;
using Cosmos.I18N.Core;
using Cosmos.I18N.Languages;
using EnumsNET;

namespace Cosmos.I18N.RunsOn.AspNetCore {
    public class AspNetCoreLanguageServiceProvider : ILanguageServiceProvider {
        private readonly LanguageManager _languageManager;
        private readonly TranslationProcessor _translationProcessor;
        private readonly Dictionary<int, ILanguagePackage> _languagePackages = new Dictionary<int, ILanguagePackage>();
        private readonly List<Locale> _languages = new List<Locale>();

        public AspNetCoreLanguageServiceProvider(LanguageManager manager, TranslationProcessor processor, IEnumerable<ILanguagePackage> languagePackages) {
            _languageManager = manager ?? throw new ArgumentNullException(nameof(manager));
            _translationProcessor = processor ?? throw new ArgumentNullException(nameof(processor));
            foreach (var package in languagePackages) {
                if (_languages.Contains(package.Language)) continue;
                _languages.Add(package.Language);
                _languagePackages.Add(package.Language.GetHashCode(), package);
            }
        }

        public ILanguagePackage GetLanguagePackage(string langName) {
            return _languagePackages.TryGetValue(langName.GetHashCode(), out var ret) ? ret : null;
        }

        public ILanguagePackage GetLanguagePackage(Locale language) {
            return _languagePackages.TryGetValue(language.GetName().GetHashCode(), out var ret) ? ret : null;
        }

        public LanguageManager GetLanguageManager() => _languageManager;

        public TranslationProcessor GetTranslationProcessor() => _translationProcessor;
    }
}