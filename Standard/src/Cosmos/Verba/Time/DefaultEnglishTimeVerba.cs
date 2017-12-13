using System.Collections.Generic;

namespace Cosmos.Verba.Time
{
    public class DefaultEnglishTimeVerba : ITimeVerba
    {
        private static readonly DefaultEnglishTimeVerba m_singletonInstance;
        public const string USEnglish = "en_US";

        static DefaultEnglishTimeVerba()
        {
            m_singletonInstance = new DefaultEnglishTimeVerba();
        }

        /// <summary>
        /// Get an english time verba instance
        /// </summary>
        public static DefaultEnglishTimeVerba Instance => m_singletonInstance;

        private DefaultEnglishTimeVerba() { }

        /// <summary>
        /// Verba name
        /// </summary>
        public string VerbaName { get; } = "DefaultEnglishTimeVerba";

        /// <summary>
        /// Language Keys
        /// </summary>
        public List<string> LanguageKeys { get; } = new List<string> { USEnglish };

        public string Now { get; } = "Now";
        public string JustNow { get; } = "Just Now";
        public string Future { get; } = "Future";
        public string Yesterday { get; } = "Yesterday";
        public string Milliseconds { get; } = "Millisecond";
        public string Seconds { get; } = "Second";
        public string Minutes { get; } = "Minute";
        public string Hours { get; } = "Hour";
        public string Days { get; } = "Day";
        public string Weeks { get; } = "Week";
        public string Weekends { get; } = "Weekend";
        public string Weekdays { get; } = "Weekday";
        public string Months { get; } = "Month";
        public string Season { get; } = "Season";
        public string Year { get; } = "Year";
        public string Ago { get; } = "Ago";
        public string ComplexString { get; } = "s";
        public string SpaceString { get; } = " ";
    }
}
