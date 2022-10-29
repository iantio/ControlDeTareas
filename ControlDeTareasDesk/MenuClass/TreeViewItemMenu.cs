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
                                Console.WriteLine(listaTareas.Count);
                                Console.WriteLine(idTarea);
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
    }
}
