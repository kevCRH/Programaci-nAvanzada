﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using TiendaMascotas.Entities;
using System.Net.Http.Json;
using System.Web.Mvc;
using System.ComponentModel;


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

        public ProductoEnt ConsultarProducto(long q)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44331/api/ConsultarProducto?q=" + q;

                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ProductoEnt>().Result;

                return new ProductoEnt();
            }
        }

        public void ActualizarProducto(ProductoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/ActualizarProducto";
                HttpResponseMessage respuesta = client.PutAsync(url, body).GetAwaiter().GetResult();
            }
        }

        
        public void ActualizarCarrito(int idProducto, int cantidad)
        {
            using (var client = new HttpClient())
            {
                ProductoEnt entidad = new ProductoEnt();
                entidad.idProducto = idProducto;
                entidad.cantidad = cantidad;
                entidad.ConsecutivoUsuario = int.Parse(HttpContext.Current.Session["Consecutivo"].ToString());


                JsonContent body = JsonContent.Create(entidad);
                string url = "https://localhost:44331/api/ActualizarCarrito";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["Token"].ToString());
                HttpResponseMessage respuesta = client.PutAsync(url, body).GetAwaiter().GetResult();
            }
        }

        public void EliminarProducto(int id)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44331/api/EliminarProducto?q=" + id;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["Token"].ToString());
                HttpResponseMessage respuesta = client.DeleteAsync(url).GetAwaiter().GetResult();
            }
        }

        public CompraEnt MostrarCompraCarrito()
        {
            using (var client = new HttpClient())
            {
                int idUsuario = int.Parse(HttpContext.Current.Session["Consecutivo"].ToString());
                string url = "https://localhost:44331/api/MostrarCompraCarrito?idUsuario=" + idUsuario;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["Token"].ToString());
                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<CompraEnt>().Result;

                return new CompraEnt();
            }
        }

        public List<DetalleComprasEnt> MostrarDetalleCarrito()
        {
            using (var client = new HttpClient())
            {
                int idUsuario = int.Parse(HttpContext.Current.Session["Consecutivo"].ToString());
                string url = "https://localhost:44331/api/MostrarDetalleCarrito?idUsuario=" + idUsuario;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Current.Session["Token"].ToString());
                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<List<DetalleComprasEnt>>().Result;

                return new List<DetalleComprasEnt>();
            }
        }

    }
}