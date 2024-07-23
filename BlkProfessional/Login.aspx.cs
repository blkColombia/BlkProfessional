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
            if (String.IsNullOrWhiteSpace(txtLogueo.Value)) {
                MostrarMensaje("el campo usuario no puede estar vacio");
                return;
            }
            if (String.IsNullOrWhiteSpace(txtPassword.Value))
            {
                MostrarMensaje("El campo contrasena no puede estar vacio");
                return;
            }

            DCL.Employees obj = new DCL.Employees();
            obj.IdentificationNumber = txtLogueo.Value;
            obj.Names = txtPassword.Value;
            DataTable dtb = Employess_BRL.SelectTable(obj,3);
            if (dtb.Rows.Count > 0)
            {
                string usuario = txtLogueo.Value;
                if (dtb.Rows[0]["Cargo"].ToString() == "Cliente") {
                    Response.Redirect($"~/Forms/MainMenu/FrmMenuPrincipal.aspx?usuario={usuario}&cliente=1");
                }
                else {
                    Response.Redirect($"~/Forms/MainMenu/FrmMenuPrincipal.aspx?usuario={usuario}&cliente=0");
                }
            }
            else {
                MostrarMensaje("Usuario y contrasena incorrecta");
            }
        }


        private void MostrarMensaje(string mensaje)
        {
            string script = "<script language='javascript'>alert('" + mensaje + "');</script>";
            this.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), script);
        }
    }
}