using ControlDeTareasWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeTareasWeb.Negocio
{
    class ConectarDAL
    {
        private static ControlDeTareasEntities modelo;

        public static ControlDeTareasEntities Modelo
        {
            get
            {
                if (modelo == null)
                {
                    modelo = new ControlDeTareasEntities();
                }
                return modelo;
            }
        }
    }
}
