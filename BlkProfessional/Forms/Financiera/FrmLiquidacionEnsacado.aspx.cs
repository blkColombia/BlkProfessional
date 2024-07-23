using BlkProfessional.Servicios;
using BRL;
using DCL;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;


namespace BlkProfessional.Forms.Financiera
{
    public partial class FrmLiquidacionEnsacado : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
            {
                CodigoCliente = txtCliente.Text,
                Action = 3
            };
            string jsonString = JsonConvert.SerializeObject(objeto);
            var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
            ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
            DataTable dtb = listaObjetos.data;
            LlenarDropdowns(dtb, ddl_Terminal, new string[] { "CodigoTerminal", "CodigoTerminal" });
            ddlYear.SelectedValue = "2024";

            string idCierre = Request.QueryString["IdCierre"];
            GFCierreFinanciero obj = new GFCierreFinanciero();
            obj.IdCierre = Convert.ToInt32(idCierre);
            DataTable dtbMes = GFCierreFinanciero_BRL.SelectTable(obj, 1);
            if (dtbMes.Rows.Count > 0)
            {
                ddlMonth.SelectedValue = dtbMes.Rows[0]["Mes"].ToString();
                if (dtbMes.Rows[0]["Estado"].ToString() != "Abierto")
                {
                    btnAprobar.Enabled = false;
                }
                else {
                    btnAprobar.Enabled = true;
                }
            }

            txtCliente.Text = "CTE0001";
            txtCliente_TextChanged(null,null);
            ddl_Terminal.SelectedValue = "BCA";
            btnResumen_Click(null,null);

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
                // Aquí puedes obtener el CommandArgument que es el IdTarea
                int idCierre = Convert.ToInt32(e.CommandArgument);
                string usuario = Request.QueryString["usuario"];
                Response.Redirect($"FrmLiquidacionEnsacado.aspx?usuario={usuario}&IdCierreDet={idCierre}");
                // Puedes realizar acciones adicionales aquí según el IdTarea seleccionado
                // Por ejemplo, puedes redirigir a una nueva página o realizar alguna lógica específica.
            }
        }

        protected void btnResumen_Click(object sender, EventArgs e)
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
                    Action = 25
                };
                string jsonString = JsonConvert.SerializeObject(objeto);
                var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
                ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
                if (listaObjetos.data != null)
                {
                    DataTable dtb = listaObjetos.data;
                    if (dtb.Rows.Count > 0)
                    {
                        gvCierre.DataSource = dtb;
                        gvCierre.DataBind();

                    }
                    else
                    {
                        MostrarMensaje("Los filtros no arrojaron informacion");
                    }
                }
                else
                {
                    MostrarMensaje("Los filtros no arrojaron informacion");
                    return;
                }


                RequesItemLedgerEntry objetoImp = new RequesItemLedgerEntry
                {
                    Terminal = ddl_Terminal.SelectedValue,
                    Fecha = convertirFecha(ddlYear.SelectedValue, ddlMonth.SelectedValue),
                    Action = 26
                };
                string jsonStringImp = JsonConvert.SerializeObject(objetoImp);
                var mensajeImp = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonStringImp);
                ResponseItemLedgerEntry listaObjetosImp = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensajeImp);
                if (listaObjetosImp.data != null)
                {
                    DataTable dtbImp = listaObjetosImp.data;
                    if (dtbImp.Rows.Count > 0)
                    {
                        gvEnsacado.DataSource = dtbImp;
                        gvEnsacado.DataBind();

                    }
                    else
                    {
                        MostrarMensaje("Los filtros no arrojaron informacion");
                    }
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
                decimal Rango1 = Convert.ToDecimal(e.Row.Cells[0].Text);
                decimal Rango2 = Convert.ToDecimal(e.Row.Cells[1].Text);
                decimal Tarifa1 = Convert.ToDecimal(e.Row.Cells[2].Text);
                decimal Tarifa2 = Convert.ToDecimal(e.Row.Cells[3].Text);
                decimal TotalMatEmpaque = Convert.ToDecimal(e.Row.Cells[4].Text);
                decimal TotalEnsacado = Convert.ToDecimal(e.Row.Cells[5].Text);
                decimal TotalCosto = Convert.ToDecimal(e.Row.Cells[6].Text);

                e.Row.Cells[0].Text = String.Format("{0:#,##0}", Rango1);
                e.Row.Cells[1].Text = String.Format("{0:#,##0}", Rango2);
                e.Row.Cells[2].Text = String.Format("${0:#,##0}", Tarifa1);
                e.Row.Cells[3].Text = String.Format("${0:#,##0}", Tarifa2);
                e.Row.Cells[4].Text = String.Format("{0:#,##0}", TotalMatEmpaque);
                e.Row.Cells[5].Text = String.Format("{0:#,##0}", TotalEnsacado);
                e.Row.Cells[6].Text = String.Format("${0:#,##0}", TotalCosto);

            }
        }

        protected void gvEnsacado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal ValorKilogramo = Convert.ToDecimal(e.Row.Cells[0].Text);
                decimal ValorToneladaContrato = Convert.ToDecimal(e.Row.Cells[1].Text);
                decimal TotalCostoMatEmp = Convert.ToDecimal(e.Row.Cells[2].Text);
                decimal TarifaImpuesto = Convert.ToDecimal(e.Row.Cells[3].Text);
                decimal TotalCostoImpuestoMatEmp = Convert.ToDecimal(e.Row.Cells[4].Text);
              

                e.Row.Cells[0].Text = String.Format("${0:#,##0}", ValorKilogramo);
                e.Row.Cells[1].Text = String.Format("${0:#,##0}", ValorToneladaContrato);
                e.Row.Cells[2].Text = String.Format("${0:#,##0}", TotalCostoMatEmp);
                e.Row.Cells[3].Text = String.Format("${0:#,##0}", TarifaImpuesto);
                e.Row.Cells[4].Text = String.Format("${0:#,##0}", TotalCostoImpuestoMatEmp);
              

            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            string idCierre = Request.QueryString["IdCierre"];
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Financiera/FrmCierreBarrancaDetalle.aspx?usuario={usuario}&IdCierre={idCierre}");
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {

            string idCierre = Request.QueryString["IdCierre"];
            DCL.GFCierreFinancieroDetalle objEmpaque = new DCL.GFCierreFinancieroDetalle();
            objEmpaque.IdConcepto = 1;
            objEmpaque.ValorConcepto = gvCierre.Rows[0].Cells[6].Text.Replace("$","").Replace(".","");
            objEmpaque.IdCierre = Convert.ToInt64(idCierre);
            BRL.GFCierreFinancieroDetalle_BRL.InsertarOrUpdate(objEmpaque,1);

            //MaaterialEmpaque
            DCL.GFCierreFinancieroDetalle objMaterialEmp = new DCL.GFCierreFinancieroDetalle();
            objMaterialEmp.IdConcepto = 2;
            objMaterialEmp.ValorConcepto = gvEnsacado.Rows[0].Cells[2].Text.Replace("$", "").Replace(".", "");
            objMaterialEmp.IdCierre = Convert.ToInt64(idCierre);
            BRL.GFCierreFinancieroDetalle_BRL.InsertarOrUpdate(objMaterialEmp, 1);

            //ImpuestoMaterialEmpaque
            DCL.GFCierreFinancieroDetalle objImpMaterial = new DCL.GFCierreFinancieroDetalle();
            objImpMaterial.IdConcepto = 3;
            objImpMaterial.ValorConcepto = gvEnsacado.Rows[0].Cells[4].Text.Replace("$", "").Replace(".", "");
            objImpMaterial.IdCierre = Convert.ToInt64(idCierre);
            BRL.GFCierreFinancieroDetalle_BRL.InsertarOrUpdate(objImpMaterial, 1);


            
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/Financiera/FrmCierreBarrancaDetalle.aspx?usuario={usuario}&IdCierre={idCierre}");

        }
    }
}