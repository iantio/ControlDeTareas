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
    /// Lógica de interacción para UserControlListarFlujo.xaml
    /// </summary>
    public partial class UserControlListarFlujo : UserControl
    {
        Empleado empleadoAux;
        TreeViewItemMenu tree { get; set; } = new TreeViewItemMenu();
        int index { get; set; } = 0;
        int totalProcesos { get; set; } = 0;
        public UserControlListarFlujo(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            InitializeComponent();
            try
            {
                tree.ReadDetalleUsuarios(empleadoAux);
                totalProcesos = tree.Items.Count;
                foreach (TreeViewItemMenu procesoEncontrado in tree.Items)
                {
                    tvwFlujo.Items.Add(procesoEncontrado);
                }
                tvwFlujo.Items.Refresh();
            }
            catch { }
        }
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            tree.Items.Clear();
            tree.ReadDetalleUsuarios(empleadoAux);
            tvwFlujo.Items.Clear();
            foreach (TreeViewItemMenu procesoEncontrado in tree.Items)
            {
                tvwFlujo.Items.Add(procesoEncontrado);
            }
            tvwFlujo.Items.Refresh();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            List<DetalleTarea> listaDetalles = new List<DetalleTarea>();
            if (tvwFlujo.SelectedItem == null)
            {
                MessageBox.Show("debe seleccionar una fila a eliminar");
            }
            else if (((TreeViewItemMenu)tvwFlujo.SelectedItem).proceso != null)
            {
                TreeViewItemMenu itemTemp = (TreeViewItemMenu)tvwFlujo.SelectedItem;
                DetalleTarea detalleTemp = new DetalleTarea();
                foreach (TreeViewItemMenu itemUnidad in itemTemp.Items)
                {
                    foreach (TreeViewItemMenu tareaEncontrada in itemUnidad.Items)
                    {
                        listaDetalles = detalleTemp.FindByTarea(tareaEncontrada.tarea.id_tarea);
                        foreach (DetalleTarea detalleEncontrado in listaDetalles)
                        {
                            detalleEncontrado.Delete();
                        }
                    }
                }
                Console.WriteLine("proceso seleccionado");
                btnRefrescar_Click(null, null);
            }
            else if (((TreeViewItemMenu)tvwFlujo.SelectedItem).unidad != null)
            {
                TreeViewItemMenu itemTemp = (TreeViewItemMenu)tvwFlujo.SelectedItem;
                DetalleTarea detalleTemp = new DetalleTarea();
                foreach (TreeViewItemMenu tareaEncontrada in itemTemp.Items)
                {
                    listaDetalles = detalleTemp.FindByTarea(tareaEncontrada.tarea.id_tarea);
                    foreach (DetalleTarea detalleEncontrado in listaDetalles)
                    {
                        detalleEncontrado.Delete();
                    }
                }
                Console.WriteLine("unidad seleccionada");
                btnRefrescar_Click(null, null);
            }
            else if (((TreeViewItemMenu)tvwFlujo.SelectedItem).tarea != null && ((TreeViewItemMenu)tvwFlujo.SelectedItem).empleado == null)
            {
                TreeViewItemMenu itemTemp = (TreeViewItemMenu)tvwFlujo.SelectedItem;
                DetalleTarea detalleTemp = new DetalleTarea();
                listaDetalles = detalleTemp.FindByTarea(itemTemp.tarea.id_tarea);
                foreach (DetalleTarea detalleEncontrado in listaDetalles)
                {
                    detalleEncontrado.Delete();
                }
                Console.WriteLine("tarea seleccionada");
                btnRefrescar_Click(null, null);
            }
            else if (((TreeViewItemMenu)tvwFlujo.SelectedItem).empleado != null)
            {
                TreeViewItemMenu itemTemp = (TreeViewItemMenu)tvwFlujo.SelectedItem;
                DetalleTarea detalleTemp = new DetalleTarea();

                detalleTemp.FindByEmpleadoTarea(itemTemp.empleado.id_rut, itemTemp.tarea.id_tarea);
                detalleTemp.Delete();

                btnRefrescar_Click(null, null);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (tvwFlujo.SelectedItem != null && ((TreeViewItemMenu)tvwFlujo.SelectedItem).proceso != null)
            {
                WinCrearFlujo winEditar = new WinCrearFlujo(empleadoAux, (TreeViewItemMenu)tvwFlujo.SelectedItem, true);
                winEditar.ShowDialog();
            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            WinCrearFlujo winCrear = new WinCrearFlujo(empleadoAux, null, false);
            winCrear.ShowDialog();
        }
    }
}
