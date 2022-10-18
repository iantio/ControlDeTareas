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
using MaterialDesignThemes.Wpf;
using ControlDeTareasWeb.Negocio;

namespace ControlDeTareasDesk
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        Empleado empleadoAux;
        public MenuPrincipal(Empleado empleadoAux)
        {
            InitializeComponent();
            this.empleadoAux = empleadoAux;
            lblBienvenida.Content = "¡Bienvenido " + this.empleadoAux.nombre_emp.ToUpper()+"!";
            lblRol.Content = this.empleadoAux.rol.nombre_rol;

            var menuUsuarios = new List<SubItem>();
            menuUsuarios.Add(new SubItem("Administracion usuarios",new UserControlUsuarios(empleadoAux)));
            menuUsuarios.Add(new SubItem("Roles"));
            var item0 = new ItemMenu("Registro", menuUsuarios, PackIconKind.Register);

            var menuProcesos = new List<SubItem>();
            menuProcesos.Add(new SubItem("Procesos", new UserControlProcesos(empleadoAux)));
            menuProcesos.Add(new SubItem("Unidades",new UserControlUnidad(empleadoAux)));
            menuProcesos.Add(new SubItem("Tareas",new UserControlTarea(empleadoAux)));
            var item1 = new ItemMenu("Procesos", menuProcesos, PackIconKind.Ballot);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
        }
        internal void SwitchScreen(object sender) 
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
