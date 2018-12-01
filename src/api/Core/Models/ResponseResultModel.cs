namespace Core.Models
{
    using Newtonsoft.Json;

    public class ResponseResultModel 
    {
        [JsonProperty("data")]
        public dynamic Data { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public dynamic ExtraData { get; set; }
    }
}