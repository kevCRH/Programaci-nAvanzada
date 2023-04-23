using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TiendaMascotas.Entities;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    //[FiltroPersonalizadoSesion]
    public class PagosController : Controller
    {
        PagosModel pagosModel = new PagosModel();
        ProductosModel productosModel = new ProductosModel();
        LogsModel LogsModel = new LogsModel();
        ProductosModel model2 = new ProductosModel();

        [HttpPost]
        public ActionResult ConfirmarPago()
        {
            try
            {
                
                if (pagosModel.ValidarStock() == 1)
                {
                    pagosModel.ConfirmarPago();

                    var Temporal = productosModel.MostrarCompraCarrito();
                    Session["CantidadCompra"] = Temporal.CantidadCompra;
                    Session["MontoCompra"] = Temporal.MontoCompra;

                    return Json("Ok", JsonRequestBehavior.AllowGet);
                    
                }
                else
                {
                    throw new Exception("Hay un producto en el carrito que ya no se encuentra disponible.");
                }

            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                Session["ErrorMessage"] = "Error al pagar: " + ex.Message;
                return RedirectToAction("ProductoCarrito", "Productos");
            }
        }


        [HttpGet]
        public ActionResult MostrarFacturas()
        {
            try
            {
                var datos = pagosModel.MostrarFacturas();
                return View(datos);
            }
            catch (Exception ex)
            {
                RegistrarLog(ex);
                return View();
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