using BRL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlkProfessional
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DCL.Employees obj = new DCL.Employees();
            obj.IdentificationNumber = txtLogueo.Value;
            obj.Names = txtPassword.Value;
            DataTable dtb = Employess_BRL.SelectTable(obj,3);
            if (dtb.Rows.Count > 0) { 
            
            
            }
        }
    }
}