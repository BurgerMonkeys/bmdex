using System.Collections.Generic;
using BMDex.Extensions;
using Newtonsoft.Json;

namespace BMDex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("types")]
        public IEnumerable<TypeSlot> Types { get; set; }

        public string FormattedName
        {
            get => Name.FirstCharToUpper();
        }
    }
}