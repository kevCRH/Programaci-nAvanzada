using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Entities
{
    public class AnimalesEnt
    {
        public int idAnimal { get; set; }

        public string tipoAnimal { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public byte[] imagen { get; set; }
    }
}