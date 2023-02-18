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
        [HttpGet]

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult login()
        {


            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(UsuariosEnt entidad) {

            model = new UsuariosModel();            
            var resultado = model.ValidarUsuario(entidad);

            if (resultado) //Es lo mismo que decir: "resultado = true"
                return View("Index"); //Si es solo una línea de código, se pueden quitar las llaves y se simplifica el código
            else
                return View();
        }

        public ActionResult Register(UsuariosEnt entidad) {

            return View();
        }


    }
}