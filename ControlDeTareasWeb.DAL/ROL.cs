//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlDeTareasWeb.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ROL
    {
        public ROL()
        {
            this.EMPLEADO = new HashSet<EMPLEADO>();
        }
    
        public int ID_ROL { get; set; }
        public string NOMBRE_ROL { get; set; }
    
        public virtual ICollection<EMPLEADO> EMPLEADO { get; set; }
    }
}
