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
    /// Lógica de interacción para WinCrearTarea.xaml
    /// </summary>
    public partial class WinCrearTarea : Window
    {
        Empleado empleadoAux { get; set; }
        Tarea tareaTemp { get; set; }
        Boolean editar { get; set; }
        public WinCrearTarea(Empleado empleadoAux,Tarea tareaTemp, Boolean editar )
        {
            InitializeComponent();
        }
    }
}
