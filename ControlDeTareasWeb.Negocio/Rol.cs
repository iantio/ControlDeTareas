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
        public List<String> ListarNombres(decimal id_empresa_rol)
        {
            Rol rolTemp = new Rol();
            List<String> ListNombre = new List<String>();
            ListNombre.Add("--Seleccione un rol--");
            foreach (Rol rol in rolTemp.ReadAll()) 
            {
                if (rol.id_empresa_rol == id_empresa_rol)
                {
                    String a = rol.nombre_rol;
                    ListNombre.Add(a);
                }
            };
            return ListNombre;
        }
    }
}
