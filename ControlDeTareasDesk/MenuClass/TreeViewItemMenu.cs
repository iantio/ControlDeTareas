using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeTareasWeb.Negocio;

namespace ControlDeTareasDesk
{
    public class TreeViewItemMenu
    {
        public TreeViewItemMenu()
        {
            this.Items = new List<TreeViewItemMenu>();
        }

        public int idItemProceso { get; set; }
        public int idItemUnidad { get; set; }
        public int idItemTarea { get; set; }
        public int idItemEmpleado { get; set; }
        public string Titulo { get; set; }
        public Proceso proceso { get; set; }
        public Unidad unidad { get; set; }
        public Tarea tarea { get; set; }
        public Empleado empleado { get; set; }
        public double Porcentaje { get; set; }
        public List<TreeViewItemMenu> Items { get; set; }
        public DetalleTarea detalleTarea { get; set; }
        public String justificacion { get; set; }
        public String colorSemaforo { get; set; } = "Green";

        public TreeViewItemMenu ReadDetalle(Empleado empleadoAux)
        {
            this.Titulo = "Prueba";
            Console.WriteLine("\nDETALLE EMPLEADOS");
            try
            {
                DetalleTarea detalle = new DetalleTarea();
                List<DetalleTarea> listaDetalles = detalle.FindByEmpleado(empleadoAux.id_rut);

                listaDetalles = detalle.FindByEmpleado(empleadoAux.id_rut);
                List<decimal> listaProcesos = (from x in listaDetalles
                                              select x.tarea.unidad.proceso.id_proceso).Distinct().ToList();
                foreach (decimal idProceso in listaProcesos)
                {
                    Proceso proceso = new Proceso();
                    proceso.LoadProceso(idProceso);
                    TreeViewItemMenu itemProceso = new TreeViewItemMenu() {Titulo = proceso.nombre_proceso, proceso = proceso, Porcentaje = 0};

                    List<decimal> listaUnidades = (from x in listaDetalles
                                                  where x.tarea.unidad.proceso.id_proceso == idProceso
                                                  select x.tarea.unidad.id_unidad).Distinct().ToList();
                    //CALCULO PORCENTAJE PROCESO
                    double porcentajeProceso = (from x in listaDetalles
                                                where x.id_estado_detalle == 5 && x.tarea.unidad.proceso.id_proceso == idProceso
                                                select x).Count();
                    double porcentajeProcesoTotal = listaDetalles.Count(x => x.tarea.unidad.proceso.id_proceso == idProceso);

                    itemProceso.Porcentaje = (porcentajeProceso / porcentajeProcesoTotal);
                    Console.WriteLine(proceso.nombre_proceso);
                    if (itemProceso.proceso.id_estado_pro != 1 || itemProceso.proceso.id_estado_pro != 5)
                    {
                        switch (itemProceso.ObtenerSemaforo())
                        {
                            case "Green":
                                break;
                            case "Yellow":
                                break;
                            case "Red":
                                itemProceso.proceso.id_estado_pro = 4;
                                itemProceso.proceso.Update();
                                break;
                        }
                    }
                    foreach (decimal idUnidad in listaUnidades)
                    {
                        Unidad unidad = new Unidad();
                        unidad.LoadUnidad(idUnidad);
                        TreeViewItemMenu itemUnidad = new TreeViewItemMenu() { Titulo = unidad.nombre_unidad, unidad = unidad,Porcentaje = 0 };
                        List<decimal> listaTareas = (from x in listaDetalles
                                                    where x.tarea.unidad.proceso.id_proceso == idProceso && x.tarea.unidad.id_unidad == idUnidad
                                                    select x.tarea.id_tarea).Distinct().ToList();
                        //CALCULO PORCENTAJE UNIDADES
                        double porcentajeUnidad = (from x in listaDetalles
                                                   where x.id_estado_detalle == 5 && x.tarea.unidad.id_unidad == idUnidad
                                                   select x).Count();
                        double porcentajeUnidadTotal = listaDetalles.Count(x => x.tarea.unidad.id_unidad == idUnidad);
                        itemUnidad.Porcentaje = porcentajeUnidad / porcentajeUnidadTotal;
                        Console.WriteLine("|_"+unidad.nombre_unidad);
                        //COLOR SEMAFORO
                        if (itemUnidad.unidad.id_estado_uni != 1 || itemUnidad.unidad.id_estado_uni != 5)
                        {
                            switch (itemUnidad.ObtenerSemaforo())
                            {
                                case "Green":
                                    break;
                                case "Yellow":
                                    break;
                                case "Red":
                                    itemUnidad.unidad.id_estado_uni = 4;
                                    itemUnidad.unidad.Update();
                                    break;
                            }
                        }
                        foreach (decimal idTarea in listaTareas)
                        {
                            if (idTarea != 0)
                            {
                                Tarea tarea = new Tarea();
                                tarea.LoadTarea(idTarea);
                                //CALCULO PORCENTAJE TAREA
                                TreeViewItemMenu itemTarea = new TreeViewItemMenu() { Titulo = tarea.nombre_tarea, Porcentaje = 0, tarea = tarea };
                                double porcentajeTarea = (from x in listaDetalles
                                                          where x.id_estado_detalle == 5 && x.tarea.id_tarea == idTarea
                                                          select x).Count();
                                double porcentajeTareaTotal = listaDetalles.Count(x => x.tarea.id_tarea == idTarea);
                                itemTarea.Porcentaje = porcentajeTarea / porcentajeTareaTotal;

                                itemUnidad.unidad = tarea.unidad;
                                itemProceso.proceso = tarea.unidad.proceso;
                                itemUnidad.Items.Add(itemTarea);
                                Console.WriteLine(" |_" + tarea.nombre_tarea);
                                //COLOR SEMAFORO
                                if (itemTarea.tarea.id_estado_tarea != 1 || itemTarea.tarea.id_estado_tarea != 5)
                                {
                                    switch (itemTarea.ObtenerSemaforo())
                                    {
                                        case "Green":
                                            break;
                                        case "Yellow":
                                            break;
                                        case "Red":
                                            itemTarea.tarea.id_estado_tarea = 4;
                                            itemTarea.tarea.Update();
                                            break;
                                    }
                                }
                            }
                        }
                        itemProceso.Items.Add(itemUnidad);
                    }
                    this.Items.Add(itemProceso);
                }
            }
            catch
            {
            }
            return this;
        }
        public TreeViewItemMenu ReadDetalleUsuarios(Empleado empleadoAux)
        {
            this.Titulo = "Prueba";
            Console.WriteLine("\nDETALLE EMPRESA");
            try
            {
                DetalleTarea detalle = new DetalleTarea();
                List<DetalleTarea> listaDetalles = detalle.FindByEmpresa(empleadoAux.id_empresa_emp);

                listaDetalles = detalle.FindByEmpresa(empleadoAux.id_empresa_emp);
                List<decimal> listaProcesos = (from x in listaDetalles
                                              select x.tarea.unidad.proceso.id_proceso).Distinct().ToList();
                idItemProceso = 0;
                idItemUnidad = 0;
                idItemTarea = 0;
                idItemEmpleado = 0;
                foreach (decimal idProceso in listaProcesos)
                {
                    //BUSCAR PROCESOS
                    Proceso proceso = new Proceso();
                    proceso.LoadProceso(idProceso);
                    TreeViewItemMenu itemProceso = new TreeViewItemMenu() { Titulo = proceso.nombre_proceso, Porcentaje = 0, proceso = proceso , idItemProceso = this.idItemProceso};
                    List<decimal> listaUnidades = (from x in listaDetalles
                                                  where x.tarea.unidad.proceso.id_proceso == idProceso
                                                  select x.tarea.unidad.id_unidad).Distinct().ToList();
                    //CALCULO PROCENTAJE PROCESO
                    double porcentajeProceso = (from x in listaDetalles
                                                 where x.id_estado_detalle == 5 && x.tarea.unidad.proceso.id_proceso == idProceso
                                                 select x).Count();
                    double porcentajeProcesoTotal = listaDetalles.Count(x => x.tarea.unidad.proceso.id_proceso == idProceso);

                    itemProceso.Porcentaje = (porcentajeProceso / porcentajeProcesoTotal);

                    Console.WriteLine(proceso.nombre_proceso);
                    //COLOR SEMAFORO
                    if (itemProceso.proceso.id_estado_pro != 1 || itemProceso.proceso.id_estado_pro != 5)
                    {
                        switch (itemProceso.ObtenerSemaforo())
                        {
                            case "Green":
                                break;
                            case "Yellow":
                                break;
                            case "Red":
                                itemProceso.proceso.id_estado_pro = 4;
                                itemProceso.proceso.Update();
                                break;
                        }
                    }
                    //ENCONTRAR UNIDADES
                    foreach (decimal idUnidad in listaUnidades)
                    {
                        Unidad unidad = new Unidad();
                        unidad.LoadUnidad(idUnidad);
                        TreeViewItemMenu itemUnidad = new TreeViewItemMenu() { Titulo = unidad.nombre_unidad, Porcentaje = 0, unidad = unidad, idItemProceso = this.idItemProceso };
                        List<decimal> listaTareas = (from x in listaDetalles
                                                     where x.tarea.unidad.proceso.id_proceso == idProceso && x.tarea.unidad.id_unidad == idUnidad
                                                     select x.tarea.id_tarea).Distinct().ToList();
                        //CALCULO PORCETNAJE UNIDADES
                        double porcentajeUnidad = (from x in listaDetalles
                                                    where x.id_estado_detalle == 5 && x.tarea.unidad.id_unidad == idUnidad
                                                    select x).Count();
                        double porcentajeUnidadTotal = listaDetalles.Count(x => x.tarea.unidad.id_unidad == idUnidad);
                        itemUnidad.Porcentaje = porcentajeUnidad / porcentajeUnidadTotal;
                        Console.WriteLine("|_" + unidad.nombre_unidad);
                        //COLOR SEMAFORO
                        if (itemUnidad.unidad.id_estado_uni != 1 || itemUnidad.unidad.id_estado_uni != 5)
                        {
                            switch (itemUnidad.ObtenerSemaforo())
                            {
                                case "Green":
                                    break;
                                case "Yellow":
                                    break;
                                case "Red":
                                    itemUnidad.unidad.id_estado_uni = 4;
                                    itemUnidad.unidad.Update();
                                    break;
                            }
                        }

                        //ENCONTRAR TAREAS
                        foreach (decimal id_tarea in listaTareas)
                        {
                            Tarea tarea = new Tarea();
                            tarea.LoadTarea(id_tarea);
                            TreeViewItemMenu itemTarea = new TreeViewItemMenu() { Titulo = tarea.nombre_tarea, Porcentaje = 0, tarea = tarea, idItemProceso = this.idItemProceso, idItemTarea = this.idItemTarea };
                            List<decimal> listaEmpleados = (from x in listaDetalles
                                                            where x.tarea.unidad.proceso.id_proceso == idProceso && x.tarea.id_tarea == id_tarea
                                                            select x.empleado.id_rut).Distinct().ToList();
                            //CALCULO PORCENTAJE TAREA
                            double porcentajeTarea = (from x in listaDetalles
                                                      where x.id_estado_detalle == 5 && x.tarea.id_tarea == id_tarea
                                                      select x).Count();
                            double porcentajeTareaTotal = listaDetalles.Count(x => x.tarea.id_tarea == id_tarea);
                            itemTarea.Porcentaje = porcentajeTarea / porcentajeTareaTotal;
                            Console.WriteLine(" |_" + tarea.nombre_tarea);
                            //COLOR SEMAFORO
                            if (itemTarea.tarea.id_estado_tarea != 1 || itemTarea.tarea.id_estado_tarea != 5)
                            {
                                switch (itemTarea.ObtenerSemaforo())
                                {
                                    case "Green":
                                        break;
                                    case "Yellow":
                                        break;
                                    case "Red":
                                        itemTarea.tarea.id_estado_tarea = 4;
                                        itemTarea.tarea.Update();
                                        break;
                                }
                            }
                            //ENCONTRAR EMPLEADOS
                            foreach (decimal idEmpleado in listaEmpleados)
                            {
                                Empleado empleado = new Empleado();
                                empleado.LoadEmpleado(idEmpleado);
                                DetalleTarea detalleTareaTemp = new DetalleTarea();
                                detalleTareaTemp.FindByEmpleadoTarea(idEmpleado,id_tarea);
                                double porcentajeTemp;
                                if (detalleTareaTemp.id_estado_detalle == 5)
                                {
                                    porcentajeTemp = 1;
                                }
                                else
                                {
                                    porcentajeTemp = 0;
                                }
                                TreeViewItemMenu itemEmpleado = new TreeViewItemMenu() { Titulo = empleado.nombre_emp, Porcentaje = porcentajeTemp, empleado = empleado, tarea = tarea, idItemTarea = idItemTarea, idItemEmpleado = idItemEmpleado, detalleTarea = detalleTareaTemp, justificacion=detalleTareaTemp.justificacion };

                                Console.WriteLine("  |_" + empleado.nombre_emp);
                                //COLOR SEMAFORO
                                if (itemEmpleado.detalleTarea.id_estado_detalle != 1 || itemEmpleado.detalleTarea.id_estado_detalle != 5)
                                {
                                    switch (itemEmpleado.ObtenerSemaforo())
                                    {
                                        case "Green":
                                            break;
                                        case "Yellow":
                                            break;
                                        case "Red":
                                            itemEmpleado.detalleTarea.id_estado_detalle = 4;
                                            itemEmpleado.detalleTarea.Update();
                                            break;
                                    }
                                }
                                itemTarea.Items.Add(itemEmpleado);
                                idItemEmpleado += 1;
                            }
                            itemUnidad.Items.Add(itemTarea);
                            idItemTarea += 1;
                        }
                        itemProceso.Items.Add(itemUnidad);
                    }
                    this.Items.Add(itemProceso);
                    idItemProceso += 1;
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
            return this;
        }
        private String ObtenerSemaforo()
        {
            TimeSpan resto = (TimeSpan)System.DateTime.Now.TimeOfDay;
            if (proceso != null)
            {
                resto = proceso.fecha_termino - System.DateTime.Now;
            }
            else if (unidad != null)
            {
                resto = unidad.fecha_termino - System.DateTime.Now;
            }
            else if (tarea != null)
            {
                resto = tarea.fecha_termino - System.DateTime.Now;
            }
            else if (empleado != null && tarea != null)
            {
                DetalleTarea detalleTareaTemp = new DetalleTarea();
                detalleTareaTemp.FindByEmpleadoTarea(empleado.id_rut, tarea.id_tarea);
                resto = tarea.fecha_termino - System.DateTime.Now;
            }
            if (resto.Days < 0)
            {
                colorSemaforo = "Red";
            }
            else if (resto.Days >= 0 && resto.Days <= 7)
            {
                colorSemaforo = "Yellow";
            }
            else if (resto.Days > 7)
            {
                colorSemaforo = "Green";
            }
            Console.WriteLine("TimeSpan: "+resto.Days+colorSemaforo);
            return colorSemaforo;
        }
    }
}
