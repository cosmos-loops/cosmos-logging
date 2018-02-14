using Cosmos.I18N.Languages;

namespace Cosmos.I18N.LanguagePackages.ZHTW {
    public abstract class LanguagePackageBase : LanguagePackage,IOperablePackage {
        protected LanguagePackageBase() : base(new zh_TW()) { }
    }
}