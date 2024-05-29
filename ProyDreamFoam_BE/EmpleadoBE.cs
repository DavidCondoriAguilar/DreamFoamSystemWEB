using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyDreamFoam_BE
{
    public class EmpleadoBE
    {
        public Int32 codEmpleado { get; set; }
        public String numroDoc { get; set; }
        public String tipoDoc { get; set; }
        public String apellidos {  get; set; }
        public String nombres {  get; set; }    
        public DateTime fecNacimiento { get; set; }
        public String genero { get; set; }
        public String correo { get; set;}
        public String direccion { get; set; }
        public Int64 telefono { get; set; }
        public DateTime fecIngreso { get; set; }

        public Int16 codCargo {  get; set; }
        public Int16 codArea { get; set; }
        public Int16 codSede { get; set; }
        public Int16 codHorario { get; set; }   
        
        public byte[] foto { get; set; }

        public DateTime fec_Reg { get; set; }
        public String usu_Reg { get; set; }
        public DateTime fec_UltMod {  get; set; }

        public String usu_UltMod { get; set; }
        public Int16 estado {  get; set; }

    }
    public class EmpleadoBECons
    {
        public Int32 codEmpleado { get; set; }
        public String numroDoc { get; set; }
        public String tipoDoc { get; set; }
        public String nombreCompleto { get; set; }
        public DateTime fecNacimiento { get; set; }
        public String genero { get; set; }
        public String correo { get; set; }
        public String direccion { get; set; }
        public Int64 telefono { get; set; }
        public DateTime fecIngreso { get; set; }

        public String cargo { get; set; }
        public String area { get; set; }
        public String sede { get; set; }
        public String horario { get; set; }

        public byte[] foto { get; set; }
    }
}
