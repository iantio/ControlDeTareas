using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeTareasWeb.DAL;

namespace ControlDeTareasWeb.Negocio
{
    public class Empresa
    {
        //Getter and Setter
        public decimal id_empresa { get; set; }
        public String nombre_empresa { get; set; }

        ControlDeTareasEntities db = new ControlDeTareasEntities();

        //Metodo
        public List<Empresa> ReadAll()
        {
            return this.db.EMPRESA.Select(p => new Empresa() {
                id_empresa = p.ID_EMPRESA,
                nombre_empresa = p.NOMBRE_EMPRESA
            }).ToList();
        }
    }
}
