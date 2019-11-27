using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Core
{
    internal static class ArgsHelper
    {
        public static object[] CleanUp(object[] messageTemplateParameters)
        {
            if (messageTemplateParameters == null)
                return null;

            var ret = new List<object>();
            var lazy = new List<object>();

            foreach (var parameter in messageTemplateParameters)
            {
                if (parameter is Args args)
                {
                    var realArgs = CleanUp((object[]) args);

                    if (realArgs.Length == 0)
                        continue;

                    if (realArgs.Length == 1)
                    {
                        ret.Add(realArgs[0]);
                    }
                    else
                    {
                        ret.Add(realArgs[0]);
                        
                        for (var i = 1; i < realArgs.Length; i++)
                            lazy.Add(realArgs[i]);
                    }
                }
                else
                {
                    ret.Add(parameter);
                }
            }

            return ret.Concat(lazy).ToArray();
        }
    }
}