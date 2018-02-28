using System.Collections.Generic;
using Cosmos.Logging.Sinks.File.Core;

namespace Cosmos.Logging.Sinks.File.OutputTemplates {
    public class OutputTemplate {
        private readonly string _originOutputTemplate;
        private readonly List<IOutputToken> _tokens;

        public OutputTemplate(string originOutputTemplate) {
            _originOutputTemplate = string.IsNullOrWhiteSpace(originOutputTemplate) ? Constants.DefaultOutputTemplate : originOutputTemplate;
            _tokens = new List<IOutputToken>();
        }

        public IReadOnlyList<IOutputToken> Tokens => _tokens;

        public string OriginTemplate => _originOutputTemplate;
    }
}