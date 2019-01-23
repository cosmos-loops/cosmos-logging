namespace Cosmos.Domain.EntityDescriptors
{
    public interface IVersionable
    {
        byte[] Version { get; set; }
    }
}