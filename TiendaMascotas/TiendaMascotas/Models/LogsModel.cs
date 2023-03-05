using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using TiendaMascotas.Entities;

namespace TiendaMascotas.Models
{
    public class LogsModel
    {
        public void RegistrarBitacora(LogsEnt entidad)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/RegistrarBitacora";
                HttpResponseMessage respuesta = cliente.PostAsync(url, body).GetAwaiter().GetResult();
            }
        }
    }
}