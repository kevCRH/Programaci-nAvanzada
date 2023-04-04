using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using TiendaMascotas.Entities;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace TiendaMascotas.Models
{
    public class AnimalesModel
    {
        public List<AnimalesEnt> MostrarAnimales()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44331/api/MostrarAnimales";
          
                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<List<AnimalesEnt>>().Result;

                return new List<AnimalesEnt>();
            }
        }

        public List<SelectListItem> ConsultarAnimales()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44331/api/ConsultarAnimales";

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["Token"].ToString());

                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadFromJsonAsync<List<TiposAnimalesEnt>>().Result;

                    List<SelectListItem> AnimalesCombo = new List<SelectListItem>();
                    foreach (var item in datos)
                    {
                        AnimalesCombo.Add(new SelectListItem
                        {
                            Value = item.idTipoAnimal.ToString(),
                            Text = item.tiposAnimal.ToString()
                        });
                    }
                    return AnimalesCombo;
                }

                return new List<SelectListItem>();
            }
        }

        public AnimalesEnt ConsultarAnimal(long q)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44331/api/ConsultarAnimal?q="+q;
                
                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();
                
                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<AnimalesEnt>().Result;

                return new AnimalesEnt();
            }
        }

        public int RegistrarAnimal(AnimalesEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/RegistrarAnimal";
                HttpResponseMessage respuesta = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public void ActualizarAnimales(AnimalesEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/ActualizarAnimales";
                HttpResponseMessage respuesta = client.PutAsync(url, body).GetAwaiter().GetResult();
            }
        }

        public void CambiarEstadoAnimal(long id) 
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44331/api/CambiarEstadoAnimal?q=" + id;
                HttpResponseMessage respuesta = client.DeleteAsync(url).GetAwaiter().GetResult();
            }
        }

    }
}