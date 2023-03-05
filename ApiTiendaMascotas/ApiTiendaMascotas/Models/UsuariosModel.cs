using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.ModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Xml;

namespace ApiTiendaMascotas.Models
{

    public class UsuariosModel
    {

        LogsModel modeloLogs = new LogsModel();

        public UsuariosEnt ValidarUsuario(UsuariosEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities()) /*Si no se usa el using, hay que cerrar la conexión al final con: "conexion.dispose()"*/
            {
                var datosBD = conexion.ValidarUsuario(entidad.CorreoElectronico, entidad.Contrasenna).FirstOrDefault(); /*Siempre que vaya consultar algo donde espere una sola respuesta*/

                if (datosBD == null)
                    return null;

                UsuariosEnt respuesta = new UsuariosEnt();
                respuesta.idUsuario = datosBD.idUsuario;
                respuesta.Nombre= datosBD.nombre;
                respuesta.Estado = datosBD.estado;


                return respuesta;
            }
        }

        public int Registrar(UsuariosEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                return conexion.Registrar(entidad.Nombre, entidad.CorreoElectronico, entidad.Cedula, entidad.CorreoElectronico, entidad.Contrasenna);
            }
        }

        public string ValidarRegistrar(string validar)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                var respuesta = (from x in conexion.Usuarios
                                 where x.correoElectronico == validar
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

        public void RecuperarContrasenna(UsuariosEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                var respuesta = (from x in conexion.Usuarios
                                 where x.correoElectronico == entidad.CorreoElectronico
                                 select x).FirstOrDefault();

                if (respuesta != null)
                {
                    String asunto = "Recuperar la contraseña"; 
                    String body = "Su contraseña es: <br> " + respuesta.contrasenna + "<br><br> Favor no contestar este correo";
                    modeloLogs.EnviarCorreo(entidad.CorreoElectronico, asunto, body);
                }
            }
        }

        public void Contactenos(ContactenosEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                String nombre = entidad.Nombre;
                String correo = entidad.CorreoElectronico;
                String mensaje = entidad.Mensaje;
                modeloLogs.RecibirCorreo(nombre, correo, mensaje);
            }
        }
    }
}