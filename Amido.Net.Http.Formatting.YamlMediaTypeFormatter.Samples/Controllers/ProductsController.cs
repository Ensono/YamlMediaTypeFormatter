using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Infrastructure;
using Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Models;

using AttributeRouting.Web.Http;

using AutoPoco;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Controllers
{
    public class ProductsController : ApiController {
        [GET("api/products")]
        public IHttpActionResult Get() {
            var factory = AutoPocoContainer.Configure(
                conf => {
                    conf.Conventions(c => c.UseDefaultConventions());
                    conf.AddFromAssemblyContainingType<Product>();
                    conf.Include<Product>()
                        .Setup(t => t.Brand)
                        .Use<BrandDataSource>()
                        .Setup(t => t.ProductName)
                        .Use<ProductNameDataSource>()
                        .Setup(t => t.Variants)
                        .Use<VariantDataSource>();
                });

            var session = factory.CreateSession();

            var products = session.List<Product>(10).Get();

            return Ok(products);
        }

        [POST("api/products")]
        public IHttpActionResult Post(IEnumerable<Product> products) {
            return Ok(products);
        }
    }
}