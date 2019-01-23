namespace Cosmos.Domain.EntityDescriptors
{
    /// <summary>
    /// To flag this entity include Id property
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IKey<out TKey>
    {
        TKey Id { get; }
    }
}