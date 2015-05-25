using System;
using System.Web.Http;
using Amido.Net.Http.Formatting.YamlMediaTypeFormatter;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof($rootnamespace$.App_Start.YamlMediaTypeFormatterConfig), "PreStart")]

namespace $rootnamespace$.App_Start {
    public static class YamlMediaTypeFormatterConfig {
        public static void PreStart() {
            GlobalConfiguration.Configuration.Formatters.Add(new YamlMediaTypeFormatter());
        }
    }
}