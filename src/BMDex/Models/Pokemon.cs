using System.Collections.Generic;
using BMDex.Extensions;
using BMDex.Resources;
using Newtonsoft.Json;

namespace BMDex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("types")]
        public IEnumerable<TypeSlot> Types { get; set; }

        public string FormattedName => Name.FirstCharToUpper();
        public string FormattedDexNumber => $"#{Id}";

        public string ImageURL => string.Format(Constants.ImageBaseUrl, Id);
    }
}