using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaMascotas.Entities
{
    public class ProductoEnt
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public int descuento { get; set; }
        public byte[] imagen { get; set; }
        public int ConsecutivoUsuario { get; set; }
    }
}