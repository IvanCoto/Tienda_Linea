using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using Tienda_Linea.Models.Objetos;

namespace Tienda_Linea.Models.Modelos
{
    public class CategoriaModel
    {
        public RespuestaCategoria Obtener_Categorias()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Categoria";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaCategoria>().Result;
                }
                return null;
            }
        }
        public RespuestaCategoria Obtener_CategoriasAdmin()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/CategoriaAdmin";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaCategoria>().Result;
                }
                return null;
            }
        }
        public RespuestaCategoria GetCategoriaById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Categoria/"+id;
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaCategoria>().Result;
                }
                return null;
            }
        }

        public RespuestaCategoria Categoria_Registrar(Categoria c)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Categoria/RegistrarCategoria";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //Serialización System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(c);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaCategoria>().Result;
                }
                return null;
            }
        }

        public RespuestaCategoria Categoria_Editar(Categoria obj)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Categoria/ActualizarCategoria";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //Serialización System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(obj);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaCategoria>().Result;
                }
                return null;
            }
        }
    }
}