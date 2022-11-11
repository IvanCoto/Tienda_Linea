using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Linea.Models.Objetos
{
    public class Carrito
    {
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public int IdCarrito { get; set; }
        public int Cantidad { get; set; }
    }

    public class CarritoRespuesta
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public Carrito respuestaObj { get; set; }
        public List<Carrito> respuestaLista { get; set; }
    }
}