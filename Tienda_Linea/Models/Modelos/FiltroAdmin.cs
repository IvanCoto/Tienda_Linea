using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tienda_Linea.Models.Modelos
{
    //Este filtro solo da paso a usuarios que no sean de tipo administrador
    public class FiltroAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Session["CodigoSeguridad"] != null)
            {
                if (filterContext.HttpContext.Session["TipoUsuario"].ToString() == "1")
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        { "controller", "Home" },

                        { "action", "Productos" }
                    });
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}