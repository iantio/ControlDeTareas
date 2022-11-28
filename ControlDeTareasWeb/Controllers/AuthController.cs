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


                empleado = new Empleado().Find(empleado.usuario);

                Session["id_rut"] = empleado.id_rut;
                Session["id_empresa_emp"] = empleado.id_empresa_emp;
                Session["id_rol_emp"] = empleado.id_rol_emp;
                Session["fecha_ingreso"] = empleado.fecha_ingreso;
                Session["nombre_emp"] = empleado.nombre_emp;

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
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}