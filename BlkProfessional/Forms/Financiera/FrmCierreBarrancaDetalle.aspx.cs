using BlkProfessional.Servicios;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using DCL;
using BRL;

namespace BlkProfessional.Forms.Financiera
{
    public partial class FrmCierreBarrancaDetalle : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
            {
                CodigoCliente = txtCliente.Text,
                Action = 3
            };
            ddlYear.SelectedValue = "2024";
            txtCliente.Text = "CTE0001";
            
            string idCierre = Request.QueryString["IdCierre"];

            GFCierreFinanciero obj = new GFCierreFinanciero();
            obj.IdCierre = Convert.ToInt32(idCierre);
            DataTable dtbMes = GFCierreFinanciero_BRL.SelectTable(obj,1);
            if (dtbMes.Rows.Count >0) {
                ddlMonth.SelectedValue = dtbMes.Rows[0]["Mes"].ToString();
            }
            

            txtCliente_TextChanged(null,null);
            string jsonString = JsonConvert.SerializeObject(objeto);
            var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
            ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
            DataTable dtb = listaObjetos.data;
            LlenarDropdowns(dtb, ddl_Terminal, new string[] { "CodigoTerminal", "CodigoTerminal" });
            ddl_Terminal.SelectedValue = "BCA";
            btnResumen_Click(null, null);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
            {
                CodigoCliente = txtCliente.Text,
                Action = 1

            };

            string jsonString = JsonConvert.SerializeObject(objeto);
            var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);

            ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);

            DataTable dtb = listaObjetos.data;
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

        public void LlenarDropdowns(DataTable dt, DropDownList ddl, string[] opciones)
        {
            try
            {
                ddl.ClearSelection();
                ddl.Items.Clear();
                ddl.SelectedValue = null;
                ddl.DataSource = dt;
                ddl.DataTextField = opciones[0].ToString();
                ddl.DataValueField = opciones[1].ToString();
                ddl.DataBind();
                string texto = "-- Seleccione --";
                if (opciones.Length > 2) { texto = opciones[2]; }
                ddl.Items.Insert(0, new ListItem(texto, "-"));
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error inesperado [LLE-DRO]: " + ex.Message);
            }
        }

        protected void ddl_Terminal_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
            {
                Terminal = ddl_Terminal.SelectedValue,
                Action = 4
            };
            string jsonString = JsonConvert.SerializeObject(objeto);
            var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
            ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
            DataTable dtb = listaObjetos.data;

            LlenarDropdowns(dtb, ddlLocation, new string[] { "Location", "Location" });
        }


        private string convertirFecha(string year, string mes)
        {

            string fecha = "";
            int dia = DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(mes));
            fecha = dia.ToString() + "/" + mes + "/" + year;
            return fecha;
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlYear.SelectedValue == "0")
                {
                    MostrarMensaje("Debe Seleccionar un año");
                    return;
                }

                if (ddlMonth.SelectedValue == "0")
                {
                    MostrarMensaje("Debe Seleccionar un Mes");
                    return;
                }

                RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
                {
                    Terminal = ddl_Terminal.SelectedValue,
                    Fecha = convertirFecha(ddlYear.SelectedValue, ddlMonth.SelectedValue),
                    Action = 14
                };
                string jsonString = JsonConvert.SerializeObject(objeto);
                var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
                ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
                if (listaObjetos.data != null)
                {
                    DataTable dtb = listaObjetos.data;

                    if (dtb.Rows.Count > 0)
                    {
                        string archivo = "InformeTolvas" + DateTime.Now.Second.ToString();
                        string rutarchivo = Server.MapPath("~/" + archivo + ".xls");
                        ExportToExcel(dtb, rutarchivo);

                        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                        response.ClearContent();
                        response.Clear();
                        response.ContentType = "application/vnd.xls";
                        response.AddHeader("Content-Disposition", "attachment; filename=" + archivo + ".xls" + ";");
                        response.TransmitFile(rutarchivo);
                        response.Flush();

                        if (System.IO.File.Exists(rutarchivo))
                        {
                            try
                            {
                                System.IO.File.Delete(rutarchivo);
                            }
                            catch (System.IO.IOException ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }
                        }
                        response.End();

                    }
                    else
                    {
                        MostrarMensaje("Los filtros no arrojaron informacion");
                    }
                }
                else
                {
                    MostrarMensaje("Los filtros no arrojaron informacion");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Por favor contacte al administrador del sistema :  " + ex.Message.ToString());
            }
        }



        private void ExportToExcel(DataTable table, string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.GetEncoding(1252));
            sw.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            sw.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            sw.Write("<BR><BR><BR>");
            sw.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            int columnscount = table.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {
                sw.Write("<Td>");
                sw.Write("<B>");
                sw.Write(table.Columns[j].ToString());
                sw.Write("</B>");
                sw.Write("</Td>");
            }
            sw.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {
                sw.Write("<TR>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    sw.Write("<Td>");
                    sw.Write(row[i].ToString());
                    sw.Write("</Td>");
                }
                sw.Write("</TR>");
            }
            sw.Write("</Table>");
            sw.Write("</font>");
            sw.Close();
        }

        protected void lnkMenu_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/MainMenu/FrmMenuFinanciera.aspx?usuario={usuario}");
        }

        protected void gvCierre_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Visualizar")
            {
                if (e.CommandArgument.ToString() == "Almacenamiento")
                {
                    string idCierre = Request.QueryString["IdCierre"];
                    string usuario = Request.QueryString["usuario"];
                    Response.Redirect($"FrmCierreBarrancaAlm.aspx?usuario={usuario}&IdCierre={idCierre}");
                }
                else {
                    string idCierre = Request.QueryString["IdCierre"];
                    string usuario = Request.QueryString["usuario"];
                    Response.Redirect($"FrmLiquidacionEnsacado.aspx?usuario={usuario}&IdCierre={idCierre}");

                }
            }
        }

        protected void btnResumen_Click(object sender, EventArgs e)
        {
            try
            {
                string idCierre = Request.QueryString["IdCierre"];

                if (ddlYear.SelectedValue == "0")
                {
                    MostrarMensaje("Debe Seleccionar un año");
                    return;
                }

                if (ddlMonth.SelectedValue == "0")
                {
                    MostrarMensaje("Debe Seleccionar un Mes");
                    return;
                }

                DCL.GFCierreFinancieroDetalle objeto = new DCL.GFCierreFinancieroDetalle
                {
                    IdCierre = Convert.ToInt32(idCierre),
                    Terminal = ddl_Terminal.SelectedValue
                };
                DataTable dtb = BRL.GFCierreFinancieroDetalle_BRL.SelectTable(objeto, 0);
                if (dtb.Rows.Count > 0)
                {
                    gvCierre.DataSource = dtb;
                    gvCierre.DataBind();
                }
                else
                {
                    MostrarMensaje("Los filtros no arrojaron informacion");
                    return;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Por favor contacte al administrador del sistema :  " + ex.Message.ToString());
            }
        }

        protected void gvCierre_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //decimal TotalValor = Convert.ToDecimal(e.Row.Cells[1].Text);
                //e.Row.Cells[1].Text = String.Format("${0:#,##0}", TotalValor);
       

            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"FrmCierreBarranca.aspx?usuario={usuario}");
        }
    }
}