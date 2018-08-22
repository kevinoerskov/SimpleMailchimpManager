using System.Collections;
using System.Collections.Generic;

namespace SimpleMailchimpManager.Entities.Request
{
    public class MergeVar : IEnumerable
    {
        private readonly IDictionary<string, object> _internalDictionary =
            new Dictionary<string, object>();

        public object this[string key] => _internalDictionary[key];

        public void Add(string key, object value) => _internalDictionary.Add(key, value);

        public bool Remove(string key) => _internalDictionary.Remove(key);

        public IEnumerable<KeyValuePair<string, object>> GetValues => _internalDictionary;

        public IEnumerator GetEnumerator()
        {
            return _internalDictionary.GetEnumerator();
        }
    }
}