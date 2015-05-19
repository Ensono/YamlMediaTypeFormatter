using System.Web.Http;

using Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples;
using Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.Controllers;

using AttributeRouting.Web.Http.WebHost;

[assembly: WebActivator.PreApplicationStartMethod(typeof(AttributeRoutingHttpConfig), "Start")]

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples 
{
    public static class AttributeRoutingHttpConfig
	{
		public static void RegisterRoutes(HttpRouteCollection routes) 
		{    
			// See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			// To debug routes locally using the built in ASP.NET development server, go to /routes.axd

            routes.MapHttpAttributeRoutes();
		}

        public static void Start() 
		{
            GlobalConfiguration.Configuration.Routes.MapHttpAttributeRoutes(cfg =>
            {
                cfg.InMemory = true;
                cfg.AutoGenerateRouteNames = true;
                cfg.AddRoutesFromAssemblyOf<ProductsController>();
            });
        }
    }
}
