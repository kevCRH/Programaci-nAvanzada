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
            //var Productos = User.Identity.Name; //no se usa hasta el momento
            return model.MostrarProductos();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/RegistrarProducto")]
        public int RegistrarProducto(ProductoEnt entidad)
        {
            return model.RegistrarProducto(entidad);
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("api/ConsultarProducto")]
        public ProductoEnt ConsultarProducto(int q)
        {
            return model.ConsultarProducto(q);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/ActualizarProducto")]
        public void ActualizarProducto(ProductoEnt entidad)
        {
            model.ActualizarProducto(entidad);
        }
        
        [HttpDelete]
        [Authorize]
        [Route("api/EliminarProducto")]
        public void EliminarProducto(int q)
        {
            model.EliminarProducto(q);
        }
        
        [HttpPut]
        [Authorize]
        [Route("api/ActualizarCarrito")]
        public void ActualizarCarrito(ProductoEnt entidad)
        {
            model.ActualizarCarrito(entidad);
        }

        [HttpGet]
        [Authorize]
        [Route("api/MostrarCompraCarrito")]
        public CompraEnt MostrarCompraCarrito(int idUsuario)
        {
            return model.MostrarCompraCarrito(idUsuario);
        }

        [HttpGet]
        [Authorize]
        [Route("api/MostrarDetalleCarrito")]
        public List<DetalleComprasEnt> MostrarDetalleCarrito(int idUsuario)
        {
            return model.MostrarDetalleCarrito(idUsuario);
        }

    }
}