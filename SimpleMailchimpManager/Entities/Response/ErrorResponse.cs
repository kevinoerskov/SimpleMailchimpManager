using Newtonsoft.Json;

namespace SimpleMailchimpManager.Entities.Response
{
    public class ErrorResponse
    {
        [JsonProperty(PropertyName = "type")]
        public string ErrorType { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string ErrorTitle { get; set; }

        [JsonProperty(PropertyName = "status")]
        public int HttpStatusCode { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public string ErrorMessage { get; set; }

        [JsonProperty(PropertyName = "instance")]
        public string ErrorId { get; set; }

    }
}