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

namespace ControlDeTareasDesk
{
    /// <summary>
    /// Lógica de interacción para WinDialogNotificacion.xaml
    /// </summary>
    public partial class WinDialogNotificacion : Window
    {
        public Boolean Resultado { get; set; }
        public String Text { get; set; }
        public WinDialogNotificacion()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (txtJustifiacion.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una justificacion");
            }
            else
            {
                Text = txtJustifiacion.Text;
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
