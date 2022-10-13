﻿using System;
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
    /// Lógica de interacción para UserControlProcesos.xaml
    /// </summary>
    public partial class UserControlProcesos : UserControl
    {
        Empleado empleadoAux { get; set; }
        public UserControlProcesos(Empleado empleadoAux)
        {
            this.empleadoAux = empleadoAux;
            InitializeComponent();
            Proceso proceso = new Proceso();
            dgProcesos.ItemsSource = null;
            dgProcesos.ItemsSource = proceso.Read(empleadoAux.id_empresa_emp);
            dgProcesos.Items.Refresh();
        }
        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            WinCrearProceso crear = new WinCrearProceso(empleadoAux);
            crear.ShowDialog();
        }
    }
}
