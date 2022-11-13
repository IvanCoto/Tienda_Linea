using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Tienda_Linea.Models;
using Tienda_Linea.Models.Objetos;
using Tienda_Linea.Models.Modelos;

namespace Tienda_Linea.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class HomeController : Controller
    {
        ProductoModel modelProducto = new ProductoModel();
        CarritoModel modelCarrito = new CarritoModel();
        CategoriaModel modelCategoria = new CategoriaModel();
        [FiltroSesion]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                ViewBag.productos = modelProducto.GetProductos().respuestaLista;
                ViewBag.categorias = modelCategoria.Obtener_Categorias().respuestaLista;
                return View();
            }
            catch (Exception ex)
            {
                //Cambiar por guardar error
                return View();
            }
        }

        [FiltroSesion]
        [HttpGet]
        public ActionResult Bicicletas(int id)
        {
            try
            {
                ViewBag.categoria = modelCategoria.GetCategoriaById(id).respuestaObj.Descripcion;
                ViewBag.productos = modelProducto.GetProductos().respuestaLista;
                return View();
            }catch (Exception ex)
            {
                //Cambiar por guardar error
                return View();
            }
        }

        [FiltroSesion]
        [HttpGet]
        public ActionResult Checkout()
        {
            try
            {
                int idUsuario = (int)Session["IdUsuario"];
                ViewBag.productos = modelCarrito.Get_Productos_Carrito(idUsuario).respuestaLista;
                return View();
            }catch (Exception ex)
            {
                //Cambiar por guardar error
                return View();
            }
        }
    }
}