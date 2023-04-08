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
    public class HomeController : Controller
    {

        UsuariosModel Usuariosmodel = new UsuariosModel();
        LogsModel LogsModel = new LogsModel();

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
                Session.Clear();
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

            //string mensaje = string.Empty;
            try
            {
                Usuariosmodel = new UsuariosModel();
                var resultado = Usuariosmodel.ValidarUsuario(entidad);
                if (resultado != null) //Es lo mismo que decir: "resultado = true"
                {
                    Session["Consecutivo"] = resultado.idUsuario; 
                    Session["NombreUsuario"] = resultado.Nombre;
                    Session["Cedula"] = resultado.Cedula;
                    Session["Token"] = resultado.Token;
                    //Session["rol"] = resultado.rol;
                    return View("Index");
                }
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
                if (Usuariosmodel.Registrar(entidad) > 0)
                    return View("login");
                else
                {
                    ViewBag.mensaje = "Creedencialas no se validaron";
                    return View("login");
                }

            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View("index");
            }
        }

        [HttpPost]
        public ActionResult ValidarRegistrar(string validar)
        {
            try
            {
                return Json(Usuariosmodel.ValidarRegistrar(validar), JsonRequestBehavior.AllowGet);
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
                Usuariosmodel.RecuperarContrasenna(entidad);
                    return View("Index");
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View("login");
            }
        }
        
        [HttpPost]
        public ActionResult Contactenos(ContactenosEnt entidad)
        {
            try
            {
                Usuariosmodel.Contactenos(entidad);
                return View("Index");
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View("login");
            }
        }

        [HttpGet]
        [FiltroSesion]
        public ActionResult Cerrarsesion()
        {
            try
            {
                Session.Clear();
                return View("Index");
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View("Index");
            }
        }
        



        public void RegistrarLog(Exception ex)
        {
            LogsEnt log = new LogsEnt();
            log.origen = ControllerContext.RouteData.Values["controller"].ToString() + "-" + ControllerContext.RouteData.Values["action"].ToString();
            log.mensajeError = ex.Message;
            LogsModel.RegistrarBitacora(log);
        } 

    }
}