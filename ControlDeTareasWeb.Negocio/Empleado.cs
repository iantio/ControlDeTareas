using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeTareasWeb.DAL;

namespace ControlDeTareasWeb.Negocio
{
    public class Empleado
    {
        //Getter and Setter
        public decimal id_rut { get; set; }
        public decimal id_empresa_emp { get; set; }
        public decimal id_rol_emp { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public String nombre_emp { get; set; }
        public String usuario { get; set; }
        public String clave { get; set; }

        public Empresa empresa { get; set; }
        public Rol rol { get; set; }

        ControlDeTareasEntities db = new ControlDeTareasEntities();
        //Metodos
        public List<Empleado> ReadAll()
        {
            return this.db.EMPLEADO.Select(p => new Empleado()
            {
                id_rut = (decimal)p.ID_RUT,
                id_empresa_emp = (decimal)p.ID_EMPRESA_EMP,
                id_rol_emp = (decimal)p.ID_ROL_EMP,
                fecha_ingreso = (DateTime)p.FECHA_INGRESO,
                nombre_emp = p.NOMBRE_EMP,
                usuario = p.USUARIO,
                clave = p.CLAVE,
                empresa = new Empresa()
                {
                    id_empresa = (decimal)p.ID_EMPRESA_EMP,
                    nombre_empresa = p.EMPRESA.NOMBRE_EMPRESA
                },
                rol = new Rol()
                {
                    id_rol = (decimal)p.ID_ROL_EMP,
                    nombre_rol = p.ROL.NOMBRE_ROL
                }
            }).ToList();
        }
        public Empleado Read(int id_rut)
        {
            return this.db.EMPLEADO.Select(p => new Empleado()
            {
                id_rut = (decimal)p.ID_RUT,
                id_empresa_emp = (decimal)p.ID_EMPRESA_EMP,
                id_rol_emp = (decimal)p.ID_ROL_EMP,
                fecha_ingreso = (DateTime)p.FECHA_INGRESO,
                nombre_emp = p.NOMBRE_EMP,
                usuario = p.USUARIO,
                clave = p.CLAVE,
                empresa = new Empresa()
                {
                    id_empresa = (decimal)p.ID_EMPRESA_EMP,
                    nombre_empresa = p.EMPRESA.NOMBRE_EMPRESA
                },
                rol = new Rol()
                {
                    id_rol = (decimal)p.ID_ROL_EMP,
                    nombre_rol = p.ROL.NOMBRE_ROL
                }
            }).Where(p => p.id_rut == id_rut ).FirstOrDefault();
        }
        public Empleado Find(String usuario) 
        {
            return this.db.EMPLEADO.Select(p => new Empleado()
            {
                id_rut = p.ID_RUT,
                id_empresa_emp = (decimal)p.ID_EMPRESA_EMP,
                id_rol_emp = (decimal)p.ID_ROL_EMP,
                fecha_ingreso = (DateTime)p.FECHA_INGRESO,
                nombre_emp = p.NOMBRE_EMP,
                usuario = p.USUARIO,
                clave = p.CLAVE,
                empresa = new Empresa()
                {
                    id_empresa = (decimal)p.ID_EMPRESA_EMP,
                    nombre_empresa = p.EMPRESA.NOMBRE_EMPRESA
                },
                rol = new Rol()
                {
                    id_rol = (decimal)p.ID_ROL_EMP,
                    nombre_rol = p.ROL.NOMBRE_ROL
                }
            }).Where(p => p.usuario == usuario).FirstOrDefault();
        }
    }
}
