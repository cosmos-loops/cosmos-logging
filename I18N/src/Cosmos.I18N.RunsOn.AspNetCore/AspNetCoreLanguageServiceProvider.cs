using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.I18N.Core;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.RunsOn.AspNetCore {
    public class AspNetCoreLanguageServiceProvider : ILanguageServiceProvider {
        private readonly LanguageManager _languageManager;
        private readonly TranslationProcessor _translationProcessor;
        private readonly Dictionary<int, ILanguagePackage> _languagePackages = new Dictionary<int, ILanguagePackage>();
        private readonly List<ILanguage> _languages = new List<ILanguage>();

        public AspNetCoreLanguageServiceProvider(LanguageManager manager, TranslationProcessor processor, IEnumerable<ILanguagePackage> languagePackages) {
            _languageManager = manager ?? throw new ArgumentNullException(nameof(manager));
            _translationProcessor = processor ?? throw new ArgumentNullException(nameof(processor));
            foreach (var package in languagePackages) {
                if (_languages.Any(x => x.Name == package.Language.Name)) continue;
                _languages.Add(package.Language);
                _languagePackages.Add(package.Language.Name.GetHashCode(), package);
            }
        }

        public ILanguagePackage GetLanguagePackage(string langName) {
            return _languagePackages.TryGetValue(langName.GetHashCode(), out var ret) ? ret : null;
        }

        public ILanguagePackage GetLanguagePackage(ILanguage language) {
            return _languagePackages.TryGetValue(language?.Name.GetHashCode() ?? 0, out var ret) ? ret : null;
        }

        public LanguageManager GetLanguageManager() => _languageManager;

        public TranslationProcessor GetTranslationProcessor() => _translationProcessor;
    }
}