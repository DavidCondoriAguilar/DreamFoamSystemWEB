using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyDreamFoam_ADO;
using ProyDreamFoam_BE;

namespace ProyDreamFoam_BL
{
    public class AreaBL
    {
        AreaADO objAreaADO = new AreaADO();
        public List<AreaBE> ListarAreas()
        {
            return objAreaADO.ListarAreas();
        }
    }
}
