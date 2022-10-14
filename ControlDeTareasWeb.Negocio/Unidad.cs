﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDeTareasWeb.DAL;

namespace ControlDeTareasWeb.Negocio
{
    public class Unidad
    {
        public decimal id_unidad { get; set; }
        public decimal id_proceso_uni { get; set; }
        public decimal id_estado_uni { get; set; }
        public decimal id_empresa_uni { get; set; }
        public String nombre_unidad { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_termino { get; set; }
        public Proceso proceso { get; set; }
        public Estado estado { get; set; }
        public Empresa empresa { get; set; }

        ControlDeTareasEntities db = new ControlDeTareasEntities();

        public List<Unidad> ReadAll()
        {
            return this.db.UNIDAD.Select(p => new Unidad()
            {
                id_unidad = (decimal)p.ID_UNIDAD,
                id_proceso_uni = (decimal)p.ID_PROCESO_UNI,
                id_estado_uni = (decimal)p.ID_ESTADO_UNI,
                id_empresa_uni = (decimal)p.ID_EMPRESA_UNI,
                nombre_unidad = p.NOMBRE_UNIDAD,
                fecha_inicio = (DateTime)p.FECHA_INICIO,
                fecha_termino = (DateTime)p.FECHA_TERMINO,
                //TEMPORAL (SUPUESTAMENTE SE PODRIAN CARGAR LOS DATOS CON "proceso.FindById(id_proceso_uni)")
                proceso = new Proceso()
                {
                    id_proceso = (decimal)p.ID_PROCESO_UNI,
                    id_estado_pro = (decimal)p.PROCESO.ID_ESTADO_PRO,
                    id_empresa_pro = (decimal)p.PROCESO.ID_EMPRESA_PRO,
                    nombre_proceso = p.PROCESO.NOMBRE_PROCESO,
                    fecha_inicio = (DateTime)p.PROCESO.FECHA_INICIO,
                    fecha_termino = (DateTime)p.PROCESO.FECHA_TERMINO,
                    estado = new Estado()
                    {
                        id_estado = (decimal)p.PROCESO.ID_ESTADO_PRO,
                        nombre_estado = p.ESTADO.NOMBRE_ESTADO
                    },
                    empresa = new Empresa() 
                    {
                        id_empresa = (decimal)p.PROCESO.ID_EMPRESA_PRO,
                        nombre_empresa = p.EMPRESA.NOMBRE_EMPRESA
                    }
                },
                estado = new Estado()
                {
                    id_estado = (decimal)p.ID_ESTADO_UNI,
                    nombre_estado = p.ESTADO.NOMBRE_ESTADO
                },
                empresa = new Empresa()
                {
                    id_empresa = (decimal)p.ID_EMPRESA_UNI,
                    nombre_empresa = p.EMPRESA.NOMBRE_EMPRESA
                }
            }).ToList();
        }
        public List<Unidad> Read(decimal id_empresa)
        {
            List<Unidad> listaProcesos = new List<Unidad>();
            try
            {
                var unidades = from p in db.UNIDAD
                               where p.ID_EMPRESA_UNI == id_empresa
                               select p;
                foreach (ControlDeTareasWeb.DAL.UNIDAD x in unidades)
                {
                    Unidad p = new Unidad();
                    p.id_unidad = (decimal)x.ID_UNIDAD;
                    p.id_proceso_uni = (decimal)x.ID_PROCESO_UNI;
                    p.id_estado_uni = (decimal)x.ID_ESTADO_UNI;
                    p.id_empresa_uni = (decimal)x.ID_EMPRESA_UNI;
                    p.nombre_unidad = x.NOMBRE_UNIDAD;
                    p.fecha_inicio = (DateTime)x.FECHA_INICIO;
                    p.fecha_termino = (DateTime)x.FECHA_TERMINO;
                    p.estado = new Estado()
                    {
                        id_estado = (decimal)x.ID_ESTADO_UNI,
                        nombre_estado = x.ESTADO.NOMBRE_ESTADO
                    };
                    p.proceso = new Proceso()
                    {
                        id_proceso = (decimal)x.ID_PROCESO_UNI,
                        id_estado_pro = (decimal)x.PROCESO.ID_ESTADO_PRO,
                        id_empresa_pro = (decimal)x.PROCESO.ID_EMPRESA_PRO,
                        nombre_proceso = x.PROCESO.NOMBRE_PROCESO,
                        fecha_inicio = (DateTime)x.PROCESO.FECHA_INICIO,
                        fecha_termino = (DateTime)x.PROCESO.FECHA_TERMINO,
                        estado = new Estado()
                        {
                            id_estado = (decimal)x.PROCESO.ID_ESTADO_PRO,
                            nombre_estado = x.ESTADO.NOMBRE_ESTADO
                        },
                        empresa = new Empresa()
                        {
                            id_empresa = (decimal)x.PROCESO.ID_EMPRESA_PRO,
                            nombre_empresa = x.EMPRESA.NOMBRE_EMPRESA
                        }
                    };
                    p.empresa = new Empresa()
                    {
                        id_empresa = (decimal)x.ID_EMPRESA_UNI,
                        nombre_empresa = x.EMPRESA.NOMBRE_EMPRESA
                    };
                    listaProcesos.Add(p);
                };
                return listaProcesos;
            }
            catch
            {
                Console.WriteLine("error al cargar datos de unidad");
                return listaProcesos;
            }
        }
    }
}
