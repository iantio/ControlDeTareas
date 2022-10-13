using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeTareasWeb.DAL;

namespace ControlDeTareasWeb.Negocio
{
    public class Estado
    {
        public decimal id_estado { get; set; }
        public String nombre_estado { get; set; }
        ControlDeTareasWeb.DAL.ControlDeTareasEntities db = new ControlDeTareasEntities();

        public List<Estado> ReadAll()
        {
            return this.db.ESTADO.Select(p => new Estado()
            {
                id_estado = (decimal)p.ID_ESTADO,
                nombre_estado = p.NOMBRE_ESTADO
            }).ToList();
        }
    }
}
