using System;
using System.Collections.Generic;

namespace Cosmos.I18N.Languages {
    public interface ILanguagePackage : IDisposable {
        ILanguage Language { get; }
        IReadOnlyDictionary<string, ILanguageResource> Resources { get; }
        void AddResource(ILanguageResource resource);
        bool CanTranslate(string resourceKey, string text);
        string Translate(string resourceKey, string text);
    }
}