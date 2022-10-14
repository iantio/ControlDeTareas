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
using MaterialDesignThemes.Wpf;
using ControlDeTareasWeb.Negocio;

namespace ControlDeTareasDesk
{
    /// <summary>
    /// Lógica de interacción para UserControlUnidad.xaml
    /// </summary>
    public partial class UserControlUnidad : UserControl
    {
        Empleado empleadoAux { get; set; }
        public UserControlUnidad(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            Unidad unidad = new Unidad();
            InitializeComponent();
            iconRefrescar.Kind = PackIconKind.Refresh;
            dgUnidades.ItemsSource = null;
            dgUnidades.ItemsSource = unidad.Read(empleadoAux.id_empresa_emp);
            dgUnidades.Items.Refresh();

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            Unidad unidad = new Unidad();
            dgUnidades.ItemsSource = null;
            dgUnidades.ItemsSource = unidad.Read(empleadoAux.id_empresa_emp);
            dgUnidades.Items.Refresh();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
