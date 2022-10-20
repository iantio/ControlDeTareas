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
            this.empleadoAux = empleadoAux;
            this.editar = editar;
            InitializeComponent();
            Proceso proceso = new Proceso();
            Estado estado = new Estado();
            cmbProceso.ItemsSource = proceso.Read(empleadoAux.id_empresa_emp);
            cmbEstado.ItemsSource = estado.ReadAll();
            if (editar)
            {
                this.tareaTemp = tareaTemp;
                txtNombre.Text = tareaTemp.nombre_tarea;
                dtpFechaInicio.SelectedDate = tareaTemp.fecha_inicio;
                dtpFechaTermino.SelectedDate = tareaTemp.fecha_termino;
                cmbProceso.SelectedValue = tareaTemp.unidad.proceso.id_proceso;
                cmbUnidad.SelectedValue = tareaTemp.unidad.id_unidad;
                cmbEstado.SelectedValue = tareaTemp.estado.id_estado;
            }
            else
            {
                this.tareaTemp = new Tarea();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("debe ingresar un nombre");
                txtNombre.Focus();
            }
            else if (dtpFechaInicio.SelectedDate == null)
            {
                MessageBox.Show("debe seleccionar un fecha de inicio");
            }
            else if (dtpFechaTermino.SelectedDate == null)
            {
                MessageBox.Show("debe seleccionar una fecha de termino");
            }
            else
            {
                tareaTemp.id_unidad_tarea = (decimal)cmbUnidad.SelectedValue;
                tareaTemp.id_empresa_tarea = empleadoAux.id_empresa_emp;
                tareaTemp.id_estado_tarea = (decimal)cmbEstado.SelectedValue;
                tareaTemp.nombre_tarea = txtNombre.Text;
                tareaTemp.fecha_inicio = dtpFechaInicio.SelectedDate.Value;
                tareaTemp.fecha_termino = dtpFechaTermino.SelectedDate.Value;
                switch (this.editar)
                {
                    case false:
                        if (tareaTemp.Create())
                        {
                            MessageBox.Show("tarea creada correctamente");
                        }
                        else
                        {
                            MessageBox.Show("error al crear la tarea");
                        }
                        break;

                    case true:
                        if (tareaTemp.Update())
                        {
                            MessageBox.Show("tarea editada correctamente");
                        }
                        else
                        {
                            MessageBox.Show("error al editar la tarea");
                        }
                        break;
                }
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbProceso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unidad unidad = new Unidad();
            Console.WriteLine(((Proceso)cmbProceso.SelectedItem).nombre_proceso, cmbUnidad.SelectedIndex.ToString());
            cmbUnidad.ItemsSource = unidad.FindByProceso(((Proceso)cmbProceso.SelectedItem).nombre_proceso, empleadoAux.id_empresa_emp);
            cmbUnidad.SelectedIndex = 0;
        }
    }
}
