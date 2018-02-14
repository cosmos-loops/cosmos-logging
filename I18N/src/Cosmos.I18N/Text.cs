using System;
using Cosmos.I18N.Core;
using Cosmos.I18N.Core.Extensions;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N {
    public struct Text : IEquatable<Text> {
        private ILanguage Language { get; set; }
        private string ResourceKey { get; set; }
        private string OriginText { get; set; }
        private object[] FormatingParameters { get; set; }

        public Text(string text, string resourceKey) : this(text, resourceKey, null, null) { }

        public Text(string text, string resourceKey, ILanguage language) : this(text, resourceKey, language, null) { }

        public Text(string text, string resourceKey, ILanguage language, params object[] parameters) {
            Language = language ?? DefaultLanguage();
            ResourceKey = resourceKey;
            OriginText = text;
            FormatingParameters = parameters;

            ILanguage DefaultLanguage() {
                var manager = StaticInstanceForILanguageServiceProvider.Instance.GetLanguageManager();
                return manager.GetCurrentCultureLanguage();
            }
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
            return Language.Name == other.Language.Name &&
                   ResourceKey == other.ResourceKey &&
                   OriginText == other.OriginText &&
                   FormatingParameters.EqualsSupportsNull(other.FormatingParameters);
        }
    }
}