using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using ProyDreamFoam_ADO;
using ProyDreamFoam_BE;

namespace ProyDreamFoam_BL
{
    public class DiarioBL
    {
        DiarioADO objDiarioADO = new DiarioADO();

        public List<DiarioBECons> ListarDiarioCompleto(String area, String estado, DateTime fecIni, DateTime fecFin)
        {
            return objDiarioADO.ListarDiarioCompleto(area, estado, fecIni, fecFin);
        }
        public List<DiarioBECons> ListarDiarioArea(String area, DateTime fecIni, DateTime fecFin)
        {
            return objDiarioADO.ListarDiarioArea(area, fecIni, fecFin); 
        }
        
        public List<DiarioBECons> ListarDiarioEstado(String estado, DateTime fecIni, DateTime fecFin)
        {
            return objDiarioADO.ListarDiarioEstado(estado, fecIni, fecFin); 
        }

        public List<DiarioBECons> ListarDiario(DateTime fecIni, DateTime fecFin)
        {
            return objDiarioADO.ListarDiario(fecIni, fecFin);
        }

        public List<DiarioBECons> ListarDiarioEmpGeneral(Int32 codigo, DateTime fecIni, DateTime fecFin)
        {
            return objDiarioADO.ListarDiarioEmpGeneral(codigo, fecIni, fecFin); 
        }

        public List<DiarioBECons> ListarDiarioEmpEstad(Int32 codigo, String estado, DateTime fecIni, DateTime fecFin)
        {
            return objDiarioADO.ListarDiarioEmpEstad(codigo, estado,fecIni, fecFin); ;
        }
        public DiarioBEMetrics MetricasEmplInd(Int32 codigo, DateTime fecIni, DateTime fecFin)
        {
            return objDiarioADO.MetricasEmplInd(codigo, fecIni, fecFin);
        }
        public DiarioBEGenMetrics MetricasGenEmpl(DateTime fecIni, DateTime fecFin)
        {
            return objDiarioADO.MetricasGenEmpl(fecIni, fecFin);
        }
        public List<DiarioBEGenMetrics> MetricasTopEmplTar()
        {
            return objDiarioADO.MetricasTopEmplTar();
        }

        public List<DiarioBEGenMetrics> MetricasTopEmplPun()
        {
            return objDiarioADO.MetricasTopEmplPun();
        }
        public List<DiarioBEGenMetrics2> MetricasDiarioAddArea(String estado)
        {
            return objDiarioADO.MetricasDiarioAddArea(estado);
        }

        public List<DiarioBEGenMetrics2> MetricasDiarioAddHora(String estado)
        {
            return objDiarioADO.MetricasDiarioAddHora(estado);
        }
        public List<DiarioBEGenMetrics2> MetricasDiarioAddSede(String estado)
        {
            return objDiarioADO.MetricasDiarioAddSede(estado);
        }
    }
}
