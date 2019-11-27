namespace Cosmos.Logging
{
    public class Args
    {
        private object[] _args;
        public Args(params object[] args) => _args = args;

        public static explicit operator object[](Args args)
        {
            return args._args;
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(_args);
        }
    }
}