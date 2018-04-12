namespace Cosmos.Domain {
    public interface IVersionable {
        byte[] Version { get; set; }
    }
}