using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace InventoryWebAPI.App_Start
{
    public class AllowCrossSiteJsonAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET");
            actionExecutedContext.Response.Headers.Add("X-Content-Type-Options" ,"nosniff");

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}