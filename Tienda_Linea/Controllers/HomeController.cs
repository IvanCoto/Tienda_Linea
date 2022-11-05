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
        CategoriaModel modelCategoria = new CategoriaModel();
        [FiltroSesion]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                Producto[] productos =
                {
                    new Producto
                    {
                        ID = 1,
                        Nombre = "Prueba",
                        Descripcion = "Descripcion de prueba",
                        Precio = 100000,
                        Impuesto = 13,
                        Stock = 1000,
                        Estado = '1'
                    },
                    new Producto
                    {
                        ID = 2,
                        Nombre = "Prueba 2",
                        Descripcion = "Descripcion de prueba 2",
                        Precio = 200000,
                        Impuesto = 13,
                        Stock = 300,
                        Estado = '1'
                    },
                    new Producto
                    {
                        ID = 2,
                        Nombre = "Prueba 2",
                        Descripcion = "Descripcion de prueba 2",
                        Precio = 200000,
                        Impuesto = 13,
                        Stock = 300,
                        Estado = '1'
                    }
                };
                Categoria[] categorias =
                {
                    new Categoria
                    {
                        Id = 1,
                        Nombre = "Bicicletas",
                        Descripcion = "Esta es una categoria de prueba",
                        Activo = true
                    },
                    new Categoria
                    {
                        Id = 2,
                        Nombre = "Accesorios",
                        Descripcion = "Esta es una categoria de prueba",
                        Activo = true
                    }
                };
                ViewBag.categories = categorias;
                ViewBag.products = productos;
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
        public ActionResult Bicicletas( string category )
        {
            try
            {
                if (category == "" || category == null)
                {
                    category = "Triatlon";
                }

                ViewBag.Category = category;
                Producto[] productos =
                {
                    new Producto
                    {
                        ID = 1,
                        Nombre = "Prueba",
                        Descripcion = "Descripcion de prueba",
                        Precio = 100000,
                        Impuesto = 13,
                        Stock = 1000,
                        Estado = '1'
                    },
                    new Producto
                    {
                        ID = 2,
                        Nombre = "Prueba 2",
                        Descripcion = "Descripcion de prueba 2",
                        Precio = 200000,
                        Impuesto = 13,
                        Stock = 300,
                        Estado = '1'
                    },
                    new Producto
                    {
                        ID = 3,
                        Nombre = "Prueba 2",
                        Descripcion = "Descripcion de prueba 2",
                        Precio = 200000,
                        Impuesto = 13,
                        Stock = 300,
                        Estado = '1'
                    },
                    new Producto
                    {
                        ID = 4,
                        Nombre = "Prueba 2",
                        Descripcion = "Descripcion de prueba 2",
                        Precio = 200000,
                        Impuesto = 13,
                        Stock = 300,
                        Estado = '1'
                    }
                };
                ViewBag.products = productos;
                return View();
            }catch (Exception ex)
            {
                //Cambiar por guardar error
                return View();
            }
        }

        [FiltroSesion]
        [HttpGet]
        public ActionResult Product( int id )
        {
            try
            {
                Producto product = new Producto
                {
                    ID = 4,
                    Nombre = "Prueba 2",
                    Descripcion = "Descripcion de prueba 2",
                    Precio = 200000,
                    Impuesto = 13,
                    Stock = 300,
                    Estado = '1'
                };
                ViewBag.Producto = product;
                ViewBag.PreviousUrl = Request.UrlReferrer.ToString();
                bool encontrado = true;
                if (encontrado)
                {
                    return View();
                }
                else
                {
                    return Redirect("");
                }
            }
            catch (Exception ex)
            {
                //Cambiar por guardar error
                return View();
            }
        }

        [FiltroSesion]
        [HttpGet]
        public ActionResult AgregarCarrito(int cantidad)
        {
            try
            {
                return RedirectToAction("Bicicletas","Home");
            }catch (Exception ex)
            {
                //Cambiar por guardar error
                return View();
            }
        }
    }
}