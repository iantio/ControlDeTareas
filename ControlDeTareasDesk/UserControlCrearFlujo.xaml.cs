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
        TreeViewItemMenu itemProcesoGuardado { get; set; }
        TreeViewItemMenu itemUnidad { get; set; } = new TreeViewItemMenu();
        TreeViewItemMenu itemUnidadGuardada { get; set; } = new TreeViewItemMenu();
        TreeViewItemMenu itemTarea { get; set; }
        TreeViewItemMenu itemTareaGuardada { get; set; }
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
            Console.WriteLine(cmbUnidad.Items.Count);
            EmpleadoCollection listaEmpleado = new EmpleadoCollection();
            //TREEVIEW
            itemProceso = new TreeViewItemMenu() { Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso, proceso = (Proceso)cmbProceso.SelectedItem};
            itemProcesoGuardado = new TreeViewItemMenu() { Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso, proceso = (Proceso)cmbProceso.SelectedItem };
            if (cmbUnidad.Items.Count != 0)
            {
                itemUnidad.Titulo = ((Unidad)cmbUnidad.SelectedItem).nombre_unidad;
                itemUnidad.unidad = (Unidad)cmbUnidad.SelectedItem;
                itemProceso.Items.Add(itemUnidad);
            }
            else
            {
                itemUnidad = new TreeViewItemMenu();
                itemProceso.Items.Add(itemUnidad);
            }
            tvwFlujo.Items.Add(itemProceso);
            tvwFlujoGuardado.Items.Add(itemProcesoGuardado);
        }

        private void cmbProceso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemProceso != null)
            {
                itemProceso.Items.Clear();
                itemProcesoGuardado.Items.Clear();
                itemProceso.Items.Add(itemUnidad);
                Unidad unidad = new Unidad();
                cmbUnidad.ItemsSource = unidad.FindByProceso((decimal)cmbProceso.SelectedValue, empleadoAux.id_empresa_emp);
                cmbUnidad.Items.Refresh();
                cmbUnidad.SelectedIndex = 0;
                lstTareas.ItemsSource = null;
                lstUsuarios.ItemsSource = null;
                itemProceso.Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso;
                itemProceso.proceso = (Proceso)cmbProceso.SelectedItem;
                itemProcesoGuardado.Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso;
                itemProcesoGuardado.proceso = (Proceso)cmbProceso.SelectedItem;
                tvwFlujo.Items.Refresh();
                tvwFlujoGuardado.Items.Refresh();
            }
        }

        private void cmbUnidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbUnidad.SelectedValue != null && itemProceso != null)
            {
                Console.WriteLine("Prueba cambio de unidad");
                lstTareas.ItemsSource = null;
                itemUnidad.Items.Clear();
                itemUnidad.Titulo = ((Unidad)cmbUnidad.SelectedItem).nombre_unidad;
                itemUnidad.unidad = (Unidad)cmbUnidad.SelectedItem;
                tvwFlujo.Items.Refresh();
            }
            else
            {
                //itemUnidad = new TreeViewItemMenu();
                itemUnidad.Titulo = "";
                itemUnidad.unidad = new Unidad() {id_unidad = 0};
            }
        }

        private void btnAgregarTarea_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUnidad.Items.Count != 0)
            {
                WinLista winListaTarea = new WinLista(empleadoAux, "tarea", (Unidad)cmbUnidad.SelectedItem);
                winListaTarea.ShowDialog();
                this.listTareas = winListaTarea.listaTareas;
                lstTareas.ItemsSource = this.listTareas;
            }
            else
            {
                MessageBox.Show("No se encontraron unidades con tareas");
            }
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
                MessageBox.Show("Primero debe añadir tareas a la lista para sumarlos a la vista");
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

        private void btnGuardarUnidad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (itemUnidad.Items != null && itemUnidad.Items.Count != 0)
                {
                    TreeViewItemMenu itemUnidadTemp = new TreeViewItemMenu() { Titulo = itemUnidad.Titulo, unidad = itemUnidad.unidad };
                    foreach (TreeViewItemMenu ta in itemUnidad.Items)
                    {
                        if (ta.Items != null || ta.Items.Count != 0)
                        {
                            TreeViewItemMenu itemTareaTemp = new TreeViewItemMenu() { Titulo = ta.Titulo, tarea = ta.tarea };
                            foreach (TreeViewItemMenu te in ta.Items)
                            {
                                TreeViewItemMenu itemEmpleadoTemp = new TreeViewItemMenu() { Titulo = te.empleado.nombre_emp, empleado = te.empleado };
                                itemTareaTemp.Items.Add(itemEmpleadoTemp);
                            }
                            itemUnidadTemp.Items.Add(itemTareaTemp);
                        }
                    }
                    itemProcesoGuardado.Items.Add(itemUnidadTemp);
                    tvwFlujo.Items.Refresh();
                    tvwFlujoGuardado.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Primero debe agregar tareas a la unidad");
                }
            }
            catch { }
        }

        private void btnGuardarFlujo_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Boolean creacionExitosa = false;
                if (itemProcesoGuardado.Items.Count > 0)
                {
                    //AQUI crear iterador que salte la pimera unidad
                    foreach (TreeViewItemMenu unidadEncontrada in itemProcesoGuardado.Items)
                    {
                        if (unidadEncontrada.Items != null || unidadEncontrada.Items.Count != 0)
                        {
                            foreach (TreeViewItemMenu tareaEncontrada in unidadEncontrada.Items)
                            {
                                if (tareaEncontrada.Items != null || tareaEncontrada.Items.Count != 0)
                                {
                                    foreach (TreeViewItemMenu empleadoEncontrado in tareaEncontrada.Items)
                                    {
                                        DetalleTarea detalleTarea = new DetalleTarea()
                                        {
                                            id_detalle = 0,
                                            id_rut_detalle = empleadoEncontrado.empleado.id_rut,
                                            id_tarea_detalle = tareaEncontrada.tarea.id_tarea
                                        };
                                        if (detalleTarea.Create())
                                        {
                                            Console.WriteLine("Detalle creado exitosamente");
                                            creacionExitosa = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error al crear detalle");
                                            creacionExitosa = false;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Para guardar debe agregar empleados a las tarea");
                                    creacionExitosa = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Para guardar debe agregar tareas a la unidad");
                            creacionExitosa = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Para guardar el flujo debe agregar al menos una unidad");
                    creacionExitosa = false;
                }
                if (creacionExitosa == true)
                {
                    MessageBox.Show("flujo creado de manera exitosa");
                }
            }
            catch
            {
            }
        }

        private void btnEliminarGrilla_Click(object sender, RoutedEventArgs e)
        {
            if (tvwFlujo.SelectedItem == null && tvwFlujoGuardado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un elemento para eliminar del flujo");
            }
            else if (tvwFlujo.SelectedItem != null && tvwFlujoGuardado.SelectedItem != null)
            {
                MessageBox.Show("Solo se puede eliminar un elemento a la vez");
            }
            else if (tvwFlujo.SelectedItem != null)
            {
                if (((TreeViewItemMenu)tvwFlujo.SelectedItem).proceso != null)
                {
                    tvwFlujo.Items.Remove((TreeViewItemMenu)tvwFlujo.SelectedItem);
                    tvwFlujo.Items.Refresh();
                }
                else if (((TreeViewItemMenu)tvwFlujo.SelectedItem).unidad != null)
                {
                    itemProceso.Items.Remove((TreeViewItemMenu)tvwFlujo.SelectedItem);
                    tvwFlujo.Items.Refresh();
                }
                else if (((TreeViewItemMenu)tvwFlujo.SelectedItem).tarea != null)
                {
                    itemUnidad.Items.Remove((TreeViewItemMenu)tvwFlujo.SelectedItem);
                    tvwFlujo.Items.Refresh();
                }
                else if (((TreeViewItemMenu)tvwFlujo.SelectedItem).empleado != null)
                {
                    itemTarea.Items.Remove((TreeViewItemMenu)tvwFlujo.SelectedItem);
                    tvwFlujo.Items.Refresh();
                }
            }
            else if (tvwFlujoGuardado.SelectedItem != null)
            {
                if (((TreeViewItemMenu)tvwFlujoGuardado.SelectedItem).unidad != null)
                {
                    itemProcesoGuardado.Items.Remove((TreeViewItemMenu)tvwFlujoGuardado.SelectedItem);
                    tvwFlujoGuardado.Items.Refresh();
                }
            }
        }
        //LIMPIAR SELECCION TREEVIEW
        public static void ClearTreeViewSelection(TreeView tv)
        {
            if (tv != null)
                ClearTreeViewItemsControlSelection(tv.Items, tv.ItemContainerGenerator);
        }
        private static void ClearTreeViewItemsControlSelection(ItemCollection ic, ItemContainerGenerator icg)
        {
            if ((ic != null) && (icg != null))
            {
                for (int i = 0; i < ic.Count; i++)
                {
                    TreeViewItem tvi = icg.ContainerFromIndex(i) as TreeViewItem;
                    if (tvi != null)
                    {
                        ClearTreeViewItemsControlSelection(tvi.Items, tvi.ItemContainerGenerator);
                        tvi.IsSelected = false;
                    }
                }
            }
        }
        private void tvwFlujo_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearTreeViewSelection(tvwFlujoGuardado);
        }

        private void tvwFlujoGuardado_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearTreeViewSelection(tvwFlujo);
        }
    }
}
