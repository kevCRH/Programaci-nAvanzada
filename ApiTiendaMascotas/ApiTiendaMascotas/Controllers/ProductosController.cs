using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTiendaMascotas.Controllers
{
    public class ProductosController : ApiController
    {
        ProductosModel model = new ProductosModel();

        [HttpGet]
        [AllowAnonymous]
        [Route("api/MostrarProductos")]
        public List<ProductoEnt> MostrarProductos()
        {
            var Productos = User.Identity.Name;
            return model.MostrarProductos();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/ConsultarProductos")]
        public List<TipoProductoEnt> ConsultarProductos()
        {
            return model.ConsultarProductos();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/RegistrarProducto")]
        public int RegistrarProducto(ProductoEnt entidad)
        {
            return model.RegistrarProducto(entidad);
        }

    }
}