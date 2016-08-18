using System.Web;
using System.Web.Mvc;

namespace dWeb.Auger.Drilling
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
