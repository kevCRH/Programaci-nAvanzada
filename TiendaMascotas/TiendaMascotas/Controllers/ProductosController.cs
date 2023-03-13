using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.App_Start;

namespace TiendaMascotas.Controllers
{
    public class ProductosController : Controller
    {

        [HttpGet]
        public ActionResult ProductosVenta()
        {
            return View();
        }

        [HttpGet]
        [FiltroSesion]
        public ActionResult ProductoCarrito()
        {
            return View();
        }
    }
}