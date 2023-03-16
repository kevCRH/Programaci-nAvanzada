using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace ApiTiendaMascotas.Controllers
{
    public class LogsController : ApiController
    {
        LogsModel model = new LogsModel();

        [HttpPost]
        [AllowAnonymous]
        [Route("api/RegistrarBitacora")]
        public void RegistrarBitacora(LogsEnt entidad)
        {
            model.RegistrarBitacora(entidad);
        }
    }

}
