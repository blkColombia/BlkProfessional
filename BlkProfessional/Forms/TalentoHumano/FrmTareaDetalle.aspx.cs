using BRL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlkProfessional.Forms.TalentoHumano
{
    public partial class FrmTareaDetalle : System.Web.UI.Page
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
                    DataTable dtb = Employess_BRL.SelectTable(obj, 1);
                    if (dtb.Rows.Count > 0) {
                        txtNombre.Value = dtb.Rows[0]["Responsable"].ToString();
                        txtCargo.Value = dtb.Rows[0]["CargoResponsable"].ToString();
                        txtFechaCierreRE.Value = dtb.Rows[0]["FechaCierreResult"].ToString();
                        txtResultadoExcelente.Value = dtb.Rows[0]["CBResultadosExcelentes"].ToString();
                        txtSolucionTareaRE.Value = dtb.Rows[0]["SolucionTareaRE"].ToString();
                        txtSeguimLRE.Value = dtb.Rows[0]["SeguimientoLiderRE"].ToString();

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
            DCL.Employees obj = new DCL.Employees();
            obj.Names = txtSeguimLRE.InnerText;
            Employess_BRL.InsertarOrUpdate(obj,3);


        }
    }
}