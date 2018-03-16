using System;
using Cosmos.I18N.Core;
using Cosmos.I18N.Core.Extensions;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N {
    public struct Text : IEquatable<Text> {
        private Locale Language { get; set; }
        private string ResourceKey { get; set; }
        private string OriginText { get; set; }
        private object[] FormatingParameters { get; set; }

        public Text(string text, string resourceKey, Locale language) : this(text, resourceKey, language, null) { }

        public Text(string text, string resourceKey, Locale language, params object[] parameters) {
            Language = language;
            ResourceKey = resourceKey;
            OriginText = text;
            FormatingParameters = parameters;
        }

        public static implicit operator string(Text t) => t.ToString();

        public override string ToString() {
            var processor = StaticInstanceForILanguageServiceProvider.Instance.GetTranslationProcessor();
            var text = processor.Translate(Language, ResourceKey, OriginText);
            if (FormatingParameters != null) {
                text = string.Format(text, FormatingParameters);
            }

            return text;
        }

        public int TextHashCode() => OriginText.GetHashCode();

        public bool Equals(Text other) {
            return Language == other.Language &&
                   ResourceKey == other.ResourceKey &&
                   OriginText == other.OriginText &&
                   FormatingParameters.EqualsSupportsNull(other.FormatingParameters);
        }
    }
}