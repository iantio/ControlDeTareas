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
        public List<TreeViewItemMenu> Items { get; set; }
    }
}
