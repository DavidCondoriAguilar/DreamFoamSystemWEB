using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyDreamFoam_BE;
using ProyDreamFoam_ADO;

namespace ProyDreamFoam_BL
{
    public class EmpleadoBL
    {
        EmpleadoADO obj = new EmpleadoADO();
        public EmpleadoBECons ConsultarEmpleado(Int32 cod)
        {
            return obj.ConsultarEmpleado(cod);
        }
    }
}
