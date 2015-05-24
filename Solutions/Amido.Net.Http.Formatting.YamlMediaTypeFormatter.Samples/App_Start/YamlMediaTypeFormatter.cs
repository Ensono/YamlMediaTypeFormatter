using System;
using System.Web.Http;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.App_Start.YamlMediaTypeFormatterConfig), "PreStart")]

namespace Amido.Net.Http.Formatting.YamlMediaTypeFormatter.Samples.App_Start {
    public static class YamlMediaTypeFormatterConfig {
        public static void PreStart() {
            GlobalConfiguration.Configuration.Formatters.Add(new YamlMediaTypeFormatter());
        }
    }
}