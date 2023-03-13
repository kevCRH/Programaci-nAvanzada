using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TiendaMascotas.App_Start
{
    public class FiltroSesion : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session.Count == 0)
            {
                if (filterContext.HttpContext.Session.Count == 0)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                     {
                     { "controller", "Home" },
                     { "action", "login" }
                     });
                }
            }
            base.OnActionExecuted(filterContext);
        }

    }
}