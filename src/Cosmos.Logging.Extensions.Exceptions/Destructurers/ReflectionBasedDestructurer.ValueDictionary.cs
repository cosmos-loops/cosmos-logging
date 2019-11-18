using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Extensions.Exceptions.Core.Internals;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers
{
    public partial class ReflectionBasedDestructurer
    {
        private object DestructureValueDictionary(
            IDictionary value,
            int level,
            IDictionary<object, IDictionary<string, object>> destructuredObjects,
            ref int nextCycleRefId)
        {
            if (destructuredObjects.ContainsKey(value))
            {
                var destructureObj = destructuredObjects[value];
                var refId = GetOrCreateRefId(ref nextCycleRefId, destructureObj);

                return new Dictionary<string, object> {{REF_LABEL, refId}};
            }

            var destructureDictionary = value.MapToStrObjDictionary();

            destructuredObjects.Add(value, destructureDictionary);

            foreach (var pair in destructureDictionary.ToDictionary(k => k.Key, v => v.Value))
            {
                destructureDictionary[pair.Key] = DestructureValue(value, level + 1, destructuredObjects, ref nextCycleRefId);
            }

            return destructureDictionary;
        }
    }
}