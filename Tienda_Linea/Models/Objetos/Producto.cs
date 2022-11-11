using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Linea.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }
    }

    public class RespuestaProducto
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public Producto respuestaObj { get; set; }
        public List<Producto> respuestaLista { get; set; }

    }
}