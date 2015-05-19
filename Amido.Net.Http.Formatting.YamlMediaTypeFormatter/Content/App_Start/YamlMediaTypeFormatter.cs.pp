using System;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof($rootnamespace$.App_Start.YamlMediaTypeFormatter), "PreStart")]

namespace $rootnamespace$.App_Start {
    public static class YamlMediaTypeFormatter {
        public static void PreStart() {
            GlobalConfiguration.Configuration.Formatters.Add(new YamlMediaTypeFormatter());
        }
    }
}