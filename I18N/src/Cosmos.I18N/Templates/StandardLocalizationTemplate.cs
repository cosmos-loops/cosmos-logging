using System.Collections.Generic;

namespace Cosmos.I18N.Templates {
    public class StandardLocalizationTemplate : ILocalizationTemplate {
        public string Language { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Contents { get; set; } = new Dictionary<string, string>();
    }
}