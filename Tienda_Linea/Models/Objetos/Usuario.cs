using System.Collections.Generic;
using Tienda_Linea.Models.Objetos;

namespace Tienda_Linea.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public Rol TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public List<TelefonoObj> Telefono { get; set; }
        public bool Activo { get; set; }
        public string Contrasenna { get; set; }
        public string Token { get; set; }
        //Se utiliza unicamente para recuperar la contraseña
        public string Recovery_Token { get; set; }
    }

    public class TelefonoObj
    {
        public int IdTelefono { get; set; }
        public int IdUsuario { get; set; }
        public string Numero { get; set; }
    }


    public class RespuestaUsuario
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public Usuario respuestaObj { get; set; }
        public List<Usuario> respuestaLista { get; set; }

    }
}