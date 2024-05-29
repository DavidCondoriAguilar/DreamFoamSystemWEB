using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamWEB
{
    public partial class DreamMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Puedes establecer la URL de destino aquí
                linkPrincipal.NavigateUrl = "~/DreamMasterPages/DreamPrincipal.aspx";
                linkGeneral.NavigateUrl = "~/DreamMasterPages/DreamConsGeneral.aspx";
                linkIndividual.NavigateUrl = "~/DreamMasterPages/DreamConsEmpleado.aspx";
                linkMetricas.NavigateUrl = "~/DreamMasterPages/DreamMetricas.aspx";
                linkLogin.NavigateUrl = "~/Login.aspx";
            }
        }
    }
}