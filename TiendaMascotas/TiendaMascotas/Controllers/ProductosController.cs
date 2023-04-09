﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.App_Start;
using TiendaMascotas.Entities;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class ProductosController : Controller
    {

        ProductosModel model = new ProductosModel();
        LogsModel LogsModel = new LogsModel();

        [HttpGet]
        public ActionResult ProductosVenta()
        {
            try
            {

                var resultado = model.MostrarProductos();
                return View(resultado);
            }
            catch (Exception ex)
            {
               // RegistrarLog(ex);
                return View();
            }

        }
        [HttpGet]
        //[FiltroSesion]
        public ActionResult RegistrarProducto()
        {
            try
            {
                ViewBag.ListadoProductos = model.MostrarProductos();// antes era: ViewBag.ListadoProductos = model.ConsultarProducto();
                return View();
            }
            catch (Exception ex)
            {
               // RegistrarLog(ex);
                return View();
            }
        }

        [HttpPost]
        //[FiltroSesion]
        public ActionResult RegistrarProducto([Bind(Include = "nombre, descripcion,cantidad,precio,descuento")] ProductoEnt entidad, HttpPostedFileBase imagen1)
        {
            try
            {
                entidad.imagen = new byte[imagen1.ContentLength];
                imagen1.InputStream.Read(entidad.imagen, 0 , imagen1.ContentLength);

                if (model.RegistrarProducto(entidad) > 0)
                {
                    var resultado = model.MostrarProductos();
                    return View("ProductosVenta", resultado);
                }
                else
                {
                    ViewBag.mensaje = "Los datos no se validaron";
                    return View();
                }
            }
            catch (Exception ex)
            {
                //RegistrarLog(ex);
                return View();
            }
        }

        [HttpGet]
        [FiltroSesion]
        public ActionResult FormProductos()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                //RegistrarLog(ex);
                return View();
            }
        }

        //Metodo registrar bitacora
        public void RegistrarLog(Exception ex)
        {
            LogsEnt log = new LogsEnt();
            log.origen = ControllerContext.RouteData.Values["controller"].ToString()
                + "-" + ControllerContext.RouteData.Values["action"].ToString();
            log.mensajeError = ex.Message;
            LogsModel.RegistrarBitacora(log);
        }


    }
}