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

        public Empleado empleado { get; set; }
        public Tarea tarea { get; set; }

        ControlDeTareasEntities db = new ControlDeTareasEntities();

        public Boolean Create()
        {
            try
            {
                DETALLE_TAREA dbDetalleTarea = new DETALLE_TAREA();
                dbDetalleTarea.ID_DETALLE = db.DETALLE_TAREA.Max(x => x.ID_DETALLE) + 1;
                dbDetalleTarea.ID_RUT_DETALLE = (int)id_rut_detalle;
                dbDetalleTarea.ID_TAREA_DETALLE = (int)id_tarea_detalle;

                db.DETALLE_TAREA.Add(dbDetalleTarea);
                db.SaveChanges();

                return true;
            }
            catch
            {
                Console.WriteLine("Error al crear Detalle Tarea");
                return false;
            }
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
                    empleado = new Empleado();
                    empleado.LoadEmpleado((decimal)x.ID_RUT_DETALLE);
                    tarea = new Tarea();
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
        public Boolean Delete()
        {
            try
            {
                DETALLE_TAREA dbDetalleTarea = db.DETALLE_TAREA.First(x => x.ID_DETALLE == id_detalle);
                db.DETALLE_TAREA.Remove(dbDetalleTarea);
                db.SaveChanges();

                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el Detalle Tarea");
                return false;
            }
        }
        public List<DetalleTarea> FindByEmpleado(decimal id_rut)
        {
            List<DetalleTarea> listaDetalle = new List<DetalleTarea>();
            var dbDetalles = db.DETALLE_TAREA.Where(x => x.ID_RUT_DETALLE == id_rut);
            foreach (DETALLE_TAREA dbDetalle in dbDetalles)
            {
                DetalleTarea detalle = new DetalleTarea();
                detalle.id_detalle = (decimal)dbDetalle.ID_DETALLE;
                detalle.id_rut_detalle = (decimal)dbDetalle.ID_RUT_DETALLE;
                detalle.id_tarea_detalle = (decimal)dbDetalle.ID_TAREA_DETALLE;
                detalle.empleado = new Empleado();
                detalle.empleado.LoadEmpleado(id_rut);
                detalle.tarea = new Tarea();
                detalle.tarea.LoadTarea((decimal)dbDetalle.ID_TAREA_DETALLE);
                listaDetalle.Add(detalle);
            }
            return listaDetalle;
        }
        public List<DetalleTarea> FindByTarea(decimal id_tarea)
        {
            List<DetalleTarea> listaDetalle = new List<DetalleTarea>();
            var dbDetalles = db.DETALLE_TAREA.Where(x => x.ID_TAREA_DETALLE == id_tarea);
            foreach (DETALLE_TAREA dbDetalle in dbDetalles)
            {
                DetalleTarea detalle = new DetalleTarea();
                detalle.id_detalle = (decimal)dbDetalle.ID_DETALLE;
                detalle.id_rut_detalle = (decimal)dbDetalle.ID_RUT_DETALLE;
                detalle.id_tarea_detalle = (decimal)dbDetalle.ID_TAREA_DETALLE;
                detalle.empleado = new Empleado();
                detalle.empleado.LoadEmpleado((decimal)dbDetalle.ID_RUT_DETALLE);
                detalle.tarea = new Tarea();
                detalle.tarea.LoadTarea(id_tarea);
                listaDetalle.Add(detalle);
            }
            return listaDetalle;
        }
    }
}
