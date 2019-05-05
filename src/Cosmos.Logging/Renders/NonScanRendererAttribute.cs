using System;

namespace Cosmos.Logging.Renders {
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class NonScanRendererAttribute : Attribute { }
}