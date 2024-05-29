using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyDreamFoam_BE
{
    public class DiarioBE
    {
        public Int32 codDiar { get; set; }
        public DateTime fecha { get; set; }
        public Int32 empleado { get; set; }
        public Int32 horario { get; set; }
        public DateTime hIngreso { get; set; }
        public DateTime hSalida { get; set; }
        public DateTime hora1 { get; set; }
        public DateTime hora2 { get; set; }
        public DateTime hora3 { get; set; }
        public DateTime hora4 { get; set; }
        public DateTime ingrTard { get; set; }
        public DateTime exeRefr { get; set; }
        public DateTime exeJornd { get; set; }
        public String observ { get; set; }
        public DateTime fec_Reg { get; set; }
        public string usu_Reg { get; set; }
        public DateTime fec_UltMod { get; set; }
        public String usu_UltMod { get; set; }


    }
    public class DiarioBECons
    {
        public DateTime fecha { get; set; }
        public String empleado { get; set; }
        public String horario { get; set; }
        public String area { get; set; }
        public DateTime ingrTard { get; set; }
        public DateTime exeRefr { get; set; }
        public DateTime exeJornd { get; set; }
        public String observ { get; set; }

    }

    public class DiarioBEMetrics
    {
        public  DateTime mayorTard { get; set; }
        public DateTime mayorExeRef { get; set; }
        public DateTime mayorExeJornd { get; set; }
        public TimeSpan sumTar { get; set; }
        public TimeSpan sumRef { get; set; }
        public TimeSpan sumJor { get; set; }
    }

    public class DiarioBEGenMetrics
    {
        public String emplPun {  get; set; }
        public int emplPunMarc {  get; set; }
        
        public String emplTar { get; set; }
        public int emplTarMarc { get; set; }
        public String areaPun {  get; set; }
        public String areaTar { get; set; }
        public String horarPun { get; set; }
        public String horarTar { get; set;}

        public String carTar { get; set; }
        public String carPun { get; set; }
    }

    public class DiarioBEGenMetrics2
    {
        public String nomArea { get; set; }
        public int areaMarc { get; set; }
        public String nomHora { get; set; }
        public int horaMarc { get; set; }
        public String nomSede { get; set; }
        public int sedeMarc { get; set; }
        public String nomCargo { get; set; }
        public int carMarc { get; set; }
    }
}
