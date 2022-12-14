using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Tienda_Linea.Models;
using Tienda_Linea.Models.Modelos;
using Tienda_Linea.Models.Objetos;

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
                    Session["IdUsuario"] = resultado.respuestaObj.IdUsuario;
                    Session["CodigoSeguridad"] = resultado.respuestaObj.Token;
                    Session["NombreUsuario"] = resultado.respuestaObj.Nombre;
                    Session["TipoUsuario"] = resultado.respuestaObj.TipoUsuario;
                    if (resultado.respuestaObj.TipoUsuario.IdRol == 1)
                    {
                        return RedirectToAction("Productos", "Home");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Auth");
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
                    Session["IdUsuario"] = resultado.respuestaObj.IdUsuario;
                    Session["CodigoSeguridad"] = resultado.respuestaObj.Token;
                    Session["NombreUsuario"] = resultado.respuestaObj.Nombre;
                    Session["TipoUsuario"] = resultado.respuestaObj.TipoUsuario;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Auth");
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
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarContraseña( string correo )
        {
            //Generar el token para la recuperacion
            Recovery recovery = new Recovery();
            recovery.Correo = correo;
            var resultado = modelUsuario.Registrar_Token(recovery);
            //Enviar alerta de que se envio el recovery
            return RedirectToAction("Index","Auth");        
        }

        [HttpGet]
        public ActionResult Recuperar( string token)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recuperar(Usuario usuario)
        {
            return View();
        }
     

        //Desencryptacion con MD5
        /*public static string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }*/
    }
}