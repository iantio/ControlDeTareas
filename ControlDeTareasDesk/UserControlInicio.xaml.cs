using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlDeTareasWeb.Negocio;

namespace ControlDeTareasDesk
{
    /// <summary>
    /// Lógica de interacción para UserControlInicio.xaml
    /// </summary>
    public partial class UserControlInicio : UserControl
    {
        Empleado empleadoAux;
        TreeViewItemMenu tree { get; set; } = new TreeViewItemMenu();
        int index { get; set; } = 0;
        int totalProcesos { get; set; } = 0;
        public UserControlInicio(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            InitializeComponent();
            try
            {
                tree.ReadDetalle(empleadoAux);
                totalProcesos = tree.Items.Count;
                lblTitle.Content = ("PROCESO: "+((TreeViewItemMenu)tree.Items[index]).proceso.nombre_proceso+" ["+(index+1)+"/"+totalProcesos+"]");
                foreach (TreeViewItemMenu unidadEncontrada in ((TreeViewItemMenu)tree.Items[index]).Items)
                {
                    tvwFlujo.Items.Add(unidadEncontrada);
                }
                tvwFlujo.Items.Refresh();
            }
            catch { }
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            tree.Items.Clear();
            tree.ReadDetalle(empleadoAux);
            tvwFlujo.Items.Clear();
            foreach (TreeViewItemMenu unidadEncontrada in ((TreeViewItemMenu)tree.Items[1]).Items)
            {
                tvwFlujo.Items.Add(unidadEncontrada);
            }
            lblTitle.Content = ("PROCESO: " + ((TreeViewItemMenu)tree.Items[1]).proceso.nombre_proceso + " [" + (1 + 1) + "/" + totalProcesos + "]");
            tvwFlujo.Items.Refresh();
            //tvwFlujo.Items.Add(tree);
            Console.WriteLine(tree.Items.Count);
            Console.WriteLine((TreeViewItemMenu)tree.Items[1]);
            tvwFlujo.Items.Refresh();
        }
    }
}
