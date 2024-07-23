using BlkProfessional.Servicios;
using BRL;
using DCL;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;


namespace BlkProfessional.Forms.Financiera.CTG
{
    public partial class FrmCierreCTGEnsacado : System.Web.UI.Page
    {
        protected decimal totalPrecio = 0, totalAlmacenamiento = 0, totalSaldo = 0, totalSalidas = 0, totalEntradas = 0, fechaMaxima = 0, tarifaAlmacenamiento = 0;

        protected void Page_Init(object sender, EventArgs e)
        {
            RequesItemLedgerEntry objCliente = new RequesItemLedgerEntry
            {
                Action = 20
            };
            string jsonStringCliente = JsonConvert.SerializeObject(objCliente);
            var mensajeCliente = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonStringCliente);
            ResponseItemLedgerEntry listaObjetosCliente = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensajeCliente);
            DataTable dtbCliente = listaObjetosCliente.data;
            LlenarDropdowns(dtbCliente, ddlCliente, new string[] { "Name", "Codigo" });

            RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
            {
                CodigoCliente = ddlCliente.SelectedValue,
                Action = 3
            };
            string jsonString = JsonConvert.SerializeObject(objeto);
            var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
            ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
            DataTable dtb = listaObjetos.data;
            LlenarDropdowns(dtb, ddl_Terminal, new string[] { "CodigoTerminal", "CodigoTerminal" });

            string idCierreDetalle = Request.QueryString["IdCierreDetalle"];
            DCL.GFCierreFinancieroDetalle objCierre = new DCL.GFCierreFinancieroDetalle();
            objCierre.IdCierreDetalle = Convert.ToInt64(idCierreDetalle);
            DataTable dtbCierre = BRL.GFCierreFinancieroDetalle_BRL.SelectTable(objCierre, 3);
            if (dtbCierre.Rows.Count > 0)
            {

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
                        btnEnvar.Enabled = false;
                    }
                    else
                    {
                        btnEnvar.Enabled = true;
                    }
                }

                ddl_Terminal.SelectedValue = dtbCierre.Rows[0][1].ToString();
                ddl_Terminal_SelectedIndexChanged(null, null);
                ddlLocation.SelectedValue = dtbCierre.Rows[0][2].ToString();
                ddlCliente.SelectedValue = dtbCierre.Rows[0][3].ToString();
                ddlCliente_SelectedIndexChanged(null, null);

            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
            {
                CodigoCliente = ddlCliente.SelectedValue,
                Terminal = ddl_Terminal.SelectedValue,
                Action = 16

            };

            string jsonString = JsonConvert.SerializeObject(objeto);
            var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);

            ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
            if (listaObjetos.data != null)
            {
                DataTable dtb = listaObjetos.data;
                if (dtb.Rows.Count > 0)
                {
                    txtDescripcionCliente.Text = dtb.Rows[0]["Name"].ToString();
                    txtTarifaAlmacenamiento.Text = String.Format("${0:#,##0}", Convert.ToDecimal(dtb.Rows[0]["TarifaAlmacenamiento"].ToString()));
                    tarifaAlmacenamiento = Convert.ToDecimal(dtb.Rows[0]["TarifaAlmacenamiento"].ToString());
                    txtTarifaDescarga.Text = String.Format("${0:#,##0}", Convert.ToDecimal(dtb.Rows[0]["TarifaDescarga"].ToString()));
                    txtTipoLiquidacion.Text = dtb.Rows[0]["TipoLiquidacion"].ToString();
                }
                else
                {
                    MostrarMensaje("El cliente no existe");
                    return;
                }
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

        protected void btnEnvar_Click(object sender, EventArgs e)
        {

            try
            {
                string usuario = Request.QueryString["usuario"];
                string idAlmacenamiento = Request.QueryString["IdAlmacenamiento"];
                string idCierre = Request.QueryString["IdCierre"];

                GFCierreFinancieroDetalle objAct = new GFCierreFinancieroDetalle();
                objAct.IdCierreDetalle = Convert.ToInt32(idAlmacenamiento);
                objAct.ValorConcepto = txtSaldoTotal.Text;
                objAct.Almacen = txtTotalIngresosAlm.Text;
                objAct.CodCliente = txtTotalIngresosDesc.Text;
                GFCierreFinancieroDetalle_BRL.InsertarOrUpdate(objAct,18);

                GFCierreFinancieroDetalle objTotal = new GFCierreFinancieroDetalle();
                objTotal.IdCierre = Convert.ToInt32(idCierre);
                objTotal.Terminal = ddl_Terminal.SelectedValue;
                objTotal.UsuarioActualizacion = usuario;
                GFCierreFinancieroDetalle_BRL.InsertarOrUpdate(objTotal, 11);

                GFCierreFinancieroDetalle objTotDesc = new GFCierreFinancieroDetalle();
                objTotDesc.IdCierre = Convert.ToInt32(idCierre);
                objTotDesc.Terminal = ddl_Terminal.SelectedValue;
                objTotDesc.UsuarioActualizacion = usuario;
                GFCierreFinancieroDetalle_BRL.InsertarOrUpdate(objTotDesc, 12);


                GFCierreFinancieroDetalle objDet = new GFCierreFinancieroDetalle();
                objDet.IdConcepto = Convert.ToInt32(idAlmacenamiento);
                DataTable dtbAlm = GFCierreFinancieroDetalle_BRL.SelectTable(objDet, 17);
                if (dtbAlm.Rows.Count > 0)
                {
                    string idCierreDetalle = dtbAlm.Rows[0]["IdCierreDetalleAlm"].ToString();
                 
                    Response.Redirect($"~/Forms/Financiera/CTG/FrmCierreCTGAEspec.aspx?usuario={usuario}&IdCierreDetalle={idCierreDetalle}&IdCierre={idCierre}&Terminal=CTG");
                }

            }
            catch (Exception ex)
            {

                MostrarMensaje("No se actualizo por favor contactarse con el administrador" + ex.ToString());
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {


            //ddlYear.Enabled = true;
            //ddlMonth.Enabled = true;
            //ddl_Terminal.Enabled = true;
            //ddlLocation.Enabled = true;
            //ddlCliente.Enabled = true;
            GridViewLiquidacion.Visible = false;
            btnEnvar.Visible = false;
            btnDescargar.Enabled = true;
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
            {
                CodigoCliente = ddlCliente.SelectedValue,
                Terminal = ddl_Terminal.SelectedValue,
                Action = 16

            };

            string jsonString = JsonConvert.SerializeObject(objeto);
            var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);

            ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
            if (listaObjetos.data != null)
            {
                DataTable dtb = listaObjetos.data;
                if (dtb.Rows.Count > 0)
                {
                    txtDescripcionCliente.Text = dtb.Rows[0]["Name"].ToString();
                    txtTarifaAlmacenamiento.Text = String.Format("${0:#,##0}", Convert.ToDecimal(dtb.Rows[0]["TarifaAlmacenamiento"].ToString()));
                    tarifaAlmacenamiento = Convert.ToDecimal(dtb.Rows[0]["TarifaAlmacenamiento"].ToString());
                    txtTarifaDescarga.Text = String.Format("${0:#,##0}", Convert.ToDecimal(dtb.Rows[0]["TarifaDescarga"].ToString()));
                    txtTipoLiquidacion.Text = dtb.Rows[0]["TipoLiquidacion"].ToString();
                }
                else
                {
                    MostrarMensaje("El cliente no existe");
                    return;
                }
            }
            else
            {
                txtDescripcionCliente.Text = "";
                txtTarifaDescarga.Text = "";
                txtTipoLiquidacion.Text = "";
                txtTarifaAlmacenamiento.Text = "";
                MostrarMensaje("El cliente no tiene el contrato actualizado, por  favor dirigase con SAC");
                return;
            }
        }

        protected void lnkMenu_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/MainMenu/FrmMenuFinanciera.aspx?usuario={usuario}");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

            string idAlmacenamiento = Request.QueryString["IdAlmacenamiento"];
            string usuario = Request.QueryString["usuario"];

            GFCierreFinancieroDetalle objDet = new GFCierreFinancieroDetalle();
            objDet.IdConcepto = Convert.ToInt32(idAlmacenamiento);
            DataTable dtbAlm = GFCierreFinancieroDetalle_BRL.SelectTable(objDet, 17);
            if (dtbAlm.Rows.Count > 0)
            {
                string idCierreDetalle = dtbAlm.Rows[0]["IdCierreDetalleAlm"].ToString();
                string idCierre = dtbAlm.Rows[0]["IdCierre"].ToString();
                Response.Redirect($"~/Forms/Financiera/CTG/FrmCierreCTGAEspec.aspx?usuario={usuario}&IdCierreDetalle={idCierreDetalle}&IdCierre={idCierre}&Terminal=CTG");
            }

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
                    MostrarMensaje("Debe seleccionar un año");
                    return;
                }
                if (ddlMonth.SelectedValue == "0")
                {
                    MostrarMensaje("Debe seleccionar un mes");
                    return;
                }

                if (ddl_Terminal.SelectedValue == "-")
                {
                    MostrarMensaje("Debe seleccionar una terminal");
                    return;
                }

                if (ddlLocation.SelectedValue == "-")
                {
                    MostrarMensaje("Debe seleccionar una bodega");
                    return;
                }

                if (String.IsNullOrEmpty(ddlCliente.SelectedValue))
                {
                    MostrarMensaje("El CLiente no puede estar vacio");
                    return;
                }
                string producto = "";


                int action = 28;

                
                string idAlmacenamiento = Request.QueryString["IdAlmacenamiento"];
                GFCierreFinancieroDetalle objFin = new GFCierreFinancieroDetalle();
                objFin.IdConcepto = Convert.ToInt32(idAlmacenamiento);
                DataTable dtbFin =GFCierreFinancieroDetalle_BRL.SelectTable(objFin,17);
                
                if (dtbFin.Rows.Count > 0) {
                    producto = dtbFin.Rows[0]["Llave"].ToString();
                    if (producto =="ENSACADO") {
                        if (dtbFin.Rows[0]["TipoLiquidacion"].ToString() !="2") {
                            action = 13;
                        }
                    }
                }

                RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
                {
                    SourceNo = producto,
                    Terminal = ddl_Terminal.SelectedValue,
                    LocationCode = ddlLocation.SelectedValue,
                    CodigoCliente = ddlCliente.SelectedValue,
                    Fecha = convertirFecha(ddlYear.SelectedValue, ddlMonth.SelectedValue),
                    Action = action
                };
                string jsonString = JsonConvert.SerializeObject(objeto);
                var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
                ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
                if (listaObjetos.data != null)
                {
                    DataTable dtb = listaObjetos.data;
                    if (dtb.Rows.Count > 0)
                    {

                        GridViewLiquidacion.DataSource = dtb;
                        GridViewLiquidacion.DataBind();
                        GridViewLiquidacion.Visible = true;
                        //string rutarchivo = Server.MapPath("~/InformeLiquidacion.xls");
                        //ExportToExcel(dtb, rutarchivo);

                        //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                        //response.ClearContent();
                        //response.Clear();
                        //response.ContentType = "application/vnd.xls";
                        //response.AddHeader("Content-Disposition", "attachment; filename=" + "InformeLiquidacion" + ".xls" + ";");
                        //response.TransmitFile(rutarchivo);
                        //response.Flush();

                        //if (System.IO.File.Exists(rutarchivo))
                        //{
                        //    try
                        //    {
                        //        System.IO.File.Delete(rutarchivo);
                        //    }
                        //    catch (System.IO.IOException ex)
                        //    {
                        //        Console.WriteLine(ex.Message);
                        //        return;
                        //    }
                        //}
                        //response.End();



                        ddlYear.Enabled = false;
                        ddlMonth.Enabled = false;
                        ddlCliente.Enabled = false;
                        ddl_Terminal.Enabled = false;
                        ddlLocation.Enabled = false;
                        btnDescargar.Enabled = false;
                        btnEnvar.Visible = true;
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

        protected void GridViewLiquidacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    // Asegúrate de que el índice de la columna "Cantidad" es correcto según tu definición de columnas en el GridView.
            //    int cantidadIndex = 2; // Ajusta esto según tu estructura.

            //    // Formatea el valor en la columna "Cantidad" con separadores de miles.
            //    if (e.Row.Cells[cantidadIndex].Text != "&nbsp;")
            //    {
            //        decimal cantidad = Convert.ToDecimal(e.Row.Cells[cantidadIndex].Text);
            //        e.Row.Cells[cantidadIndex].Text = String.Format("{0:N0}", cantidad);
            //    }
            //}

        }

        protected void GridViewLiquidacion_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridViewLiquidacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Asegúrate de que el índice de la columna "Cantidad" es correcto según tu definición de columnas en el GridView.
                int fecha = 1;
                int saldoInicial = 2;
                int entradas = 3;
                int salidas = 4;
                //int saldo = 5;
                int valorUnitario = 6;
                int valorAlmacenamiento = 7;
                int tarifaDescarga = 8;
                int descarga = 9;

                // Formatea el valor en la columna "Cantidad" con separadores de miles.
                if (e.Row.Cells[fecha].Text != "&nbsp;")
                {
                    fechaMaxima = Convert.ToDateTime(e.Row.Cells[fecha].Text).Day;
                    string Fecha = Convert.ToDateTime(e.Row.Cells[fecha].Text).ToShortDateString();
                    decimal SaldoInicial = Convert.ToDecimal(e.Row.Cells[saldoInicial].Text);
                    //decimal Entradas = Convert.ToDecimal(e.Row.Cells[entradas].Text); 
                    //decimal Salidas = Convert.ToDecimal(e.Row.Cells[salidas].Text);
                    // decimal Saldo = Convert.ToDecimal(e.Row.Cells[saldo].Text);
                    //decimal ValorUnitario = Convert.ToDecimal(e.Row.Cells[valorUnitario].Text);
                    //  decimal ValorAlmacenamiento = Convert.ToDecimal(e.Row.Cells[valorAlmacenamiento].Text);
                    //  decimal TarifaDescarga = Convert.ToDecimal(e.Row.Cells[tarifaDescarga].Text);
                    decimal Descarga = Convert.ToDecimal(String.IsNullOrEmpty(e.Row.Cells[8].Text) ? "0" : e.Row.Cells[8].Text);
                    e.Row.Cells[fecha].Text = String.Format("{0:dd/MM/yyyy}", Fecha);
                    e.Row.Cells[saldoInicial].Text = String.Format("{0:N0}", SaldoInicial);
                    //e.Row.Cells[entradas].Text = String.Format("{0:N0}", Entradas);
                    //e.Row.Cells[salidas].Text = String.Format("{0:N0}", Salidas);
                    //   e.Row.Cells[saldo].Text = String.Format("{0:N0}", Saldo);
                    //e.Row.Cells[valorUnitario].Text = String.Format("${0:#,##0}", ValorUnitario);
                    //e.Row.Cells[valorAlmacenamiento].Text = String.Format("${0:#,##0}", ValorAlmacenamiento);
                    //e.Row.Cells[tarifaDescarga].Text = String.Format("{0:N0}", TarifaDescarga);

                }


                Label lblEntradas = (Label)e.Row.FindControl("lblEntradas");
                if (!String.IsNullOrEmpty(lblEntradas.Text) && lblEntradas.Text != "&nbsp;")
                {
                    string precios = (String.IsNullOrEmpty(lblEntradas.Text)) ? "0" : lblEntradas.Text;
                    decimal precio = Convert.ToDecimal(precios);
                    totalEntradas += precio;
                    lblEntradas.Text = String.Format("{0:N0}", Math.Abs(Convert.ToDecimal(lblEntradas.Text)));
                }

                Label lblSalidas = (Label)e.Row.FindControl("lblSalidas");
                if (!String.IsNullOrEmpty(lblSalidas.Text) && lblSalidas.Text != "&nbsp;")
                {
                    string precios = (String.IsNullOrEmpty(lblSalidas.Text)) ? "0" : lblSalidas.Text;
                    decimal precio = Convert.ToDecimal(precios);
                    totalSalidas += precio;
                    lblSalidas.Text = String.Format("{0:N0}", Math.Abs(Convert.ToDecimal(lblSalidas.Text)));
                }

                Label lblSaldo = (Label)e.Row.FindControl("lblSaldo");
                if (!String.IsNullOrEmpty(lblSaldo.Text) && lblSaldo.Text != "&nbsp;")
                {
                    string precios = (String.IsNullOrEmpty(lblSaldo.Text)) ? "0" : lblSaldo.Text;
                    decimal precio = Convert.ToDecimal(precios);
                    totalSaldo += precio;
                    lblSaldo.Text = String.Format("{0:N0}", Math.Abs(Convert.ToDecimal(lblSaldo.Text)));
                    txtSaldoTotal.Text = precio.ToString();
                }


                Label lblValorAlmacenamiento = (Label)e.Row.FindControl("lblValorAlmacenamiento");
                if (!String.IsNullOrEmpty(lblValorAlmacenamiento.Text) && lblValorAlmacenamiento.Text != "&nbsp;")
                {
                    string precios = (String.IsNullOrEmpty(lblValorAlmacenamiento.Text)) ? "0" : lblValorAlmacenamiento.Text;
                    decimal precio = Convert.ToDecimal(precios);
                    totalAlmacenamiento += precio;
                    lblValorAlmacenamiento.Text = String.Format("${0:#,##0}", Math.Abs(Convert.ToDecimal(lblValorAlmacenamiento.Text)));
                }



                Label lblValorDescarga = (Label)e.Row.FindControl("lblValorDescarga");
                if (!String.IsNullOrEmpty(lblValorDescarga.Text) && lblValorDescarga.Text != "&nbsp;")
                {
                    string precios = (String.IsNullOrEmpty(lblValorDescarga.Text)) ? "0" : lblValorDescarga.Text;
                    decimal precio = Convert.ToDecimal(precios);
                    totalPrecio += precio;
                    lblValorDescarga.Text = String.Format("${0:#,##0}", Math.Abs(Convert.ToDecimal(lblValorDescarga.Text)));
                }

                if (txtTipoLiquidacion.Text == "Diario")
                {
                    lblValorDescarga.Visible = true;
                    lblValorAlmacenamiento.Visible = true;
                }
                else
                {
                    lblValorDescarga.Visible = true;
                    lblValorAlmacenamiento.Visible = false;
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

                Label lblTotalDescarga = (Label)e.Row.FindControl("lblTotalDescarga");
                lblTotalDescarga.Text = String.Format("${0:#,##0}", Math.Abs(totalPrecio));
                txtTotalIngresosDesc.Text = totalPrecio.ToString();


                Label lblTotalSaldo = (Label)e.Row.FindControl("lblTotalSaldo");


                Label lblTotalSalidas = (Label)e.Row.FindControl("lblTotalSalidas");
                lblTotalSalidas.Text = String.Format("{0:N0}", Math.Abs(totalSalidas));

                Label lblTotalEntradas = (Label)e.Row.FindControl("lblTotalEntradas");
                lblTotalEntradas.Text = String.Format("{0:N0}", Math.Abs(totalEntradas));

                Label lblTotalAlmacenamiento = (Label)e.Row.FindControl("lblTotalAlmacenamiento");

                if (txtTipoLiquidacion.Text == "Promedio")
                {
                    tarifaAlmacenamiento = Convert.ToDecimal(txtTarifaAlmacenamiento.Text.Replace("$", ""));

                    decimal promedio = (Math.Abs(totalSaldo) / fechaMaxima) / 1000;
                    lblTotalAlmacenamiento.Text = String.Format("${0:#,##0}", promedio * tarifaAlmacenamiento);
                    lblTotalSaldo.Text = String.Format("{0:N3}", promedio);
                    // lblTotalDescarga.Text = String.Format("${0:#,##0}", lblTotalDescarga.Text);
                    txtTotalIngresosAlm.Text = Convert.ToDecimal(lblTotalAlmacenamiento.Text.Replace("$", "")).ToString();
                }
                else
                {
                    lblTotalAlmacenamiento.Text = String.Format("${0:#,##0}", Math.Abs(totalAlmacenamiento));
                    txtTotalIngresosAlm.Text = Convert.ToDecimal(lblTotalAlmacenamiento.Text.Replace("$", "")).ToString();
                    lblTotalSaldo.Text = String.Format("{0:N0}", Math.Abs(totalSaldo));
                }

            }

        }
    }
}