using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Entities
{
    public class UsuariosEnt
    {
        public String NombreUsuario { get; set; }

        public String Contrasenna { get; set; }

        public String Nombre { get; set; }

        public String Cedula { get; set; }

        public int ConfirmarContrasenna { get; set; }

    }
}