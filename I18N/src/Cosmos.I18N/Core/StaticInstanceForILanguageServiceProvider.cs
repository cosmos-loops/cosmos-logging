using System;

namespace Cosmos.I18N.Core {
    public static class StaticInstanceForILanguageServiceProvider {
        private static ILanguageServiceProvider _instance { get; set; }

        public static void SetInstance(ILanguageServiceProvider languageServiceProvider) {
            _instance = languageServiceProvider ?? throw new ArgumentNullException(nameof(languageServiceProvider));
        }

        public static ILanguageServiceProvider Instance => _instance;
    }
}