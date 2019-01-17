using System;
using System.Collections.Generic;

namespace Cosmos
{
    public abstract class InstanceScanner<TClass> : TypeScanner
    {
        protected InstanceScanner() : base() { }

        protected InstanceScanner(string scannerName) : base(scannerName) { }

        protected InstanceScanner(Type baseType) : base(baseType) { }

        protected InstanceScanner(string scannerName, Type baseType) : base(scannerName, baseType) { }

        public virtual IEnumerable<TClass> ScanAndReturnInstances()
        {
            foreach (var type in Scan())
            {
                yield return type.CreateInstance<TClass>();
            }
        }
    }
}