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
    public class AdopcionesController : ApiController
    {
        AdopcionesModel model = new AdopcionesModel();
        
        [HttpPost]
        [AllowAnonymous]
        [Route("api/RegistrarAdopciones")]
        public int RegistrarAdopciones(AdopcionesEnt entidad)
        {
            return model.RegistrarAdopcion(entidad);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/MostrarAdopciones")]
        public List<AdopcionesEnt> MostrarAdopciones()
        {
            return model.MostrarAdopciones();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/CambiarEstadoAdopcion")]
        public void CambiarEstadoAdopcion(int q, int e, UsuariosEnt entidad)
        {
            model.CambiarEstadoAdopcion(q,e,entidad);
        }
    }
}
