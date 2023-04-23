using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using TiendaMascotas.Entities;

namespace TiendaMascotas.Models
{
    public class PagosModel
    {

        
        public int ValidarStock()
        {
            using (var client = new HttpClient())
            {
                PagosEnt entidad = new PagosEnt();
                entidad.IdUsuario = int.Parse(HttpContext.Current.Session["Consecutivo"].ToString());

                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/validarStock";
                HttpResponseMessage respuesta = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }



        public void ConfirmarPago()
        {
            using (var client = new HttpClient())
            {
                PagosEnt entidad = new PagosEnt();
                entidad.IdUsuario = int.Parse(HttpContext.Current.Session["Consecutivo"].ToString());

                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/ConfirmarPago";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["Token"].ToString());
                HttpResponseMessage respuesta = client.PostAsync(url, body).GetAwaiter().GetResult();
            }
        }

        public List<PagosEnt> MostrarFacturas()
        {
            using (var client = new HttpClient())
            {
                int IdUsuario = int.Parse(HttpContext.Current.Session["Consecutivo"].ToString());
                string url = "https://localhost:44331/api/MostrarFacturas?IdUsuario=" + IdUsuario;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["Token"].ToString());
                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<List<PagosEnt>>().Result;

                return new List<PagosEnt>();
            }
        }


    }
}