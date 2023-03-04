using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Entities;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class HomeController : Controller
    {

        UsuariosModel model = new UsuariosModel();

        //Abrir vistas

        [HttpGet]
        public ActionResult Index()
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
        public ActionResult login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View("Index");
            }
        }


        //Generar métodos
        [HttpPost]
        public ActionResult IniciarSesion(UsuariosEnt entidad) {

            string mensaje = string.Empty;
            try
            {
                model = new UsuariosModel();
                var resultado = model.ValidarUsuario(entidad);
                if (resultado) //Es lo mismo que decir: "resultado = true"
                    return View("Index"); //Si es solo una línea de código, se pueden quitar las llaves y se simplifica el código
                else
                {
                    ViewBag.mensaje = "Creedencialas no se validaron";
                    return View("login");
                }
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                ViewBag.mensaje = "Creedencialas no se validaron";
                return View("login");
            }

        }

        [HttpPost]
        public ActionResult Registrar(UsuariosEnt entidad)
        {
            try
            {
                if (model.Registrar(entidad) > 0)
                    return View("Index");
                else
                {
                    ViewBag.mensaje = "Creedencialas no se validaron";
                    return View("login");
                }

            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View("login");
            }
        }

        [HttpPost]
        public ActionResult ValidarRegistrar(string validar)
        {
            try
            {
                return Json(model.ValidarRegistrar(validar), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpGet]
        public ActionResult RecuperarContrasenna()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View("login");
            }
        }



        [HttpPost]
        public ActionResult RecuperarContrasenna(UsuariosEnt entidad)
        {
            try
            {
                model.RecuperarContrasenna(entidad);
                    return View("Index");
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View("login");
            }
        }


        public void RegistrarLog(Exception ex)
        {
            LogsEnt log = new LogsEnt();
            log.origen = ControllerContext.RouteData.Values["controller"].ToString() + "-" + ControllerContext.RouteData.Values["action"].ToString();
            log.mensajeError = ex.Message;
            model.RegistrarBitacora(log);
        } 

    }
}