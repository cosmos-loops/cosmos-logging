using System;

namespace Cosmos.Logging.Extensions.Exceptions.Core.Internals {
    internal class ReflectionPropertyInfo {
        public string Name { get; set; }

        public Type DeclaringType { get; set; }

        public Func<object, object> Getter { get; set; }
    }
}