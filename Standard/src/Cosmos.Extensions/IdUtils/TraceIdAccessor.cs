namespace Cosmos.IdUtils
{
    public sealed class TraceIdAccessor
    {
        private static readonly ITraceIdMaker DefaultMaker = new DefaultTraceIdMaker();
        private readonly string _id;

        public TraceIdAccessor(ITraceIdMaker maker)
        {
            _id = maker == null ? DefaultMaker.CreateId() : maker.CreateId();
        }

        public string GetTraceId() => _id;
    }
}