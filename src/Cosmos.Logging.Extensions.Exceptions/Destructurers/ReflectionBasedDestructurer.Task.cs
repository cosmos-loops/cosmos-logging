using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmos.Logging.Extensions.Exceptions.Destructurers {
    public partial class ReflectionBasedDestructurer {
        private object DestructureTask(Task value, int level, IDictionary<object, IDictionary<string, object>> destructuredObjects, ref int nextCyclicRefId) {
            if (destructuredObjects.TryGetValue(value, out var destructuredTask)) {
                var refId = GetOrCreateRefId(ref nextCyclicRefId, destructuredTask);

                return new SortedList<string, object> {{REF_LABEL, refId}};
            }

            var destructuredSortedList = new SortedList<string, object>();
            destructuredObjects.Add(value, destructuredSortedList);

            destructuredSortedList[nameof(Task.Id)]              = value.Id;
            destructuredSortedList[nameof(Task.Status)]          = value.Status.ToString("G");
            destructuredSortedList[nameof(Task.CreationOptions)] = value.CreationOptions.ToString("F");

            if (value.IsFaulted) {
                destructuredSortedList[nameof(Task.Exception)] = DestructureValue(value.Exception, level, destructuredObjects, ref nextCyclicRefId);
            }

            return destructuredSortedList;
        }
    }
}