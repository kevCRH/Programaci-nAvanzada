using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.ModeloBD;
using ApiTiendaMascotas.Models;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace ApiTiendaMascotas.Controllers
{
    public class UsuariosController : ApiController
    {
        UsuariosModel model = new UsuariosModel();

        [HttpPost]
        [Route("api/ValidarUsuario")]
        public bool ValidarUsuario(UsuariosEnt entidad)
        {
            return model.ValidarUsuario(entidad);
        }

        [HttpPost]
        [Route("api/Registrar")]
        public int Registrar(UsuariosEnt entidad)
        {
            return model.Registrar(entidad);
        }

        [HttpGet]
        [Route("api/ValidarRegistrar")]
        public string ValidarRegistrar(string validar)
        {
            return model.ValidarRegistrar(validar);
        }
    }
}
