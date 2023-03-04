using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaMascotas.Entities
{
    public class UsuariosEnt
    {
        public String CorreoElectronico { get; set; }

        public String Cedula { get; set; }

        public String Nombre { get; set; } //De momento no se está usando

        public String Contrasenna { get; set; }

        public int ConfirmarContrasenna { get; set; }
    }
}