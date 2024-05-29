using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyDreamFoam_ADO;
using ProyDreamFoam_BE;

namespace ProyDreamFoam_BL
{
    public class UserSystemBL
    {
        UserSystemADO UserSystemADO = new UserSystemADO();

        public UserSystemBE ConsultarUserSystem(String nombre)
        {
            return UserSystemADO.ConsultarUserSystem(nombre);
        }
    }
}
