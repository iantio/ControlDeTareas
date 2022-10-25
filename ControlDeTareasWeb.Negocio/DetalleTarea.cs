using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeTareasWeb.DAL;

namespace ControlDeTareasWeb.Negocio
{
    public class DetalleTarea
    {
        public decimal id_detalle { get; set; }
        public decimal id_rut_detalle { get; set; }
        public decimal id_tarea_detalle { get; set; }
        public int MyProperty { get; set; }
        public Empleado empleado;
        public Tarea tarea;

        ControlDeTareasEntities db = new ControlDeTareasEntities();

        public Boolean Create()
        {
            DETALLE_TAREA dbDetalleTarea = new DETALLE_TAREA();
            dbDetalleTarea.ID_DETALLE = (int)id_detalle;

            return true;
        }
        public List<DetalleTarea> Read(decimal id_empresa)
        {
            List<DetalleTarea> listDetalle = new List<DetalleTarea>();
            try
            {
                var detalles = from c in db.DETALLE_TAREA
                               where c.EMPLEADO.ID_EMPRESA_EMP == id_empresa
                               select c;
                foreach (DETALLE_TAREA x in detalles)
                {
                    id_detalle = (decimal)x.ID_DETALLE;
                    id_rut_detalle = (decimal)x.ID_RUT_DETALLE;
                    id_tarea_detalle = (decimal)x.ID_TAREA_DETALLE;
                    empleado.LoadEmpleado((decimal)x.ID_RUT_DETALLE);
                    tarea.LoadTarea(id_tarea_detalle);
                    listDetalle.Add(this);
                }
            }
            catch
            {
                Console.WriteLine("Error al leer datos");
            }
            return listDetalle;
        }
    }
}
