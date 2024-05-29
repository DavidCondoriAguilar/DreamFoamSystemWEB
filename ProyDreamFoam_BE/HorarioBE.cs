using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyDreamFoam_BE
{
    public class HorarioBE
    {
        public Int32 codHorario {  get; set; }
        public String desHorario { get; set; }
        public DateTime ingLUN {  get; set; }
        public DateTime salLUN {  get; set; }
        public DateTime ingMAR {  get; set; }
        public DateTime salMAR { get; set; }
        public DateTime ingMIE { get; set; }
        public DateTime salMIE { get; set;}
        public DateTime ingJUE { get; set; }
        public DateTime salJUE { get; set; }
        public DateTime ingVIE { get; set; }
        public DateTime salVIE { get; set; }
        public DateTime ingSAB { get; set; }
        public DateTime salSAB { get; set; }
        public DateTime ingDOM { get; set; }
        public DateTime salDOM { get; set; }
        public Int32 refriger { get; set; }
        public Int32 tolernc { get; set; }
        public Int16 diaDesc { get; set; }

        public DateTime fec_Reg { get; set; }
        public string usu_Reg { get; set; }
        public DateTime fec_UltMod { get; set; }
        public String usu_UltMod { get; set; }


    }
}
