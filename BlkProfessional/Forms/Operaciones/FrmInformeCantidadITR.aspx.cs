using BlkProfessional.Servicios;
using BRL;
using DCL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace BlkProfessional.Forms.Operaciones
{
    public partial class FrmInformeCantidadITR : System.Web.UI.Page
    {
        protected decimal totalIngresos = 0;
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
                //CodigoCliente = txtCliente.Text,
                Action = 3
            };
            string jsonString = JsonConvert.SerializeObject(objeto);
            var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
            ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
            DataTable dtb = listaObjetos.data;
            LlenarDropdowns(dtb, ddl_Terminal, new string[] { "CodigoTerminal", "CodigoTerminal" });
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void txtCliente_TextChanged(object sender, EventArgs e)
        {
            RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
            {
                CodigoCliente = ddlCliente.SelectedValue,
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

            //LlenarDropdowns(dtb, ddlLocation, new string[] { "Location", "Location" });
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
                if (String.IsNullOrEmpty(txtFechaInicio.Text)) {
                    MostrarMensaje("La fecha Inicio no puede ser vacia");
                    return;
                }

                if (String.IsNullOrEmpty(txtFechaFin.Text)) {
                    MostrarMensaje("La fecha Fin no puede ser vacia");
                    return;
                }

                if (ddlCliente.SelectedValue =="-") {
                    MostrarMensaje("el Cliente no puede estar vacio");
                    return;
                }

                if (ddl_Terminal.SelectedValue =="-") {
                    MostrarMensaje("debes seleccionar una terminal");
                    return;
                }

                            
                RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
                {
                    Terminal = ddl_Terminal.SelectedValue,
                    // LocationCode = ddlLocation.SelectedValue,
                    CodigoCliente = ddlCliente.SelectedValue,
                    Fecha = txtFechaInicio.Text + ";" + txtFechaFin.Text,
                    Action = 15
                };
                string jsonString = JsonConvert.SerializeObject(objeto);
                var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
                ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
                if (listaObjetos.data != null) {
                    DataTable dtb = listaObjetos.data;
                    if (dtb.Rows.Count > 0)
                    {

                        string rutarchivo = Server.MapPath("~/InformeLogisticayTransporte.xls");
                        ExportToExcel(dtb, rutarchivo);

                        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                        response.ClearContent();
                        response.Clear();
                        response.ContentType = "application/vnd.xls";
                        response.AddHeader("Content-Disposition", "attachment; filename=" + "InformeLogisticayTransporte" + ".xls" + ";");
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


                        ddl_Terminal.Enabled = false;
                        ddlCliente.Enabled = false;
                        txtFechaInicio.Enabled = false;
                        txtFechaFin.Enabled = false;                       
                    }
                    else
                    {
                        gvLogisticaITR.Visible = false;
                        ddl_Terminal.Enabled = true;
                        ddlCliente.Enabled = true;
                        txtFechaInicio.Enabled = true;
                        txtFechaFin.Enabled = true;
                        btnGenerar.Enabled = true;
                        btnEnvar.Visible = false;
                        MostrarMensaje("Los filtros no arrojaron informacion");
                    }
                }
                else {
                    gvLogisticaITR.Visible = false;
                    ddl_Terminal.Enabled = true;
                    ddlCliente.Enabled = true;
                    txtFechaInicio.Enabled = true;
                    txtFechaFin.Enabled = true;
                    btnGenerar.Enabled = true;
                    btnEnvar.Visible = false;
                    MostrarMensaje("Los filtros no arrojaron informacion");
                }
            }
            catch (Exception ex)
            {
                gvLogisticaITR.Visible = false;
                ddl_Terminal.Enabled = true;
                ddlCliente.Enabled = true;
                txtFechaInicio.Enabled = true;
                txtFechaFin.Enabled = true;
                btnGenerar.Enabled = true;
                btnEnvar.Visible = false;
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

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtFechaInicio.Text))
                {
                    MostrarMensaje("La fecha Inicio no puede ser vacia");
                    return;
                }

                if (String.IsNullOrEmpty(txtFechaFin.Text))
                {
                    MostrarMensaje("La fecha Fin no puede ser vacia");
                    return;
                }

                if (ddlCliente.SelectedValue == "-")
                {
                    MostrarMensaje("el Cliente no puede estar vacio");
                    return;
                }

                if (ddl_Terminal.SelectedValue == "-")
                {
                    MostrarMensaje("debes seleccionar una terminal");
                    return;
                }


                RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
                {
                    Terminal = ddl_Terminal.SelectedValue,
                    // LocationCode = ddlLocation.SelectedValue,
                    CodigoCliente = ddlCliente.SelectedValue,
                    Fecha = txtFechaInicio.Text + ";" + txtFechaFin.Text,
                    Action = 15
                };
                string jsonString = JsonConvert.SerializeObject(objeto);
                var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
                ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
                if (listaObjetos.data != null)
                {
                    DataTable dtb = listaObjetos.data;
                    if (dtb.Rows.Count > 0)
                    {

                        gvLogisticaITR.DataSource = dtb;
                        gvLogisticaITR.DataBind();
                        gvLogisticaITR.Visible = true;
                        ddl_Terminal.Enabled = false;
                        ddlCliente.Enabled = false;
                        txtFechaInicio.Enabled = false;
                        txtFechaFin.Enabled = false;
                        btnGenerar.Enabled = false;
                        btnEnvar.Visible = true;
                    }
                    else
                    {
                        gvLogisticaITR.Visible = false;
                        ddl_Terminal.Enabled = true;
                        ddlCliente.Enabled = true;
                        txtFechaInicio.Enabled = true;
                        txtFechaFin.Enabled = true;
                        btnGenerar.Enabled = true;
                        btnEnvar.Visible = false;
                        MostrarMensaje("Los filtros no arrojaron informacion");
                    }
                }
                else {
                    gvLogisticaITR.Visible = false;
                    ddl_Terminal.Enabled = true;
                    ddlCliente.Enabled = true;
                    txtFechaInicio.Enabled = true;
                    txtFechaFin.Enabled = true;
                    btnGenerar.Enabled = true;
                    btnEnvar.Visible = false;
                    MostrarMensaje("Los filtros no arrojaron informacion");

                }
            }
            catch (Exception ex)
            {
                gvLogisticaITR.Visible = false;
                ddl_Terminal.Enabled = true;
                ddlCliente.Enabled = true;
                txtFechaInicio.Enabled = true;
                txtFechaFin.Enabled = true;
                btnGenerar.Enabled = true;
                btnEnvar.Visible = false;
                MostrarMensaje("Por favor contacte al administrador del sistema :  " + ex.Message.ToString());
            }
        }

        protected void gvLogisticaITR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblTarifa = (Label)e.Row.FindControl("lblTarifa");
                if (!String.IsNullOrEmpty(lblTarifa.Text) && lblTarifa.Text != "&nbsp;")
                {
                    lblTarifa.Text = String.Format("${0:#,##0}", Math.Abs(Convert.ToDecimal(lblTarifa.Text)));
                }

                    Label lblIngresos = (Label)e.Row.FindControl("lbllIngreso");
                if (!String.IsNullOrEmpty(lblIngresos.Text) && lblIngresos.Text != "&nbsp;")
                {
                    string precios = (String.IsNullOrEmpty(lblIngresos.Text)) ? "0" : lblIngresos.Text;
                    decimal precio = Convert.ToDecimal(precios);
                    totalIngresos += precio;
                    lblIngresos.Text = String.Format("${0:#,##0}", Math.Abs(Convert.ToDecimal(lblIngresos.Text)));

                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer) {

                Label lblTotalIngresos = (Label)e.Row.FindControl("lblTotalIngresos");
                lblTotalIngresos.Text = String.Format("${0:#,##0}", Math.Abs(totalIngresos));
            }
        }

        protected void gvLogisticaITR_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
            {
                CodigoCliente = ddlCliente.SelectedValue,
                Terminal = ddl_Terminal.SelectedValue,
                Action = 1
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
                MostrarMensaje("El cliente no tiene el contrato actualizado, por  favor dirigase con SAC");
                return;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ddlCliente.Enabled = true;
            ddl_Terminal.Enabled = true;
            gvLogisticaITR.Visible = false;
            btnDescargar.Enabled = true;
            btnGenerar.Enabled = true;
            txtFechaFin.Enabled = true;
            txtFechaInicio.Enabled = true;
            btnEnvar.Visible = false;
        }

        protected void btnEnvar_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            foreach (GridViewRow row in gvLogisticaITR.Rows)
            {
                Weekly objDescarga = new Weekly();
                objDescarga.Terminal = ddl_Terminal.SelectedValue;
                objDescarga.Clase = "Logistics Operations";
                objDescarga.Year = Convert.ToDateTime(txtFechaInicio.Text).Year.ToString();
                objDescarga.Mes = Convert.ToDateTime(txtFechaFin.Text).Month.ToString();
                objDescarga.Cliente = ddlCliente.SelectedValue;
                objDescarga.DesCliente = txtDescripcionCliente.Text;
                objDescarga.SubCliente = ddlCliente.SelectedValue;
                objDescarga.TipoCuenta = "Ingresos";
                objDescarga.Cuenta = "ITR IMPO";
                objDescarga.Observacion = "Liquidacion Importacion " + row.Cells[1].Text;
                objDescarga.TotalEjecutadoMes = Convert.ToDecimal(((Label)row.Cells[4].FindControl("lbllIngreso")).Text.Replace("$","")).ToString();
                objDescarga.UsuarioCreacion = usuario;
                Weekly_BRL.InsertarOrUpdate(objDescarga, 0);
            }
            ddlCliente.Enabled = true;
            ddl_Terminal.Enabled = true;
            gvLogisticaITR.Visible = false;
            btnDescargar.Enabled = true;
            btnGenerar.Enabled = true;
            txtFechaFin.Enabled = true;
            txtFechaInicio.Enabled = true;
            btnEnvar.Visible = false;
            MostrarMensaje("Guardado con Exito");
        }

        protected void lnkMenu_Click(object sender, EventArgs e)
        {
            string usuario = Request.QueryString["usuario"];
            Response.Redirect($"~/Forms/MainMenu/FrmMenuSAC.aspx?usuario={usuario}");
        }
    }
}