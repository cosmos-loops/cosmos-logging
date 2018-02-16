using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.Configurations {
    public class I18NOptions {
        private readonly Dictionary<Locale, ILanguagePackage> __languagePackages = new Dictionary<Locale, ILanguagePackage>();
        private readonly List<Locale> __languageList = new List<Locale>();
        private readonly object __lock_package = new object();
        private readonly object __lock_resource = new object();
        private readonly object __lock2 = new object();

        #region Add package

        public I18NOptions AddPackage(Func<ILanguagePackage> packageProvider) {
            return AddPackage(packageProvider());
        }

        public I18NOptions AddPackage(ILanguagePackage package) {
            if (package == null) throw new ArgumentNullException(nameof(package));
            lock (__lock_package) {
                if (TryRegisterLanguageOnce(package.Language)) {
                    AddPackageInternal(package);
                } else if (__languagePackages.TryGetValue(package.Language, out var pkg) && pkg.IsFuture()) {
                    __languagePackages[package.Language] = package.Merge(__languagePackages[package.Language]);
                } else {
                    throw new ArgumentException($"Language package '{package.Language}' has been added.");
                }
            }

            return this;
        }

        private void AddPackageInternal(ILanguagePackage package) {
            __languagePackages.Add(package.Language, package);
        }

        #endregion

        #region Add resource

        public I18NOptions AddResource(Locale language, Func<ILanguageResource> resourceProvider) {
            return AddResource(language, resourceProvider());
        }

        public I18NOptions AddResource(Locale language, ILanguageResource resource) {
            if (resource == null) throw new ArgumentNullException(nameof(resource));
            lock (__lock_resource) {
                if (TryRegisterLanguageOnce(language)) {
                    var future = new FutureFillingPackage(language);
                    future.AddResource(resource);
                    AddPackageInternal(future);
                } else if (__languagePackages.TryGetValue(language, out var package)) {
                    package.AddResource(resource);
                } else {
                    throw new InvalidOperationException($"Something broken when add new resource '{resource.Name}'.");
                }
            }

            return this;
        }

        #endregion

        #region Expose readonly properties

        public IReadOnlyDictionary<Locale, ILanguagePackage> LanguagePackages => __languagePackages;

        public IReadOnlyList<Locale> RegisteredLanguages => __languageList;

        #endregion

        private bool TryRegisterLanguageOnce(Locale lang) {
            bool ret = false;
            if (!__languageList.Contains(lang)) {
                lock (__lock2) {
                    if (!__languageList.Contains(lang)) {
                        __languageList.Add(lang);
                        ret = true;
                    }
                }
            }

            return ret;
        }
    }
}