using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyDreamFoam_BE;

namespace ProyDreamFoam_ADO
{
    public  class UserSystemADO
    {
        public UserSystemBE ConsultarUserSystem(String nomUser)
        {
            try
            { 
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();
                Tb_UserSystem objUserSystem = 
                    (from userSystem in dreamDB.Tb_UserSystem
                     where userSystem.nomUser == nomUser
                     select userSystem
                    ).FirstOrDefault();

                UserSystemBE user = new UserSystemBE();
                if (objUserSystem == null) {
                        user.codUser = 0;
                }
                else
                {
                    user.codUser = Convert.ToInt16(objUserSystem.codUser);
                    user.nomUser = objUserSystem.nomUser;
                    user.passUser = objUserSystem.passUser;
                    user.estdUser = Convert.ToInt16(objUserSystem.estdUser);
                }
                return user;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
