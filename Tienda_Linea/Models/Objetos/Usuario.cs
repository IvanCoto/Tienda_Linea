using System.Collections.Generic;

namespace Tienda_Linea.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contrasenna { get; set; }
        public string Token { get; set; }
        //Se utiliza unicamente para recuperar la contraseña
        public string Recovery_Token { get; set; }
    }

    public class DireccionObj
    {
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }
        public string Exacta { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
    }

    public class RespuestaUsuario
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public Usuario respuestaObj { get; set; }
        public List<Usuario> respuestaLista { get; set; }

    }
}