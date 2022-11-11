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
                Unidad unidad = new Unidad();
                List<Unidad> unidades = unidad.FindByProceso(proceso.id_proceso, empleadoAux.id_empresa_emp);
                Tarea tarea = new Tarea();
                List<Tarea> tareas = new List<Tarea>();
                DetalleTarea detalle = new DetalleTarea();
                List<DetalleTarea> detalles = new List<DetalleTarea>();

                foreach (Unidad unidadEncontrada in unidades)
                {
                    tareas = tarea.FindByUnidad(unidadEncontrada.id_unidad,empleadoAux.id_empresa_emp);
                    if (MessageBox.Show("Este Proceso esta asignado a una Unidad, ¿esta seguro de eliminarlo considerando que puede estar siendo utilizado en un flujo?", "Seleccione una opcion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        foreach (Tarea tareaEncontrada in tareas)
                        {
                            detalles = detalle.FindByTarea(tareaEncontrada.id_tarea);
                            foreach (DetalleTarea detalleEncontrado in detalles)
                            {
                                if (detalleEncontrado.Delete())
                                {
                                    Console.WriteLine("Detalle eliminado");
                                }
                                else { Console.WriteLine("Error al eliminar Detalle"); }
                            }
                            if (tareaEncontrada.Delete())
                            {
                                Console.WriteLine("Tarea eliminada");
                            }
                            else { Console.WriteLine("Error al eliminar Tarea"); }
                        }
                        if (unidadEncontrada.Delete())
                        {
                            Console.WriteLine("Unidad eliminada");
                        }
                        else { Console.WriteLine("Error al eliminar Unidad"); }
                    }
                }
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
