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
    /// Lógica de interacción para WinCrearUnidad.xaml
    /// </summary>
    public partial class WinCrearUnidad : Window
    {
        Empleado empleadoAux { get; set; }
        Unidad unidadTemp { get; set; }
        Boolean editar { get; set; }
        public WinCrearUnidad(Empleado empleadoAux, Unidad unidadTemp, Boolean editar)
        {
            this.empleadoAux = empleadoAux;
            this.editar = editar;
            InitializeComponent();
            Proceso proceso = new Proceso();
            Estado estado = new Estado();
            cmbProceso.ItemsSource = proceso.Read(empleadoAux.id_empresa_emp);
            cmbEstado.ItemsSource = estado.ReadAll();
            if (this.editar == true)
            {
                this.unidadTemp = unidadTemp;
                txtNombre.Text = this.unidadTemp.nombre_unidad;
                cmbProceso.SelectedValue = unidadTemp.id_proceso_uni;
                cmbEstado.SelectedValue = unidadTemp.id_estado_uni;
                dtpFechaInicio.SelectedDate = unidadTemp.fecha_inicio;
                dtpFechaTermino.SelectedDate = unidadTemp.fecha_termino;
            }
            else
            {
                this.unidadTemp = new Unidad();
            }
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre");
                txtNombre.Focus();
            }
            else if (dtpFechaInicio.SelectedDate == null)
            {
                MessageBox.Show("Debe ingresar una fecha de inicio");
                txtNombre.Focus();
            }
            else if (dtpFechaTermino.SelectedDate == null)
            {
                MessageBox.Show("Debe ingresar una fecha de inicio");
                txtNombre.Focus();
            }
            else
            {
                unidadTemp.id_proceso_uni = (decimal)cmbProceso.SelectedValue;
                unidadTemp.id_estado_uni = (decimal)cmbEstado.SelectedValue;
                unidadTemp.id_empresa_uni = empleadoAux.id_empresa_emp;
                unidadTemp.nombre_unidad = txtNombre.Text;
                unidadTemp.fecha_inicio = dtpFechaInicio.SelectedDate.Value;
                unidadTemp.fecha_termino = dtpFechaTermino.SelectedDate.Value;
                switch (this.editar)
                {
                    case false:
                        unidadTemp.id_unidad = 0;
                        if (unidadTemp.Create())
                        {
                            MessageBox.Show("Unidad guardada correctamente");
                        }
                        else
                        {
                            MessageBox.Show("Error al crear la unidad");
                        }
                        break;
                    case true:
                        if (unidadTemp.Update())
                        {
                            MessageBox.Show("Unidad guardada correctamente");
                        }
                        else
                        {
                            MessageBox.Show("Error al editar la unidad");
                        }
                        break;
                }
            }
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
