using System;
using Cosmos.I18N.Core;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.Adapters.Xml {
    public static class XmlFormattingAdapterExtensions {
        public static II18NServiceCollection AddXmlResourceFrom(this II18NServiceCollection services, string path) {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));

            using (var adapter = new XmlFileAdapter(path)) {
                if (adapter.Process()) {
                    var speaker = adapter.Speak();
                    var language = services.ExposeLanguageManager.GetLanguage(speaker.Language);
                    services.ExposeOptions.AddResource(language, LanguageResourceFactory.Create(speaker, language));
                }
            }

            return services;
        }

        public static II18NServiceCollection AddXmlResource(this II18NServiceCollection services, string originContext) {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (string.IsNullOrWhiteSpace(originContext)) throw new ArgumentNullException(nameof(originContext));

            using (var adapter = new XmlContentAdapter(originContext)) {
                if (adapter.Process()) {
                    var speaker = adapter.Speak();
                    var language = services.ExposeLanguageManager.GetLanguage(speaker.Language);
                    services.ExposeOptions.AddResource(language, LanguageResourceFactory.Create(speaker, language));
                }
            }

            return services;
        }
    }
}