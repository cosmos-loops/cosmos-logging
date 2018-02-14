using Cosmos.I18N.Languages;

namespace Cosmos.I18N.LanguagePackages.ENUS {
    public abstract class LanguagePackageBase : LanguagePackage, IOperablePackage {
        protected LanguagePackageBase() : base(new en_US()) { }
    }
}