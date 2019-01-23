namespace Cosmos.Domain.EntityDescriptors
{
    /// <summary>
    /// To flag this entity can be mark as deleted.
    /// </summary>
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}