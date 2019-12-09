using System;
using System.Collections.Generic;
using Cosmos.Logging.Core.ObjectResolving;

namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Destructure configuration
    /// </summary>
    public class DestructureConfiguration {
        /// <summary>
        /// Additional scalar types
        /// </summary>
        public List<Type> AdditionalScalarTypes = new List<Type>();

        /// <summary>
        /// Additional destructure resolve rules
        /// </summary>
        public List<IDestructureResolveRule> AdditionalDestructureResolveRules = new List<IDestructureResolveRule>();

        /// <summary>
        /// Gets or sets maximum length of string, default is <c>int.MaxValue</c>.
        /// </summary>
        public int MaximumLengthOfString { get; set; } = int.MaxValue;

        /// <summary>
        /// Gets or sets maximum level of level-limited, default is <c>10</c>.
        /// </summary>
        public int MaximumLevelOfNestLevelLimited { get; set; } = 10;

        /// <summary>
        /// Gets or sets maximum loop count for collection, default is <c>int.MaxValue</c>.
        /// </summary>
        public int MaximumLoopCountForCollection { get; set; } = int.MaxValue;
    }
}