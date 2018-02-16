using System;

namespace Cosmos.I18N.Languages {
    public static class FutureFillingPackageExtensions {
        public static bool IsFuture(this ILanguagePackage package) {
            return package is FutureFillingPackage;
        }

        public static TPackage Merge<TPackage>(this TPackage target, ILanguagePackage package) where TPackage : class, ILanguagePackage {
            if (package == null) throw new ArgumentNullException(nameof(package));
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!package.IsFuture()) throw new ArgumentException($"package '{package.Language.ToLocaleString()}' should be an instance of FutureFillingPackage.");

            foreach (var resource in package.Resources) {
                target.AddResource(resource.Value);
            }

            package.Dispose();

            return target;
        }
    }
}