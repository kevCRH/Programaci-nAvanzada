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
                return conexion.RegistrarAdopcion(entidad.idAnimal,entidad.cedula, DateTime.Now);
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
                           cedula = item.cedula,
                           nombre = item.nombre,
                           correo = item.correoElectronico,
                           fecha = item.fechaAdopcion,
                           rol = item.rol,
                           nombreAnimal = item.nombre_animal,
                           descripcion = item.descripcion,
                           tipoAnimal = item.tipoAnimal
                        });
                    }
                }
                return respuesta;
            }
        }

    }

}