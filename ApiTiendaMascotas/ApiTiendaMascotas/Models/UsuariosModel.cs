using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.ModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaMascotas.Models
{
    public class UsuariosModel
    {
        public bool ValidarUsuario(UsuariosEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities()) /*Si no se usa el using, hay que cerrar la conexión al final con: "conexion.dispose()"*/
            {
                var respuesta = conexion.ValidarUsuario(entidad.NombreUsuario, entidad.Contrasenna).FirstOrDefault(); /*Siempre que vaya consultar algo donde espere una sola respuesta*/

                if (respuesta != null)
                    return true;
                else
                    return false;
            }
        }

        public int Registrar(UsuariosEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                return conexion.Registrar(entidad.Nombre, entidad.Cedula, entidad.NombreUsuario, entidad.Contrasenna);
            }
        }

        public string ValidarRegistrar(string validar)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                var respuesta = (from x in conexion.Usuarios
                                 where x.nombreUsuario == validar
                                 select x).FirstOrDefault();

                if (respuesta == null)
                    return string.Empty;
                else
                {
                    if (respuesta.estado == false)
                        return "El nombre de usuario se encuentra inactivo";
                    else
                        return "Es Usuario ya está registrado";
                }
            }
        }
    }
}