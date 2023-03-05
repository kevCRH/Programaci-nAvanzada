using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.ModeloBD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
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
        public void EnviarCorreo(string CorreoElectronico, string asunto, string body)
        {
            string correoSMTP = ConfigurationManager.AppSettings["correoSMTP"].ToString();
            string claveSMTP = ConfigurationManager.AppSettings["claveSMTP"].ToString();

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(CorreoElectronico, "Usuario"));
            msg.From = new MailAddress(correoSMTP, "Administrador");
            msg.Subject = asunto;
            msg.Body = body;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(correoSMTP, claveSMTP);
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Send(msg);
        }

        public void RecibirCorreo(string nombre, string correo, string mensaje)
        {
            string correoSMTP = ConfigurationManager.AppSettings["correoSMTP"].ToString();
            string claveSMTP = ConfigurationManager.AppSettings["claveSMTP"].ToString();

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(correoSMTP, nombre));
            msg.From = new MailAddress(correoSMTP, "Mensaje de usuario");
            msg.Subject = "Mensaje departe de: " + nombre;
            msg.Body = mensaje;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(correoSMTP, claveSMTP);
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Send(msg);
        }
    }
}

