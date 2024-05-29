using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyDreamFoam_BE;
using ProyDreamFoam_BL;


namespace DreamWEB
{
    public partial class Login : System.Web.UI.Page
    {
       
        UserSystemBE objUserSystmeBE = new UserSystemBE();  
        UserSystemBL objUserSystemBL = new UserSystemBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() != "" & txtPassword.Text.Trim() != "")
            {
                objUserSystmeBE = objUserSystemBL.ConsultarUserSystem(txtNombre.Text.Trim());
                if (objUserSystmeBE.codUser == 0)
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                    txtNombre.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                }
                else if (txtNombre.Text.Trim() == objUserSystmeBE.nomUser && txtPassword.Text.Trim() == objUserSystmeBE.passUser)
                {
                    lblMensaje.Text = "Bienvenido!";
                    Response.Redirect("~/DreamMasterPages/DreamPrincipal.aspx");
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                    txtNombre.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                }
            }
            else
            {
                lblMensaje.Text = "Por favor todos los campos son obligatorios";
                txtNombre.Text = String.Empty;
                txtPassword.Text = String.Empty;
            }
        }
    }
}