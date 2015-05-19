using System;
using System.Collections.Generic;
using System.Linq;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Models {
    public class Product {
        public string ProductName { get; set; }

        public string Brand { get; set; }

        public IEnumerable<Variant> Variants { get; set; }
    }
}