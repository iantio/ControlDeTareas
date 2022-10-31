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
        TreeViewItemMenu tree { get; set; }
        public UserControlInicio(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            InitializeComponent();
            try
            {
                tree = new TreeViewItemMenu();
                tree.ReadDetalle(empleadoAux);
                tvwFlujo.Items.Add(tree);
                tvwFlujo.Items.Refresh();
            }
            catch { }
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            this.tree.Items.Clear();
            this.tree.ReadDetalle(empleadoAux);
            //tvwFlujo.Items.Add(tree);
            tvwFlujo.Items.Refresh();
        }
    }
}
