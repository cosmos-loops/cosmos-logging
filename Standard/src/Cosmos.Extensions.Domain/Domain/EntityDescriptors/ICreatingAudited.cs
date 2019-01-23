namespace Cosmos.Domain.EntityDescriptors
{
    public interface ICreatingAudited : ICreatedTime
    {
        string CreatedOperatorId { get; set; }
    }
}