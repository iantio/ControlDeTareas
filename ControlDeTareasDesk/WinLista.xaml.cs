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
using System.Windows.Shapes;
using ControlDeTareasWeb.Negocio;

namespace ControlDeTareasDesk
{
    /// <summary>
    /// Lógica de interacción para WinLista.xaml
    /// </summary>
    public partial class WinLista : Window
    {
        Empleado empleadoAux { get; set; }
        public List<Tarea> listaTareas { get; set; }
        public List<Empleado> listaEmpleados { get; set; }
        decimal id_unidad { get; set; }
        String tipo;
        public WinLista(Empleado empleadoAux,String tipo,Unidad unidad)
        {
            this.empleadoAux = empleadoAux;
            this.tipo = tipo;
            InitializeComponent();
            dgTareas.ItemsSource = null;
            dgEmpleados.ItemsSource = null;
            switch (tipo) 
            {
                case "tarea":
                    listaTareas = new List<Tarea>();
                    Tarea tarea = new Tarea();
                    lblTitle.Content = "Buscador de Tareas";
                    dgEmpleados.IsEnabled = false;
                    this.dgTareas.Visibility = Visibility.Visible;
                    dgTareas.ItemsSource = tarea.FindByUnidad(unidad.id_unidad, empleadoAux.id_empresa_emp);
                    dgTareas.Items.Refresh();
                    this.id_unidad = unidad.id_unidad;
                    break;
                case "empleado":
                    listaEmpleados = new List<Empleado>();
                    EmpleadoCollection coleccionEmpleados = new EmpleadoCollection();
                    lblTitle.Content = "Buscador de Empleados";
                    dgTareas.IsEnabled = false;
                    this.dgEmpleados.Visibility = Visibility.Visible;
                    dgEmpleados.ItemsSource = coleccionEmpleados.ReadByEmpresa(empleadoAux.id_empresa_emp);
                    dgEmpleados.Items.Refresh();
                    break;
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgTareas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Tarea> seleccionTarea = new List<Tarea>();
            
            if (dgTareas.SelectedItem != null)
            {
                // ... Get SelectedItems from DataGrid.
                var grid = sender as DataGrid;
                var selected = grid.SelectedItems;
                Console.WriteLine(selected);
                foreach (var item in selected)
                {
                    Tarea tareaSeleccionada = item as Tarea;
                    seleccionTarea.Add(tareaSeleccionada);
                }
            }
            listaTareas = seleccionTarea;
        }

        private void dgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Empleado> seleccionEmpleado = new List<Empleado>();
            if (dgEmpleados.SelectedItem != null)
            {
                // ... Get SelectedItems from DataGrid.
                var grid = sender as DataGrid;
                var selected = grid.SelectedItems;
                foreach (var item in selected)
                {
                    Empleado empleadoSelecciondo = item as Empleado;
                    seleccionEmpleado.Add(empleadoSelecciondo);
                }
            }
            listaEmpleados = seleccionEmpleado;
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            dgTareas.SelectedItem = null;
            dgEmpleados.SelectedItem = null;
        }

        private void btn_Buscar_Click(object sender, RoutedEventArgs e)
        {
            Tarea tareaBusqueda = new Tarea();
            EmpleadoCollection listaEmpleado = new EmpleadoCollection();
            if (txtBuscar.Text.Trim() == "")
            {
                MessageBox.Show("ingrese un nombre a buscar");
            }
            else
            {
                switch (tipo)
                {
                    case "tarea":
                        dgTareas.ItemsSource = null;
                        dgTareas.ItemsSource = tareaBusqueda.FindByTareaUnidad(txtBuscar.Text.ToUpper(),id_unidad ,empleadoAux.id_empresa_emp);
                        dgTareas.Items.Refresh();
                        break;
                    case "empleado":
                        dgEmpleados.ItemsSource = null;
                        dgEmpleados.ItemsSource = listaEmpleado.FindByNombre(txtBuscar.Text.ToUpper(), empleadoAux.id_empresa_emp);
                        dgEmpleados.Items.Refresh();
                        break;
                }
            }
        }
    }
}
