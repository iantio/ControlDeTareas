using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ControlDeTareasWeb.Negocio;
using Microsoft.AspNetCore.Mvc;

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


        //////////////////////////////////////////
        ////// ADMINISTRACION UNIDADES CRUD //////
        //////////////////////////////////////////
        public ActionResult AdministracionUnidades()
        {
            ViewBag.unidad = new Negocio.Unidad().Read(Decimal.Parse(Session["id_empresa_emp"].ToString()));
            
            return View();
        }
        
        [HttpPost]
        public ActionResult AdministracionUnidades(FormCollection form)
        {
            string buscar = (form["buscar"]).ToUpper();

            Unidad unidad = new Unidad();

            List<Unidad> listaunidad = (unidad.Read((Decimal)Session["id_empresa_emp"]));

            List<Unidad> buscadounidad = listaunidad.Where(x => x.nombre_unidad.Contains(buscar) || x.id_unidad.ToString() == (buscar)).ToList();

            ViewBag.unidad = buscadounidad;
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
        public ActionResult DeleteUnidad(int id)
        {
            Unidad unidadEliminar = new Unidad() { id_unidad = id };
            if (unidadEliminar.Delete())
            {
                TempData["mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("AdministracionUnidades");
            }

            TempData["mensaje"] = "No se a podido eliminar Unidad";
            return RedirectToAction("AdministracionUnidades");
        }
        public ActionResult EditarUnidad(int id)
        {
            Unidad unidad = new Unidad().LoadUnidad(id);

            if(unidad == null)
            {
                return RedirectToAction("AdministracionUnidades");
            }
            EnviarEstado();
            EnviarProcesos();
            EnviarEmpresa();
            return View(unidad);
        }

        [HttpPost]
        public ActionResult EditarUnidad([Bind(Include = "id_unidad, id_proceso_uni, id_estado_uni, id_empresa_uni, nombre_unidad, fecha_inicio, fecha_termino")] Unidad unidad)
        {
            try
            {
                unidad.Update();
                TempData["mensaje"] = "Modificado Correctamente";
                return RedirectToAction("AdministracionUnidades");
            }
            catch
            {
                return View();
            }
        }
        //////////////////////
        ////// FIN CRUD //////
        //////////////////////

        //////////////////////////////////////////
        ////// ADMINISTRACION USUARIOS CRUD //////
        //////////////////////////////////////////
        public ActionResult AdministracionUsuarios()
        {
            ViewBag.empleados = new Negocio.EmpleadoCollection().ReadByEmpresa(Decimal.Parse(Session["id_empresa_emp"].ToString()));
            return View();
        }

        [HttpPost]
        public ActionResult AdministracionUsuarios(FormCollection form)
        {
            string buscar = (form["buscar"]).ToUpper();

            EmpleadoCollection empleado = new EmpleadoCollection();

            List<Empleado> listaempleado = (empleado.ReadByEmpresa((Decimal)Session["id_empresa_emp"]));

            List<Empleado> buscadoempleado = listaempleado.Where(x => x.nombre_emp.Contains(buscar) || x.id_rut.ToString() == (buscar)).ToList();

            ViewBag.empleados = buscadoempleado;
            return View();
        }

        public ActionResult CreateEmpleado()
        {
            EnviarEmpresa();
            EnviarRol();
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmpleado([Bind(Include = "ID_RUT, ID_EMPRESA_EMP, ID_ROL_EMP, FECHA_INGRESO, NOMBRE_EMP, USUARIO, CLAVE")] Empleado empleado)
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

        public ActionResult EditarEmpleado(string id)
        {
            Empleado empleado = new Empleado().Read(int.Parse(id));

            if (empleado.id_rut == int.Parse(id))
            {
                EnviarEmpresa();
                EnviarRol();
                return View(empleado);
                
            }
            return RedirectToAction("AdministracionUsuarios");
        }

        [HttpPost]
        public ActionResult EditarEmpleado([Bind(Include = "ID_RUT, ID_EMPRESA_EMP, ID_ROL_EMP, FECHA_INGRESO, NOMBRE_EMP, USUARIO, CLAVE")] Empleado empleado)
        {
            try
            {
                empleado.Update();
                TempData["mensaje"] = "Modificado Correctamente";
                return RedirectToAction("AdministracionUsuarios");
            }
            catch
            {
                return View();
            }
        }
        //////////////////////
        ////// FIN CRUD //////
        //////////////////////

        //////////////////////////////////////////
        ////// ADMINISTRACION PROCESOS CRUD //////
        //////////////////////////////////////////
        public ActionResult AdministracionProcesos()
        {
            Console.WriteLine(User.Identity.Name);
            ViewBag.procesos = new Negocio.Proceso().Read(Decimal.Parse(Session["id_empresa_emp"].ToString()));
            return View();
        }

        [HttpPost]
        public ActionResult AdministracionProcesos(FormCollection form)
        {
            string buscar = (form["buscar"]).ToUpper();

            Proceso proceso = new Proceso();

            List<Proceso> listaproceso = (proceso.Read((Decimal)Session["id_empresa_emp"]));

            List<Proceso> buscadoproceso = listaproceso.Where(x => x.nombre_proceso.Contains(buscar) || x.id_proceso.ToString() == (buscar)).ToList();

            ViewBag.procesos = buscadoproceso;
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
        public ActionResult EditarProceso(int id)
        {
            Proceso proceso = new Proceso().LoadProceso(id);

            if (proceso == null)
            {
                return RedirectToAction("AdministracionProcesos");
            }
            EnviarEstado();
            EnviarEmpresa();
            return View(proceso);
        }

        [HttpPost]
        public ActionResult EditarProceso([Bind(Include = "ID_PROCESO, ID_ESTADO_PRO, NOMBRE_PROCESO, FECHA_INICIO, FECHA_TERMINO")] Proceso proceso)
        {
            try
            {
                proceso.Update();
                TempData["mensaje"] = "Modificado Correctamente";
                return RedirectToAction("AdministracionProcesos");
            }
            catch
            {
                return View();
            }
        }
        //////////////////////
        ////// FIN CRUD //////
        //////////////////////

        //////////////////////////////////////////
        ////// ADMINISTRACION TAREAS CRUD ////////
        //////////////////////////////////////////
        public ActionResult AdministracionTareas()
        {
            Console.WriteLine(User.Identity.Name);
            ViewBag.tareas = new Tarea().Read(Decimal.Parse(Session["id_empresa_emp"].ToString()));
            return View();
        }

        [HttpPost]
        public ActionResult AdministracionTareas(FormCollection form)
        {
            string buscar = (form["buscar"]).ToUpper();

            Tarea tarea = new Tarea();

            List<Tarea> listatarea = (tarea.Read((Decimal)Session["id_empresa_emp"]));

            List<Tarea> buscadotarea = listatarea.Where(x => x.nombre_tarea.Contains(buscar) || x.id_tarea.ToString() == (buscar)).ToList();

            ViewBag.tareas = buscadotarea;
            return View();
        }

        public ActionResult CreateTarea()
        {
            EnviarUnidad();
            EnviarEstado();
            return View();
        }

        [HttpPost]
        public ActionResult CreateTarea([Bind(Include = "ID_TAREA, ID_UNIDAD_TAREA, ID_ESTADO_TAREA, ID_EMPRESA_TAREA, NOMBRE_TAREA, FECHA_INICIO, FECHA_TERMINO")] Tarea tarea)
        {
            try
            {
                // TODO: Add insert logic here
                tarea.id_empresa_tarea = int.Parse(Session["id_empresa_emp"].ToString());
                tarea.Create();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("AdministracionTareas", "Empresa");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteTarea(int id)
        {
            Tarea tareaeliminar = new Tarea() { id_tarea = id };
            if (tareaeliminar.Delete())
            {
                TempData["mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("AdministracionTareas");
            }

            TempData["mensaje"] = "Una unidad esta utilizando este proceso!";
            return RedirectToAction("AdministracionTareas");
        }

        public ActionResult EditarTarea(int id)
        {
            Tarea tarea = new Tarea().LoadTarea(id);

            if (tarea == null)
            {
                return RedirectToAction("AdministracionTareas");
            }
            EnviarUnidad();
            EnviarEstado();
            return View(tarea);
        }

        [HttpPost]
        public ActionResult EditarTarea([Bind(Include = "ID_TAREA, ID_UNIDAD_TAREA, ID_ESTADO_TAREA, ID_EMPRESA_TAREA, NOMBRE_TAREA, FECHA_INICIO, FECHA_TERMINO, UNIDAD, ESTADO, EMPRESA")] Tarea tarea)
        {
            try
            {
                tarea.Update();
                TempData["mensaje"] = "Modificado Correctamente";
                return RedirectToAction("AdministracionTareas");
            }
            catch
            {
                return View();
            }
        }
        //////////////////////
        ////// FIN CRUD //////
        //////////////////////

        /////////////////////////////////
        ////// VARIABLES GLOGABLES //////
        /////////////////////////////////
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

        private void EnviarUnidad()
        {
            ViewBag.unidad = new Unidad().Read(int.Parse(Session["id_empresa_emp"].ToString()));
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
