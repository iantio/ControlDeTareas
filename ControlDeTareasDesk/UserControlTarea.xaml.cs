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
    /// Lógica de interacción para UserControlTarea.xaml
    /// </summary>
    public partial class UserControlTarea : UserControl
    {
        Empleado empleadoAux { get; set; }
        public UserControlTarea(Empleado empleadoAux)
        {
            Tarea tarea = new Tarea();
            this.empleadoAux = empleadoAux;
            InitializeComponent();
            iconRefrescar.Kind = PackIconKind.Refresh;
            dgTareas.ItemsSource = null;
            dgTareas.ItemsSource = tarea.Read(empleadoAux.id_empresa_emp);
            dgTareas.Items.Refresh();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            WinCrearTarea crearTarea = new WinCrearTarea(empleadoAux, null, false);
            crearTarea.ShowDialog();
            btnRefrescar_Click(null,null);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (dgTareas.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una tarea para editar");
            }
            else
            {
                WinCrearTarea editarTarea = new WinCrearTarea(empleadoAux, (Tarea)dgTareas.SelectedItem, true);
                editarTarea.ShowDialog();
                btnRefrescar_Click(null, null);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
            {
                MessageBox.Show("debe ingresar una tarea a buscar");
            }
            else
            {
                Tarea tarea = new Tarea();
                dgTareas.ItemsSource = null;
                dgTareas.ItemsSource = tarea.Find(empleadoAux.id_empresa_emp,txtBuscar.Text);
                dgTareas.Items.Refresh();
            }
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            Tarea tarea = new Tarea();
            dgTareas.ItemsSource = null;
            dgTareas.ItemsSource = tarea.Read(empleadoAux.id_empresa_emp);
            dgTareas.Items.Refresh();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgTareas.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una tarea para eliminar");
            }
            else
            {
                Tarea tarea = (Tarea)dgTareas.SelectedItem;
                tarea.Delete();
                btnRefrescar_Click(null,null);
            }
        }
    }
}
