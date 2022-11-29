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
    /// Lógica de interacción para WinDialogNotificacion.xaml
    /// </summary>
    public partial class WinDialogNotificacion : Window
    {

        public Boolean Resultado { get; set; }
        public String Text { get; set; }
        DetalleTarea detalleTarea { get; set; }
        public WinDialogNotificacion(DetalleTarea detalleTarea)
        {
            this.detalleTarea = detalleTarea;
            InitializeComponent();
            if(detalleTarea != null)
            {
                lblTitulo.Content = "Justificacion de "+detalleTarea.empleado.nombre_emp+":";
                txtJustificacion.Text = detalleTarea.justificacion;
                txtJustificacion.IsReadOnly = true;
                btnEnviar.Content = "Reenviar";
            }
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (detalleTarea != null)
            {
                detalleTarea.id_estado_detalle = 1;
                detalleTarea.Update();
                MessageBox.Show("notificacion reenviada");
            }
            else if (txtJustificacion.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una justificacion");
            }
            else
            {
                Text = txtJustificacion.Text;
                Resultado = true;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Resultado = false;
            this.Close();
        }
    }
}
