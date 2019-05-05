using System;

namespace Cosmos.Logging.Core {
    public interface IAdditionalOperation {
        AdditionalOperationTypes Type { get; }
        Type Flag { get; }
        object GetOpt();
    }
}