using System;

namespace Cosmos.Domain.EntityDescriptors
{
    /// <summary>
    /// To flag that this entity include created time.
    /// </summary>
    public interface ICreatedTime
    {
        DateTime CreatedTime { get; set; }
    }
}