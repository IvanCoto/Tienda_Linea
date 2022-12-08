using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;

namespace Tienda_Linea.Models.Modelos
{
    public class MarcaModel
    {
        public RespuestaMarca Obtener_Marcas()
        {
            using(HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Marca";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaMarca>().Result;
                }
                return null;
            }
        }

        public RespuestaMarca Obtener_MarcasAdmin()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/MarcaAdmin";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaMarca>().Result;
                }
                return null;
            }
        }

        public RespuestaMarca GetMarcaById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Marca/" + id;
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaMarca>().Result;
                }
                return null;
            }
        }

        public RespuestaMarca Marca_Registrar(Marca m)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Marca/RegistrarMarca";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //Serialización System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(m);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaMarca>().Result;
                }
                return null;
            }
        }

        public RespuestaMarca Marca_Editar(Marca obj)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Marca/ActualizarMarca";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //Serialización System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(obj);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaMarca>().Result;
                }
                return null;
            }
        }
    }
}