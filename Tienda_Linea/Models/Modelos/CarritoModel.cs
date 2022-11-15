using Tienda_Linea.Models.Objetos;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Web;

namespace Tienda_Linea.Models.Modelos
{
    public class CarritoModel
    {
        public CarritoRespuesta Get_Productos_Carrito(int id)
        {
            using(HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Carrito/GetCarrito/?id=" + id;
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<CarritoRespuesta>().Result;
                }
                return null;
            }
        }
    }
}