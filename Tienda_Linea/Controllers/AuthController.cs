using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using Tienda_Linea.Models;
using Tienda_Linea.Models.Modelos;

namespace Tienda_Linea.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class AuthController : Controller
    {
        // GET: Auth
        UsuarioModel modelUsuario = new UsuarioModel();
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Ingresar( Usuario usuario )
        {
            //string identificacion, string passw
            try
            {
                var resultado = modelUsuario.Valida_Usuario(usuario);
                if (resultado != null && resultado.Codigo == 1)
                {
                    Session["CodigoSeguridad"] = resultado.respuestaObj.Token;
                    Session["NombreUsuario"] = resultado.respuestaObj.Nombre;
                    Session["TipoUsuario"] = resultado.respuestaObj.TipoUsuario;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
             catch ( Exception ex )
            {
                /*Agregar error a base de datos*/
                //Content retorna un texto en lugar de vista
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Registrar( Usuario usuario )
        {
            try
            {
                var resultado = modelUsuario.Registrar_Usuario(usuario);
                if (resultado != null && resultado.Codigo == 1)
                {
                    Session["CodigoSeguridad"] = resultado.respuestaObj.Token;
                    Session["NombreUsuario"] = resultado.respuestaObj.Nombre;
                    Session["TipoUsuario"] = resultado.respuestaObj.TipoUsuario;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch ( Exception ex )
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Auth");
        }

        [HttpGet]
        public ActionResult RecuperarContraseña()
        {
            //Generar el token para la recuperacion

            return View();
        }

        [HttpPost]
        public ActionResult RecuperarContraseña( String correo )
        {
            return null;
        }
    }
}