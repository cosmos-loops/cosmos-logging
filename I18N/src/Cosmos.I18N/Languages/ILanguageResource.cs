namespace Cosmos.I18N.Languages {
    public interface ILanguageResource {
        Locale BindingTo { get; set; }
        string Name { get; }
        bool CanTranslate(string referenceKey);
        string Translate(string referenceKey);
    }
}