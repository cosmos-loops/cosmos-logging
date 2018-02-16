using System.Collections.Generic;
using Cosmos.I18N.Languages;

namespace Cosmos.I18N.Templates {
    public class StandardLocalizationTemplate : ILocalizationTemplate {
        public Locale Language { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Contents { get; set; } = new Dictionary<string, string>();
    }
}