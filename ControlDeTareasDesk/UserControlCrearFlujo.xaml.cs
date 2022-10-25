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
    /// Lógica de interacción para UserControlCrearFlujo.xaml
    /// </summary>
    public partial class UserControlCrearFlujo : UserControl
    {
        Empleado empleadoAux { get; set; }
        List<Tarea> listTareas = new List<Tarea>();
        List<Empleado> listEmpleado = new List<Empleado>();
        TreeViewItemMenu itemProceso { get; set; }
        TreeViewItemMenu itemUnidad { get; set; }
        TreeViewItemMenu itemTarea { get; set; }
        public UserControlCrearFlujo(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            Proceso proceso = new Proceso();
            Unidad unidad = new Unidad();
            Tarea tarea = new Tarea();
            InitializeComponent();
            cmbProceso.ItemsSource = null;
            cmbProceso.ItemsSource = proceso.Read(empleadoAux.id_empresa_emp);
            cmbProceso.SelectedIndex = 0;
            cmbUnidad.ItemsSource = null;
            cmbUnidad.ItemsSource = unidad.FindByProceso((decimal)cmbProceso.SelectedValue,empleadoAux.id_empresa_emp);
            cmbUnidad.SelectedIndex = 0;
            EmpleadoCollection listaEmpleado = new EmpleadoCollection();
            //TREEVIEW
            itemProceso = new TreeViewItemMenu() { Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso };
            itemUnidad = new TreeViewItemMenu() { Titulo = ((Unidad)cmbUnidad.SelectedItem).nombre_unidad };
            itemProceso.Items.Add(itemUnidad);
            tvwFlujo.Items.Add(itemProceso);
        }

        private void cmbProceso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemProceso != null)
            {
                Unidad unidad = new Unidad();
                cmbUnidad.ItemsSource = unidad.FindByProceso((decimal)cmbProceso.SelectedValue, empleadoAux.id_empresa_emp);
                cmbUnidad.Items.Refresh();
                cmbUnidad.SelectedIndex = 0;
                lstTareas.ItemsSource = null;
                lstUsuarios.ItemsSource = null;
                itemProceso.Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso;
                tvwFlujo.Items.Refresh();
            }
        }

        private void cmbUnidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbUnidad.SelectedValue != null && itemProceso != null)
            {
                lstTareas.ItemsSource = null;
                itemUnidad.Items.Clear();
                itemUnidad.Titulo = ((Unidad)cmbUnidad.SelectedItem).nombre_unidad;
                tvwFlujo.Items.Refresh();
            }
        }

        private void btnAgregarTarea_Click(object sender, RoutedEventArgs e)
        {
            WinLista winListaTarea = new WinLista(empleadoAux,"tarea",(Unidad)cmbUnidad.SelectedItem);
            winListaTarea.ShowDialog();
            this.listTareas = winListaTarea.listaTareas;
            lstTareas.ItemsSource = this.listTareas;
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            WinLista winListaEmpleado = new WinLista(empleadoAux, "empleado", null);
            winListaEmpleado.ShowDialog();
            this.listEmpleado = winListaEmpleado.listaEmpleados;
            lstUsuarios.ItemsSource = this.listEmpleado;
            lstUsuarios.Items.Refresh();
        }

        private void btnEliminarTarea_Click(object sender, RoutedEventArgs e)
        {
            if (lstTareas.SelectedItem != null)
            {
                listTareas.Remove((Tarea)lstTareas.SelectedItem);
                //lstTareas.Items.Remove(lstTareas.SelectedItem);
                lstTareas.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione una tarea para quitar de la lista");
            }
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (lstUsuarios.SelectedItem != null)
            {
                listEmpleado.Remove((Empleado)lstUsuarios.SelectedItem);
                //lstTareas.Items.Remove(lstTareas.SelectedItem);
                lstUsuarios.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione un empleado para quitar de la lista");
            }
        }

        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {
            if (lstTareas.Items == null || lstTareas.Items.Count == 0)
            {
                MessageBox.Show("Primero debe agregar tareas a la lista para guardar");
            }
            else if (lstUsuarios.Items == null || lstUsuarios.Items.Count == 0)
            {
                MessageBox.Show("Primero debe agregar empleados a la lista para guardar");
            }
            else
            {
                foreach (Tarea t in lstTareas.Items)
                {
                    itemTarea = new TreeViewItemMenu() { Titulo = t.nombre_tarea, tarea = t };
                    foreach (Empleado emp in lstUsuarios.Items)
                    {
                        TreeViewItemMenu itemUsuario = new TreeViewItemMenu() { Titulo = emp.nombre_emp, empleado = emp };
                        itemTarea.Items.Add(itemUsuario);
                    };
                    itemUnidad.Items.Add(itemTarea);
                    tvwFlujo.Items.Refresh();
                };
            }
        }
    }
}
