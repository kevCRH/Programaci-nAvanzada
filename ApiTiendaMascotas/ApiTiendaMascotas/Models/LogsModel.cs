using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.ModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaMascotas.Models
{
    public class LogsModel
    {

        public void RegistrarBitacora(LogsEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                Bitacoras bitacora = new Bitacoras();
                bitacora.fechaHora = DateTime.Now;
                bitacora.origen = entidad.origen;
                bitacora.mensajeError = entidad.mensajeError;

                conexion.Bitacoras.Add(bitacora);
                conexion.SaveChanges();
            }
        }
    }
}