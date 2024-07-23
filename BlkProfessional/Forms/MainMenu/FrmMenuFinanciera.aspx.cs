using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlkProfessional.Forms.MainMenu
{
    public partial class FrmMenuFinanciera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lnkInventario_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmInventario.aspx?usuario={usuario}");
        }

        protected void lnkDespachos_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmInformeDespachos.aspx?usuario={usuario}");

        }

        protected void lnkOperacionITR_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmInventarioOperacionITR.aspx?usuario={usuario}");

        }

        protected void lnkInformeTolvas_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmInformeTolvas.aspx?usuario={usuario}");
        }

        protected void lnkMenu_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/MainMenu/FrmMenuPrincipal.aspx?usuario={usuario}");
        }

        protected void lnkPicking_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmPicking.aspx?usuario={usuario}");
        }

        protected void lnkLiquidacion_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Operaciones/FrmAlmacenamientoDescarga.aspx?usuario={usuario}");
        }

        protected void lnkWeekly_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Financiera/FrmIngresosBlk.aspx?usuario={usuario}");
        }

        protected void lnkInformeTolvas_Click1(object sender, EventArgs e)
        {

        }

        protected void lnkCierreBarranca_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Financiera/FrmCierreBarranca.aspx?usuario={usuario}");
        }

        protected void lnkCedisTerceros_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Financiera/CEDIS/FrmCierreCedis.aspx?usuario={usuario}");
        }

        protected void lnkCierreCartagena_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Financiera/CTG/FrmCierreCTG.aspx?usuario={usuario}");
        }
    }
}