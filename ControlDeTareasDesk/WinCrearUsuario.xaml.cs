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
        bool editar { get; set; }
        public WinCrearUsuario(Empleado empleadoAux,Empleado empleadoTemp,bool editar)
        {
            this.empleadoAux = empleadoAux;
            this.editar = editar;
            this.empleadoTemp = new Empleado();
            InitializeComponent();
            dtpFechaIngreso.SelectedDate = System.DateTime.Now;
            if (editar == true)
            {
                this.empleadoTemp = empleadoTemp;
                txtRut.IsEnabled = false;
                txtRut.Text = empleadoTemp.id_rut.ToString();
                txtNombre.Text = empleadoTemp.nombre_emp;
                txtUsuario.Text = empleadoTemp.usuario;
                pwdClave.IsEnabled = false;
                pwdClave.Text = empleadoTemp.clave;
                cmbRol.SelectedIndex = (int)empleadoTemp.id_rol_emp;
            };
            Rol rolCombo = new Rol();
            cmbRol.ItemsSource = rolCombo.ListarNombres(empleadoAux.id_empresa_emp);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
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
                empleadoTemp.id_rut = (decimal)int.Parse(txtRut.Text);
                empleadoTemp.id_empresa_emp = empleadoAux.id_empresa_emp;
                empleadoTemp.id_rol_emp = (decimal)cmbRol.SelectedIndex;
                empleadoTemp.fecha_ingreso = dtpFechaIngreso.SelectedDate.Value;
                empleadoTemp.nombre_emp = txtNombre.Text;
                empleadoTemp.usuario = txtUsuario.Text;
                empleadoTemp.clave = pwdClave.Text;
                try
                {
                    switch (editar)
                    {
                        case false:
                            if (empleadoTemp.Create())
                            {
                                MessageBox.Show("Usuario Creado");
                            }
                            else
                            {
                                MessageBox.Show("Error al crear");
                            }
                            break;
                        case true:
                            if (empleadoTemp.Update())
                            {
                                MessageBox.Show("Usuario Actualizado");
                            }
                            else { MessageBox.Show("Error al actualizar"); }
                            break;
                    }
                }
                catch 
                {
                    MessageBox.Show("Error al guardar");
                }

            }
        }
    }
}
