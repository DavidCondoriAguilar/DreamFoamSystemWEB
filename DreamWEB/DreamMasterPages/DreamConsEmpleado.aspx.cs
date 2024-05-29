using ProyDreamFoam_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProyDreamFoam_BL;
using System.IO;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace DreamWEB.DreamMasterPages
{
    public partial class DreamConsEmpleado : System.Web.UI.Page
    {
        EmpleadoBL objEmpleadoBL = new EmpleadoBL();
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
        //private int codEmp
        //{
        //    get
        //    {
        //        return (int)ViewState["codEmp"];
        //    }
        //    set
        //    {
        //        ViewState["codEmp"] = value;
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void IniciarDatosEmpleado(EmpleadoBECons obj)
        {
            txtTipDoc.Text = obj.tipoDoc.ToString();
            txtNumDoc.Text = obj.numroDoc.ToString();
            txtEmpleado.Text = obj.nombreCompleto.ToString();
            txtCorreo.Text = obj.correo.ToString();
            txtFechaIng.Text = obj.fecIngreso.ToString("d");
            txtArea.Text=obj.area.ToString();
            txtCargo.Text=obj.cargo.ToString();
            txtHorario.Text=obj.horario.ToString();
            txtSede.Text=obj.sede.ToString();

            byte[] img = obj.foto;
            if (img != null && img.Length > 0)
            {
                using (MemoryStream memoryStream = new MemoryStream(img))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
                    using (Bitmap bitmap = new Bitmap(image))
                    {
                        using (MemoryStream bitmapStream = new MemoryStream())
                        {
                            bitmap.Save(bitmapStream, System.Drawing.Imaging.ImageFormat.Png); 
                            byte[] bitmapData = bitmapStream.ToArray();
                            string base64String = Convert.ToBase64String(bitmapData);
                            string imageUrl = "data:image/png;base64," + base64String;
                            imgFoto.ImageUrl = imageUrl;
                        }
                    }
                }
            }
            else
            {
                imgFoto.ImageUrl = "~/FotosTemp/noimage.jpg";
            }

        }
        protected void IniciarMetricas(Int32 codigo, String estado, DateTime fecIni, DateTime fecFin)
        {
            if(estado == "")
            {
                txtNumReg.Text = objDiarioBL.ListarDiarioEmpGeneral(codigo, fecIni, fecFin).Count.ToString();
            
            }
            else
            {
                txtNumReg.Text = objDiarioBL.ListarDiarioEmpEstad(codigo, estado, fecIni, fecFin).Count.ToString();
            }
            txtNumAsis.Text = objDiarioBL.ListarDiarioEmpEstad(codigo, "PUNTUAL", fecIni, fecFin).Count.ToString();
            txtNumTar.Text = objDiarioBL.ListarDiarioEmpEstad(codigo,"TARDE",fecIni, fecFin).Count.ToString();
            
            DiarioBEMetrics metr = new DiarioBEMetrics();
            metr = objDiarioBL.MetricasEmplInd(codigo, fecIni, fecFin);
            lblMensaje.Text = String.Empty;
            txtHrsTard.Text = metr.sumTar.ToString("T");
            txtExeRef.Text = metr.sumRef.ToString("T");
            txtExeJor.Text = metr.sumJor.ToString("T");
            txtMasTar.Text = metr.mayorTard.ToString("T");
            txtMasRef.Text = metr.mayorExeRef.ToString("T");
            txtMasJor.Text = metr.mayorExeJornd.ToString("T");

            int numAsist = objDiarioBL.ListarDiarioEmpEstad(codigo, "PUNTUAL", fecIni, fecFin).Count;
            int numTar = objDiarioBL.ListarDiarioEmpEstad(codigo, "TARDE", fecIni, fecFin).Count;

            DataPoint dpAsist = new DataPoint();
            dpAsist.YValues = new double[] { numAsist };
            dpAsist.Label = "#PERCENT\nPUNTUAL";

            DataPoint dpTard = new DataPoint();
            dpTard.YValues = new double[] { numTar };
            dpTard.Label = "#PERCENT\nTARDE";

            charAsistPorcent.Series[0].Points.Add(dpAsist);
            charAsistPorcent.Series[0].Points.Add(dpTard);
            charAsistPorcent.Titles.Add("GRAFICO DE\n PUNTUALIDAD Y TARDANZAS");
            charAsistPorcent.DataBind();

        }

        private void CargarPaginacion()
        {
            Int32 codigo = Convert.ToInt32(txtCodigo.Text);
            String estado = cboEstado.SelectedItem.ToString();
            DateTime fecIni = Convert.ToDateTime(txtFecInicio.Text);
            DateTime fecFin = Convert.ToDateTime(txtFecFin.Text);
            
            switch (tipoCons)
            {
                case 1:
                    grvConsEmpleado.DataSource = objDiarioBL.ListarDiarioEmpGeneral(codigo, fecIni, fecFin);
                    grvConsEmpleado.DataBind();
                    break;
                case 2:
                    grvConsEmpleado.DataSource = objDiarioBL.ListarDiarioEmpEstad(codigo, estado, fecIni, fecFin);
                    grvConsEmpleado.DataBind();
                    break;
                default:
                    lblMensaje.Text = "No se encontro tipoCons";
                    break;
            }
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtCodigo.Text == String.Empty){
                    lblMensaje.Text = "El campo del codigo del empleado es obligatorio";
                }
                else if (txtFecInicio.Text.Trim() == String.Empty || txtFecFin.Text.Trim() == String.Empty)
                {
                    lblMensaje.Text = "Los campos de fechas son obligatorios";
                }
                else if (Convert.ToDateTime(txtFecInicio.Text.Trim()) > Convert.ToDateTime(txtFecFin.Text.Trim()))
                {
                    lblMensaje.Text = "La fecha de inicio no puede ser mayor que la de fin";
                }
                else
                {
                    Int32 codigo = Convert.ToInt32(txtCodigo.Text);
                    String estado = cboEstado.SelectedItem.ToString();
                    DateTime fecIni = Convert.ToDateTime(txtFecInicio.Text);
                    DateTime fecFin = Convert.ToDateTime(txtFecFin.Text);

                    EmpleadoBECons objEmple = new EmpleadoBECons();
                    objEmple = objEmpleadoBL.ConsultarEmpleado(codigo);

                    if(objEmple.codEmpleado == 0)
                    {
                        lblMensaje.Text = "No existe el empleado";
                    }
                    else
                    {
                        //codEmp = codigo;
                        IniciarDatosEmpleado(objEmple);
                        if (Convert.ToInt32(cboEstado.SelectedValue.ToString()) == 1)
                        {
                            tipoCons = 1;
                            grvConsEmpleado.DataSource = objDiarioBL.ListarDiarioEmpGeneral(codigo,fecIni,fecFin);
                            IniciarDatosEmpleado(objEmple);
                            grvConsEmpleado.DataBind();
                            IniciarMetricas(codigo,"",fecIni, fecFin);
                        }
                        else
                        {
                            tipoCons = 2;
                            grvConsEmpleado.DataSource = objDiarioBL.ListarDiarioEmpEstad(codigo,estado, fecIni,fecFin);   
                            grvConsEmpleado.DataBind();
                            IniciarDatosEmpleado(objEmple);
                            IniciarMetricas(codigo,estado, fecIni, fecFin);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.Text = "No puede ingresar caracteres en este campo";
            }
        }

        protected void grvConsEmpleado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvConsEmpleado.PageIndex = e.NewPageIndex;
            CargarPaginacion();
        }


       
    }
}