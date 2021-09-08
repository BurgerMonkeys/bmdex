using System.Collections.Generic;
using Newtonsoft.Json;

namespace BMDex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("types")]
        public IEnumerable<TypeSlot> Types { get; set; }
    }
}