//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyDreamFoam_ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tb_Diario
    {
        public int codDiar { get; set; }
        public System.DateTime fecha { get; set; }
        public int empleado { get; set; }
        public int horario { get; set; }
        public Nullable<System.TimeSpan> hIngreso { get; set; }
        public Nullable<System.TimeSpan> hSalida { get; set; }
        public Nullable<System.TimeSpan> hora1 { get; set; }
        public Nullable<System.TimeSpan> hora2 { get; set; }
        public Nullable<System.TimeSpan> hora3 { get; set; }
        public Nullable<System.TimeSpan> hora4 { get; set; }
        public Nullable<System.TimeSpan> ingrTard { get; set; }
        public Nullable<System.TimeSpan> exeRefr { get; set; }
        public Nullable<System.TimeSpan> exeJornd { get; set; }
        public string observ { get; set; }
        public Nullable<System.DateTime> fec_Reg { get; set; }
        public string usu_Reg { get; set; }
        public Nullable<System.DateTime> fec_UltMod { get; set; }
        public string usu_UltMod { get; set; }
    
        public virtual Tb_Empleado Tb_Empleado { get; set; }
    }
}
