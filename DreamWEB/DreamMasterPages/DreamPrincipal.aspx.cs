using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DreamWEB.DreamMasterPages
{
    public partial class DreamPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsGeneral_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DreamMasterPages/DreamConsGeneral.aspx");
        }

        protected void btnConsEmpl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DreamMasterPages/DreamConsEmpleado.aspx");
        }

        protected void btnMetrics_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DreamMasterPages/DreamMetricas.aspx");
        }
    }
}