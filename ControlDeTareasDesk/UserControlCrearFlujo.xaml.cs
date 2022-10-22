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
    /// Lógica de interacción para UserControlCrearFlujo.xaml
    /// </summary>
    public partial class UserControlCrearFlujo : UserControl
    {
        Empleado empleadoAux { get; set; }
        public UserControlCrearFlujo(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            InitializeComponent();
        }
    }
}
