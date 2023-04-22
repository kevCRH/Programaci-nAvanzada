using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using TiendaMascotas.App_Start;
using TiendaMascotas.Entities;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class HomeController : Controller
    {

        UsuariosModel Usuariosmodel = new UsuariosModel();
        LogsModel LogsModel = new LogsModel();
        ProductosModel productosModel = new ProductosModel();
        AdopcionesModel adopcionesModel = new AdopcionesModel();

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
                if (resultado != null)
                {
                    Session["Consecutivo"] = resultado.idUsuario; 
                    Session["NombreUsuario"] = resultado.Nombre;
                    Session["Cedula"] = resultado.Cedula;
                    Session["Correo"] = resultado.CorreoElectronico;
                    Session["Token"] = resultado.Token;
                    //Consultar los productos
                    var datos = productosModel.MostrarProductos();
                    var Temporal = productosModel.MostrarCompraCarrito();
                    Session["CantidadCompra"] = Temporal.CantidadCompra;
                    Session["MontoCompra"] = Temporal.MontoCompra;
                    Session["rol"] = resultado.Rol;
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


        [HttpGet]
        //[FiltroPersonalizadoSesion]
        public ActionResult IniciarSesion()
        {
            try
            {
                //Consultar los productos
                var datos = productosModel.MostrarProductos();
                var Temporal = productosModel.MostrarCompraCarrito();
                Session["CantidadCompra"] = Temporal.CantidadCompra;
                Session["MontoCompra"] = Temporal.MontoCompra;

                return View(datos);
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View("Index");
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


        [HttpGet]
        //[FiltroSesion]
        public ActionResult SolicitudesAdopcion()
        {
            try
            {
                var resultado = adopcionesModel.MostrarAdopciones();
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
        public ActionResult ListadoAdopcion()
        {
            try
            {
                var resultado = adopcionesModel.MostrarAdopciones();
                return View(resultado);
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View();
            }
        }

        [HttpPost]
        public ActionResult SolicitarAdopcion(int idAnimal, string Cedula)
        {
            AdopcionesEnt adopcion = new AdopcionesEnt();

            adopcion.idAnimal = idAnimal;
            adopcion.cedula = Cedula;
            adopcionesModel.RegistrarAdopciones(adopcion);
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        //

        public void RegistrarLog(Exception ex)
        {
            LogsEnt log = new LogsEnt();
            log.origen = ControllerContext.RouteData.Values["controller"].ToString() + "-" + ControllerContext.RouteData.Values["action"].ToString();
            log.mensajeError = ex.Message;
            LogsModel.RegistrarBitacora(log);
        } 

    }
}