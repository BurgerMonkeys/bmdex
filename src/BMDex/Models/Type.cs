using Newtonsoft.Json;

namespace BMDex.Models
{
    public class Type
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}