using System;
using System.Collections.Generic;
using Cosmos.Logging.Core.ObjectResolving;

namespace Cosmos.Logging.Configurations {
    public class DestructureConfiguration {
        public List<Type> AdditionalScalarTypes = new List<Type>();
        public List<IDestructureResolveRule> AdditionalDestructureResolveRules = new List<IDestructureResolveRule>();
        public int MaximumLengthOfString { get; set; } = int.MaxValue;
        public int MaximumLevelOfNestLevelLimited { get; set; } = 10;
        public int MaximumLoopCountForCollection { get; set; } = int.MaxValue;
    }
}