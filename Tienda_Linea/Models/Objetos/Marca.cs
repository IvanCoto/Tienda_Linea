using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Linea.Models
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }

    public class RespuestaMarca
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public Marca respuestaObj { get; set; }
        public List<Marca> respuestaLista { get; set; }

    }
}