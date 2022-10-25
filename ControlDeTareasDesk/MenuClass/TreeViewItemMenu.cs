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
        public TreeViewItemMenu(Tarea tarea)
        {
            this.Items = new List<TreeViewItemMenu>();
            this.tarea = tarea;
        }

        public string Titulo { get; set; }
        public Proceso proceso { get; set; }
        public Unidad unidad { get; set; }
        public Tarea tarea { get; set; }
        public Empleado empleado { get; set; }
        public List<List<DetalleTarea>> listaListaDetalles { get; set; }
        public List<TreeViewItemMenu> Items { get; set; }

        public TreeViewItemMenu ReadDetalle(decimal id_rut)
        {
            DetalleTarea detalle = new DetalleTarea();
            List<DetalleTarea> listaDetalles;
            listaDetalles = detalle.FindByEmpleado(id_rut);
            var test = (from x in listaDetalles
                        select x.tarea.unidad.id_proceso_uni);
            foreach (var tes in test) 
            {
                Console.WriteLine(tes.ToString());
            }
            //foreach (DetalleTarea detalleEncontrado in listaDetalles)
            //{
            //    //List<DetalleTarea> listaDetalles;
            //    listaDetalles = detalle.FindByEmpleado(id_rut);
            //    this.empleado = empleado.Read((int)id_rut);
            //    //this.tarea.LoadTarea();
            //}
            return null;
        }
    }
}
