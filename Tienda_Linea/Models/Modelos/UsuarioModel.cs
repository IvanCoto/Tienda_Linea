using Tienda_Linea.Models.Objetos;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Net.Http.Headers;

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
    }
}