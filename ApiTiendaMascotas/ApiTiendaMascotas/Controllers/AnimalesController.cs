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
    public class AnimalesController : ApiController
    {
        AnimalesModel model = new AnimalesModel(); 

        [HttpGet]
        [AllowAnonymous]
        [Route("api/MostrarAnimales")]
        public List<AnimalesEnt> MostrarAnimales()
        {
            var animales = User.Identity.Name;
            return model.MostrarAnimales();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/ConsultarAnimales")]
        public List<TiposAnimalesEnt> ConsultarAnimales()
        {
            return model.ConsultarAnimales();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/ConsultarAnimal")]
        public AnimalesEnt ConsultarAnimal(long q)
        {
            return model.ConsultarAnimal(q);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/RegistrarAnimal")]
        public int RegistrarAnimal(AnimalesEnt entidad)
        {
            return model.RegistrarAnimal(entidad);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/ActualizarAnimales")]
        public void ActualizarAnimales(AnimalesEnt entidad) 
        {
            model.ActualizarAnimales(entidad);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/CambiarEstadoAnimal")]
        public void CambiarEstadoAnimal(long q)
        {
            model.CambiarEstadoAnimal(q);
        }
    }
}
