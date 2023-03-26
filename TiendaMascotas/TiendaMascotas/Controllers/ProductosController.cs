using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.App_Start;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class ProductosController : Controller
    {

        ProductosModel model = new ProductosModel();

        [HttpGet]
        public ActionResult AgregarProducto()
        {
            try
            {
                //var resultado = model.MostrarAnimales();
                return View();
            }
            catch (Exception ex)
            {
                //RegistrarLog(ex);
                return View();
            }
        }

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