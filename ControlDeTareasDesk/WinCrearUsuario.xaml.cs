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
    /// Lógica de interacción para WinCrearUsuario.xaml
    /// </summary>
    public partial class WinCrearUsuario : Window
    {
        Empleado empleadoAux;
        Empleado empleadoTemp;
        public WinCrearUsuario(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            InitializeComponent();

            Rol rolCombo = new Rol();
            cmbRol.ItemsSource = rolCombo.ListarNombres();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if (txtRut.Text.Trim() == "") 
            {
                MessageBox.Show("Debe ingresar un rut");
                txtRut.Focus();
            }
            else if (!int.TryParse(txtRut.Text,out num))
            {
                MessageBox.Show("Debe ingresar un rut");
                txtRut.Focus();
            }
            else if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre");
            }
        }
    }
}
