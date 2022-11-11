using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Linea.Models
{
    public class Categoria
    {
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }

    public class RespuestaCategoria
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public Categoria respuestaObj { get; set; }
        public List<Categoria> respuestaLista { get; set; }

    }
}