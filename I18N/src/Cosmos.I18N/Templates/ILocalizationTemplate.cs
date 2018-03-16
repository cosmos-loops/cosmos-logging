using System.Collections.Generic;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.Templates {
    public interface ILocalizationTemplate {
        Locale Language { get; set; }
        string Name { get; set; }
        Dictionary<string, string> Contents { get; set; }
    }
}