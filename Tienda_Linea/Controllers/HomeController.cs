using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda_Linea.Models;

namespace Tienda_Linea.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
                    Cantidad = 1000,
                    Estado = '1'
                },
                new Producto
                {
                    ID = 2,
                    Nombre = "Prueba 2",
                    Descripcion = "Descripcion de prueba 2",
                    Precio = 200000,
                    Impuesto = 13,
                    Cantidad = 300,
                    Estado = '1'
                },
                new Producto
                {
                    ID = 2,
                    Nombre = "Prueba 2",
                    Descripcion = "Descripcion de prueba 2",
                    Precio = 200000,
                    Impuesto = 13,
                    Cantidad = 300,
                    Estado = '1'
                },
                new Producto
                {
                    ID = 2,
                    Nombre = "Prueba 2",
                    Descripcion = "Descripcion de prueba 2",
                    Precio = 200000,
                    Impuesto = 13,
                    Cantidad = 300,
                    Estado = '1'
                }
            };
            ViewBag.products = productos;

            return View();
        }

        public ActionResult Bicicletas( string category )
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
                    Cantidad = 1000,
                    Estado = '1'
                },
                new Producto
                {
                    ID = 2,
                    Nombre = "Prueba 2",
                    Descripcion = "Descripcion de prueba 2",
                    Precio = 200000,
                    Impuesto = 13,
                    Cantidad = 300,
                    Estado = '1'
                },
                new Producto
                {
                    ID = 2,
                    Nombre = "Prueba 2",
                    Descripcion = "Descripcion de prueba 2",
                    Precio = 200000,
                    Impuesto = 13,
                    Cantidad = 300,
                    Estado = '1'
                },
                new Producto
                {
                    ID = 2,
                    Nombre = "Prueba 2",
                    Descripcion = "Descripcion de prueba 2",
                    Precio = 200000,
                    Impuesto = 13,
                    Cantidad = 300,
                    Estado = '1'
                }
            };
            ViewBag.products = productos;
            return View();
        }
    }
}