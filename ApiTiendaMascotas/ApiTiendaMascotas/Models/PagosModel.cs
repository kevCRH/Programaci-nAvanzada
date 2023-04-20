using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.ModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaMascotas.Models
{
    public class PagosModel
    {

        public void ConfirmarPago(int idUsuario)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                conexion.ConfirmarPago(idUsuario);
            }
        }

        public List<PagosEnt> MostrarFacturas(int IdUsuario)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                var datosBD = conexion.MostrarFacturas(IdUsuario).ToList();

                List<PagosEnt> respuesta = new List<PagosEnt>();

                if (datosBD.Count > 0)
                {
                    foreach (var item in datosBD)
                    {
                        respuesta.Add(new PagosEnt
                        {
                            IdMaestro = item.idMaestro,
                            FechaCompra = item.FechaCompra,
                            Total = item.Total
                        });
                    }
                }

                return respuesta;
            }
        }

    }
}