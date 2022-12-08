 using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using Tienda_Linea.Models.Objetos;

namespace Tienda_Linea.Models.Modelos
{
    public class RolModel
    {
        public RespuestaRol GetRoles()
        {
            using(HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Roles";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaRol>().Result;
                }
                return null;
            }
        }

        public RespuestaRol GetRolById(int rolId)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Roles/"+rolId;
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaRol>().Result;
                }
                return null;
            }
        }

        public RespuestaRol Rol_Registrar(Rol r)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Roles/RegistrarRol";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //Serialización System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(r);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaRol>().Result;
                }
                return null;
            }
        }

        public RespuestaRol Rol_Editar(Rol obj)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Roles/ActualizarRol";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //Serialización System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(obj);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaRol>().Result;
                }
                return null;
            }
        }
    }
}