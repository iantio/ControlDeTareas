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
    /// Lógica de interacción para UserControlProcesos.xaml
    /// </summary>
    public partial class UserControlProcesos : UserControl
    {
        Empleado empleadoAux { get; set; }
        public UserControlProcesos(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            InitializeComponent();
            Proceso proceso = new Proceso();
            dgProcesos.ItemsSource = null;
            dgProcesos.ItemsSource = proceso.Read(empleadoAux.id_empresa_emp);
            dgProcesos.Items.Refresh();
            iconRefrescar.Kind = PackIconKind.Refresh;
        }
        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            WinCrearProceso crear = new WinCrearProceso(empleadoAux,null,false);
            crear.ShowDialog();
            btnRefrescar_Click(null, null);
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Proceso proceso = new Proceso();
            if (txtBuscar.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre a buscar");
            }
            else
            {
                try
                {
                    dgProcesos.ItemsSource = null;
                    dgProcesos.ItemsSource = proceso.Find(txtBuscar.Text.ToUpper(), (decimal)empleadoAux.id_empresa_emp); ;
                    dgProcesos.Items.Refresh();
                }
                catch
                {
                    MessageBox.Show("Usuario no encontrado");
                }
            }
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            Proceso proceso = new Proceso();
            dgProcesos.ItemsSource = null;
            dgProcesos.ItemsSource = proceso.Read(empleadoAux.id_empresa_emp);
            dgProcesos.Items.Refresh();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgProcesos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un proceso para elimnar");
            }
            else
            {
                Proceso proceso = (Proceso)dgProcesos.SelectedItem;
                if (proceso.Delete())
                {
                    MessageBox.Show("Proceso eliminado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al eliminar el proceso");
                }
            }
            btnRefrescar_Click(null, null);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgProcesos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un proceso para editar");
            }
            else
            {
                Proceso procesoTemp = (Proceso)dgProcesos.SelectedItem;
                WinCrearProceso crear = new WinCrearProceso(empleadoAux,procesoTemp,true);
                crear.ShowDialog();
                btnRefrescar_Click(null, null);
            }
        }
    }
}
