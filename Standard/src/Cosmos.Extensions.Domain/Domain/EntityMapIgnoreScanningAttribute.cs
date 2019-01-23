using System;

namespace Cosmos.Domain
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityMapIgnoreScanningAttribute : Attribute { }
}