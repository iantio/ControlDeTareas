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
        int contadorNotificaciones = 0;
        DetalleTarea detalleNotificacion { get; set; } = new DetalleTarea();
        Empleado empleadoAux;
        public MenuPrincipal(Empleado empleadoAux)
        {
            //Inicializar componentes
            InitializeComponent();
            //Verificador notificaciones
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5); //seleccion tiempo de actualizacion formato = (h,m,s)
            dispatcherTimer.Start();

            this.empleadoAux = empleadoAux;
            lblBienvenida.Content = "¡Bienvenido " + this.empleadoAux.nombre_emp.ToUpper()+"!";
            lblRol.Content = this.empleadoAux.rol.nombre_rol;

            var menuUsuarios = new List<SubItem>();
            menuUsuarios.Add(new SubItem("Administracion usuarios",new UserControlUsuarios(empleadoAux)));
            //menuUsuarios.Add(new SubItem("Roles"));
            var item0 = new ItemMenu("Registro", menuUsuarios, PackIconKind.Register);

            var menuProcesos = new List<SubItem>();
            menuProcesos.Add(new SubItem("Procesos", new UserControlProcesos(empleadoAux)));
            menuProcesos.Add(new SubItem("Unidades",new UserControlUnidad(empleadoAux)));
            menuProcesos.Add(new SubItem("Tareas",new UserControlTarea(empleadoAux)));
            var item1 = new ItemMenu("Procesos", menuProcesos, PackIconKind.Ballot);

            var menuDiseño = new List<SubItem>();
            menuDiseño.Add(new SubItem("Diseñar flujo", new UserControlCrearFlujo(empleadoAux)));
            menuDiseño.Add(new SubItem("Control de fujos", new UserControlListarFlujo(empleadoAux)));

            var item2 = new ItemMenu("Diseño", menuDiseño, PackIconKind.DeveloperBoard);

            var item = new ItemMenu("Dashboad", new UserControlInicio(empleadoAux), PackIconKind.ViewDashboard);

            var test = new ItemMenu("Test", new UserControlTest(empleadoAux), PackIconKind.Settings);
            if (empleadoAux.rol.nombre_rol == "ADMINISTRADOR")
            {
                Menu.Children.Add(new UserControlMenuItem(item, this));
                Menu.Children.Add(new UserControlMenuItem(item0, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
                Menu.Children.Add(new UserControlMenuItem(item2, this));
                Menu.Children.Add(new UserControlMenuItem(test, this));
            }
            else if (empleadoAux.rol.nombre_rol == "DISEÑADOR")
            {
                Menu.Children.Add(new UserControlMenuItem(item, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
                Menu.Children.Add(new UserControlMenuItem(item2, this));
            }
            else if (empleadoAux.rol.nombre_rol == "FUNCIONARIO")
            {
                Menu.Children.Add(new UserControlMenuItem(item, this));
                Menu.Children.Add(new UserControlMenuItem(test, this));
            }
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
        //funcion de la variable que se actualizara con el temporizador
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            contadorNotificaciones = detalleNotificacion.verificarNotificacion(empleadoAux);
            if (contadorNotificaciones == 0)
            {
                countNotificacion.Badge = null;
            }
            else
            {
                countNotificacion.Badge = contadorNotificaciones;
            }
        }
        private void btnNotificacion_Click(object sender, RoutedEventArgs e)
        {
            WinNotificaciones winNotificacion = new WinNotificaciones(empleadoAux);
            winNotificacion.ShowDialog();
        }
    }
}
