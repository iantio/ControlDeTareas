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
    /// Lógica de interacción para WinNotificaciones.xaml
    /// </summary>
    public partial class WinNotificaciones : Window
    {
        Empleado empleadoAux { get; set; }
        public WinNotificaciones(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            DetalleTarea detalleNotificacion = new DetalleTarea();
            InitializeComponent();
            itemsNotificacion.ItemsSource = detalleNotificacion.ListarNotificacion(empleadoAux.id_rut);
            if (itemsNotificacion == null || itemsNotificacion.Items.Count == 0)
            {
                lblSinNotificaciones.Visibility = Visibility.Visible ;
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            DetalleTarea detalle = (DetalleTarea)(((Button)sender).DataContext);
            detalle.id_estado_detalle= 3;
            detalle.justificacion = null;
            detalle.Update();
            Console.WriteLine(detalle.id_estado_detalle);
            refrescar();
        }
        private void refrescar()
        {
            DetalleTarea detalleNotificacion = new DetalleTarea();
            itemsNotificacion.ItemsSource = detalleNotificacion.ListarNotificacion(empleadoAux.id_rut);
            itemsNotificacion.Items.Refresh();
            if (itemsNotificacion == null || itemsNotificacion.Items.Count == 0)
            {
                lblSinNotificaciones.Visibility = Visibility.Visible;
            }
        }

        private void btnRechazar_Click(object sender, RoutedEventArgs e)
        {
            WinDialogNotificacion dialogNotificacion = new WinDialogNotificacion(null);
            dialogNotificacion.ShowDialog();
            if (dialogNotificacion.Resultado)
            {
                DetalleTarea detalle = (DetalleTarea)(((Button)sender).DataContext);
                detalle.id_estado_detalle = 2;
                detalle.justificacion = dialogNotificacion.Text;
                detalle.Update();
                refrescar();
                Console.WriteLine(dialogNotificacion.Text);
            }
        }
    }
}
