using System;
using Cosmos.I18N.Core;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.Adapters.Json {
    public static class JsonFormattingAdapterExtensions {
        public static II18NServiceCollection AddJsonResourceFrom(this II18NServiceCollection services, string path) {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));

            using (var adapter = new JsonFileAdapter(path)) {
                if (adapter.Process()) {
                    var speaker = adapter.Speak();
                    var language = speaker.Language;
                    services.ExposeOptions.AddResource(language, LanguageResourceFactory.Create(speaker));
                }
            }

            return services;
        }

        public static II18NServiceCollection AddJsonResource(this II18NServiceCollection services, string originContext) {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (string.IsNullOrWhiteSpace(originContext)) throw new ArgumentNullException(nameof(originContext));

            using (var adapter = new JsonContentAdapter(originContext)) {
                if (adapter.Process()) {
                    var speaker = adapter.Speak();
                    var language = speaker.Language;
                    services.ExposeOptions.AddResource(language, LanguageResourceFactory.Create(speaker));
                }
            }

            return services;
        }
    }
}