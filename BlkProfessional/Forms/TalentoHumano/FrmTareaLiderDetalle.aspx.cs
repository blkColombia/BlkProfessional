using BRL;
using System;
using System.Data;

namespace BlkProfessional.Forms.TalentoHumano
{
    public partial class FrmTareaLiderDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica si el parámetro IdTarea está presente en la URL
                if (Request.QueryString["IdTarea"] != null)
                {
                    // Obtén el valor del parámetro IdTarea
                    string idTarea = Request.QueryString["IdTarea"];

                    DCL.Employees obj = new DCL.Employees();
                    obj.EmployeeId = Convert.ToInt32(idTarea);
                    DataTable dtb = Employess_BRL.SelectTable(obj, 8);
                    if (dtb.Rows.Count > 0)
                    {
                        txtNombre.Value = dtb.Rows[0]["Responsable"].ToString();
                        txtCargo.Value = dtb.Rows[0]["CargoResponsable"].ToString();
                        txtFechaCierreRE.Value = dtb.Rows[0]["FechaCierreResult"].ToString();
                        txtResultadoExcelente.Value = dtb.Rows[0]["CBResultadosExcelentes"].ToString();
                        txtSolucionTareaRE.Value = dtb.Rows[0]["SolucionTareaRE"].ToString();
                        txtSeguimLRE.Value = dtb.Rows[0]["SeguimientoLiderRE"].ToString();
                        ddlEstadoTareaR.SelectedValue = dtb.Rows[0]["ddlEstadoResultadoTarea"].ToString();
                        ddlEstadoTareaCBC.SelectedValue = dtb.Rows[0]["ddlEstadoTareaSC"].ToString();
                        txtResponsableSC.Value = dtb.Rows[0]["Responsable"].ToString();
                        txtCargoSC.Value = dtb.Rows[0]["CargoResponsable"].ToString();
                        txtFechaCierreSC.Value = dtb.Rows[0]["FechaCierreSC"].ToString();
                        txtCompromisoSC.Value = dtb.Rows[0]["CBServicioalCliente"].ToString();
                        txtSolucionSC.Value = dtb.Rows[0]["SolucionTareaSC"].ToString();
                        txtSeguimLSC.Value = dtb.Rows[0]["SeguimientoLiderSC"].ToString();


                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string idTarea = Request.QueryString["IdTarea"];

            DCL.Employees obj = new DCL.Employees();
            obj.Names = txtSeguimLRE.InnerText;
            obj.EmployeeId = Convert.ToInt32(idTarea);
            obj.ChargeId = Convert.ToInt32(ddlEstadoTareaR.SelectedValue);
            Employess_BRL.InsertarOrUpdate(obj, 9);

            MostrarMensaje("Guardado con Exito");
        }

        private void MostrarMensaje(string mensaje)
        {
            string script = "<script language='javascript'>alert('" + mensaje + "');</script>";
            this.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), script);
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];

            Response.Redirect($"FrmTareaLider.aspx?usuario={usuario}");
        }

        protected void btnGuardarD_Click(object sender, EventArgs e)
        {
            string idTarea = Request.QueryString["IdTarea"];
            DCL.Employees obj = new DCL.Employees();
            obj.Names = txtSeguimLSC.InnerText;
            obj.EmployeeId = Convert.ToInt32(idTarea);
            obj.ChargeId = Convert.ToInt32(ddlEstadoTareaCBC.SelectedValue);
            Employess_BRL.InsertarOrUpdate(obj, 10);

            MostrarMensaje("Guardado con Exito");
        }
    }
}