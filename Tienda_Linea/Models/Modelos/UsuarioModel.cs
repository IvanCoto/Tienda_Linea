using Tienda_Linea.Models.Objetos;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Net.Http.Headers;
using System.Net.Mail;
using System;
using Microsoft.Ajax.Utilities;
using System.Security.Cryptography;
using System.Text;

namespace Tienda_Linea.Models.Modelos
{
    public class UsuarioModel
    {
        public RespuestaUsuario Valida_Usuario(Usuario usuario)
        {
            using(HttpClient client = new HttpClient())
            {
                usuario.Contrasenna = Encrypt(usuario.Contrasenna);
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/IniciarSesion";
                JsonContent content = JsonContent.Create(usuario);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaUsuario>().Result;
                }
                return null;
            }
        }

        public RespuestaUsuario GetUsuarios()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaUsuario>().Result;
                }
                return null;
            }
        }

        public RespuestaUsuario GetUsuarioById(int IdUsuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/"+IdUsuario;
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaUsuario>().Result;
                }
                return null;
            }
        }

        public RespuestaUsuario Registrar_Usuario(Usuario usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                usuario.Contrasenna = Encrypt(usuario.Contrasenna);
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/RegistrarUsuario";
                JsonContent content = JsonContent.Create(usuario);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaUsuario>().Result;
                }
                return null;
            }
        }

        public RespuestaUsuario Registrar_UsuarioAdmin(Usuario usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                usuario.Contrasenna = Encrypt(usuario.Contrasenna);
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/RegistrarUsuarioAdmin";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                JsonContent content = JsonContent.Create(usuario);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaUsuario>().Result;
                }
                return null;
            }
        }

        public RespuestaUsuario Actualizar_Usuario(Usuario usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/ActualizarUsuario";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                JsonContent content = JsonContent.Create(usuario);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaUsuario>().Result;
                }
                return null;
            }
        }

        public Respuesta Registrar_Token(Recovery recovery)
        {
            using (HttpClient client = new HttpClient())
            {
                string token = Encrypt(Guid.NewGuid().ToString());
                recovery.Token = token;
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Recovery";
                JsonContent content = JsonContent.Create(recovery);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    Enviar_Email(recovery);
                    return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                }
                return null;
            }
        }

        public void Enviar_Email(Recovery recovery)
        {
            string urlDomain = "https://localhost:44392/";
            string subject = "Recuperacion de Contraseña";
            string url = urlDomain+"/Auth/Recuperar/?token="+recovery.Token;
            string body = "Este correo es para recuperar tu contraseña\n"+url;
            string FromMail = "tiendabicicletas@outlook.com";
            string emailTo = recovery.Correo;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
            SmtpServer.Port = 587;
            //En correo y contraseña van credenciales de un correo office
            SmtpServer.Credentials = new System.Net.NetworkCredential("tiendabicicletas@outlook.com", "5l@3lIs2yw%m");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        //Encryptacion con MD5
        public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
    }
}