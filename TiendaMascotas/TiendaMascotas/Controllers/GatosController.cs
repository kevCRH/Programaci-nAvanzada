﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.App_Start;

namespace TiendaMascotas.Controllers
{
    public class GatosController : Controller
    {
        
        [HttpGet]
        public ActionResult AdopcionGatos()
        {
            return View();
        }

        [HttpGet]
        [FiltroSesion]
        public ActionResult FormGato()
        {
            return View();
        }
    }
}