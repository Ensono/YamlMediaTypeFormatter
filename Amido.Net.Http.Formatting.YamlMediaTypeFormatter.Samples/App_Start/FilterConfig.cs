using System.Web.Mvc;

namespace YamlMediaTypeFormatter.Samples {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}