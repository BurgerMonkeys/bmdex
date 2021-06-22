using System;
using System.Collections;
using System.Collections.Generic;

namespace BMDex.Resources
{
    public class ResourceResponse<T>
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
