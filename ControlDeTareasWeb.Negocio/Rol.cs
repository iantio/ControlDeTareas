﻿using System;
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
        public String nombre_rol { get; set; }

        ControlDeTareasEntities db = new ControlDeTareasEntities();

        //Metodos
        public List<Rol> ReadAll()
        {
            return this.db.ROL.Select(p => new Rol()
            {
                id_rol = p.ID_ROL,
                nombre_rol = p.NOMBRE_ROL
            }).ToList();
        }
        public List<String> ListarNombres()
        {
            Rol rolTemp = new Rol();
            List<String> ListNombre = new List<String>();
            ListNombre.Add("--Selecciones un rol--");
            foreach (Rol rol in rolTemp.ReadAll()) 
            {
                String a = rol.nombre_rol;
                ListNombre.Add(a);
            };
            return ListNombre;
        }
    }
}
