using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Linea.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}