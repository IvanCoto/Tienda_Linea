using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Linea.Models.Objetos
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public bool activo { get; set; }
        public DateTime fechaRegistro { get; set; }
    }

    public class RespuestaRol
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public Rol respuestaObj { get; set; }
        public List<Rol> respuestaLista { get; set; }

    }
}