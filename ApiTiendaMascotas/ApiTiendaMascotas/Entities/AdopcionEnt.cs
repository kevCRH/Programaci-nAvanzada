using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaMascotas.Entities
{
    public class AdopcionesEnt
    {
        public int idAdopcion { get; set; }
        public string cedula { get; set; }
        public int idAnimal { get; set;}
        public DateTime fecha { get; set;}
        public string nombre { get; set;}
        public string correo { get; set;}
        public string rol { get; set;}
        public string nombreAnimal { get; set;}
        public string descripcion { get; set;}
        public string tipoAnimal { get; set;}
        public string estadoAdopcion { get; set;}
        public byte[] imagen { get; set; }

    }
}