using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using ProyDreamFoam_BE;
using ProyDreamFoam_BL;

namespace DreamWEB.DreamMasterPages
{
    public partial class DreamMetricas : System.Web.UI.Page
    {
        DiarioBL diarioBL = new DiarioBL();
        protected void Page_Load(object sender, EventArgs e)
        {

            grdTopPun.DataSource = diarioBL.MetricasTopEmplPun();
            grdTopTar.DataSource = diarioBL.MetricasTopEmplTar();
            grdArePunt.DataSource = diarioBL.MetricasDiarioAddArea("PUNTUAL");
            grdAreaTar.DataSource = diarioBL.MetricasDiarioAddArea("TARDE");
            grdHorPun.DataSource = diarioBL.MetricasDiarioAddHora("PUNTUAL");
            grdHorTar.DataSource = diarioBL.MetricasDiarioAddHora("TARDE");
            grdSedePun.DataSource = diarioBL.MetricasDiarioAddSede("PUNTUAL");
            grdSedeTar.DataSource = diarioBL.MetricasDiarioAddSede("TARDE");

            grdTopPun.DataBind();
            grdTopTar.DataBind();
            grdAreaTar.DataBind();
            grdArePunt.DataBind();
            grdHorPun.DataBind();
            grdSedePun.DataBind();
            grdHorTar.DataBind();
            grdSedeTar.DataBind();

            //charArePunt
            List<DiarioBEGenMetrics2> lstAre = diarioBL.MetricasDiarioAddArea("PUNTUAL");
            foreach(var obj in lstAre)
            {
                DataPoint dp = new DataPoint();
                dp.YValues = new double[] {obj.areaMarc};
                dp.Label = "#PERCENT\n" + obj.nomArea;
                charArePunt.Series[0].Points.Add(dp);
            }
            charArePunt.Titles.Add("GRAFICO DE PUNTUALIDAD\nSEGÚN AREA");
            charArePunt.DataBind();

            lstAre = diarioBL.MetricasDiarioAddArea("TARDE");
            foreach(var obj in lstAre)
            {
                DataPoint dp = new DataPoint();
                dp.YValues = new double[] { obj.areaMarc };
                dp.Label = "#PERCENT\n" + obj.nomArea;
                charAreTar.Series[0].Points.Add(dp);
            }
            charAreTar.Titles.Add("GRAFICO DE TARDANZAS\nSEGÚN AREA");
            charAreTar.DataBind();

            List<DiarioBEGenMetrics2> lstHor = diarioBL.MetricasDiarioAddHora("PUNTUAL");
            foreach (var obj in lstHor)
            {
                DataPoint dp = new DataPoint();
                dp.YValues = new double[] { obj.horaMarc };
                dp.Label = "#PERCENT\n" + obj.nomHora;
                charHorPun.Series[0].Points.Add(dp);
            }
            charHorPun.Titles.Add("GRAFICO DE PUNTUALIDAD\nSEGÚN HORARIO");
            charHorPun.DataBind();

            lstHor = diarioBL.MetricasDiarioAddHora("TARDE");
            foreach (var obj in lstHor)
            {
                DataPoint dp = new DataPoint();
                dp.YValues = new double[] { obj.horaMarc };
                dp.Label = "#PERCENT\n" + obj.nomHora;
                charHorTar.Series[0].Points.Add(dp);
            }
            charHorTar.Titles.Add("GRAFICO DE TARDANZAS\nSEGÚN HORARIO");
            charHorTar.DataBind();

            List<DiarioBEGenMetrics2> lstSede = diarioBL.MetricasDiarioAddSede("PUNTUAL");
            foreach (var obj in lstSede)
            {
                DataPoint dp = new DataPoint();
                dp.YValues = new double[] { obj.sedeMarc };
                dp.Label = "#PERCENT\n" + obj.nomSede;
                charSedePun.Series[0].Points.Add(dp);
            }
            charSedePun.Titles.Add("GRAFICO DE PUNTUALIDAD\nSEGÚN SEDE");
            charSedePun.DataBind();
            
            lstSede = diarioBL.MetricasDiarioAddSede("TARDE");
            foreach (var obj in lstSede)
            {
                DataPoint dp = new DataPoint();
                dp.YValues = new double[] { obj.sedeMarc };
                dp.Label = "#PERCENT\n" + obj.nomSede;
                charSedeTar.Series[0].Points.Add(dp);
            }
            charSedeTar.Titles.Add("GRAFICO DE TARDANZA\nSEGÚN SEDE");
            charSedeTar.DataBind();
        }

        protected void charHorPun_Load(object sender, EventArgs e)
        {

        }
    }
}