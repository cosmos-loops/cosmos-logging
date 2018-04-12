namespace Cosmos.Domain {
    public interface IDeletable {
        bool IsDeleted { get; set; }
    }
}