using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Linea.Models.Objetos
{
    public class Respuesta
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public Usuario respuestaObj { get; set; }
        public List<Usuario> respuestaLista { get; set; }
    }
}