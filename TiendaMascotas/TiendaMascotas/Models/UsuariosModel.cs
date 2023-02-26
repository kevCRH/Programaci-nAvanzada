using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using TiendaMascotas.Entities;
using TiendaMascotas.ModeloBD;

namespace TiendaMascotas.Models
{
    public class UsuariosModel
    {

        public bool ValidarUsuario(UsuariosEnt entidad)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/ValidarUsuario";
                HttpResponseMessage respuesta = cliente.PostAsync(url, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<bool>().Result;
                }
                return false;
            }

        }

        public void Registrar(UsuariosEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                conexion.Registrar(entidad.Nombre, entidad.Cedula, entidad.NombreUsuario, entidad.Contrasenna);
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

        public void RegistrarBitacora(string origen, string mensajeError)
        {
            using (var conexion = new ProyectoPAEntities()) /*Podríamos hacer un proc. almacenado desde la BD, o dejarlo así*/
            {
                Bitacoras bitacora = new Bitacoras();
                bitacora.fechaHora = DateTime.Now;
                bitacora.origen= origen;
                bitacora.mensajeError= mensajeError;

                conexion.Bitacoras.Add(bitacora);
                conexion.SaveChanges();
            }
        }
    }
}