using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Entities
{
    public class UsuariosEnt
    {
        public String CorreoElectronico { get; set; }

        public String Cedula { get; set; }

        public String Nombre { get; set; }

        public String Contrasenna { get; set; }

        public int ConfirmarContrasenna { get; set; }

        public int idUsuario { get; set; }

        public bool Estado { get; set; }

    }
}