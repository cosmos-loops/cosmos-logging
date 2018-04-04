using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Verba.Boolean {
    /// <summary>
    /// Global boolean verba manager
    /// </summary>
    public static class GlobalBooleanVerbaManager {
        private static readonly ConcurrentDictionary<string, IBooleanVerba> m_booleanVerbaDict;

        private static readonly object m_lockObject;
        private static readonly object m_trueCacheLockObject;
        private static readonly object m_falseCacheLockObject;

        private static readonly List<string> m_trueVerbaCache;
        private static readonly List<string> m_falseVerbaCache;

        static GlobalBooleanVerbaManager() {
            m_booleanVerbaDict = new ConcurrentDictionary<string, IBooleanVerba>();

            m_lockObject = new object();
            m_trueCacheLockObject = new object();
            m_falseCacheLockObject = new object();

            m_trueVerbaCache = new List<string>();
            m_falseVerbaCache = new List<string>();

            AddBooleanVerba(DefaultBooleanVerba.Instance);
        }

        /// <summary>
        /// Add boolean verba into <see cref="GlobalBooleanVerbaManager"/>
        /// </summary>
        /// <param name="verba"></param>
        public static void AddBooleanVerba(IBooleanVerba verba) {
            if (verba == null) {
                throw new ArgumentNullException(nameof(verba));
            }

            if (!m_booleanVerbaDict.ContainsKey(verba.VerbaName)) {
                lock (m_lockObject) {
                    if (!m_booleanVerbaDict.ContainsKey(verba.VerbaName) && m_booleanVerbaDict.TryAdd(verba.VerbaName, verba)) {
                        RefreshTrueVerbaCache();
                        RefreshFalseVerbaCache();
                    }
                }
            }
        }

        private static void RefreshTrueVerbaCache() {
            lock (m_trueCacheLockObject) {
                m_trueVerbaCache.Clear();
                m_trueVerbaCache.AddRange(m_booleanVerbaDict.Values.SelectMany(x => x.TrueVerbaList).Distinct().ToList());
            }
        }

        private static void RefreshFalseVerbaCache() {
            lock (m_falseCacheLockObject) {
                m_falseVerbaCache.Clear();
                m_falseVerbaCache.AddRange(m_booleanVerbaDict.Values.SelectMany(x => x.FalseVerbaList).Distinct().ToList());
            }
        }

        /// <summary>
        /// To determine the alas value is true, false or null.
        /// </summary>
        /// <param name="verbaAlias"></param>
        /// <returns></returns>
        public static bool? Determining(string verbaAlias) {
            if (string.IsNullOrWhiteSpace(verbaAlias)) {
                return null;
            }

            var verba = verbaAlias.Trim().ToLower();

            if (m_falseVerbaCache.Contains(verba)) {
                return false;
            }

            if (m_trueVerbaCache.Contains(verba)) {
                return true;
            }

            return null;
        }
    }
}