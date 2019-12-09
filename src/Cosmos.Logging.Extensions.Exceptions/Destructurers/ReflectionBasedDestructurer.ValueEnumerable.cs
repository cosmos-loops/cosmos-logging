using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    public partial class ReflectionBasedDestructurer {
        private object DestructureValueEnumerable(
            IEnumerable value,
            int level,
            IDictionary<object, IDictionary<string, object>> destructuredObjects,
            ref int nextCyclicRefId) {
            if (destructuredObjects.ContainsKey(value)) {
                return new Dictionary<string, object> {{REF_LABEL, CYCLIC_REF_MSG}};
            }

            destructuredObjects.Add(value, new Dictionary<string, object>());

            var destructureList = new List<object>();

            foreach (var o in value.Cast<object>())
                destructureList.Add(DestructureValue(o, level + 1, destructuredObjects, ref nextCyclicRefId));

            return destructureList;
        }
    }
}