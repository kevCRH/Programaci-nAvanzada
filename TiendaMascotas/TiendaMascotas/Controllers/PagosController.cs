using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    //[FiltroPersonalizadoSesion]
    public class PagosController : Controller
    {
        PagosModel pagosModel = new PagosModel();
        ProductosModel productosModel = new ProductosModel();

        [HttpPost]
        public ActionResult ConfirmarPago()
        {
            pagosModel.ConfirmarPago();

            var Temporal = productosModel.MostrarCompraCarrito();
            Session["CantidadCompra"] = Temporal.CantidadCompra;
            Session["MontoCompra"] = Temporal.MontoCompra;

            return RedirectToAction("MostrarFacturas", "Pagos");
        }

        [HttpGet]
        public ActionResult MostrarFacturas()
        {
            var datos = pagosModel.MostrarFacturas();
            return View(datos);
        }


    }
}