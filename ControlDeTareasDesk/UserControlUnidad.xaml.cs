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
            if (txtBuscar.Text.Trim() == "")
            {
                MessageBox.Show("debe ingresar un nombre para buscar");
                txtBuscar.Focus();
            }
            else
            {
                Unidad unidadTemp = new Unidad();
                dgUnidades.ItemsSource = null;
                dgUnidades.ItemsSource = unidadTemp.Find(txtBuscar.Text,empleadoAux.id_empresa_emp);
                dgUnidades.Items.Refresh();

            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            WinCrearUnidad winCrear = new WinCrearUnidad(empleadoAux,null,false);
            winCrear.ShowDialog();
            btnRefrescar_Click(null, null);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgUnidades.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una unidad para editar");
            }
            else
            {
                WinCrearUnidad winEditar = new WinCrearUnidad(empleadoAux, (Unidad)dgUnidades.SelectedItem, true);
                winEditar.ShowDialog();
                btnRefrescar_Click(null,null);
            }
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
            Unidad unidadTemp = (Unidad)dgUnidades.SelectedItem;
            Tarea tareaTemp = new Tarea();
            DetalleTarea detalle = new DetalleTarea();
            if (dgUnidades.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una unidad para eliminar");
            }
            else if (tareaTemp.FindByUnidad(unidadTemp.id_unidad, unidadTemp.id_empresa_uni) != null)
            {
                foreach(Tarea tareaEncontrada in tareaTemp.FindByUnidad(unidadTemp.id_unidad, unidadTemp.id_empresa_uni))
                {
                    if (MessageBox.Show("Este unidad esta asignada a una tarea, ¿esta seguro de eliminarla considerando que la tarea puede estar en un flujo?", "Seleccione una opcion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            foreach (DetalleTarea detalleEncontrado in detalle.FindByTarea(tareaEncontrada.id_tarea))
                            {
                                detalleEncontrado.Delete();
                            }
                            tareaEncontrada.Delete();
                        }
                        catch
                        {
                            Console.WriteLine("Error: no se encontraron tareas en detalle");
                        }
                    }
                }
                unidadTemp.Delete();
                btnRefrescar_Click(null, null);
            }
            else
            {
                unidadTemp.Delete();
                btnRefrescar_Click(null, null);
            }
        }
    }
}
