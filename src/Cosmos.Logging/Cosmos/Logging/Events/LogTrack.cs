namespace Cosmos.Logging.Events {
    /// <summary>
    /// Business Track
    /// </summary>
    public struct LogTrack {
        /// <summary>
        /// Create a new instance of <see cref="LogTrack"/>.
        /// </summary>
        /// <param name="id"></param>
        public LogTrack(string id) {
            Id = id;
            Name = string.Empty;
            BusinessTraceId = string.Empty;
        }

        /// <summary>
        /// Create a new instance of <see cref="LogTrack"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public LogTrack(string id, string name) {
            Id = id;
            Name = name;
            BusinessTraceId = string.Empty;
        }

        /// <summary>
        /// Create a new instance of <see cref="LogTrack"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="businessTraceId"></param>
        public LogTrack(string id, string name, string businessTraceId) {
            Id = id;
            Name = name;
            BusinessTraceId = businessTraceId;
        }

        /// <summary>
        /// Gets business track id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets business track name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets business trace id
        /// </summary>
        public string BusinessTraceId { get; }

        /// <summary>
        /// Create a new instance of <see cref="LogTrack"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static LogTrack Create<T>(T id) => new LogTrack(id.ToString());

        /// <summary>
        /// Create a new instance of <see cref="LogTrack"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static LogTrack Create<T>(T id, string name) => new LogTrack(id.ToString(), name);

        /// <summary>
        /// Create a new instance of <see cref="LogTrack"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="businessTraceId"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static LogTrack Create<T>(T id, string name, string businessTraceId) => new LogTrack(id.ToString(), name, businessTraceId);
    }
}