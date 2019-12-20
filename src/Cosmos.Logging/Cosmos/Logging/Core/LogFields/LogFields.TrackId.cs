namespace Cosmos.Logging.Core.LogFields {
    /// <summary>
    /// Business track id field
    /// </summary>
    public class TrackField : ILogField<TrackField.TrackValue> {
        private readonly TrackValue _value = new TrackValue();

        /// <summary>
        /// Create a new instance of <see cref="TrackField"/>.
        /// </summary>
        /// <param name="id"></param>
        public TrackField(string id) {
            _value.Id = id;
        }

        /// <summary>
        /// Create a new instance of <see cref="TrackField"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public TrackField(string id, string name) {
            _value.Id = id;
            _value.Name = name;
        }

        /// <summary>
        /// Create a new instance of <see cref="TrackField"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="businessTraceId"></param>
        public TrackField(string id, string name, string businessTraceId) {
            _value.Id = id;
            _value.Name = name;
            _value.BizTraceId = businessTraceId;
        }

        /// <inheritdoc />
        public LogFieldTypes Type => LogFieldTypes.TrackId;

        /// <inheritdoc />
        public TrackValue Value => _value;

        /// <inheritdoc />
        public int Sort { get; set; } = 1;

        /// <summary>
        /// Track value for TrackField
        /// </summary>
        public class TrackValue {
            /// <summary>
            /// Id
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// Name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Business trace id
            /// </summary>
            public string BizTraceId { get; set; }
        }
    }
}