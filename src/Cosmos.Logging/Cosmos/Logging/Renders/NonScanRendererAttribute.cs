using System;

namespace Cosmos.Logging.Renders {
    /// <summary>
    /// Non scan renderer attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class NonScanRendererAttribute : Attribute { }
}