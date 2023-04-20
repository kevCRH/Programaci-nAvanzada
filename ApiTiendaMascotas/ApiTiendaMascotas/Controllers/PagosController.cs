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
    public class PagosController : ApiController
    {
        PagosModel model = new PagosModel();

        [HttpPost]
        [Authorize]
        [Route("api/ConfirmarPago")]
        public void ConfirmarPago(PagosEnt entidad)
        {
            model.ConfirmarPago(entidad.IdUsuario);
        }

        [HttpGet]
        [Authorize]
        [Route("api/MostrarFacturas")]
        public List<PagosEnt> MostrarFacturas(int idUsuario)
        {
            return model.MostrarFacturas(idUsuario);
        }

    }
}