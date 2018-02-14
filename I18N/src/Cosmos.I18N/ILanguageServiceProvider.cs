using Cosmos.I18N.Core;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N {
    public interface ILanguageServiceProvider {
        ILanguagePackage GetLanguagePackage(string langName);
        ILanguagePackage GetLanguagePackage(ILanguage language);
        LanguageManager GetLanguageManager();
        TranslationProcessor GetTranslationProcessor();
    }
}