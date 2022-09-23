using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeTareasWeb.Negocio
{
     public class EmpleadoCollection
    {
        private List<ControlDeTareasWeb.Negocio.Empleado> GenerarListaCli(List<ControlDeTareasWeb.DAL.EMPLEADO> empleadosDAL)
        {
            List<Empleado> listaCli = new List<Empleado>();
            foreach (ControlDeTareasWeb.DAL.EMPLEADO empleadoDAL in empleadosDAL)
            {
                Empleado empleadoTemp = new Empleado();

                empleadoTemp.id_rut = empleadoDAL.ID_RUT;
                empleadoTemp.id_empresa_emp = (decimal)empleadoDAL.ID_EMPRESA_EMP;
                empleadoTemp.id_rol_emp = (decimal)empleadoDAL.ID_ROL_EMP;
                empleadoTemp.fecha_ingreso = (DateTime)empleadoDAL.FECHA_INGRESO;
                empleadoTemp.nombre_emp = empleadoDAL.NOMBRE_EMP;
                empleadoTemp.usuario = empleadoDAL.USUARIO;
                empleadoTemp.clave = empleadoDAL.CLAVE;

                listaCli.Add(empleadoTemp);
            }
            return listaCli;
        }
        public List<Empleado> ReadAll()
        {
            var clientes = ConectarDAL.Modelo.EMPLEADO;

            return GenerarListaCli(clientes.ToList());
        }
        //public List<Empleado> FindByRut(String rut)
        //{
        //    var clientes = ConectarDAL.Modelo.EMPLEADO.Where(x => x.RutEmpleado.Contains(rut));

        //    return GenerarListaCli(clientes.ToList());
        //}
        public List<Empleado> FindByUser(String usuario)
        {
            var clientes = ConectarDAL.Modelo.EMPLEADO.Where(x => x.USUARIO.Contains(usuario));

            return GenerarListaCli(clientes.ToList());
        }
    }
}
