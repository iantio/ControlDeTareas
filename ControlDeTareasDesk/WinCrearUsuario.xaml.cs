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
        Empleado empleadoTemp { get; set; }

        public WinCrearUsuario(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            
            InitializeComponent();
            empleadoTemp = new Empleado();

            Rol rolCombo = new Rol();
            cmbRol.ItemsSource = rolCombo.ListarNombres();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(System.DateTime.Now);
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            int num; //variable utilizada para la conversion a int

            if (txtRut.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un rut");
                txtRut.Focus();
            }
            else if (!int.TryParse(txtRut.Text, out num))
            {
                MessageBox.Show("Debe ingresar un rut");
                txtRut.Focus();
            }
            else if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre");
                txtNombre.Focus();
            }
            else if (txtUsuario.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Usuario");
                txtUsuario.Focus();
            }
            else if (pwdClave.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una contraseña");
                pwdClave.Focus();
            }
            else 
            {
                empleadoTemp.id_rut = int.Parse(txtRut.Text);
                empleadoTemp.id_empresa_emp = empleadoAux.id_empresa_emp;
                empleadoTemp.id_rol_emp = cmbRol.SelectedIndex;
                empleadoTemp.fecha_ingreso = System.DateTime.Now.Date;
                empleadoTemp.nombre_emp = txtNombre.Text;
                empleadoTemp.usuario = txtUsuario.Text;
                empleadoTemp.clave = pwdClave.Text;
                try
                {
                    if (empleadoTemp.Create())
                    {
                        MessageBox.Show("Usuario Creado");
                    }
                    else 
                    {
                        MessageBox.Show("Error al crear");
                    }
                }
                catch 
                {
                    MessageBox.Show("Error al crear");
                }

            }
        }
    }
}
