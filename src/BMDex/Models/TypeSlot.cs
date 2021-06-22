using Newtonsoft.Json;

namespace BMDex.Models
{
    public class TypeSlot
    {
        [JsonProperty("slot")]
        public int Slot { get; set; }

        [JsonProperty("type")]
        public Type Type { get; set; }
    }
}