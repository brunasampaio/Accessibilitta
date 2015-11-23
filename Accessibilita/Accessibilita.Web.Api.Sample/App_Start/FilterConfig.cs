using System.Web;
using System.Web.Mvc;

namespace Accessibilitta.Web.Api.Sample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
