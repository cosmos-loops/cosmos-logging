namespace Cosmos.Data.Abstractions {
    public interface IDbEntity { }

    public interface IDbEntity<TPrimaryKey> : IDbEntity {
        TPrimaryKey Id { get; set; }
    }
}