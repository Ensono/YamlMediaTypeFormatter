using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            config.MapHttpAttributeRoutes();

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            xml.Indent = true;
        }
    }
}