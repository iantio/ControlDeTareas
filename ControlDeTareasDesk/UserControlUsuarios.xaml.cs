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
    /// Lógica de interacción para UserControlUsuarios.xaml
    /// </summary>
    public partial class UserControlUsuarios : UserControl
    {
        Empleado empleadoAux;
        public UserControlUsuarios(Empleado empleadoAux)
        {
            InitializeComponent();
            this.empleadoAux = empleadoAux;
            EmpleadoCollection empleadoCollection = new EmpleadoCollection();
            dgUsuarios.ItemsSource = null;
            dgUsuarios.ItemsSource = empleadoCollection.ReadAll();
            dgUsuarios.Items.Refresh();
        }
    }
}
