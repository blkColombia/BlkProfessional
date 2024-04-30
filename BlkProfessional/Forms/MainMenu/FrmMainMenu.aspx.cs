using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlkProfessional.Forms.Menu
{
    public partial class FrmMainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTareas_Click(object sender, ImageClickEventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/TalentoHumano/FrmTarea.aspx?usuario={usuario}");
        }

        protected void btnLider_Click(object sender, ImageClickEventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/TalentoHumano/FrmTareaLider.aspx?usuario={usuario}");

        }

        protected void btnEstadistica_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}