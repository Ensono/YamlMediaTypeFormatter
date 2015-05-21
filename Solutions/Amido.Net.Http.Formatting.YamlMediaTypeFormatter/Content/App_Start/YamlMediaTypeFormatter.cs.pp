using System;
using System.Web.Http;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof($rootnamespace$.App_Start.YamlMediaTypeFormatterConfig), "PreStart")]

namespace $rootnamespace$.App_Start {
    public static class YamlMediaTypeFormatterConfig {
        public static void PreStart() {
            GlobalConfiguration.Configuration.Formatters.Add(new YamlMediaTypeFormatter());
        }
    }
}