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
    
    public partial class PROCESO
    {
        public PROCESO()
        {
            this.UNIDAD = new HashSet<UNIDAD>();
        }
    
        public int ID_PROCESO { get; set; }
        public Nullable<short> ID_ESTADO_PRO { get; set; }
        public Nullable<int> ID_EMPRESA_PRO { get; set; }
        public string NOMBRE_PROCESO { get; set; }
        public Nullable<System.DateTime> FECHA_INICIO { get; set; }
        public Nullable<System.DateTime> FECHA_TERMINO { get; set; }
    
        public virtual EMPRESA EMPRESA { get; set; }
        public virtual ESTADO ESTADO { get; set; }
        public virtual ICollection<UNIDAD> UNIDAD { get; set; }
    }
}
