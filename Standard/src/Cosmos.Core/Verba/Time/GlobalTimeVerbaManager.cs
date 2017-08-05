using System;
using System.Collections.Concurrent;
using Cosmos.Abstractions.Verba;

namespace Cosmos.Verba.Time
{
    /// <summary>
    /// Global time verba manager
    /// </summary>
    public static class GlobalTimeVerbaManager
    {
        private static readonly ConcurrentDictionary<string, ITimeVerba> m_timeVerbaDict;
        private static readonly ConcurrentDictionary<string, string> m_languageKeyMapDict;
        private static string m_defaultLanguageKey;

        private static readonly object m_lockObject;
        private static readonly object m_languageKeyCacheLockObject;

        private static readonly ConcurrentDictionary<string, ITimeVerba> m_languageKeyVerbaCache;

        static GlobalTimeVerbaManager()
        {
            m_timeVerbaDict = new ConcurrentDictionary<string, ITimeVerba>();
            m_languageKeyMapDict = new ConcurrentDictionary<string, string>();

            m_lockObject = new object();
            m_languageKeyCacheLockObject = new object();

            m_languageKeyVerbaCache = new ConcurrentDictionary<string, ITimeVerba>();

            AddTimeVerba(DefaultSimplifiedChineseTimeVerba.Instance);
            AddTimeVerba(DefaultTraditionalChineseTimeVerba.Instance);
            AddTimeVerba(DefaultEnglishTimeVerba.Instance);

            DefaultLanguageKey = DefaultEnglishTimeVerba.USEnglish;
        }

        /// <summary>
        /// Add time verba into <see cref="GlobalTimeVerbaManager"/>
        /// </summary>
        /// <param name="verba"></param>
        public static void AddTimeVerba(ITimeVerba verba)
        {
            if (verba == null)
            {
                throw new ArgumentNullException(nameof(verba));
            }

            if (!m_timeVerbaDict.ContainsKey(verba.VerbaName))
            {
                lock (m_lockObject)
                {
                    if (!m_timeVerbaDict.ContainsKey(verba.VerbaName) && m_timeVerbaDict.TryAdd(verba.VerbaName, verba))
                    {
                        foreach (var key in verba.LanguageKeys)
                        {
                            m_languageKeyMapDict.TryAdd(key, verba.VerbaName);
                        }

                        RefreshLanguageKeyVerbaCache();
                    }
                }
            }
        }

        public static string DefaultLanguageKey
        {
            get => m_defaultLanguageKey;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }

                lock (m_languageKeyCacheLockObject)
                {
                    if (!m_languageKeyMapDict.ContainsKey(value))
                    {
                        return;
                    }

                    m_defaultLanguageKey = value;
                }
            }
        }

        public static string CurrentLanguageKey => DefaultLanguageKey;

        private static void RefreshLanguageKeyVerbaCache()
        {
            lock (m_languageKeyCacheLockObject)
            {
                var keys = m_languageKeyMapDict.Keys;
                m_languageKeyVerbaCache.Clear();
                foreach (var key in keys)
                {
                    m_languageKeyVerbaCache[key] = m_timeVerbaDict[key];
                }
            }
        }

        /// <summary>
        /// Get <see cref="ITimeVerba"/> from manager
        /// </summary>
        /// <returns></returns>
        public static ITimeVerba GetVerba()
        {
            return GetVerba(DefaultLanguageKey);
        }

        /// <summary>
        /// Get <see cref="ITimeVerba"/> from manager
        /// </summary>
        /// <param name="languageKey"></param>
        /// <returns></returns>
        public static ITimeVerba GetVerba(string languageKey)
        {
            if (string.IsNullOrWhiteSpace(languageKey))
            {
                return null;
            }

            if (!m_languageKeyVerbaCache.ContainsKey(languageKey))
            {
                return null;
            }

            return m_languageKeyVerbaCache[languageKey];
        }

        /// <summary>
        /// Get value from <see cref="ITimeVerba"/>
        /// </summary>
        /// <param name="verbaFunc"></param>
        /// <returns></returns>
        public static string FromVerba(Func<ITimeVerba, string> verbaFunc)
        {
            return FromVerba(DefaultLanguageKey, verbaFunc);
        }

        /// <summary>
        /// Get value from <see cref="ITimeVerba"/>
        /// </summary>
        /// <param name="languageKey"></param>
        /// <param name="verbaFunc"></param>
        /// <returns></returns>
        public static string FromVerba(string languageKey, Func<ITimeVerba, string> verbaFunc)
        {
            if (string.IsNullOrWhiteSpace(languageKey))
            {
                return string.Empty;
            }

            if (verbaFunc == null)
            {
                return string.Empty;
            }

            if (!m_languageKeyVerbaCache.ContainsKey(languageKey))
            {
                return string.Empty;
            }

            return verbaFunc(m_languageKeyVerbaCache[languageKey]);
        }


        /// <summary>
        /// 现在言词
        /// </summary>
        public static string Now => FromVerba(v => v.Now);

        /// <summary>
        /// 昨天言词
        /// </summary>
        public static string Yesterday => FromVerba(v => v.Yesterday);

        /// <summary>
        /// 未来言词
        /// </summary>
        public static string Future => FromVerba(v => v.Future);

        /// <summary>
        /// 毫秒言词
        /// </summary>
        public static string Milliseconds = FromVerba(v => v.Milliseconds);

        /// <summary>
        /// 秒钟言词
        /// </summary>
        public static string Seconds => FromVerba(v => v.Seconds);

        /// <summary>
        /// 分钟言词
        /// </summary>
        public static string Minutes => FromVerba(v => v.Minutes);

        /// <summary>
        /// 小时言词
        /// </summary>
        public static string Hours => FromVerba(v => v.Hours);

        /// <summary>
        /// 日言词
        /// </summary>
        public static string Days => FromVerba(v => v.Days);

        /// <summary>
        /// 周言词
        /// </summary>
        public static string Weeks => FromVerba(v => v.Weeks);

        /// <summary>
        /// 周末言词
        /// </summary>
        public static string Weekends => FromVerba(v => v.Weekends);

        /// <summary>
        /// 工作日言词
        /// </summary>
        public static string Weekdays => FromVerba(v => v.Weekdays);

        /// <summary>
        /// 月份言词
        /// </summary>
        public static string Months => FromVerba(v => v.Months);

        /// <summary>
        /// 季节言词
        /// </summary>
        public static string Season => FromVerba(v => v.Season);

        /// <summary>
        /// 年言词
        /// </summary>
        public static string Year => FromVerba(v => v.Year);

        /// <summary>
        /// 之前言词
        /// </summary>
        public static string Ago => FromVerba(v => v.Ago);

        /// <summary>
        /// 单词复数言词
        /// </summary>
        public static string ComplexString => FromVerba(v => v.ComplexString);

        /// <summary>
        /// 单词间隔言词
        /// </summary>
        public static string SpaceString => FromVerba(v => v.SpaceString);
    }
}
