using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.ModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaMascotas.Models
{
    public class AnimalesModel
    {
        public List<AnimalesEnt> MostrarAnimales()
        {
            using (var conexion = new ProyectoPAEntities())
            {
                List<AnimalesEnt> respuesta = new List<AnimalesEnt>();
                var datosBD = conexion.MostrarAnimales().ToList();

                if (datosBD.Count > 0)
                {
                    foreach (var item in datosBD)
                    {
                        respuesta.Add(new AnimalesEnt()
                        {
                            idAnimal = item.idAnimal,
                            Nombre = item.nombre,
                            tipoAnimal = item.tipoAnimal,
                            Descripcion = item.descripcion,
                            Estado= item.estado
                        });
                    }
                }
                return respuesta;
            }
        }

        public List<TiposAnimalesEnt> ConsultarAnimales()
        {
            using (var conexion = new ProyectoPAEntities())
            {
                List<TiposAnimalesEnt> respuesta = new List<TiposAnimalesEnt>();
                var datosBD = (from x in conexion.TipoAnimal
                               select x).ToList();

                if (datosBD.Count > 0)
                {
                    foreach (var item in datosBD)
                    {
                        respuesta.Add(new TiposAnimalesEnt()
                        {
                            idTipoAnimal = item.idTipoAnimal,
                            tiposAnimal = item.tipoAnimal1
                        });
                    }
                }
                return respuesta;
            }
        }

        public AnimalesEnt ConsultarAnimal(long q)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                AnimalesEnt respuesta = new AnimalesEnt();
                var datosBD = (from x in conexion.Animales
                               where x.idAnimal == q
                               select x).FirstOrDefault();  
                if (datosBD != null)
                {
                    respuesta.idAnimal = datosBD.idAnimal;
                    respuesta.Nombre = datosBD.nombre;
                    respuesta.Descripcion = datosBD.descripcion;
                    respuesta.tipoAnimal = datosBD.idTipoAnimal;
                }
                return respuesta;
            }
        }

        public int RegistrarAnimal(AnimalesEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                return conexion.RegistrarAnimal(entidad.tipoAnimal, entidad.Nombre, entidad.Descripcion);
            }
        }

        public void ActualizarAnimales(AnimalesEnt entidad) 
        {
            using (var conexion = new ProyectoPAEntities())
            {
                var respuesta = (from x in conexion.Animales
                                 where x.idAnimal == entidad.idAnimal
                                 select x).FirstOrDefault();
                if (respuesta != null)
                {
                    respuesta.nombre = entidad.Nombre;
                    respuesta.descripcion = entidad.Descripcion;
                    respuesta.idTipoAnimal = entidad.tipoAnimal; 
                    conexion.SaveChanges(); 
                }
            }
        }

        public void CambiarEstadoAnimal(long q)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                var respuesta = (from x in conexion.Animales
                                 where x.idAnimal == q
                                 select x).FirstOrDefault();
                if (respuesta != null) 
                {
                    var estadoActual = respuesta.estado;
                    respuesta.estado = (estadoActual == true ? false : true);
                    conexion.SaveChanges();    
                }
            }
        }

    }
}