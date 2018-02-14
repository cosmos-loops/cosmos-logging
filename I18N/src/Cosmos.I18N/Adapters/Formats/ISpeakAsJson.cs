using Cosmos.I18N.Templates;

namespace Cosmos.I18N.Adapters.Formats {
    public interface ISpeakAsJson<out TTemplate> where TTemplate : class, ILocalizationTemplate, new() {
        TTemplate Speak();
    }
}