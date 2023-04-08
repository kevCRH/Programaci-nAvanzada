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
    public class ProductosModel
    {
        public List<ProductoEnt> MostrarProductos()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44331/api/MostrarProductos";

                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;

                return new List<ProductoEnt>();
            }
        }

        /*//TIPO PRODUCTO (ELIMINADO)
        public List<SelectListItem> ConsultarProducto()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44331/api/ConsultarProductos";

            

                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadFromJsonAsync<List<TipoProductoEnt>>().Result;

                    List<SelectListItem> ProductosCombo = new List<SelectListItem>();
                    foreach (var item in datos)
                    {
                        ProductosCombo.Add(new SelectListItem
                        {
                            Value = item.idTipoProducto.ToString(),
                            Text = item.TipoProducto.ToString()
                        });
                    }
                    return ProductosCombo;
                }

                return new List<SelectListItem>();
            }
        }*/

        public int RegistrarProducto( ProductoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/RegistrarProducto";
                HttpResponseMessage respuesta = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }



    }
}