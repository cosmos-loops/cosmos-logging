using System;
using System.IO;
using Cosmos.I18N.Adapters.Json.Internals;
using Cosmos.I18N.Core;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.Adapters.Json {
    public static class JsonFormattingAdapterExtensions {
        public static II18NServiceCollection AddJsonResourceFrom(this II18NServiceCollection services, string path, bool referenceToBasePath = true) {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));

            if (PathHelper.IsSeveralPath(path)) {
                foreach (var file in PathHelper.GetSeveralPathList(services.ExposeOptions, path)) {
                    AddJsonResourceFromOnce(services, file, false);
                }

                return services;
            }

            return AddJsonResourceFromOnce(services, path, referenceToBasePath);
        }

        private static II18NServiceCollection AddJsonResourceFromOnce(II18NServiceCollection services, string path, bool referenceToBasePath) {
            try {
                using (var adapter = new JsonFileAdapter(PathHelper.Combine(services.ExposeOptions, path, referenceToBasePath))) {
                    if (adapter.Process()) {
                        var speaker = adapter.Speak();
                        var language = speaker.Language;
                        services.ExposeOptions.AddResource(language, LanguageResourceFactory.Create(speaker));
                    }
                }
            }
            catch (Exception exception) {
                InternalLogger.WriteLine($"Thrown exception when add xml resource from {path}, message: {0}", exception.Message);
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