using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Entities
{
    public class CompraEnt
    {
        public int CantidadCompra { get; set; }
        public decimal MontoCompra { get; set; }
    }

    public class DetalleComprasEnt
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Impuesto { get; set; }
        public decimal? Total { get; set; }
    }
}
