using ApiTiendaMascotas.App_Start;
using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.ModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaMascotas.Models
{
    public class AdopcionesModel
    {
        //LogsModel modeloLogs = new LogsModel();

        public int RegistrarAdopcion(AdopcionesEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {   
                return conexion.RegistrarAdopcion(entidad.idAnimal,entidad.cedula, DateTime.Now,3);
            }
        }

        public List<AdopcionesEnt> MostrarAdopciones() 
        {
            using (var conexion = new ProyectoPAEntities()) 
            {
                List<AdopcionesEnt> respuesta = new List<AdopcionesEnt>();
                var datosBD = conexion.MostrarAdopciones().ToList();

                if (datosBD.Count > 0)
                {
                    foreach (var item in datosBD)
                    {
                        respuesta.Add(new AdopcionesEnt()
                        {
                           idAdopcion = item.idAdopcion,
                           cedula = item.cedula,
                           nombre = item.nombre,
                           correo = item.correoElectronico,
                           fecha = item.fechaAdopcion,
                           rol = item.rol,
                           nombreAnimal = item.nombre_animal,
                           descripcion = item.descripcion,
                           tipoAnimal = item.tipoAnimal,
                           estadoAdopcion = item.estadoAdopcion,
                        });
                    }
                }
                return respuesta;
            }
        }

        public void CambiarEstadoAdopcion(int q, int e)
        {
            using (var conexion = new ProyectoPAEntities())
            {

                if (e == 1)
                {
                    //metodo enviar correo si fue aceptada la donacion
                    conexion.CambiarEstadoAdopcion(q, e);
                }
                else if (e == 2) 
                {
                    //metodo enviar correo si fue denegada la donacion
                    conexion.CambiarEstadoAdopcion(q, e);
                }

            }
        }

    }

}