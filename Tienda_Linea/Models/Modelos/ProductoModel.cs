using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;

namespace Tienda_Linea.Models.Modelos
{
    public class ProductoModel
    {
        public RespuestaProducto GetProductos()
        {
            using(HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Producto";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaProducto>().Result;
                }
                return null;
            }
        } 
    }
}