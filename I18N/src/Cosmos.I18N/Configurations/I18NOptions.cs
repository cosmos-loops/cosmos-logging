using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.Configurations {
    public class I18NOptions {
        private readonly Dictionary<string, ILanguagePackage> __languagePackages = new Dictionary<string, ILanguagePackage>();
        private readonly List<ILanguage> __languageList = new List<ILanguage>();
        private readonly object __lock = new object();

        #region Add package

        public I18NOptions AddPackage(Func<ILanguagePackage> packageProvider) {
            return AddPackage(packageProvider());
        }

        public I18NOptions AddPackage(ILanguagePackage package) {
            if (package == null) throw new ArgumentNullException(nameof(package));
            lock (__lock) {
                var langName = package.Language.Name;
                if (__languageList.All(x => x.Name != langName)) {
                    __languageList.Add(package.Language);
                    __languagePackages.Add(package.Language.Name, package);
                } else if (__languagePackages.TryGetValue(langName, out var pkg) && pkg.IsFuture()) {
                    __languagePackages[langName] = package.Merge(__languagePackages[langName]);
                } else {
                    throw new ArgumentException($"Language package '{langName}' has been added.");
                }
            }

            return this;
        }

        #endregion

        #region Add resource

        public I18NOptions AddResource(ILanguage language, Func<ILanguageResource> resourceProvider) {
            return AddResource(language, resourceProvider());
        }

        public I18NOptions AddResource(ILanguage language, ILanguageResource resource) {
            if (language == null) throw new ArgumentNullException(nameof(language));
            if (resource == null) throw new ArgumentNullException(nameof(resource));
            lock (__lock) {
                if (__languageList.All(x => x.Name != language.Name)) {
                    var future = new FutureFillingPackage(language);
                    future.AddResource(resource);
                    AddPackage(future);
                } else if (__languagePackages.TryGetValue(language.Name, out var package)) {
                    package.AddResource(resource);
                } else {
                    throw new InvalidOperationException($"Something broken when add new resource '{resource.Name}'.");
                }
            }

            return this;
        }

        #endregion
        
        #region Expose readonly properties

        public IReadOnlyDictionary<string, ILanguagePackage> LanguagePackages => __languagePackages;

        public IReadOnlyList<ILanguage> RegisteredLanguages => __languageList;

        #endregion

    }
}