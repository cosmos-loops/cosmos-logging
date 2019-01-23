using System;

namespace Cosmos.Domain.EntityDescriptors
{
    public interface IUpdatingAudited
    {
        DateTime? LastUpdatedTime { get; set; }

        string LastUpdatedOperatorId { get; set; }
    }
}