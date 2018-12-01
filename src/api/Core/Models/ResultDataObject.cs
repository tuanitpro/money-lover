namespace Core.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    public class ResultDataObject
    {
        [JsonProperty("errors")]
        public ICollection<string> Errors { get; } = new List<string>();

        [JsonProperty("data")]
        public dynamic Data { get; set; }

        [JsonProperty("success")]
        public bool IsSuccess { get { return !Errors.Any(); } }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}