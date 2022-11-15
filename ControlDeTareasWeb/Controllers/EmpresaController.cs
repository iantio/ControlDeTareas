using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ControlDeTareasWeb.Negocio;

namespace ControlDeTareasWeb.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
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

        ////// ADMINISTRACION UNIDADES CRUD //////
        public ActionResult AdministracionUnidades()
        {
            ViewBag.unidad = new Negocio.Unidad().ReadAll();
            
            return View();
        }

        

        public ActionResult CreateUnidad()
        {
            EnviarEstado();
            EnviarCategorias();
            EnviarEmpresa();
            return View();
        }


        [HttpPost]
        public ActionResult CreateUnidad([Bind(Include = "id_unidad, nombre_unidad, id_proceso_uni, id_estado_uni, ID_EMPRESA_UNI, fecha_inicio, fecha_termino")] Unidad unidad)
        {
            try
            {
                // TODO: Add insert logic here
                unidad.Create();
                TempData["mensaje"] = "Guardado correctamente";
                
                return RedirectToAction("AdministracionUnidades", "Empresa");
            }
            catch
            {
                return View();
            }
        }
        ////// FIN CRUD //////

        ////// ADMINISTRACION USUARIOS CRUD //////
        public ActionResult AdministracionUsuarios()
        {
            ViewBag.empleados = new Negocio.Empleado().ReadAll();
            return View();
        }

        public ActionResult CreateEmpleado()
        {
            EnviarEmpresa();
            EnviarRol();
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmpleado([Bind(Include = "ID_RUT ,ID_EMPRESA_EMP, ID_ROL_EMP, FECHA_INGRESO, NOMBRE_EMP, USUARIO, CLAVE,")] Empleado empleado)
        {
            try
            {
                // TODO: Add insert logic here
                empleado.Create();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("AdministracionUsuarios", "Empresa");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteEmpleado(int id)
        {

            if (new Empleado().Delete(id))
            {
                TempData["mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("AdministracionUsuarios");
            }

            TempData["mensaje"] = "No se a podido eliminar Empleado";
            return RedirectToAction("AdministracionProcesos");
        }
        ////// FIN CRUD //////


        ////// ADMINISTRACION PROCESOS CRUD //////
        public ActionResult AdministracionProcesos()
        {
            ViewBag.procesos = new Negocio.Proceso().ReadAll();
            return View();
        }

        public ActionResult CreateProceso()
        {
            EnviarEstado();
            EnviarEmpresa();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProceso([Bind(Include = "ID_PROCESO, ID_ESTADO_PRO, ID_EMPRESA_PRO, NOMBRE_PROCESO, FECHA_INICIO, FECHA_TERMINO")]Proceso proceso)
        {
            try
            {
                // TODO: Add insert logic here
                proceso.Create();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("AdministracionProcesos","Empresa");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteProceso(int id)
        {

            if (new Proceso().Delete(id))
            {
                TempData["mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("AdministracionProcesos");
            }

            TempData["mensaje"] = "Una unidad esta utilizando este proceso!";
            return RedirectToAction("AdministracionProcesos");
        }
        ////// FIN CRUD //////

        ////// VARIABLES GLOGABLES //////
        private void EnviarCategorias()
        {
            ViewBag.procesos = new Proceso().ReadAll();
        }
        private void EnviarEstado()
        {
            ViewBag.estado = new Negocio.Estado().ReadAll();
        }

        private void EnviarEmpresa()
        {
            ViewBag.empresa = new Negocio.Empresa().ReadAll();
        }

        private void EnviarRol()
        {
            ViewBag.rol = new Negocio.Rol().ReadAll();
        }

        ////// //////















        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empresa/Create       

        // POST: Empresa/Create
        
        

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        // POST: Empresa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
