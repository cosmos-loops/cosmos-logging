using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Verba
{
    /// <summary>
    /// Global boolean verba manager
    /// </summary>
    public static class GlobalBooleanVerbaManager
    {
        private static IDictionary<string, IBooleanVerba> m_booleanVerbaDict { get; }
        private static object m_lockObject = new object();
        private static object m_trueCacheLockObject = new object();
        private static object m_falseCacheLockObject = new object();

        static GlobalBooleanVerbaManager()
        {
            m_booleanVerbaDict = new ConcurrentDictionary<string, IBooleanVerba>();

            AddBooleanVerba(DefaultBooleanVerba.Instance);
        }

        private static IList<string> m_trueVerbaCache { get; set; } = new List<string>();
        private static IList<string> m_falseVerbaCache { get; set; } = new List<string>();

        /// <summary>
        /// Add boolean verba into manager
        /// </summary>
        /// <param name="verba"></param>
        public static void AddBooleanVerba(IBooleanVerba verba)
        {
            //todo check null

            if (!m_booleanVerbaDict.ContainsKey(verba.VerbaName))
            {
                lock (m_lockObject)
                {
                    if (!m_booleanVerbaDict.ContainsKey(verba.VerbaName))
                    {
                        m_booleanVerbaDict.Add(verba.VerbaName, verba);

                        RefreshTrueVerbaCache();
                        RefreshFalseVerbaCache();
                    }
                }
            }
        }

        private static void RefreshTrueVerbaCache()
        {
            lock (m_trueCacheLockObject)
            {
                m_trueVerbaCache.Clear();
                m_trueVerbaCache = m_booleanVerbaDict.Values.SelectMany(x => x.TrueVerbaList).Distinct().ToList();
            }
        }

        private static void RefreshFalseVerbaCache()
        {
            lock (m_falseCacheLockObject)
            {
                m_falseVerbaCache.Clear();
                m_falseVerbaCache = m_booleanVerbaDict.Values.SelectMany(x => x.FalseVerbaList).Distinct().ToList();
            }
        }

        /// <summary>
        /// To determine the alas value is true, false or null.
        /// </summary>
        /// <param name="verbaAlias"></param>
        /// <returns></returns>
        public static bool? Determining(string verbaAlias)
        {
            if (string.IsNullOrWhiteSpace(verbaAlias))
                return null;

            var verba = verbaAlias.Trim().ToLower();

            if (m_falseVerbaCache.Contains(verba))
                return false;

            if (m_trueVerbaCache.Contains(verba))
                return true;

            return null;
        }
    }
}
