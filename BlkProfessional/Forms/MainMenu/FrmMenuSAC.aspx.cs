using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlkProfessional.Forms.MainMenu
{
    public partial class FrmMenuSAC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkLiquidacionITR_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmLiquidacionITR.aspx?usuario={usuario}");
        }

        protected void lnkDescargas_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmLiquidacionDescargasITR.aspx?usuario={usuario}");
        }

        protected void lnlAlmacenamientoMes_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmInformeLiquidacionMes.aspx?usuario={usuario}");
        }

        protected void lnkCantidadITR_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmInformeCantidadITR.aspx?usuario={usuario}");            
        }

        protected void lnkDescargaAlma_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmAlmacenamientoDescarga.aspx?usuario={usuario}");
        }

        protected void lnkCierre_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Sac/FrmLiquidacionImportaciones.aspx?usuario={usuario}");
        }

        protected void lnkMenu_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/MainMenu/FrmMenuPrincipal.aspx?usuario={usuario}");
        }
    }
}