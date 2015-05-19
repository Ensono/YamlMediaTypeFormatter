using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Models;

using AttributeRouting.Web.Http;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Controllers {
    public class ProductController : ApiController {
        [GET("api/product")]
        public IHttpActionResult Get() {
            var product = new Product {
                                          ProductName = "Azure T-Shirt",
                                          Brand = "Microsoft",
                                          Variants =
                                              new List<Variant> {
                                                                    new Variant { Colour = "Red", Size = "Large" },
                                                                    new Variant { Colour = "Blue", Size = "Medium" }
                                                                }
                                      };

            return Ok(product);
        }

        [POST("api/product")]
        public IHttpActionResult Post([FromBody]Product product) {
            return Ok(product);
        }
    }
}