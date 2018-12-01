namespace Core.Models
{
    using Newtonsoft.Json;

    public class CategoryModel
    {
        [JsonProperty("value")]
        public int Id { get; set; }

        [JsonProperty("label")]
        public string Name { get; set; }

        [JsonIgnore]
        public int SortOrder { get; set; }
    }
}