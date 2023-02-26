using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.Models;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace ApiTiendaMascotas.Controllers
{
    public class UsuariosController : ApiController
    {
        UsuariosModel model = new UsuariosModel();

        [Route("api/ValidarUsuario")]
        [HttpPost]
        public bool ValidarUsuario(UsuariosEnt entidad)
        {
            return model.ValidarUsuario(entidad);
        }
    }
}
