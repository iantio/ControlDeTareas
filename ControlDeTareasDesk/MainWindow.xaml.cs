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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Empleado empleadoAux = new Empleado();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInicioSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Empleado empleado = new Empleado();
                empleadoAux = empleado.Find(txtUsuario.Text);
                if (txtEmpresa.Text.Trim() == "")
                {
                    MessageBox.Show("Debe rellenar el campo Empresa");
                    txtEmpresa.Focus();
                }
                else if(txtUsuario.Text.Trim() == "") 
                {
                    MessageBox.Show("Debe rellenar el campo Usuario");
                    txtUsuario.Focus();
                }
                else if (pwdClave.Password.Trim() == "")
                {
                    MessageBox.Show("Debe rellenar el campo Contraseña");
                    pwdClave.Focus();
                }
                else if (empleadoAux == null)
                {
                    MessageBox.Show("Credenciales invalidas");
                    Console.WriteLine("Usuario no encontrado");
                }
                else if (txtEmpresa.Text.ToLower() != empleadoAux.empresa.nombre_empresa || txtUsuario.Text.ToLower() != empleadoAux.usuario || pwdClave.Password != empleadoAux.clave)
                {
                    Console.WriteLine(empleadoAux.id_rut+' '+ empleadoAux.usuario +' '+ empleadoAux.clave);
                    MessageBox.Show("Credenciales invalidas");
                }
                else
                {
                    MenuPrincipal windowListarContrato = new MenuPrincipal(empleadoAux);
                    windowListarContrato.ShowDialog();
                    empleadoAux = null;
                    txtEmpresa.Clear();
                    txtUsuario.Clear();
                    pwdClave.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Credenciales invalidas");
            }
        }
    }
}
