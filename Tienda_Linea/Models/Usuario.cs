﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Linea.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Contrasenna { get; set; }
        public bool Activo { get; set; }
        public int Rol { get; set; }
    }
}