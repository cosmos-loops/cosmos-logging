using System;
using System.Linq;
using Cosmos.I18N.Templates;

namespace Cosmos.I18N.Languages {
    public static class LanguageResourceFactory {
        public static LanguageResource Create(StandardLocalizationTemplate template) => Create<StandardLocalizationTemplate>(template);

        public static LanguageResource Create<TTemplate>(TTemplate template) where TTemplate : StandardLocalizationTemplate, ILocalizationTemplate, new() {
            if (template == null) throw new ArgumentNullException(nameof(template));
            if (string.IsNullOrWhiteSpace(template.Name)) throw new ArgumentNullException(nameof(template.Name));
            return new LanguageResource(template.Language, template.Name, template.Contents.ToDictionary(k => k.Key.GetHashCode(), v => v.Value));
        }
    }
}