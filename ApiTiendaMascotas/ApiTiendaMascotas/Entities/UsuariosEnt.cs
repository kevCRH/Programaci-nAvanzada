using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaMascotas.Entities
{
    public class UsuariosEnt
    {

        public int idUsuario { get; set; }

        public String Cedula { get; set; }

        public String Nombre { get; set; }

        public String CorreoElectronico { get; set; }

        public String Contrasenna { get; set; }

        public int ConfirmarContrasenna { get; set; }

        public bool Estado { get; set; }

        public string Token { get; set; }
    }
}