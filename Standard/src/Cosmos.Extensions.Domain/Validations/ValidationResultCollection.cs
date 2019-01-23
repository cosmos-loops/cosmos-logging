using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Results;

namespace Cosmos.Validations
{
    public class ValidationResultCollection : IValidationResult
    {
        private const string UNAMED = "unamed";
        private readonly List<ValidationResult> _results;
        private readonly IDictionary<string, List<ValidationResult>> _resultsFlagedByStrategy;

        public ValidationResultCollection()
        {
            _results = new List<ValidationResult>();
            _resultsFlagedByStrategy = new Dictionary<string, List<ValidationResult>>();
            UpdateResultFlagedByStrategy(UNAMED, new List<ValidationResult>());
        }

        public ValidationResultCollection(ValidationResult result) : this()
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
            UpdateResultFlagedByStrategy(UNAMED, result);
        }

        public ValidationResultCollection(ValidationResult result, string strategyName) : this()
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
            UpdateResultFlagedByStrategy(strategyName, result);
        }

        public ValidationResultCollection(IEnumerable<ValidationResult> results) : this()
        {
            if (results == null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
            UpdateResultFlagedByStrategy(UNAMED, results.ToList());
        }

        public ValidationResultCollection(IEnumerable<ValidationResult> results, string strategyName) : this()
        {
            if (results == null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
            UpdateResultFlagedByStrategy(strategyName, results.ToList());
        }

        public ValidationResultCollection(ValidationResultCollection collection) : this()
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            ErrorCode = collection.ErrorCode;
            Flag = collection.Flag;
            _results = collection._results;
            UpdateResultFlagedByStrategy(collection);
        }

        public int Count => _results.Select(x => x.Errors.Count).Sum();

        public bool IsValid => _results.All(result => result.IsValid);

        public long ErrorCode { get; set; } = 1001;

        public string Flag { get; set; } = "__EMPTY_FLG";

        public void Add(ValidationResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            _results.Add(result);
        }

        public void AddRange(IEnumerable<ValidationResult> results)
        {
            if (results == null)
                throw new ArgumentNullException(nameof(results));
            _results.AddRange(results);
        }

        public string ToMessage()
        {
            if (IsValid)
                return string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine($"Code: {ErrorCode}");
            sb.AppendLine($"Flag: {Flag}");
            foreach (var result in _results)
                sb.Append(GetErrorString(result));

            return sb.ToString();
        }

        private StringBuilder GetErrorString(ValidationResult result)
        {
            var sb = new StringBuilder();
            foreach (var error in result.Errors)
                sb.AppendLine($"{error.PropertyName}, {error.ErrorMessage}");

            return sb;
        }

        public IEnumerator<ValidationResult> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return ToMessage();
        }

        private void UpdateResultFlagedByStrategy(ValidationResultCollection coll)
        {
            foreach (var set in coll._resultsFlagedByStrategy)
            {
                UpdateResultFlagedByStrategy(set.Key, set.Value);
            }
        }

        private void UpdateResultFlagedByStrategy(string name, List<ValidationResult> results)
        {
            if (_resultsFlagedByStrategy.ContainsKey(name))
            {
                _resultsFlagedByStrategy[name].AddRange(results);
            }
            else
            {
                _resultsFlagedByStrategy.Add(name, results);
            }
        }

        private void UpdateResultFlagedByStrategy(string name, ValidationResult result)
        {
            if (_resultsFlagedByStrategy.ContainsKey(name))
            {
                _resultsFlagedByStrategy[name].Add(result);
            }
            else
            {
                _resultsFlagedByStrategy.Add(name, new List<ValidationResult> {result});
            }
        }

        internal ValidationResultCollection Filter(Action<IEnumerable<ValidationResult>> filter)
        {
            var ret = _results;
            filter?.Invoke(ret);

            return ret.Count == 0 ? null : new ValidationResultCollection(ret);
        }

        internal ValidationResultCollection Filter(string strategyName)
        {
            if (string.IsNullOrWhiteSpace(strategyName))
                strategyName = UNAMED;

            return _resultsFlagedByStrategy.TryGetValue(strategyName, out var ret)
                ? new ValidationResultCollection(ret)
                : null;
        }
    }
}