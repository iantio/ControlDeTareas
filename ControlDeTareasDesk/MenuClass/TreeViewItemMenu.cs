using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeTareasWeb.Negocio;

namespace ControlDeTareasDesk
{
    public class TreeViewItemMenu
    {
        public TreeViewItemMenu()
        {
            this.Items = new List<TreeViewItemMenu>();
        }

        public int idItemProceso { get; set; }
        public int idItemUnidad { get; set; }
        public int idItemTarea { get; set; }
        public int idItemEmpleado { get; set; }
        public string Titulo { get; set; }
        public Proceso proceso { get; set; }
        public Unidad unidad { get; set; }
        public Tarea tarea { get; set; }
        public Empleado empleado { get; set; }
        public double Porcentaje { get; set; }
        public List<TreeViewItemMenu> Items { get; set; }

        public TreeViewItemMenu ReadDetalle(Empleado empleadoAux)
        {
            this.Titulo = "Prueba";
            Console.WriteLine("\nDETALLE EMPLEADOS");
            try
            {
                DetalleTarea detalle = new DetalleTarea();
                List<DetalleTarea> listaDetalles = detalle.FindByEmpleado(empleadoAux.id_rut);

                listaDetalles = detalle.FindByEmpleado(empleadoAux.id_rut);
                List<String> listaProcesos = (from x in listaDetalles
                                              select x.tarea.unidad.proceso.nombre_proceso).Distinct().ToList();
                foreach (String nombreProceso in listaProcesos)
                {
                    Proceso proceso = new Proceso();
                    TreeViewItemMenu itemProceso = new TreeViewItemMenu() {Titulo=nombreProceso, Porcentaje= 0.1};
                    List<String> listaUnidades = (from x in listaDetalles
                                                  where x.tarea.unidad.proceso.nombre_proceso == nombreProceso
                                                  select x.tarea.unidad.nombre_unidad).Distinct().ToList();
                    Console.WriteLine(nombreProceso);
                    foreach (String nombreUnidad in listaUnidades)
                    {
                        Unidad unidad = new Unidad();
                        TreeViewItemMenu itemUnidad = new TreeViewItemMenu() { Titulo = nombreUnidad, Porcentaje = 0.5 };
                        List<decimal> listaTareas = (from x in listaDetalles
                                                    where x.tarea.unidad.proceso.nombre_proceso == nombreProceso && x.tarea.unidad.nombre_unidad == nombreUnidad
                                                    select x.tarea.id_tarea).Distinct().ToList();
                        Console.WriteLine("|_"+nombreUnidad);
                        foreach (decimal idTarea in listaTareas)
                        {
                            if (idTarea != 0)
                            {
                                Tarea tarea = new Tarea();
                                tarea.LoadTarea(idTarea);

                                TreeViewItemMenu itemTarea = new TreeViewItemMenu() { Titulo = tarea.nombre_tarea, Porcentaje = 0.9, tarea = tarea };

                                itemUnidad.unidad = tarea.unidad;
                                itemProceso.proceso = tarea.unidad.proceso;
                                itemUnidad.Items.Add(itemTarea);
                                Console.WriteLine(" |_" + tarea.nombre_tarea);
                            }
                        }
                        itemProceso.Items.Add(itemUnidad);
                    }
                    this.Items.Add(itemProceso);
                }
            }
            catch
            {
            }
            return this;
        }
        public TreeViewItemMenu ReadDetalleUsuarios(Empleado empleadoAux)
        {
            this.Titulo = "Prueba";
            Console.WriteLine("\nDETALLE EMPRESA");
            try
            {
                DetalleTarea detalle = new DetalleTarea();
                List<DetalleTarea> listaDetalles = detalle.FindByEmpresa(empleadoAux.id_empresa_emp);

                listaDetalles = detalle.FindByEmpresa(empleadoAux.id_empresa_emp);
                List<decimal> listaProcesos = (from x in listaDetalles
                                              select x.tarea.unidad.proceso.id_proceso).Distinct().ToList();
                idItemProceso = 0;
                idItemUnidad = 0;
                idItemTarea = 0;
                idItemEmpleado = 0;
                foreach (decimal idProceso in listaProcesos)
                {
                    Proceso proceso = new Proceso();
                    proceso.LoadProceso(idProceso);
                    TreeViewItemMenu itemProceso = new TreeViewItemMenu() { Titulo = proceso.nombre_proceso, Porcentaje = 0.1, proceso = proceso , idItemProceso = this.idItemProceso};
                    List<decimal> listaUnidades = (from x in listaDetalles
                                                  where x.tarea.unidad.proceso.id_proceso == idProceso
                                                  select x.tarea.unidad.id_unidad).Distinct().ToList();
                    Console.WriteLine(proceso.nombre_proceso);
                    foreach (decimal idUnidad in listaUnidades)
                    {
                        Unidad unidad = new Unidad();
                        unidad.LoadUnidad(idUnidad);
                        TreeViewItemMenu itemUnidad = new TreeViewItemMenu() { Titulo = unidad.nombre_unidad, Porcentaje = 0.5, unidad = unidad, idItemProceso = this.idItemProceso };
                        List<decimal> listaTareas = (from x in listaDetalles
                                                     where x.tarea.unidad.proceso.id_proceso == idProceso && x.tarea.unidad.id_unidad == idUnidad
                                                     select x.tarea.id_tarea).Distinct().ToList();
                        Console.WriteLine("|_" + unidad.nombre_unidad);
                        foreach (decimal id_tarea in listaTareas)
                        {
                            Tarea tarea = new Tarea();
                            tarea.LoadTarea(id_tarea);
                            TreeViewItemMenu itemTarea = new TreeViewItemMenu() { Titulo = tarea.nombre_tarea, Porcentaje = 0.5, tarea = tarea, idItemProceso = this.idItemProceso, idItemTarea = this.idItemTarea };
                            List<decimal> listaEmpleados = (from x in listaDetalles
                                                            where x.tarea.unidad.proceso.id_proceso == idProceso && x.tarea.id_tarea == id_tarea
                                                            select x.empleado.id_rut).Distinct().ToList();
                            Console.WriteLine(" |_" + tarea.nombre_tarea);
                            foreach (decimal idEmpleado in listaEmpleados)
                            {
                                Empleado empleado = new Empleado();
                                empleado.LoadEmpleado(idEmpleado);

                                TreeViewItemMenu itemEmpleado = new TreeViewItemMenu() { Titulo = empleado.nombre_emp, Porcentaje = 0.1, empleado = empleado, tarea = tarea, idItemTarea = idItemTarea, idItemEmpleado = idItemEmpleado};

                                Console.WriteLine("  |_" + empleado.nombre_emp);
                                itemTarea.Items.Add(itemEmpleado);
                                idItemEmpleado += 1;
                            }
                            itemUnidad.Items.Add(itemTarea);
                            idItemTarea += 1;
                        }
                        itemProceso.Items.Add(itemUnidad);
                    }
                    this.Items.Add(itemProceso);
                    idItemProceso += 1;
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            return this;
        }
    }
}
