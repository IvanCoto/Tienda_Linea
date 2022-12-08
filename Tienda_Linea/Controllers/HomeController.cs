using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tienda_Linea.Models;
using Tienda_Linea.Models.Objetos;
using Tienda_Linea.Models.Modelos;
using System.Linq;

namespace Tienda_Linea.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class HomeController : Controller
    {
        ProductoModel modelProducto = new ProductoModel();
        CarritoModel modelCarrito = new CarritoModel();
        CategoriaModel modelCategoria = new CategoriaModel();
        UsuarioModel modelUsuario = new UsuarioModel();
        UsuarioModel adminusuario = new UsuarioModel(); //esta instacia la hicimos otra vez xq visual esta berrinchudo
        MarcaModel modelMarca = new MarcaModel();
        RolModel modelRol = new RolModel();

        [FiltroAdmin]
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

        //------------------------------------------------------------------------------------------------//

        [FiltroSesion]
        [HttpGet]
        public ActionResult Productos()
        {
            try
            {
                ViewBag.Productos = modelProducto.GetProductosAdmin().respuestaLista;
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
        public ActionResult Actualizarproducto(int idProducto)
        {
            try
            {
                var producto = modelProducto.GetProductoById(idProducto);
                if(producto != null && producto.Codigo == 1)
                {
                    var categorias = modelCategoria.Obtener_Categorias();
                    var marcas = modelMarca.Obtener_Marcas();

                    if (categorias != null && categorias.Codigo == 1 && marcas != null && marcas.Codigo == 1)
                    {
                        var opcionesCategorias = new List<SelectListItem>();
                        foreach (var item in categorias.respuestaLista)
                            opcionesCategorias.Add(new SelectListItem { Text = item.Descripcion, Value = item.IdCategoria.ToString(), Selected = item.IdCategoria == producto.respuestaObj.IdCategoria ? true : false });

                        var opcionesMarcas = new List<SelectListItem>();
                        foreach (var item in marcas.respuestaLista)
                            opcionesMarcas.Add(new SelectListItem { Text = item.Descripcion, Value = item.IdMarca.ToString(), Selected = item.IdMarca == producto.respuestaObj.IdMarca ? true : false });
                        
                        ViewBag.Categorias = opcionesCategorias;
                        ViewBag.Marcas = opcionesMarcas;
                        return View(producto.respuestaObj);
                    }
                }
                return RedirectToAction("Productos", "Home");
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpPost]
        public ActionResult Actualizarproducto(Producto producto)
        {
            try
            {
                var resultado = modelProducto.Producto_Editar(producto);
                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Productos", "Home");
                }
                else
                {
                    return RedirectToAction("Productos", "Home");
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpGet]
        public ActionResult Registrarproducto()
        {
            try
            {
                var categorias = modelCategoria.Obtener_Categorias();
                var marcas = modelMarca.Obtener_Marcas();

                if (categorias != null && categorias.Codigo == 1 && marcas != null && marcas.Codigo == 1)
                {
                    var opcionesCategorias = new List<SelectListItem>();
                    foreach (var item in categorias.respuestaLista)
                        opcionesCategorias.Add(new SelectListItem { Text = item.Descripcion, Value = item.IdCategoria.ToString() });

                    var opcionesMarcas = new List<SelectListItem>();
                    foreach (var item in marcas.respuestaLista)
                        opcionesMarcas.Add(new SelectListItem { Text = item.Descripcion, Value = item.IdMarca.ToString() });

                    ViewBag.Categorias = opcionesCategorias;
                    ViewBag.Marcas = opcionesMarcas;
                    return View();
                }
                return RedirectToAction("Productos", "Home");
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpPost]
        public ActionResult Registrarproducto(Producto producto)
        {
            try
            {
                var resultado = modelProducto.Producto_Registrar(producto);
                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Productos", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }


        //-----------------------------------------------------------------------------------------------//



        [FiltroSesion]
        [HttpGet]
        public ActionResult Roles()
        {
            try
            {
                ViewBag.Roles = modelRol.GetRoles().respuestaLista;
                if(modelRol.GetRoles().respuestaLista.Count > 0)
                {
                    return View();
                }
                else
                {
                    return View();
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
        public ActionResult Registrarrol()
        {
            try
            {
               return View();
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpPost]
        public ActionResult Registrarrol(Rol rol)
        {
            try
            {
                var resultado = modelRol.Rol_Registrar(rol);
                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Roles", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpGet]
        public ActionResult Actualizarrol(int idRol)
        {
            try
            {
                var rol = modelRol.GetRolById(idRol);
                if (rol != null && rol.Codigo == 1)
                {
                    return View(rol.respuestaObj);
                }
                else
                {
                    return RedirectToAction("Roles", "Home");
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpPost]
        public ActionResult Actualizarrol(Rol rol)
        {
            try
            {
                var resultado = modelRol.Rol_Editar(rol);
                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Roles", "Home");
                }
                else
                {
                    return RedirectToAction("Rolactualizar", "Home");
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        //--------------------------------------------------------------------//


        [FiltroSesion]
        [HttpGet]
        public ActionResult Categorias()
        {
            try
            {
                ViewBag.Categorias = modelCategoria.Obtener_CategoriasAdmin().respuestaLista;
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
        public ActionResult Registrarcategoria()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpPost]
        public ActionResult Registrarcategoria(Categoria categoria)
        {
            try
            {
                var resultado = modelCategoria.Categoria_Registrar(categoria);
                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Categorias", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpGet]
        public ActionResult Actualizarcategoria(int idCategoria)
        {
            try
            {
                var rol = modelCategoria.GetCategoriaById(idCategoria);
                if (rol != null && rol.Codigo == 1)
                {
                    return View(rol.respuestaObj);
                }
                else
                {
                    return RedirectToAction("Categorias", "Home");
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpPost]
        public ActionResult Actualizarcategoria(Categoria categoria)
        {
            try
            {
                var resultado = modelCategoria.Categoria_Editar(categoria);
                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Categorias", "Home");
                }
                else
                {
                    return RedirectToAction("Actualizarcategoria", "Home");
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        //--------------------------------------------------------------------//


        [FiltroSesion]
        [HttpGet]
        public ActionResult Marcas()
        {
            try
            {
                ViewBag.Marcas = modelMarca.Obtener_MarcasAdmin().respuestaLista;
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
        public ActionResult Registrarmarca()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpPost]
        public ActionResult Registrarmarca(Marca marca)
        {
            try
            {
                var resultado = modelMarca.Marca_Registrar(marca);
                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Marcas", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpGet]
        public ActionResult Actualizarmarca(int idMarca)
        {
            try
            {
                var marca = modelMarca.GetMarcaById(idMarca);
                if (marca != null && marca.Codigo == 1)
                {
                    return View(marca.respuestaObj);
                }
                else
                {
                    return RedirectToAction("Marcas", "Home");
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpPost]
        public ActionResult Actualizarmarca(Marca marca)
        {
            try
            {
                var resultado = modelMarca.Marca_Editar(marca);
                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Marcas", "Home");
                }
                else
                {
                    return RedirectToAction("Actualizarmarca", "Home");
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }


        //--------------------------------------------------------------------//


        [FiltroSesion]
        [HttpGet]
        public ActionResult Usuarios()
        {
            try
            {
                ViewBag.Usuarios = modelUsuario.GetUsuarios().respuestaLista;
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
        public ActionResult Registrarusuario()
        {
            try
            {
                var roles = modelRol.GetRoles();
                var opcionesRoles = new List<SelectListItem>();
                foreach (var item in roles.respuestaLista)
                    opcionesRoles.Add(new SelectListItem { Text = item.Descripcion, Value = item.IdRol.ToString() });

                ViewBag.Roles = opcionesRoles;
                return View();
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpPost]
        public ActionResult Registrarusuario(Usuario usuario)
        {
            try
            {
                var resultado = modelUsuario.Registrar_UsuarioAdmin(usuario);
                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Usuarios", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpGet]
        public ActionResult Actualizarusuario(int idUsuario)
        {
            try
            {
                var usuario = modelUsuario.GetUsuarioById(idUsuario);
                var roles = modelRol.GetRoles();
                var opcionesRoles = new List<SelectListItem>();
                foreach (var item in roles.respuestaLista)
                    opcionesRoles.Add(new SelectListItem { Text = item.Descripcion, Value = item.IdRol.ToString(), Selected = item.IdRol == usuario.respuestaObj.TipoUsuario.IdRol ? true : false });

                ViewBag.Roles = opcionesRoles;
                if (usuario != null && usuario.Codigo == 1)
                {
                    return View(usuario.respuestaObj);
                }
                else
                {
                    return RedirectToAction("Usuarios", "Home");
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }

        [FiltroSesion]
        [HttpPost]
        public ActionResult Actualizarusuario(Usuario usuario)
        {
            try
            {
                var resultado = modelUsuario.Actualizar_Usuario(usuario);
                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Usuarios", "Home");
                }
                else
                {
                    return RedirectToAction("Actualizarusuario", "Home");
                }
            }
            catch (Exception ex)
            {
                /*Agregar error a base de datos*/
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }


        //--------------------------------------------------------------------//

        public ActionResult DetalleCompra()
        {
            return View();
        }
    }
}