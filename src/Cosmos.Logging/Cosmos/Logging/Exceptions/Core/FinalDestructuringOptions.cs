using System.Collections.Generic;
using Cosmos.Logging.Exceptions.Configurations;
using Cosmos.Logging.Exceptions.Destructurers;
using Cosmos.Logging.Exceptions.Filters;

namespace Cosmos.Logging.Exceptions.Core {
    internal sealed class FinalDestructuringOptions : IDestructuringOptions {
        public FinalDestructuringOptions(ExceptionOptions options, ExceptionConfiguration configuration) {
            Name = DestructuringOptionsGetter.GetRealRootName(configuration, options);
            DestructureDepth = DestructuringOptionsGetter.GetRealDepth(configuration, options);
            Destructurers = options.Destructurers;
            Filter = options.ExceptionPropertyFilter;
        }

        public string Name { get; }
        public int DestructureDepth { get; }
        public IEnumerable<IExceptionDestructurer> Destructurers { get; }
        public IExceptionPropertyFilter Filter { get; }

        public static FinalDestructuringOptions Create(ExceptionOptions options, ExceptionConfiguration configuration)
            => new FinalDestructuringOptions(options, configuration);

        public static FinalDestructuringOptions Current { get; set; }
    }
}