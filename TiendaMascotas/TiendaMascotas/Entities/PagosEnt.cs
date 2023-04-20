using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Entities
{
    public class PagosEnt
    {
        public int IdUsuario { get; set; }
        public long IdMaestro { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
    }
}