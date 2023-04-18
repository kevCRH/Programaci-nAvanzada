﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using TiendaMascotas.Entities;
using System.Web.Mvc;

namespace TiendaMascotas.Models
{
    public class AdopcionesModel
    {

        public int RegistrarAdopciones(AdopcionesEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/RegistrarAdopciones";
                HttpResponseMessage respuesta = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<AdopcionesEnt> MostrarAdopciones()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44331/api/MostrarAdopciones";

                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<List<AdopcionesEnt>>().Result;

                return new List<AdopcionesEnt>();
            }
        }

        public void CambiarEstadoAdopcion(int idAdopcion, int id, UsuariosEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/CambiarEstadoAdopcion?q=" + idAdopcion + "&e="+ id;
                HttpResponseMessage respuesta = client.PostAsync(url, body).GetAwaiter().GetResult();
            }
        }
    }
}