namespace Cosmos.Domain {
    public interface IChangeTrackable<in TObject> where TObject : IDomainObject {
        ChangedValueDescriptorCollection GetChanges(TObject otherObj);
    }
}