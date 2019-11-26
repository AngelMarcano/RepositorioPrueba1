using InventoryWebAPI.App_Start;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace InventoryWebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AllowCrossSiteJsonAttribute());
        }

        
    }
}
