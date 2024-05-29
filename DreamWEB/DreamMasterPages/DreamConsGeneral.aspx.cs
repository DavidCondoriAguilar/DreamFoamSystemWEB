using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using ProyDreamFoam_BE;
using ProyDreamFoam_BL;

namespace DreamWEB.DreamMasterPages
{
    public partial class DreamConsGeneral : System.Web.UI.Page
    {
        AreaBL objAreaBL = new AreaBL();
        DiarioBL objDiarioBL = new DiarioBL();

        private int tipoCons
        {
            get
            {
                return (int)ViewState["TipoCons"];
            }
            set
            {
                ViewState["TipoCons"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Page.IsPostBack == false)
                {
                    cboArea.DataSource = objAreaBL.ListarAreas();
                    cboArea.DataValueField = "codArea";
                    cboArea.DataTextField = "nomArea";
                    cboArea.DataBind();
                }
            }
            catch(Exception ex) 
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private void CargarPaginacion()
        {
            String area = cboArea.SelectedItem.ToString();
            String estado = cboEstado.SelectedItem.ToString();
            DateTime fecIni = Convert.ToDateTime(txtFecInicio.Text);
            DateTime fecFin = Convert.ToDateTime(txtFecFin.Text);
          
            switch (tipoCons)
            {
                case 1:
                    grvConsGeneral.DataSource = objDiarioBL.ListarDiario(fecIni, fecFin);
                    grvConsGeneral.DataBind();
                    break;
                case 2:
                    grvConsGeneral.DataSource = objDiarioBL.ListarDiarioEstado(estado, fecIni, fecFin);
                    grvConsGeneral.DataBind();
                    break;
                case 3:
                    grvConsGeneral.DataSource = objDiarioBL.ListarDiarioArea(area, fecIni, fecFin);
                    grvConsGeneral.DataBind();
                    break;
                case 4:
                    grvConsGeneral.DataSource = objDiarioBL.ListarDiarioCompleto(area, estado, fecIni, fecFin);
                    grvConsGeneral.DataBind();
                    
                    break;
                default:
                    lblMensaje.Text = "No se encontro tipoCons";
                    break;
            }
        }
        
        private void IniciarMetricas(int numAsist2, int numTar2,String area ,DateTime fecIni ,DateTime fecFin)
        {
            DiarioBEGenMetrics metr = new DiarioBEGenMetrics();
            metr = objDiarioBL.MetricasGenEmpl(fecIni, fecFin);

            txtEmpPunt.Text = metr.emplPun;
            txtEmpPuntMar.Text = metr.emplPunMarc.ToString();
            txtEmpTar.Text = metr.emplTar;
            txtEmpTarMar.Text = metr.emplTarMarc.ToString();

            txtAreaPun.Text = metr.areaPun;
            txtAreaTar.Text = metr.areaTar;

            txtCarPun.Text = metr.carPun;
            txtCarTar.Text = metr.carTar;

            txtHorPun.Text = metr.horarPun;
            txtHorTar.Text = metr.horarTar;

            int numAsist1 = objDiarioBL.ListarDiarioEstado("PUNTUAL", fecIni, fecFin).Count;
            int numTar1 = objDiarioBL.ListarDiarioEstado("TARDE", fecIni, fecFin).Count;


            DataPoint dpAsist = new DataPoint();
            dpAsist.YValues = new double[] { numAsist1 };
            dpAsist.Label = "#PERCENT\nPUNTUAL";

            DataPoint dpTard = new DataPoint();
            dpTard.YValues = new double[] { numTar1 };
            dpTard.Label = "#PERCENT\nTARDE";

            DataPoint dpAsist2 = new DataPoint();
            dpAsist2.YValues = new double[] { numAsist2 };
            dpAsist2.Label = "#PERCENT\nPUNTUAL";

            DataPoint dpTard2 = new DataPoint();
            dpTard2.YValues = new double[] { numTar2 };
            dpTard2.Label = "#PERCENT\nTARDE";

            charTarPun.Series[0].Points.Add(dpAsist);
            charTarPun.Series[0].Points.Add(dpTard);
            charTarPun.Titles.Add("GRAFICO GENERAL\n PUNTUALIDAD Y TARDANZA");
            charTarPun.DataBind();

            charArea.Series[0].Points.Add(dpAsist2);
            charArea.Series[0].Points.Add(dpTard2);
            charArea.Titles.Add("AREA SELECT "+ area +"\n GRAFICO PUNTUALIDAD Y TARDANZA");
            charArea.DataBind();

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtFecInicio.Text.Trim() == String.Empty || txtFecFin.Text.Trim() == String.Empty) {
                    lblMensaje.Text = "Los campos de fechas son obligatorios";
                }
                else if(Convert.ToDateTime(txtFecInicio.Text.Trim()) > Convert.ToDateTime(txtFecFin.Text.Trim()))
                {
                    lblMensaje.Text = "La fecha de inicio no puede ser mayor que la de fin";
                }
                else
                {
                    lblMensaje.Text = String.Empty;
                    String area = cboArea.SelectedItem.ToString();
                    String estado = cboEstado.SelectedItem.ToString();
                    DateTime fecIni = Convert.ToDateTime(txtFecInicio.Text);
                    DateTime fecFin = Convert.ToDateTime(txtFecFin.Text);
                    int numAsist2;
                    int numTar2;

                    if (Convert.ToInt32(cboArea.SelectedValue.ToString()) == 0 && Convert.ToInt32(cboEstado.SelectedValue.ToString()) == 1)
                    {
                        tipoCons = 1;
                        grvConsGeneral.DataSource = objDiarioBL.ListarDiario(fecIni, fecFin);
                        txtNumReg.Text = objDiarioBL.ListarDiario(fecIni, fecFin).Count.ToString();
                        numAsist2 = objDiarioBL.ListarDiarioEstado("PUNTUAL", fecIni, fecFin).Count;
                        numTar2 = objDiarioBL.ListarDiarioEstado("TARDE", fecIni, fecFin).Count;
                        IniciarMetricas(numAsist2, numTar2,"TODAS",fecIni, fecFin);
                        grvConsGeneral.DataBind();
                      

                    }
                    else if (Convert.ToInt32(cboArea.SelectedValue.ToString()) == 0)
                    {
                        tipoCons = 2;
                        grvConsGeneral.DataSource = objDiarioBL.ListarDiarioEstado(estado, fecIni, fecFin);
                        txtNumReg.Text = objDiarioBL.ListarDiarioEstado(estado, fecIni, fecFin).Count.ToString();
                        numAsist2 = objDiarioBL.ListarDiarioEstado("PUNTUAL", fecIni, fecFin).Count;
                        numTar2 = objDiarioBL.ListarDiarioEstado("TARDE", fecIni, fecFin).Count;
                        IniciarMetricas(numAsist2, numTar2, "TODAS", fecIni, fecFin);
                        grvConsGeneral.DataBind();
                   
                    }
                    else if (Convert.ToInt32(cboEstado.SelectedValue.ToString()) == 1)
                    {
                        tipoCons = 3;
                        grvConsGeneral.DataSource = objDiarioBL.ListarDiarioArea(area,fecIni, fecFin);
                        txtNumReg.Text = objDiarioBL.ListarDiarioArea(area, fecIni, fecFin).Count.ToString();
                        numAsist2 = objDiarioBL.ListarDiarioCompleto(area, "PUNTUAL", fecIni, fecFin).Count;
                        numTar2 = objDiarioBL.ListarDiarioCompleto(area, "TARDE", fecIni, fecFin).Count;
                        IniciarMetricas(numAsist2, numTar2, area, fecIni, fecFin);
                        grvConsGeneral.DataBind();
                     
                    }
                    else
                    {
                       tipoCons = 4;
                       grvConsGeneral.DataSource = objDiarioBL.ListarDiarioCompleto(area,estado,fecIni,fecFin);
                        txtNumReg.Text = objDiarioBL.ListarDiarioCompleto(area, estado, fecIni, fecFin).Count.ToString();
                        numAsist2 = objDiarioBL.ListarDiarioCompleto(area, "PUNTUAL", fecIni, fecFin).Count;
                        numTar2 = objDiarioBL.ListarDiarioCompleto(area, "TARDE", fecIni, fecFin).Count;
                        IniciarMetricas(numAsist2, numTar2, area, fecIni, fecFin);
                        grvConsGeneral.DataBind();
                       
                    }
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.Text = "Ingrese el formato correcto de fecha dd/mm/aaaa";
            }
        }

        protected void grvConsGeneral_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvConsGeneral.PageIndex = e.NewPageIndex;
            CargarPaginacion();
           
        }
    }
}