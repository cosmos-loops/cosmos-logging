using System;
using EnumsNET;

namespace Cosmos.I18N.Languages {
    public static class LocaleExtensions {
        public static string ToLocaleString(this Locale locale) {
            return locale.GetName();
        }

        public static Locale ToLocale(this string lang) {
            if (string.IsNullOrWhiteSpace(lang)) throw new ArgumentNullException(nameof(lang));
            return Enums.GetMember<Locale>(lang, true).Value;
        }
    }
}