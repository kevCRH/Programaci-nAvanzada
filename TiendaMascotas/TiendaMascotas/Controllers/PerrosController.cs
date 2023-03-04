using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaMascotas.Controllers
{
    public class PerrosController : Controller
    {

        [HttpGet]
        public ActionResult AdopcionPerros()
        {
            return View();
        }
    }
}