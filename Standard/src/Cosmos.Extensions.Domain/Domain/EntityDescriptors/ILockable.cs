namespace Cosmos.Domain.EntityDescriptors
{
    /// <summary>
    /// To flag this entity can be locked.
    /// </summary>
    public interface ILockable
    {
        bool IsLocaked { get; set; }
    }
}