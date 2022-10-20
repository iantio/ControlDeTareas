using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeTareasWeb.DAL;

namespace ControlDeTareasWeb.Negocio
{
    public class Tarea
    {
        public decimal id_tarea { get; set; }
        public decimal id_unidad_tarea { get; set; }
        public decimal id_estado_tarea { get; set; }
        public decimal id_empresa_tarea { get; set; }
        public String nombre_tarea { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_termino { get; set; }
        public Unidad unidad { get; set; }
        public Estado estado { get; set; }
        public Empresa empresa { get; set; }

        ControlDeTareasEntities db = new ControlDeTareasEntities();

        public Boolean Create()
        {
            try
            {
                TAREA dbTarea = new TAREA();
                dbTarea.ID_TAREA = db.TAREA.Max(x => x.ID_TAREA) + 1;
                dbTarea.ID_UNIDAD_TAREA = (int)id_unidad_tarea;
                dbTarea.ID_ESTADO_TAREA = (short)id_estado_tarea;
                dbTarea.ID_EMPRESA_TAREA = (int)id_empresa_tarea;
                dbTarea.NOMBRE_TAREA = nombre_tarea.ToUpper();
                dbTarea.FECHA_INICIO = fecha_inicio;
                dbTarea.FECHA_TERMINO = fecha_termino;

                db.TAREA.Add(dbTarea);
                db.SaveChanges();
                return true;
            }
            catch
            {
                Console.WriteLine("error al crear la tarea");
                return false;
            }
        }
        public List<Tarea> Read(decimal id_empresa)
        {
            List<Tarea> listaTareas = new List<Tarea>();
            try
            {
                var tareas = from p in db.TAREA
                             where p.ID_EMPRESA_TAREA == id_empresa
                             select p;
                foreach (ControlDeTareasWeb.DAL.TAREA x in tareas)
                {
                    Tarea p = new Tarea();
                    p.id_tarea = (decimal)x.ID_TAREA;
                    p.id_unidad_tarea = (decimal)x.ID_UNIDAD_TAREA;
                    p.id_estado_tarea = (decimal)x.ID_ESTADO_TAREA;
                    p.id_empresa_tarea = (decimal)x.ID_EMPRESA_TAREA;
                    p.nombre_tarea = x.NOMBRE_TAREA;
                    p.fecha_inicio = (DateTime)x.FECHA_INICIO;
                    p.fecha_termino = (DateTime)x.FECHA_TERMINO;
                    p.unidad = new Unidad()
                    {
                        id_unidad = (decimal)x.ID_UNIDAD_TAREA,
                        id_proceso_uni = (decimal)x.UNIDAD.ID_PROCESO_UNI,
                        id_estado_uni = (decimal)x.UNIDAD.ID_ESTADO_UNI,
                        id_empresa_uni = (decimal)x.UNIDAD.ID_EMPRESA_UNI,
                        nombre_unidad = x.UNIDAD.NOMBRE_UNIDAD,
                        fecha_inicio = (DateTime)x.UNIDAD.FECHA_INICIO,
                        fecha_termino = (DateTime)x.UNIDAD.FECHA_TERMINO,
                        estado = new Estado()
                        {
                            id_estado = (decimal)x.UNIDAD.ID_ESTADO_UNI,
                            nombre_estado = x.UNIDAD.ESTADO.NOMBRE_ESTADO
                        },
                        proceso = new Proceso()
                        {
                            id_proceso = (decimal)x.UNIDAD.ID_PROCESO_UNI,
                            id_estado_pro = (decimal)x.UNIDAD.PROCESO.ID_ESTADO_PRO,
                            id_empresa_pro = (decimal)x.UNIDAD.PROCESO.ID_EMPRESA_PRO,
                            nombre_proceso = x.UNIDAD.PROCESO.NOMBRE_PROCESO,
                            fecha_inicio = (DateTime)x.UNIDAD.PROCESO.FECHA_INICIO,
                            fecha_termino = (DateTime)x.UNIDAD.PROCESO.FECHA_TERMINO,
                            estado = new Estado()
                            {
                                id_estado = (decimal)x.UNIDAD.PROCESO.ID_ESTADO_PRO,
                                nombre_estado = x.UNIDAD.PROCESO.ESTADO.NOMBRE_ESTADO
                            },
                            empresa = new Empresa()
                            {
                                id_empresa = (decimal)x.UNIDAD.PROCESO.ID_EMPRESA_PRO,
                                nombre_empresa = x.UNIDAD.PROCESO.EMPRESA.NOMBRE_EMPRESA
                            }
                        },
                        empresa = new Empresa()
                        {
                            id_empresa = (decimal)x.UNIDAD.ID_EMPRESA_UNI,
                            nombre_empresa = x.UNIDAD.EMPRESA.NOMBRE_EMPRESA
                        }
                    };
                    p.estado = new Estado()
                    {
                        id_estado = (decimal)x.ID_ESTADO_TAREA,
                        nombre_estado = x.ESTADO.NOMBRE_ESTADO
                    };
                    p.empresa = new Empresa()
                    {
                        id_empresa = (decimal)x.ID_EMPRESA_TAREA,
                        nombre_empresa = x.EMPRESA.NOMBRE_EMPRESA
                    };
                    listaTareas.Add(p);
                };
                return listaTareas;
            }
            catch
            {
                Console.WriteLine("error al cargar datos de tarea");
                return listaTareas;
            }
        }
        public Boolean Update() 
        {
            try
            {
                TAREA dbTarea = db.TAREA.First(x => x.ID_TAREA == id_tarea);
                dbTarea.ID_UNIDAD_TAREA = (int)id_unidad_tarea;
                dbTarea.ID_ESTADO_TAREA = (short)id_estado_tarea;
                dbTarea.ID_EMPRESA_TAREA = (int)id_empresa_tarea;
                dbTarea.NOMBRE_TAREA = nombre_tarea.ToUpper();
                dbTarea.FECHA_INICIO = fecha_inicio;
                dbTarea.FECHA_TERMINO = fecha_termino;
                db.SaveChanges();
                return true;
            }
            catch
            {
                Console.WriteLine("Error al actualizar");
                return false;
            }
        }
        public Boolean Delete()
        {
            try
            {
                TAREA tarea = db.TAREA.First(x => x.ID_TAREA == id_tarea);
                db.TAREA.Remove(tarea);
                db.SaveChanges();
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar");
                return false;
            }
        }
        public List<Tarea> Find(decimal id_empresa, String busqueda)
        {
            List<Tarea> listaTareas = new List<Tarea>();
            try
            {
                var tareas = from p in db.TAREA
                             where p.ID_EMPRESA_TAREA == id_empresa && p.NOMBRE_TAREA.Contains(busqueda.ToUpper())
                             select p;
                foreach (ControlDeTareasWeb.DAL.TAREA x in tareas)
                {
                    Tarea p = new Tarea();
                    p.id_tarea = (decimal)x.ID_TAREA;
                    p.id_unidad_tarea = (decimal)x.ID_UNIDAD_TAREA;
                    p.id_estado_tarea = (decimal)x.ID_ESTADO_TAREA;
                    p.id_empresa_tarea = (decimal)x.ID_EMPRESA_TAREA;
                    p.nombre_tarea = x.NOMBRE_TAREA;
                    p.fecha_inicio = (DateTime)x.FECHA_INICIO;
                    p.fecha_termino = (DateTime)x.FECHA_TERMINO;
                    p.unidad = new Unidad()
                    {
                        id_unidad = (decimal)x.ID_UNIDAD_TAREA,
                        id_proceso_uni = (decimal)x.UNIDAD.ID_PROCESO_UNI,
                        id_estado_uni = (decimal)x.UNIDAD.ID_ESTADO_UNI,
                        id_empresa_uni = (decimal)x.UNIDAD.ID_EMPRESA_UNI,
                        nombre_unidad = x.UNIDAD.NOMBRE_UNIDAD,
                        fecha_inicio = (DateTime)x.UNIDAD.FECHA_INICIO,
                        fecha_termino = (DateTime)x.UNIDAD.FECHA_TERMINO,
                        estado = new Estado()
                        {
                            id_estado = (decimal)x.UNIDAD.ID_ESTADO_UNI,
                            nombre_estado = x.UNIDAD.ESTADO.NOMBRE_ESTADO
                        },
                        proceso = new Proceso()
                        {
                            id_proceso = (decimal)x.UNIDAD.ID_PROCESO_UNI,
                            id_estado_pro = (decimal)x.UNIDAD.PROCESO.ID_ESTADO_PRO,
                            id_empresa_pro = (decimal)x.UNIDAD.PROCESO.ID_EMPRESA_PRO,
                            nombre_proceso = x.UNIDAD.PROCESO.NOMBRE_PROCESO,
                            fecha_inicio = (DateTime)x.UNIDAD.PROCESO.FECHA_INICIO,
                            fecha_termino = (DateTime)x.UNIDAD.PROCESO.FECHA_TERMINO,
                            estado = new Estado()
                            {
                                id_estado = (decimal)x.UNIDAD.PROCESO.ID_ESTADO_PRO,
                                nombre_estado = x.UNIDAD.PROCESO.ESTADO.NOMBRE_ESTADO
                            },
                            empresa = new Empresa()
                            {
                                id_empresa = (decimal)x.UNIDAD.PROCESO.ID_EMPRESA_PRO,
                                nombre_empresa = x.UNIDAD.PROCESO.EMPRESA.NOMBRE_EMPRESA
                            }
                        },
                        empresa = new Empresa()
                        {
                            id_empresa = (decimal)x.UNIDAD.ID_EMPRESA_UNI,
                            nombre_empresa = x.UNIDAD.EMPRESA.NOMBRE_EMPRESA
                        }
                    };
                    p.estado = new Estado()
                    {
                        id_estado = (decimal)x.ID_ESTADO_TAREA,
                        nombre_estado = x.ESTADO.NOMBRE_ESTADO
                    };
                    p.empresa = new Empresa()
                    {
                        id_empresa = (decimal)x.ID_EMPRESA_TAREA,
                        nombre_empresa = x.EMPRESA.NOMBRE_EMPRESA
                    };
                    listaTareas.Add(p);
                };
                return listaTareas;
            }
            catch
            {
                Console.WriteLine("error al cargar datos de tarea");
                return listaTareas;
            }
        }
    }
}
