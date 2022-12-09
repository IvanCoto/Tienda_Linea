using Tienda_Linea.Models.Objetos;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net.Http.Json;

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
                /*if (respuesta.IsSuccessStatusCode)
                    return Json("OK", JsonRequestBehavior.AllowGet);
                else
                    return Json(null, JsonRequestBehavior.DenyGet);*/
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<CarritoRespuesta>().Result;
                }
                return null;
            }
        }

        public CarritoRespuesta Add_Productos_Carrito(Carrito carrito)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Carrito/AgregarACarrito";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                
                JsonContent contenido = JsonContent.Create(carrito);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<CarritoRespuesta>().Result;
                }
                return null;
            }
        }

        public CarritoRespuesta Delete_Productos_Carrito(Carrito carrito)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Carrito/RestCart";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                JsonContent contenido = JsonContent.Create(carrito);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<CarritoRespuesta>().Result;
                }
                return null;
            }
        }
    }
}