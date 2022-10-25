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
    /// Lógica de interacción para UserControlTest.xaml
    /// </summary>
    public partial class UserControlTest : UserControl
    {
        Empleado empleadoAux { get; set; }
        List<Tarea> listTareas = new List<Tarea>();
        List<Empleado> listEmpleado = new List<Empleado>();
        TreeViewItemMenu itemProceso { get; set; }
        TreeViewItemMenu itemUnidad { get; set; }
        TreeViewItemMenu itemTarea { get; set; }
        public UserControlTest(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            EmpleadoCollection listaEmpleado = new EmpleadoCollection();
            Proceso proceso = new Proceso();
            Unidad unidad = new Unidad();
            Tarea tarea = new Tarea();
            InitializeComponent();
            //COMBO BOX PROCESO
            cmbProceso.ItemsSource = null;
            cmbProceso.ItemsSource = proceso.Read(empleadoAux.id_empresa_emp);
            cmbProceso.SelectedIndex = 0;
            //COMBO BOX UNIDAD
            cmbUnidad.ItemsSource = null;
            cmbUnidad.ItemsSource = unidad.FindByProceso((decimal)cmbProceso.SelectedValue, empleadoAux.id_empresa_emp);
            cmbUnidad.SelectedIndex = 0;
            //LISTA DE USUARIOS
            lstUsuarios.ItemsSource = listaEmpleado.ReadByEmpresa(empleadoAux.id_empresa_emp);
            //TREEVIEW
            itemProceso = new TreeViewItemMenu() { Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso };
            itemUnidad = new TreeViewItemMenu() { Titulo = ((Unidad)cmbUnidad.SelectedItem).nombre_unidad };
            //itemTarea = new TreeViewItemMenu() { Titulo = "Tarea #1.1" };
            //agregar usuario
            //itemTarea.Items.Add(new TreeViewItemMenu() { Titulo = "Usuario #1" });
            //agregar tarea
            //itemUnidad.Items.Add(itemTarea);
            //agregar unidad
            itemProceso.Items.Add(itemUnidad);
            tvwFlujo.Items.Add(itemProceso);
            lstTareas.ItemsSource = tarea.FindByUnidad((decimal)cmbUnidad.SelectedValue, empleadoAux.id_empresa_emp);
            lstTareas.Items.Refresh();

        }
        private void cmbProceso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (itemProceso != null)
                {
                    Unidad unidad = new Unidad();

                    cmbUnidad.ItemsSource = unidad.FindByProceso((decimal)cmbProceso.SelectedValue, empleadoAux.id_empresa_emp);
                    cmbUnidad.Items.Refresh();
                    cmbUnidad.SelectedIndex = 0;

                    itemProceso.Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso;
                    tvwFlujo.Items.Refresh();
                }
            }
            catch
            {
            }
        }

        private void cmbUnidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbUnidad.SelectedValue != null && itemProceso != null)
                {
                    Tarea tarea = new Tarea();
                    lstTareas.ItemsSource = tarea.FindByUnidad((decimal)cmbUnidad.SelectedValue, empleadoAux.id_empresa_emp);
                    lstTareas.Items.Refresh();
                    itemProceso.Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso;
                    itemUnidad.Titulo = ((Unidad)cmbUnidad.SelectedItem).nombre_unidad;
                    tvwFlujo.Items.Refresh();
                }
            }
            catch
            {
            }
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (tvwFlujo.SelectedItem != null && ((TreeViewItemMenu)tvwFlujo.SelectedItem).tarea != null )
            {
                TreeViewItemMenu tareaSeleccionada = (TreeViewItemMenu)tvwFlujo.SelectedItem;
                TreeViewItemMenu itemUsuario = new TreeViewItemMenu() { Titulo = ((Empleado)lstUsuarios.SelectedItem).nombre_emp };
                ((TreeViewItemMenu)tvwFlujo.SelectedItem).Items.Add(itemUsuario);

                tvwFlujo.Items.Refresh();
                Console.WriteLine("xd");
                Console.WriteLine(tareaSeleccionada);
                tvwFlujo.FindName(tareaSeleccionada.Titulo);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una tarea");
            }
        }

        private void btnAgregarTarea_Click(object sender, RoutedEventArgs e)
        {
            if (lstTareas.SelectedItem != null)
            {
                
                TreeViewItemMenu nuevaTarea = new TreeViewItemMenu() { Titulo = ((Tarea)lstTareas.SelectedItem).nombre_tarea, tarea = (Tarea)lstTareas.SelectedItem };
                itemUnidad.Items.Add(nuevaTarea);
                tvwFlujo.Items.Refresh();
            }
            else
            {
                MessageBox.Show("seleccione un elemento");
            }
        }
    }
}
