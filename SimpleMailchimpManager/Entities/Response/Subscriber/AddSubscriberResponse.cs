using Newtonsoft.Json;

namespace SimpleMailchimpManager.Entities.Response.Subscriber
{
    public class AddSubscriberResponse
    {
        [JsonProperty(PropertyName = "id")]
        public string EmailId { get; set; }

        [JsonProperty(PropertyName = "email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "unique_email_id")]
        public string UniqueEmailAddress { get; set; }

        [JsonProperty(PropertyName = "email_type")]
        public string EmailType { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string SubscriberStatus { get; set; }

        [JsonProperty(PropertyName = "unsubscribe_reason")]
        public string UnsubscribeReason { get; set; }
    }
}