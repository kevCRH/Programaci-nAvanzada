using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.App_Start;
using TiendaMascotas.Entities;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class GatosController : Controller
    {
        AnimalesModel model = new AnimalesModel();
        LogsModel LogsModel = new LogsModel();

        [HttpGet]
        public ActionResult AdopcionGatos()
        {
            try
            {
                var resultado = model.MostrarAnimales();
                return View(resultado);
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View();
            }
        }

        [HttpGet]
        //[FiltroSesion]
        public ActionResult FormGato()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View();
            }
        }

        [HttpGet]
        //[FiltroSesion]
        public ActionResult RegistrarAnimal()
        {
            try
            {
                ViewBag.ListadoAnimales = model.ConsultarAnimales();
                return View();
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View();
            }
        }

        [HttpPost]
        //[FiltroSesion]
        public ActionResult RegistrarAnimal([Bind(Include = "Nombre, tipoAnimal,Descripcion")] AnimalesEnt entidad, HttpPostedFileBase imagen1)
        {
            try
            {
                entidad.imagen = new byte[imagen1.ContentLength];
                imagen1.InputStream.Read(entidad.imagen, 0, imagen1.ContentLength);
                if (model.RegistrarAnimal(entidad) > 0)
                {
                    var resultado = model.MostrarAnimales();
                    return View("AdopcionGatos", resultado);
                }
                else
                {
                    ViewBag.mensaje = "Creedencialas no se validaron";
                    return View();
                }
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View();
            }
        }

        [HttpGet]
        //[FiltroSesion]
        public ActionResult ActualizarAnimales(long q)
        {
            try
            {
                var resultado = model.ConsultarAnimal(q);
                ViewBag.ListadoAnimales = model.ConsultarAnimales();
                return View(resultado);
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View();
            }
        }

        [HttpPost]
        //[FiltroSesion]
        public ActionResult ActualizarAnimales([Bind(Include = "idAnimal, Nombre, tipoAnimal,Descripcion")] AnimalesEnt entidad, HttpPostedFileBase imagen1)
        {
            try
            {
                entidad.imagen = new byte[imagen1.ContentLength];
                if (entidad.imagen != null)
                {
                    imagen1.InputStream.Read(entidad.imagen, 0, imagen1.ContentLength);
                    model.ActualizarAnimales(entidad);
                    return RedirectToAction("AdopcionGatos", "Gatos");
                }
                else
                {
                    model.ActualizarAnimales(entidad);
                    return RedirectToAction("AdopcionGatos", "Gatos");
                }      
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View();
            }
        }

        [HttpPost]
        //[FiltroSesion]
        public ActionResult CambiarEstado(long id)
        {
            model.CambiarEstadoAnimal(id);
            return Json("Ok", JsonRequestBehavior.AllowGet);
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