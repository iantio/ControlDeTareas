using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeTareasWeb.Negocio
{
    // CLASE ENCARGADA DE GUARDAR LOS TIPOS DE FILTROS PARA EL DATAGRID
     public class EmpleadoCollection
    {
        //OBTENCION DE LOS DATOS DE LA TABLA EMPLEADO
        private List<ControlDeTareasWeb.Negocio.Empleado> GenerarListaEmp(List<ControlDeTareasWeb.DAL.EMPLEADO> empleadosDAL)
        {
            List<Empleado> listaEmp = new List<Empleado>();
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
                empleadoTemp.empresa = new Empresa()
                {
                    id_empresa = (decimal)empleadoDAL.ID_EMPRESA_EMP,
                    nombre_empresa = empleadoDAL.EMPRESA.NOMBRE_EMPRESA
                };
                empleadoTemp.rol = new Rol()
                {
                    id_rol = (decimal)empleadoDAL.ID_ROL_EMP,
                    nombre_rol = empleadoDAL.ROL.NOMBRE_ROL
                };
                listaEmp.Add(empleadoTemp);
            }
            return listaEmp;
        }
        //CARGAR LOS DATOS DE LA TABLA EMPLEADO
        public List<Empleado> ReadAll()
        {
            var empleados = ConectarDAL.Modelo.EMPLEADO;

            return GenerarListaEmp(empleados.ToList());
        }
        public List<Empleado> ReadByEmpresa(decimal id_empresa)
        {
            var empleados = ConectarDAL.Modelo.EMPLEADO.Where(x =>x.ID_EMPRESA_EMP == id_empresa);

            return GenerarListaEmp(empleados.ToList());
        }
        //FILTRAR POR RUT
        public List<Empleado> FindByRut(int rut, decimal id_empresa)
        {
            var empleados = ConectarDAL.Modelo.EMPLEADO.Where(x => x.ID_RUT == rut && x.ID_EMPRESA_EMP == id_empresa);

            return GenerarListaEmp(empleados.ToList());
        }
        public List<Empleado> FindByNombre(String nombre,decimal id_empresa)
        {
            var empleados = ConectarDAL.Modelo.EMPLEADO.Where(x => x.NOMBRE_EMP.Contains(nombre) && x.ID_EMPRESA_EMP == id_empresa);

            return GenerarListaEmp(empleados.ToList());
        }
    }
}
