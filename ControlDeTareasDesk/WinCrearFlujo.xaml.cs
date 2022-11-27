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
    public partial class WinCrearFlujo : Window
    {
        Boolean editar { get; set; } = false;
        TreeViewItemMenu itemEditable { get; set; }
        Empleado empleadoAux { get; set; }
        List<Tarea> listTareas = new List<Tarea>();
        List<Empleado> listEmpleado = new List<Empleado>();

        TreeViewItemMenu itemProceso { get; set; }
        TreeViewItemMenu itemProcesoGuardado { get; set; }
        TreeViewItemMenu itemUnidad { get; set; } = new TreeViewItemMenu();
        TreeViewItemMenu itemTarea { get; set; }
        public WinCrearFlujo(Empleado empleadoAux, TreeViewItemMenu itemEditable, Boolean editar)
        {
            this.editar = editar;
            this.itemEditable = itemEditable;
            this.empleadoAux = empleadoAux;
            Proceso proceso = new Proceso();
            Unidad unidad = new Unidad();
            Tarea tarea = new Tarea();
            InitializeComponent();
            //CARGAR COMBOBOX
            cmbProceso.ItemsSource = null;
            cmbProceso.ItemsSource = proceso.Read(empleadoAux.id_empresa_emp);
            cmbUnidad.ItemsSource = null;
            if (editar)
            {
                cmbProceso.SelectedValue = itemEditable.proceso.id_proceso;
                cmbProceso.IsEnabled = false;
            }
            else
            {
                cmbProceso.SelectedIndex = 0;
            }
            cmbUnidad.ItemsSource = null;
            cmbUnidad.ItemsSource = unidad.FindByProceso((decimal)cmbProceso.SelectedValue, empleadoAux.id_empresa_emp);
            cmbUnidad.SelectedIndex = 0;

            EmpleadoCollection listaEmpleado = new EmpleadoCollection();
            //TREEVIEW
            itemProceso = new TreeViewItemMenu() { Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso, proceso = (Proceso)cmbProceso.SelectedItem };
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
            //tvwFlujoGuardado.Items.Add(itemEditable);
            if (editar)
            {
                itemProcesoGuardado = itemEditable;
            }
            else
            {
                itemProcesoGuardado = new TreeViewItemMenu() { Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso, proceso = (Proceso)cmbProceso.SelectedItem };
            }
            tvwFlujoGuardado.Items.Add(itemProcesoGuardado);
        }

        private void cmbProceso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemProceso != null)
            {
                itemProceso.Items.Clear();
                itemProceso.Items.Add(itemUnidad);
                Unidad unidad = new Unidad();
                cmbUnidad.ItemsSource = unidad.FindByProceso((decimal)cmbProceso.SelectedValue, empleadoAux.id_empresa_emp);
                cmbUnidad.Items.Refresh();
                cmbUnidad.SelectedIndex = 0;
                lstTareas.ItemsSource = null;
                lstUsuarios.ItemsSource = null;
                itemProceso.Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso;
                itemProceso.proceso = (Proceso)cmbProceso.SelectedItem;
                tvwFlujo.Items.Refresh();
                if (!editar)
                {
                    itemProcesoGuardado.Items.Clear();
                    itemProcesoGuardado.Titulo = ((Proceso)cmbProceso.SelectedItem).nombre_proceso;
                    itemProcesoGuardado.proceso = (Proceso)cmbProceso.SelectedItem;
                    tvwFlujoGuardado.Items.Refresh();
                }
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
                itemUnidad.unidad = new Unidad() { id_unidad = 0 };
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

        private void btnAnadirTarea_Click(object sender, RoutedEventArgs e)
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
                    if (itemUnidad.Items.Find(x => x.Titulo.Equals(t.nombre_tarea)) != null)
                    {
                        if (MessageBox.Show("La tarea "+t.nombre_tarea+" ya existe en el flujo, ¿desea actualizarla?", "Seleccione una opcion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            (itemUnidad.Items.Find(x => x.Titulo.Equals(t.nombre_tarea))).Items.Clear();
                            foreach (Empleado emp in lstUsuarios.Items)
                            {
                                TreeViewItemMenu itemEmpleado = new TreeViewItemMenu() { Titulo = emp.nombre_emp, empleado = emp };
                                (itemUnidad.Items.Find(x => x.Titulo.Equals(t.nombre_tarea))).Items.Add(itemEmpleado);
                            };
                        }
                        tvwFlujo.Items.Refresh();
                    }
                    else
                    {
                        TreeViewItemMenu itemTareaTemp = new TreeViewItemMenu() { Titulo = t.nombre_tarea, tarea = t };
                        foreach (Empleado emp in lstUsuarios.Items)
                        {
                            TreeViewItemMenu itemEmpleado = new TreeViewItemMenu() { Titulo = emp.nombre_emp, empleado = emp };
                            itemTareaTemp.Items.Add(itemEmpleado);
                        };
                        itemTarea = itemTareaTemp;
                        itemUnidad.Items.Add(itemTareaTemp);
                        tvwFlujo.Items.Refresh();
                    }
                };
            }
        }

        private void btnGuardarUnidad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (itemUnidad.Items != null && itemUnidad.Items.Count != 0)
                {
                    if (itemProcesoGuardado.Items.Find(x => x.Titulo.Equals(itemUnidad.Titulo)) != null)
                    {
                        TreeViewItemMenu unidadEncontrada = itemProcesoGuardado.Items.Find(x => x.Titulo.Equals(itemUnidad.Titulo));
                        if (MessageBox.Show("La Unidad " + unidadEncontrada.Titulo.ToUpper() + " ya existe en el flujo, ¿desea actualizar los cambios?", "Seleccione una opcion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            itemProcesoGuardado.Items.Remove(unidadEncontrada);
                            btnGuardarUnidad_Click(null,null);
                        }
                        tvwFlujoGuardado.Items.Refresh();
                    }
                    else
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
                List<decimal> listDetallesEdits = new List<decimal>();
                List<decimal> listDetallesAntiguos = new List<decimal>();
                 if (itemProcesoGuardado.Items.Count != 0 || itemProcesoGuardado != null)
                {
                    //VERIFICAR SI EL PROCESO EXISTE
                    DetalleTarea vp = new DetalleTarea();
                    if (vp.verificarProceso(itemProcesoGuardado.proceso.id_proceso) && editar == false)
                    {
                        MessageBox.Show("Proceso ya existe");
                        return;
                    }
                    //BUSCAR CADA UNIDAD ALMACENADA EN EL TREEVIEW tvwFlujoGuardado
                    foreach (TreeViewItemMenu unidadEncontrada in itemProcesoGuardado.Items)
                    {
                        if (unidadEncontrada.Items != null || unidadEncontrada.Items.Count != 0)
                        {
                            //BUSCAR CADA TAREA ALAMACENADA EN LA UNIDAD
                            foreach (TreeViewItemMenu tareaEncontrada in unidadEncontrada.Items)
                            {
                                if (tareaEncontrada.Items != null || tareaEncontrada.Items.Count != 0)
                                {
                                    //BUSCAR CADA EMPLEADO ALMACENADO EN LA TAREA
                                    foreach (TreeViewItemMenu empleadoEncontrado in tareaEncontrada.Items)
                                    {
                                        //CREAR DETALLE TAREA
                                        if (editar)
                                        {
                                            DetalleTarea detalleTarea = new DetalleTarea();
                                            //AÑADIR LOS DETALLES ANTIGUOS A UNA LISTA
                                            if (listDetallesAntiguos.Count() == 0 || listDetallesAntiguos == null)
                                            {
                                                foreach (DetalleTarea detalle in detalleTarea.FindByProceso(itemProcesoGuardado.proceso.id_proceso))
                                                {
                                                    listDetallesAntiguos.Add(detalle.id_detalle);
                                                }
                                            }
                                            //DEJAR INTACTO A LOS DETALLES QUE NO FUERON EDITADOS
                                            if (detalleTarea.FindByEmpleadoTarea(empleadoEncontrado.empleado.id_rut, tareaEncontrada.tarea.id_tarea))
                                            {
                                                DetalleTarea detalleTareaTemp = new DetalleTarea();
                                                detalleTareaTemp.FindByEmpleadoTarea(empleadoEncontrado.empleado.id_rut, tareaEncontrada.tarea.id_tarea);
                                                listDetallesEdits.Add(detalleTareaTemp.id_detalle);
                                            }
                                            //AGREGAR LOS NUEVOS DETALLES
                                            else
                                            {
                                                detalleTarea.id_detalle = 0;
                                                detalleTarea.id_rut_detalle = empleadoEncontrado.empleado.id_rut;
                                                detalleTarea.id_tarea_detalle = tareaEncontrada.tarea.id_tarea;
                                                detalleTarea.Create();
                                                listDetallesEdits.Add(detalleTarea.id_detalle);
                                            }
                                        }
                                        else
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
                if (creacionExitosa)
                {
                    MessageBox.Show("flujo creado de manera exitosa");
                }
                //ELIMINAR LOS DETALLES QUE NO ESTAN EN EL NUEVO FLUJO
                if (editar)
                {
                    List<decimal> detallesDiferencia = listDetallesAntiguos.Except(listDetallesEdits).ToList();
                    foreach (decimal detalleEcontrado in detallesDiferencia)
                    {
                        DetalleTarea detalleTemp = new DetalleTarea();
                        detalleTemp.LoadDetalle(detalleEcontrado);
                        Console.WriteLine(detalleTemp.id_detalle.ToString()+ detalleTemp.id_rut_detalle+ detalleTemp.id_tarea_detalle);
                        detalleTemp.Delete();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error al guardar el flujo");
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
                    MessageBox.Show("No puede elimnar el proceso del flujo de edicion");
                }
                else if (((TreeViewItemMenu)tvwFlujo.SelectedItem).unidad != null)
                {
                    MessageBox.Show("No puede elimnar la unidad del flujo de edicion");
                }
                else if (((TreeViewItemMenu)tvwFlujo.SelectedItem).tarea != null)
                {
                    itemUnidad.Items.Remove((TreeViewItemMenu)tvwFlujo.SelectedItem);
                    tvwFlujo.Items.Refresh();
                }
                else
                {
                    itemTarea.Items.Remove((TreeViewItemMenu)tvwFlujo.SelectedItem);
                    tvwFlujo.Items.Refresh();
                }
            }
            else if (tvwFlujoGuardado.SelectedItem != null)
            {
                if (((TreeViewItemMenu)tvwFlujoGuardado.SelectedItem).proceso != null)
                {
                    MessageBox.Show("No puede elimnar el proceso del flujo");
                }
                else if (((TreeViewItemMenu)tvwFlujoGuardado.SelectedItem).unidad != null)
                {
                    itemProcesoGuardado.Items.Remove((TreeViewItemMenu)tvwFlujoGuardado.SelectedItem);
                    tvwFlujoGuardado.Items.Refresh();
                }
                else if (((TreeViewItemMenu)tvwFlujoGuardado.SelectedItem).tarea != null && ((TreeViewItemMenu)tvwFlujoGuardado.SelectedItem).empleado == null)
                {
                    (itemProcesoGuardado.Items.Find(x => x.unidad.id_unidad == ((TreeViewItemMenu)tvwFlujoGuardado.SelectedItem).tarea.id_unidad_tarea)).Items.Remove((TreeViewItemMenu)tvwFlujoGuardado.SelectedItem);
                    tvwFlujoGuardado.Items.Refresh();
                }
                else if (((TreeViewItemMenu)tvwFlujoGuardado.SelectedItem).empleado != null)
                {
                    foreach (TreeViewItemMenu unidadEncontrada in itemProcesoGuardado.Items)
                    {
                        foreach (TreeViewItemMenu tareaEncontrada in unidadEncontrada.Items)
                        {
                            foreach (TreeViewItemMenu empleadoEcontrado in tareaEncontrada.Items)
                            {
                                if (empleadoEcontrado == (TreeViewItemMenu)tvwFlujoGuardado.SelectedItem)
                                {
                                    tareaEncontrada.Items.Remove(empleadoEcontrado);
                                    tvwFlujoGuardado.Items.Refresh();
                                    return;
                                }
                            }
                        }
                    }
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
