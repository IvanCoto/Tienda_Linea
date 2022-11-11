using Tienda_Linea.Models.Objetos;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Net.Http.Headers;
using System.Net.Mail;
using System;
using Microsoft.Ajax.Utilities;

namespace Tienda_Linea.Models.Modelos
{
    public class UsuarioModel
    {
        public Respuesta Valida_Usuario(Usuario usuario)
        {
            using(HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/IniciarSesion";
                JsonContent content = JsonContent.Create(usuario);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                }
                return null;
            }
        }

        public Respuesta Registrar_Usuario(Usuario usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/RegistrarUsuario";
                JsonContent content = JsonContent.Create(usuario);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                }
                return null;
            }
        }

        public Respuesta Registrar_Token(Recovery recovery)
        {
            using (HttpClient client = new HttpClient())
            {
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
    }
}