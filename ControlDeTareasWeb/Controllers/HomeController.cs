using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ControlDeTareasWeb.Negocio;

using ControlDeTareasWeb.DAL;
using ControlDeTareasWeb.Controllers;
using System.Web.Security;

namespace ControlDeTareasWeb.Controllers
{
    public class HomeController : Controller
    {        
        Empleado sesion { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(EMPLEADO objUser)
        {
            if (ModelState.IsValid)
            {
                using (ControlDeTareasEntities db = new ControlDeTareasEntities())
                {
                    var obj = db.EMPLEADO.Where(a => a.USUARIO.Equals(objUser.USUARIO) && a.CLAVE.Equals(objUser.CLAVE)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.ID_RUT.ToString();
                        Session["UserName"] = obj.USUARIO.ToString();                  
                        return RedirectToAction("Index", "Empresa");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        //sesion = new Empleado();

        //sesion.Find(txtUsuario);

        //return View();
        //if (sesion.usuario == txtUsuario && sesion.clave == txtPassword && sesion.empresa.nombre_empresa == txtEmpresa)
        //{

        //}
        //else
        //{
        //    Console.WriteLine("asd");         
        //}




        public ActionResult OlvContrasena()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        public ActionResult Empresa()
        {
            return View();
        }
            
    }

}