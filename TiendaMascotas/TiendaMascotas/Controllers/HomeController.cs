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
                model.RegistrarBitacora("Método ActionResult Index", ex.Message);
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
                model.RegistrarBitacora("Método ActionResult login", ex.Message);
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
                model.RegistrarBitacora("Método IniciarSesion", ex.Message);
                ViewBag.mensaje = "Creedencialas no se validaron";
                return View("login");
            }

        }

        [HttpPost]
        public ActionResult Registrar(UsuariosEnt entidad)
        {
            try
            {
                model.Registrar(entidad);
                return View("login");
            }
            catch (Exception ex)
            {
                model.RegistrarBitacora("Método ActionResult Registrar", ex.Message);
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
                model.RegistrarBitacora("Método ActionResult ValidarRegistrar", ex.Message);
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }
    }
}