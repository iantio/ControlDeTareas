using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ControlDeTareasWeb.Negocio;

namespace ControlDeTareasWeb.Controllers
{
    [Authorize]
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            return View();
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
            ViewBag.unidad = new Negocio.Unidad().Read(Decimal.Parse(Session["id_empresa_emp"].ToString()));
            
            return View();
        }

        

        public ActionResult CreateUnidad()
        {
            EnviarEstado();
            EnviarProcesos();
            EnviarEmpresa();
            return View();
        }


        [HttpPost]
        public ActionResult CreateUnidad([Bind(Include = "nombre_unidad, id_proceso_uni, id_estado_uni, fecha_inicio, fecha_termino")] Unidad unidad)
        {
            try
            {
                
                unidad.id_empresa_uni = int.Parse(Session["id_empresa_emp"].ToString());
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
            ViewBag.empleados = new Negocio.EmpleadoCollection().ReadByEmpresa(Decimal.Parse(Session["id_empresa_emp"].ToString()));
            return View();
        }

        public ActionResult CreateEmpleado()
        {
            EnviarEmpresa();
            EnviarRol();
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmpleado([Bind(Include = "ID_RUT , ID_ROL_EMP, FECHA_INGRESO, NOMBRE_EMP, USUARIO, CLAVE,")] Empleado empleado)
        {
            try
            {
                empleado.id_empresa_emp = int.Parse(Session["id_empresa_emp"].ToString());
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
            Empleado empleadoeliminar = new Empleado() { id_rut = id };
            if (empleadoeliminar.Delete())
            {
                TempData["mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("AdministracionUsuarios");
            }

            TempData["mensaje"] = "No se a podido eliminar Empleado";
            return RedirectToAction("AdministracionUsuarios");
        }
        ////// FIN CRUD //////


        ////// ADMINISTRACION PROCESOS CRUD //////
        public ActionResult AdministracionProcesos()
        {
            Console.WriteLine(User.Identity.Name);
            ViewBag.procesos = new Negocio.Proceso().Read(Decimal.Parse(Session["id_empresa_emp"].ToString()));
            return View();
        }

        public ActionResult CreateProceso()
        {
            EnviarEstado();
            EnviarEmpresa();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProceso([Bind(Include = "ID_PROCESO, ID_ESTADO_PRO, NOMBRE_PROCESO, FECHA_INICIO, FECHA_TERMINO")]Proceso proceso)
        {
            try
            {
                // TODO: Add insert logic here
                proceso.id_empresa_pro = int.Parse(Session["id_empresa_emp"].ToString());
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
            Proceso procesoeliminar = new Proceso() { id_proceso = id };
            if (procesoeliminar.Delete())
            {
                TempData["mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("AdministracionProcesos");
            }

            TempData["mensaje"] = "Una unidad esta utilizando este proceso!";
            return RedirectToAction("AdministracionProcesos");
        }
        ////// FIN CRUD //////

        ////// VARIABLES GLOGABLES //////
        private void EnviarProcesos()
        {
            try
            {
                ViewBag.procesos = new Proceso().Read(int.Parse(Session["id_empresa_emp"].ToString()));
            }
            catch (Exception)
            {
            }
          
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

        private void EnviarEmpleado()
        {
            ViewBag.procesos = new Empleado().ReadAll();
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
