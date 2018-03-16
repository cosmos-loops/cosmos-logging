using System;
using System.Collections.Generic;
using Cosmos.I18N.Core;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.RunsOn.Console {
    public class ConsoleLanguageServiceProvider : ILanguageServiceProvider {

        private readonly LanguageManager _languageManager;
        private readonly TranslationProcessor _translationProcessor;
        private readonly Dictionary<Locale, ILanguagePackage> _languagePackages = new Dictionary<Locale, ILanguagePackage>();

        public ConsoleLanguageServiceProvider(LanguageManager manager, TranslationProcessor processor, IEnumerable<ILanguagePackage> languagePackages) {
            _languageManager = manager ?? throw new ArgumentNullException(nameof(manager));
            _translationProcessor = processor ?? throw new ArgumentNullException(nameof(processor));
            foreach (var package in languagePackages) {
                if (_languagePackages.ContainsKey(package.Language)) continue;
                _languagePackages.Add(package.Language, package);
            }
        }

        public ILanguagePackage GetLanguagePackage(string langName) {
            return GetLanguagePackage(langName.ToLocale());
        }

        public ILanguagePackage GetLanguagePackage(Locale language) {
            return _languagePackages.TryGetValue(language, out var ret) ? ret : null;
        }

        public LanguageManager GetLanguageManager() => _languageManager;

        public TranslationProcessor GetTranslationProcessor() => _translationProcessor;
    }
}