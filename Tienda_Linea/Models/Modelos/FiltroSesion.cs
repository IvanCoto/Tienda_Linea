using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tienda_Linea.Models.Modelos
{
    public class FiltroSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["CodigoSeguridad"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Auth" },

                    { "action", "Index" }
                });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}