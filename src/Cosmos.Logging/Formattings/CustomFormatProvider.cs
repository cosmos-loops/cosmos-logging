using System.Collections.Generic;

namespace Cosmos.Logging.Formattings
{
    public abstract class CustomFormatProvider
    {
        public abstract IEnumerable<FormatEvent> CreateCommandEvent(string format = null);
    }
}