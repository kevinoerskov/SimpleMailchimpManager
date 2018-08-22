using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMailchimpManager.Entities.Request
{
    internal class Subscriber
    {
        [JsonProperty(PropertyName = "email_address")]
        internal string Email { get; }

        [JsonProperty(PropertyName = "status")]
        internal string Status { get; }

        [JsonProperty(PropertyName = "merge_fields")]
        internal IDictionary<string, object> MergeVar { get; }

        internal Subscriber(string email, string status, MergeVar mergeVar)
            : this(email, status)
        {
            MergeVar = mergeVar
                .GetValues
                .ToDictionary(e => e.Key, e => e.Value);
        }

        internal Subscriber(string email, string status)
        {
            Email = email;
            Status = status;
        }
    }
}