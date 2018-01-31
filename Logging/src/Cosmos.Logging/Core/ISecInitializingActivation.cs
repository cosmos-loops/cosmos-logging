using System;

namespace Cosmos.Logging.Core {
    public interface ISecInitializingActivation {
        Action GetSecProcessing();
    }
}