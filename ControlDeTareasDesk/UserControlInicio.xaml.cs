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
    /// Lógica de interacción para UserControlInicio.xaml
    /// </summary>
    public partial class UserControlInicio : UserControl
    {
        Empleado empleadoAux;
        TreeViewItemMenu tree { get; set; } = new TreeViewItemMenu();
        int index { get; set; } = 0;
        int totalProcesos { get; set; } = 0;
        public UserControlInicio(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            InitializeComponent();
            try
            {
                tree.ReadDetalle(empleadoAux);
                totalProcesos = tree.Items.Count;
                lblTitle.Content = ("PROCESO: "+((TreeViewItemMenu)tree.Items[index]).proceso.nombre_proceso+" ["+(index+1)+"/"+totalProcesos+"]");
                pbProgreso.Value = ((TreeViewItemMenu)tree.Items[index]).Porcentaje;
                foreach (TreeViewItemMenu unidadEncontrada in ((TreeViewItemMenu)tree.Items[index]).Items)
                {
                    tvwFlujo.Items.Add(unidadEncontrada);
                }
                tvwFlujo.Items.Refresh();
            }
            catch{ }
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tree.Items.Clear();
                tree.ReadDetalle(empleadoAux);
                tvwFlujo.Items.Clear();
                foreach (TreeViewItemMenu unidadEncontrada in ((TreeViewItemMenu)tree.Items[index]).Items)
                {
                    tvwFlujo.Items.Add(unidadEncontrada);
                }
                totalProcesos = tree.Items.Count;
                lblTitle.Content = ("PROCESO: " + ((TreeViewItemMenu)tree.Items[index]).proceso.nombre_proceso + " [" + (index + 1) + "/" + totalProcesos + "]");
                tvwFlujo.Items.Refresh();
                pbProgreso.Value = ((TreeViewItemMenu)tree.Items[index]).Porcentaje;
            }
            catch
            {
                lblTitle.Content = "Sin procesos asignados";
                Console.WriteLine("procesos no encontrados");
            }
        }

        private void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            if (tvwFlujo.SelectedItem == null || ((TreeViewItemMenu)tvwFlujo.SelectedItem).proceso != null || ((TreeViewItemMenu)tvwFlujo.SelectedItem).unidad != null)
            {
                MessageBox.Show("Debe seleccionar una tarea para marcarla como terminada");
            }
            else if (MessageBox.Show("Desea marcar la tarea " + ((TreeViewItemMenu)tvwFlujo.SelectedItem).tarea.nombre_tarea + " como terminada", "Terminar tarea", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DetalleTarea detalleTerminado = new DetalleTarea();
                detalleTerminado.FindByEmpleadoTarea(empleadoAux.id_rut, ((TreeViewItemMenu)tvwFlujo.SelectedItem).tarea.id_tarea);
                detalleTerminado.id_estado_detalle = 5;
                detalleTerminado.Update();
                Console.WriteLine(detalleTerminado.id_detalle);
            }
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (totalProcesos == 0)
            {
                return;
            }
            else if (totalProcesos == index + 1)
            {
                index = 0;
                btnRefrescar_Click(null, null);
            }
            else
            {
                index += 1;
                btnRefrescar_Click(null, null);
            }
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            if (totalProcesos == 0)
            {
                return;
            }
            else if ((index+1)-totalProcesos != 0)
            {
                index = totalProcesos-1;
                btnRefrescar_Click(null, null);
            }
            else
            {
                index -= 1;
                btnRefrescar_Click(null, null);
            }
        }
    }
}
