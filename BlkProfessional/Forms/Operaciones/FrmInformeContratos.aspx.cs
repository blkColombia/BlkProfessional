using BRL;
using DCL;
using System;
using System.Data;

namespace BlkProfessional.Forms.Operaciones
{
    public partial class FrmInformeContratos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            ItemLedgerEntry obj = new ItemLedgerEntry();
            obj.CustomerNo = txtCliente.Text;
            DataTable dtb = ItemLedgerEntry_BRL.SelectTable(obj, 1);
            if (dtb.Rows.Count > 0)
            {
                txtDescripcionCliente.Text = dtb.Rows[0]["Name"].ToString();
            }
            else
            {
                MostrarMensaje("El cliente no existe");
                return;
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            string script = "<script language='javascript'>alert('" + mensaje + "');</script>";
            this.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), script);
        }
    }
}