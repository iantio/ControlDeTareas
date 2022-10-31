using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeTareasWeb.DAL;

namespace ControlDeTareasWeb.Negocio
{
    public class Rol
    {
        //getter and setter
        public decimal id_rol { get; set; }
        public decimal id_empresa_rol { get; set; }
        public String nombre_rol { get; set; }
        public Empresa empresa { get; set; }

        ControlDeTareasEntities db = new ControlDeTareasEntities();

        //Metodos
        public List<Rol> ReadAll()
        {
            return this.db.ROL.Select(p => new Rol()
            {
                id_rol = p.ID_ROL,
                id_empresa_rol = (decimal)p.ID_EMPRESA_ROL,
                nombre_rol = p.NOMBRE_ROL,
                empresa = new Empresa()
                {
                    id_empresa = (decimal)p.ID_EMPRESA_ROL,
                    nombre_empresa = p.EMPRESA.NOMBRE_EMPRESA
                }
            }).ToList();
        }
        public List<Rol> ListarNombres(decimal id_empresa_rol)
        {
            Rol rolTemp = new Rol();
            List<Rol> rol = new List<Rol>();
            foreach (Rol rolEncontrado in rolTemp.ReadAll())
            {
                if (rolEncontrado.id_empresa_rol == id_empresa_rol)
                {
                    rol.Add(rolEncontrado);
                }
            };
            return rol;
        }
    }
}
