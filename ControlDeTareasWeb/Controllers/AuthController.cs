using ControlDeTareasWeb.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControlDeTareasWeb.Controllers
{
    public class AuthController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Empleado empleado, string ReturnUrl)
        {
            if (IsValid(empleado))
            {
                FormsAuthentication.SetAuthCookie(empleado.usuario, false);

                if(ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }

                return RedirectToAction("Index", "Empresa");
            }

            TempData["mensaje"] = "Credenciales Incorrectas";
            return View(empleado);
        }

        private bool IsValid(Empleado empleado)
        {
            return empleado.Autenticar();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}