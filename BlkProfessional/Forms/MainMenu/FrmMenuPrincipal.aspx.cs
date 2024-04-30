using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlkProfessional.Forms.MainMenu
{
    public partial class FrmMenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGestionHumana_Click(object sender, ImageClickEventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/MainMenu/FrmMainMenu.aspx?usuario={usuario}");
        }

        protected void btnSac_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnOperaciones_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void lnkGestionHumana_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/MainMenu/FrmMainMenu.aspx?usuario={usuario}");
        }

        protected void lnkOperaciones_Click(object sender, EventArgs e)
        {
           
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/MainMenu/FrmMenuOperaciones.aspx?usuario={usuario}");
        }

        protected void lnkSAC_Click(object sender, EventArgs e)
        {  
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/MainMenu/FrmMenuSAC.aspx?usuario={usuario}");
        }

        private void MostrarMensaje(string mensaje)
        {
            string script = "<script language='javascript'>alert('" + mensaje + "');</script>";
            this.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), script);
        }

        protected void lnkGestionFinanciera_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/MainMenu/FrmMenuFinanciera.aspx?usuario={usuario}");
        }
    }
}