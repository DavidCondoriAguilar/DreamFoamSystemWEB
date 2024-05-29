
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyDreamFoam_BE;

namespace ProyDreamFoam_ADO
{
    public class AreaADO
    {
        public List<AreaBE> ListarAreas()
        {
            try{
                DreamFoam_DBEntities dreamDB = new DreamFoam_DBEntities();

                List<AreaBE> objLista = new List<AreaBE>();
                AreaBE primerVal = new AreaBE();
                primerVal.codArea = 0;
                primerVal.nomArea = "Todas las areas";
                objLista.Add(primerVal);
                var query = dreamDB.usp_ListarArea();

                foreach(var result in query)
                {
                    AreaBE objAreaBE = new AreaBE();  
                    objAreaBE.codArea = result.codArea;
                    objAreaBE.nomArea = result.nomArea;
                    objLista.Add(objAreaBE);
                }
                return objLista;

            }catch(EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
