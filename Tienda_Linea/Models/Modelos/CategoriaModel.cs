using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Tienda_Linea.Models.Objetos;

namespace Tienda_Linea.Models.Modelos
{
    public class CategoriaModel
    {
        public Respuesta Obtener_Categorias()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Categoria";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<Respuesta>().Result;
                }
                return null;
            }
        }
    }
}