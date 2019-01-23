using System;

namespace Cosmos.Domain.EntityDescriptors
{
    /// <summary>
    /// To flag this entity will be expired, include start time and end time.
    /// </summary>
    public interface IExpireable
    {
        DateTime? ExpireLimitedFromTime { get; set; }

        DateTime? ExpireLimitedToTime { get; set; }

        bool IsStart();

        bool IsStart(DateTime targetTime);

        bool IsExpired();

        bool IsExpired(DateTime targetTime);

        bool IsActive();

        bool IsActive(DateTime targetTime);
    }
}