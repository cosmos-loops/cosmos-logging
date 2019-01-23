using System.Text;

namespace Cosmos.Domain
{
    public sealed class DescriptionContext
    {
        private StringBuilder _stringBuilder;

        public DescriptionContext()
        {
            _stringBuilder = new StringBuilder();
        }

        public void Add(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return;
            _stringBuilder.Append(description);
        }

        public void Add<TValue>(string name, TValue value)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;
            if (value == null || value.Equals(default(TValue)) || string.IsNullOrWhiteSpace(value.ToString()))
                return;
            _stringBuilder.Append($"{name}:{value}");
        }

        public void FlushCache()
        {
            _stringBuilder.Clear();
        }

        public string Output()
        {
            if (_stringBuilder.Length == 0)
                return string.Empty;
            return _stringBuilder.ToString().TrimEnd().TrimEnd(',');
        }

        public override string ToString()
        {
            return Output();
        }
    }
}