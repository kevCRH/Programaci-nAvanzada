﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using TiendaMascotas.Entities;

namespace TiendaMascotas.Models
{
    public class UsuariosModel
    {

        public UsuariosEnt ValidarUsuario(UsuariosEnt entidad)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/ValidarUsuario";
                HttpResponseMessage respuesta = cliente.PostAsync(url, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<UsuariosEnt>().Result;
                }
                return null;
            }

        }

        public int Registrar(UsuariosEnt entidad)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/Registrar";
                HttpResponseMessage respuesta = cliente.PostAsync(url, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<int>().Result;
                }
                return 0;
            }
        }

        public string ValidarRegistrar(string validar)
        {
            using (var cliente = new HttpClient())
            {
                string url = "https://localhost:44331/api/ValidarRegistrar?validar=" + validar;

                HttpResponseMessage respuesta = cliente.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<string>().Result;
                }
                return "ERROR";
            }
        }

        public void RecuperarContrasenna(UsuariosEnt entidad)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/RecuperarContrasenna";
                HttpResponseMessage respuesta = cliente.PostAsync(url, body).GetAwaiter().GetResult();

            }
        }

        public void Contactenos(ContactenosEnt entidad)
        {
            using (var cliente = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/Contactenos";
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["Token"].ToString());
                HttpResponseMessage respuesta = cliente.PostAsync(url, body).GetAwaiter().GetResult();
            }
        }
    }
}