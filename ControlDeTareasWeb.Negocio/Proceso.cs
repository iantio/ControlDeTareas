using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeTareasWeb.DAL;

namespace ControlDeTareasWeb.Negocio
{
    public class Proceso
    {
        public decimal id_proceso { get; set; }
        public decimal id_estado_pro { get; set; }
        public decimal id_empresa_pro { get; set; }
        public String nombre_proceso { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_termino { get; set; }
        public Estado estado { get; set; }
        public Empresa empresa { get; set; }

        ControlDeTareasEntities db = new ControlDeTareasEntities();
        public List<Proceso> ReadAll()
        {
            return this.db.PROCESO.Select(p => new Proceso()
            {
                id_proceso = (decimal)p.ID_PROCESO,
                id_estado_pro = (decimal)p.ID_ESTADO_PRO,
                id_empresa_pro = (decimal)p.ID_EMPRESA_PRO,
                nombre_proceso = p.NOMBRE_PROCESO,
                fecha_inicio = (DateTime)p.FECHA_INICIO,
                fecha_termino = (DateTime)p.FECHA_TERMINO,
                estado = new Estado() 
                {
                    id_estado = (decimal)p.ID_ESTADO_PRO,
                    nombre_estado = p.ESTADO.NOMBRE_ESTADO
                },
                empresa = new Empresa()
                {
                    id_empresa = (decimal)p.ID_EMPRESA_PRO,
                    nombre_empresa = p.EMPRESA.NOMBRE_EMPRESA
                }
            }).ToList();
        }
        public List<Proceso> Read(decimal id_empresa)
        {
            List<Proceso> listaProcesos = new List<Proceso>();
            try
            {
                var procesos = from p in db.PROCESO
                               where p.ID_EMPRESA_PRO == id_empresa
                               select p;
                foreach (ControlDeTareasWeb.DAL.PROCESO x in procesos)
                {
                    Proceso p = new Proceso();
                    p.id_proceso = (decimal)x.ID_PROCESO;
                    p.id_estado_pro = (decimal)x.ID_ESTADO_PRO;
                    p.id_empresa_pro = (decimal)x.ID_EMPRESA_PRO;
                    p.nombre_proceso = x.NOMBRE_PROCESO;
                    p.fecha_inicio = (DateTime)x.FECHA_INICIO;
                    p.fecha_termino = (DateTime)x.FECHA_TERMINO;
                    p.estado = new Estado() 
                    {
                        id_estado = (decimal)x.ID_ESTADO_PRO,
                        nombre_estado = x.ESTADO.NOMBRE_ESTADO
                    };
                    p.empresa = new Empresa()
                    {
                        id_empresa = (decimal)x.ID_EMPRESA_PRO,
                        nombre_empresa = x.EMPRESA.NOMBRE_EMPRESA
                    };
                    listaProcesos.Add(p);
                };
                return listaProcesos;
            }
            catch 
            {
                Console.WriteLine("error al cargar datos de proceso");
                return listaProcesos;
            }
        }
    }
}
