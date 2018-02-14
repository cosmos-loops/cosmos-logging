using System;
using System.Linq;
using Cosmos.I18N.Templates;

namespace Cosmos.I18N.Languages {
    public static class LanguageResourceFactory {
        public static LanguageResource Create(StandardLocalizationTemplate template, LanguageManager languageManager) =>
            Create<StandardLocalizationTemplate>(template, languageManager);

        public static LanguageResource Create<TTemplate>(TTemplate template, LanguageManager languageManager)
            where TTemplate : StandardLocalizationTemplate, ILocalizationTemplate, new() {
            if (template == null) throw new ArgumentNullException(nameof(template));
            if (languageManager == null) throw new ArgumentNullException(nameof(languageManager));
            return Create(template, languageManager.GetLanguage(template.Language));
        }

        public static LanguageResource Create(StandardLocalizationTemplate template, ILanguage language) =>
            Create<StandardLocalizationTemplate>(template, language);

        public static LanguageResource Create<TTemplate>(TTemplate template, ILanguage language)
            where TTemplate : StandardLocalizationTemplate, ILocalizationTemplate, new() {
            if (template == null) throw new ArgumentNullException(nameof(template));
            if (language == null) throw new ArgumentNullException(nameof(language));
            return new LanguageResource(template.Name, template.Contents.ToDictionary(k => k.Key.GetHashCode(), v => v.Value)) {BindingLanguage = language};
        }
    }
}