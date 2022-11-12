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

        // ADMINISTRACION UNIDADES CRUD
        public ActionResult AdministracionUnidades()
        {
            ViewBag.unidad = new Negocio.Unidad().ReadAll();
            
            return View();
        }

        

        public ActionResult CreateUnidad()
        {
            EnviarEstado();
            EnviarCategorias();
            return View();
        }

        private void EnviarCategorias()
        {
            ViewBag.procesos = new Proceso().ReadAll();
        }
        private void EnviarEstado()
        {
            ViewBag.estado = new Negocio.Estado().ReadAll();
        }

        [HttpPost]
        public ActionResult CreateUnidad([Bind(Include = "id_unidad ,id_proceso_uni ,id_estado_uni,id_empresa_uni,nombre_unidad,fecha_inicio,clave,fecha_termino,proceso,estado,empresa")] Empleado empleado)
        {
            try
            {
                // TODO: Add insert logic here
                empleado.Create();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("AdministracionUnidades", "Empresa");
            }
            catch
            {
                return View();
            }
        }
        //FIN CRUD

        // ADMINISTRACION USUARIOS CRUD
        public ActionResult AdministracionUsuarios()
        {
            ViewBag.empleados = new Negocio.Empleado().ReadAll();
            return View();
        }

        public ActionResult CreateEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmpleado([Bind(Include = "id_rut ,id_empresa_emp,id_rol_emp,fecha_ingreso,nombre_emp,usuario,clave,empresa,rol")] Empleado empleado)
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
        //FIN CRUD


        // ADMINISTRACION PROCESOS CRUD
        public ActionResult AdministracionProcesos()
        {
            ViewBag.procesos = new Negocio.Proceso().ReadAll();
            return View();
        }

        public ActionResult CreateProceso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProceso([Bind(Include = "id_proceso,id_estado_pro,id_empresa_pro,nombre_proceso,fecha_inicio,fecha_termino")]Proceso proceso)
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
        // FIN CRUD


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

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
