using System.Collections.Generic;

namespace BMDex.Models
{
    public class ResourceResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IEnumerable<ResourceItem> Results { get; set; }
    }
}
