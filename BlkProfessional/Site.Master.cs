using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlkProfessional
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["Usuario"];
            DCL.Employees obj = new DCL.Employees();
            obj.IdentificationNumber = usuario;
            DataTable dtb = BRL.Employess_BRL.SelectTable(obj,11);
            if (dtb.Rows.Count > 0) {
                lblUser.Text = dtb.Rows[0]["Nombres"].ToString();
            }
        }
    }
}