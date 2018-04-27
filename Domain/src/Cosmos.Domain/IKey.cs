namespace Cosmos.Domain {
    public interface IKey<out TKey> {
        TKey Id { get; }
    }
}