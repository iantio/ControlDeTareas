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
    /// Lógica de interacción para WinCrearProceso.xaml
    /// </summary>
    public partial class WinCrearProceso : Window
    {
        Empleado empleadoAux { get; set; }
        Proceso procesoTemp { get; set; }
        Boolean editar { get; set; }
        public WinCrearProceso(Empleado empleadoAux,Proceso procesoTemp, Boolean editar)
        {
            this.procesoTemp = procesoTemp;
            this.editar = editar;
            this.empleadoAux = empleadoAux;
            InitializeComponent();
            if (editar == true)
            {
                txtNombreProceso.Text = this.procesoTemp.nombre_proceso;
                dtpFechaInicio.SelectedDate = procesoTemp.fecha_inicio;
                dtpFechaTermino.SelectedDate = procesoTemp.fecha_termino;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Proceso proceso = new Proceso();
            Console.WriteLine();
            proceso.id_estado_pro = 2;
            proceso.id_empresa_pro = empleadoAux.id_empresa_emp;
            proceso.nombre_proceso = txtNombreProceso.Text;
            proceso.fecha_inicio = dtpFechaInicio.SelectedDate.Value;
            proceso.fecha_termino = dtpFechaTermino.SelectedDate.Value;
            switch (editar)
            {
                case false:
                    proceso.id_proceso = 0;
                    if (proceso.Create())
                    {
                        MessageBox.Show("Proceso creado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el proceso");
                    }
                    break;
                case true:
                    proceso.id_proceso = procesoTemp.id_proceso;
                    if (proceso.Update())
                    {
                        MessageBox.Show("Proceso editado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al editar el proceso");
                    }
                    break;
            }
        }
    }
}
