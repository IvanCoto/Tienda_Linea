using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Linea.Models
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuesto { get; set; }
        public int Stock { get; set; }
        public char Estado { get; set; }
        public bool Activo { get; set; }
    }
}