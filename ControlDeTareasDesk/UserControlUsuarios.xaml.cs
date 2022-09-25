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
    /// Lógica de interacción para UserControlUsuarios.xaml
    /// </summary>
    public partial class UserControlUsuarios : UserControl
    {
        Empleado empleadoAux;
        Empleado empleadoTemp;
        public UserControlUsuarios(Empleado empleadoAux)
        {
            InitializeComponent();
            this.empleadoAux = empleadoAux;
            EmpleadoCollection empleadoCollection = new EmpleadoCollection();
            dgUsuarios.ItemsSource = null;
            //dgUsuarios.ItemsSource = empleadoAux.ReadAll();               *OTRA FORMA DE OBTENER LA LISTA DE USUARIOS*
            dgUsuarios.ItemsSource = empleadoCollection.ReadByEmpresa(empleadoAux.id_empresa_emp);
            dgUsuarios.Items.Refresh();
        }

        private void btnBuscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado();
            String test = (String)cmbFiltro.Text;
            String busqueda = txtBuscar.Text;
            EmpleadoCollection empleadoCollection = new EmpleadoCollection();
            switch (test.Trim())
            {
                case "":
                    Console.WriteLine("busqueda vacia");
                    break;
                case "Rut":
                    try
                    {
                        dgUsuarios.ItemsSource = null;
                        dgUsuarios.ItemsSource = empleadoCollection.FindByRut(int.Parse(txtBuscar.Text), empleadoAux.id_empresa_emp);
                        dgUsuarios.Items.Refresh();
                    }
                    catch { MessageBox.Show("Usuario no encontrado"); }
                    break;
                case "Nombre":
                    try
                    {
                        empleadoCollection.FindByNombre(busqueda, empleadoAux.id_empresa_emp);
                        if ((empleadoCollection.FindByNombre(txtBuscar.Text, empleadoAux.id_empresa_emp)).First() == null)
                        {
                            Console.WriteLine("error");
                        }
                        dgUsuarios.ItemsSource = null;
                        dgUsuarios.ItemsSource = empleadoCollection.FindByNombre(txtBuscar.Text, empleadoAux.id_empresa_emp);
                        dgUsuarios.Items.Refresh();
                    }
                    catch { MessageBox.Show("Usuario no encontrado"); }
                    break;
            }
        }

        private void btnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            WinCrearUsuario crearUsuario = new WinCrearUsuario(empleadoAux);
            crearUsuario.ShowDialog();
            EmpleadoCollection empleadoCollection = new EmpleadoCollection();
            dgUsuarios.ItemsSource = null;
            dgUsuarios.ItemsSource = empleadoCollection.ReadAll();
            dgUsuarios.Items.Refresh();
        }

        private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            empleadoTemp = (Empleado)dgUsuarios.SelectedItem;
            if (dgUsuarios.SelectedItem != null)
            {
                if (empleadoTemp.Delete())
                {
                    empleadoTemp = (Empleado)dgUsuarios.SelectedItem;
                    MessageBox.Show("empleado eliminado");
                    EmpleadoCollection empleadoCollection = new EmpleadoCollection();
                    dgUsuarios.ItemsSource = null;
                    dgUsuarios.ItemsSource = empleadoCollection.ReadAll();
                    dgUsuarios.Items.Refresh();
                }
                else 
                {
                    MessageBox.Show("Error al eliminar");
                }
            }
            else { MessageBox.Show("Debe seleccionar un empleado"); }
        }
    }
}
