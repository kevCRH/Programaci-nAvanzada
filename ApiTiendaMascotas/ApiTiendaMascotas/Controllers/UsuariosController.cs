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
        [AllowAnonymous]
        [Route("api/ValidarUsuario")]
        public UsuariosEnt ValidarUsuario(UsuariosEnt entidad)
        {
            var usuario = User.Identity.Name;
            return model.ValidarUsuario(entidad);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/Registrar")]
        public int Registrar(UsuariosEnt entidad)
        {
            return model.Registrar(entidad);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/ValidarRegistrar")]
        public string ValidarRegistrar(string validar)
        {
            return model.ValidarRegistrar(validar);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/RecuperarContrasenna")]
        public void RecuperarContrasenna(UsuariosEnt entidad)
        {
            model.RecuperarContrasenna(entidad);
        }


        [HttpPost]
        [Authorize]
        [Route("api/Contactenos")]
        public void Contactenos(ContactenosEnt entidad)
        {
            model.Contactenos(entidad);
        }

    }
}
