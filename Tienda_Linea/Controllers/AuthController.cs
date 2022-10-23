using System;
using System.Web.Mvc;

namespace Tienda_Linea.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ingresar( string identificacion, string passw)
        {
            try
            {
                return Redirect("/");
            }
             catch ( Exception ex )
            {
                /*Agregar error a base de datos*/
                //Content retorna un texto en lugar de vista
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        public ActionResult Registrar( string nombre, string identificacion, string passw, string passw2)
        {
            try
            {
                return View("Index");
            }
            catch ( Exception ex )
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }
    }
}