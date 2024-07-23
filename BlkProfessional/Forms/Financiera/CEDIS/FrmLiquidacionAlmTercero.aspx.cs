using BlkProfessional.Servicios;
using BRL;
using DCL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;


namespace BlkProfessional.Forms.Financiera.CEDIS
{
    public partial class FrmLiquidacionAlmTercero : System.Web.UI.Page
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
                string idCierreDetalle = Request.QueryString["IdCierreDetalle"];


                DCL.GFCierreFinancieroDetalle objSumatoria = new DCL.GFCierreFinancieroDetalle();
                objSumatoria.IdCierreDetalle = Convert.ToInt64(idCierreDetalle);
                DataTable dtb = GFCierreFinancieroDetalle_BRL.SelectTable(objSumatoria, 9);
                if (dtb.Rows.Count > 0)
                {

                    //Se actualiza Almacenamiento
                    DCL.GFCierreFinancieroDetalle objAlm = new DCL.GFCierreFinancieroDetalle();
                    objAlm.Terminal = dtb.Rows[0]["Terminal"].ToString();
                    objAlm.Almacen = dtb.Rows[0]["Almacen"].ToString();
                    objAlm.IdCierre = Convert.ToInt32(dtb.Rows[0]["IdCierre"].ToString());//Descarga
                    objAlm.IdConcepto = 11;//concepto de almacenamiento
                    objAlm.ValorConcepto = txtTotalIngresosAlm.Text;
                    objAlm.UsuarioActualizacion = usuario;
                    objAlm.CodCliente = dtb.Rows[0]["CodCliente"].ToString();
                    GFCierreFinancieroDetalle_BRL.InsertarOrUpdate(objAlm, 10);

                    //Se actualiza la descarga
                    DCL.GFCierreFinancieroDetalle objDesc = new DCL.GFCierreFinancieroDetalle();
                    objDesc.Terminal = dtb.Rows[0]["Terminal"].ToString();
                    objDesc.Almacen = dtb.Rows[0]["Almacen"].ToString();
                    objDesc.IdCierre = Convert.ToInt32(dtb.Rows[0]["IdCierre"].ToString());//Descarga
                    objDesc.ValorConcepto = txtTotalIngresosDesc.Text;
                    objDesc.IdConcepto = 12;//concepto de Descarga
                    objDesc.UsuarioActualizacion = usuario;
                    objDesc.CodCliente = dtb.Rows[0]["CodCliente"].ToString();
                    GFCierreFinancieroDetalle_BRL.InsertarOrUpdate(objDesc, 13);

                    //se actualiza totalizado de almacenamiento
                    DCL.GFCierreFinancieroDetalle objAlmT = new DCL.GFCierreFinancieroDetalle();
                    objAlmT.Terminal = dtb.Rows[0]["Terminal"].ToString();
                    objAlmT.IdCierre = Convert.ToInt32(dtb.Rows[0]["IdCierre"].ToString());//Descarga
                    objAlmT.UsuarioActualizacion = usuario;
                    objAlmT.CodCliente = dtb.Rows[0]["CodCliente"].ToString();
                    GFCierreFinancieroDetalle_BRL.InsertarOrUpdate(objAlmT, 11);

                    //se actualiza totalizado de Descargue
                    DCL.GFCierreFinancieroDetalle objDescT = new DCL.GFCierreFinancieroDetalle();
                    objDescT.Terminal = dtb.Rows[0]["Terminal"].ToString();
                    objDescT.IdCierre = Convert.ToInt32(dtb.Rows[0]["IdCierre"].ToString());//Descarga
                    objDescT.UsuarioActualizacion = usuario;
                    objDescT.CodCliente = dtb.Rows[0]["CodCliente"].ToString();
                    GFCierreFinancieroDetalle_BRL.InsertarOrUpdate(objDescT, 12);


                    string idcierre = dtb.Rows[0][1].ToString();
                    string Terminal = dtb.Rows[0]["Terminal"].ToString();
                    if (rdbGenerarLiq.SelectedValue == "Si") {
                        if (rdbTipoDocumento.SelectedValue == "Pdf")
                        {
                            generarPdf();
                        }
                        else
                        {
                            GenerarExcel();
                        }
                    }
                    else {
                        Response.Redirect($"FrmCierreCediAlm.aspx?usuario={usuario}&IdCierre={idcierre}&Terminal={Terminal}");
                    }
                   

                    MostrarMensaje("Guardado con Exito");
                }
                else
                {
                    MostrarMensaje("No se actualizo con exito");
                }
            }
            catch (Exception ex)
            {

                MostrarMensaje("No se actualizo por favor contactarse con el administrador" + ex.ToString());
            }
        }

        private string convertirFechaMexio(string year, string mes)
        {

            string fecha = "";
            int dia = DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(mes));
            fecha = mes + "/" + dia.ToString() + "/" + year;
            return fecha;
        }


        public void generarPdf()
        {

            string fecha = convertirFechaMexio(ddlYear.SelectedValue, ddlMonth.SelectedValue);
            Int64 Total = 0;

            DCL.Weekly obj = new DCL.Weekly();
            obj.FechaInicio = fecha;
            obj.Cliente = ddlCliente.SelectedValue;
            obj.Terminal = ddl_Terminal.SelectedValue;
            DataTable dtb = Weekly_BRL.SelectTable(obj, 4);
            if (dtb.Rows.Count > 0)
            {
                try
                {
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    int year = Convert.ToInt32(ddlYear.SelectedValue);
                    int mes = Convert.ToInt32(ddlMonth.SelectedValue);

                    // DateTime FechaFin = new DateTime(year, mes, DateTime.DaysInMonth(year, mes));
                    // Obtener la ruta física de la carpeta "PDFs" dentro del proyecto
                    string relativeFolderPath = Server.MapPath("~/Plantillas/");
                    string relativeImagen = Server.MapPath("~/Img/logo.png");

                    string relativeFilePath = Path.Combine(relativeFolderPath, "Liquidacion_"+ddlCliente.SelectedValue + timestamp + ".pdf");

                    // Crear la carpeta si no existe
                    if (!Directory.Exists(relativeFolderPath))
                    {
                        Directory.CreateDirectory(relativeFolderPath);
                    }

                    // Crear un nuevo archivo PDF usando el nombre de archivo único y la ruta relativa


                    // Creamos el documento con el tamaño de página tradicional
                    Document doc = new Document(PageSize.LETTER);
                    // Indicamos donde vamos a guardar el documento
                    //PdfWriter writer = PdfWriter.GetInstance(doc,
                    //                            new FileStream(@"C:\Users\JeissonFranciscoMont\Documents\PDF\PRuebassdsd"+DateTime.Now.Second.ToString()+".pdf", FileMode.Create));

                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(relativeFilePath, FileMode.Create));

                    // Le colocamos el título y el autor
                    // **Nota: Esto no será visible en el documento
                    doc.AddTitle("Liquidacion");
                    doc.AddCreator("Jeison Montaño");

                    // Abrimos el archivo
                    doc.Open();
                    doc.NewPage();//Pagina 1
                    iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(relativeImagen);
                    //   iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(@"C:\Users\JeissonFranciscoMont\source\repos\BlkProfessional\BlkProfessional\Img\logo.png");
                    //image1.ScalePercent(50f);
                    // image1.ScaleAbsoluteWidth(170);
                    //image1.ScaleAbsoluteHeight(70);

                    // Creamos el tipo de Font que vamos utilizar
                    iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    iTextSharp.text.Font _standardFontEncabezado = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    iTextSharp.text.Font _standardFontEncTabla = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);

                    PdfPTable tblEncabezado = new PdfPTable(2);
                    tblEncabezado.WidthPercentage = 100;

                    PdfPCell Enc1 = new PdfPCell(image1);
                    Enc1.Border = 0;
                    PdfPTable tblSubEncabezado = new PdfPTable(1);
                    tblSubEncabezado.WidthPercentage = 100;
                    PdfPCell SubEnc1 = new PdfPCell(new Phrase("INFORME DE LIQUIDACION", _standardFontEncabezado));
                    SubEnc1.BorderWidth = 0;
                    PdfPCell SubEnc2 = new PdfPCell(new Phrase("Periodo : 01/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue + " al "+ convertirFecha(ddlYear.SelectedValue, ddlMonth.SelectedValue), _standardFont));
                    SubEnc2.BorderWidth = 0;
                    PdfPCell SubEncPedido = new PdfPCell(new Phrase("No Pedido : " + "00001", _standardFont));
                    SubEncPedido.BorderWidth = 0;

                    tblSubEncabezado.AddCell(SubEnc1);
                    tblSubEncabezado.AddCell(SubEnc2);
                    tblSubEncabezado.AddCell(SubEncPedido);

                    PdfPCell Enc2 = new PdfPCell(tblSubEncabezado);
                    Enc2.BorderWidth = 0;
                    Enc2.PaddingTop = 25f;

                    tblEncabezado.AddCell(Enc2);
                    tblEncabezado.AddCell(Enc1);
                    doc.Add(tblEncabezado);
                    doc.Add(Chunk.NEWLINE);

                    PdfPTable tblLinea = new PdfPTable(1);
                    tblLinea.WidthPercentage = 100;

                    PdfPCell Linea1 = new PdfPCell();
                    Linea1.BorderWidth = 0;
                    Linea1.PaddingTop = 10f;
                    Linea1.BorderWidthBottom = 0.25f;

                    tblLinea.AddCell(Linea1);
                    doc.Add(tblLinea);

                    doc.Add(Chunk.NEWLINE);
                    // Escribimos el encabezamiento en el documento

                    PdfPTable tblDatos = new PdfPTable(1);
                    tblDatos.WidthPercentage = 100;


                    PdfPCell CLiente = new PdfPCell(new Phrase("Cliente :     " + dtb.Rows[0]["Cliente"].ToString(), _standardFont));
                    CLiente.BorderWidth = 0;
                    CLiente.PaddingTop = 10f;
                    CLiente.Left = 0;
                    CLiente.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    PdfPCell Nit = new PdfPCell(new Phrase("Nit o CC:    102239723 ", _standardFont));
                    Nit.BorderWidth = 0;
                    Nit.PaddingTop = 2f;
                    Nit.Left = 0;
                    Nit.HorizontalAlignment = PdfPCell.ALIGN_LEFT;


                    PdfPCell Direccion = new PdfPCell(new Phrase("Direccion : " +txtDireccion.Text, _standardFont));
                    Direccion.BorderWidth = 0;
                    Direccion.PaddingTop = 2f;
                    Direccion.Left = 0;
                    Direccion.HorizontalAlignment = PdfPCell.ALIGN_LEFT;


                    PdfPCell Ciudad = new PdfPCell(new Phrase("Ciudad :     "+txtCiudad.Text, _standardFont));
                    Ciudad.BorderWidth = 0;
                    Ciudad.PaddingTop = 2f;
                    Ciudad.Left = 0;
                    Ciudad.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    PdfPCell Telefono = new PdfPCell(new Phrase("Telefono :   "+txtTelefono.Text, _standardFont));
                    Telefono.BorderWidth = 0;
                    Telefono.PaddingTop = 2f;
                    Telefono.Left = 0;
                    Telefono.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    PdfPCell Espacio = new PdfPCell(new Phrase("Terminal :   " + dtb.Rows[0]["Terminal"].ToString(), _standardFont));
                    Espacio.BorderWidth = 0;
                    Espacio.PaddingTop = 2f;
                    Espacio.Left = 0;
                    Espacio.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    tblDatos.AddCell(CLiente);
                    //tblDatos.AddCell(Nit);
                    tblDatos.AddCell(Direccion);
                    tblDatos.AddCell(Ciudad);
                    tblDatos.AddCell(Telefono);
                    tblDatos.AddCell(Espacio);
                    doc.Add(tblDatos);
                    doc.Add(new Paragraph(" "));

                    PdfPTable tblLinea2 = new PdfPTable(1);
                    tblLinea2.WidthPercentage = 100;

                    PdfPCell Linea2 = new PdfPCell(new Phrase("", _standardFont));
                    Linea2.BorderWidth = 0;
                    Linea2.BorderWidthBottom = 0.25f;

                    PdfPCell Espacio2 = new PdfPCell(new Phrase("", _standardFont));
                    Espacio2.BorderWidth = 0;
                    Espacio2.BorderWidthBottom = 0;


                    tblLinea2.AddCell(Linea2);
                    tblLinea2.AddCell(Espacio2);
                    doc.Add(tblLinea2);
                    doc.Add(Chunk.SPACETABBING);




                    // Creamos una tabla que contendrá el nombre, apellido y país
                    // de nuestros visitante.
                    PdfPTable tblPrueba = new PdfPTable(4);
                    tblPrueba.WidthPercentage = 100;
                    tblPrueba.PaddingTop = 20f;


                    // Configuramos el título de las columnas de la tabla
                    PdfPCell clItem = new PdfPCell(new Phrase("Item", _standardFontEncTabla));
                    clItem.BorderWidth = 0.5f;
                    clItem.BackgroundColor = new BaseColor(250, 98, 21);
                    clItem.PaddingTop = 7f;
                    clItem.PaddingBottom = 4f;
                    clItem.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clItem.VerticalAlignment = PdfPCell.ALIGN_CENTER;


                    PdfPCell clCECO = new PdfPCell(new Phrase("CECO", _standardFontEncTabla));
                    clCECO.BorderWidth = 0.5f;
                    clCECO.BackgroundColor = new BaseColor(250, 98, 21);
                    clCECO.BorderWidthLeft = 0;
                    clCECO.PaddingBottom = 4f;
                    clCECO.PaddingTop = 7f;
                    clCECO.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clCECO.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell clDescripcion = new PdfPCell(new Phrase("Descripcion", _standardFontEncTabla));
                    clDescripcion.BorderWidth = 0.5f;
                    clDescripcion.BorderWidthLeft = 0;
                    clDescripcion.BorderWidthRight = 0;
                    clDescripcion.BackgroundColor = new BaseColor(250, 98, 21);
                    clDescripcion.PaddingBottom = 4f;
                    clDescripcion.PaddingTop = 7f;
                    clDescripcion.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clDescripcion.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell clTotal = new PdfPCell(new Phrase("Total", _standardFontEncTabla));
                    clTotal.BorderWidth = 0.5f;
                    clTotal.BackgroundColor = new BaseColor(250, 98, 21);
                    clTotal.PaddingBottom = 4f;
                    clTotal.PaddingTop = 7f;
                    clTotal.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clTotal.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    // Añadimos las celdas a la tabla
                    tblPrueba.AddCell(clItem);
                    tblPrueba.AddCell(clCECO);
                    tblPrueba.AddCell(clDescripcion);
                    tblPrueba.AddCell(clTotal);
                    doc.Add(new Paragraph(" "));



                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        // Llenamos la tabla con información
                        clItem = new PdfPCell(new Phrase((i + 1).ToString(), _standardFont));
                        clItem.BorderWidth = 0.5f;
                        clItem.PaddingTop = 7f;
                        clItem.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clItem.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        clCECO = new PdfPCell(new Phrase(dtb.Rows[i]["CentrodeCosto"].ToString(), _standardFont));
                        clCECO.BorderWidth = 0.5f;
                        clCECO.PaddingTop = 7f;
                        clCECO.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clCECO.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        clDescripcion = new PdfPCell(new Phrase(dtb.Rows[i]["Concepto"].ToString(), _standardFont));
                        clDescripcion.BorderWidth = 0.5f;
                        clDescripcion.PaddingTop = 7f;
                        clDescripcion.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clDescripcion.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        decimal valorIngreso = Convert.ToDecimal(dtb.Rows[i]["ValorIngreso"].ToString().Replace(",", ""));
                        string valorIngresoFormateado = "$ " + valorIngreso.ToString("#,##0");

                        clTotal = new PdfPCell(new Phrase(valorIngresoFormateado, _standardFont));
                        clTotal.BorderWidth = 0.5f;
                        clTotal.PaddingTop = 7f;
                        clTotal.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clTotal.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        Total += Convert.ToInt64(dtb.Rows[i]["ValorIngreso"].ToString().Replace(",", ""));

                        // Añadimos las celdas a la tabla
                        tblPrueba.AddCell(clItem);
                        tblPrueba.AddCell(clCECO);
                        tblPrueba.AddCell(clDescripcion);
                        tblPrueba.AddCell(clTotal);
                    }

                    clItem = new PdfPCell(new Phrase("", _standardFont));
                    clItem.BorderWidth = 0.5f;
                    clItem.PaddingTop = 7f;
                    clItem.Colspan = 2;



                    clDescripcion = new PdfPCell(new Phrase("SubTotal", _standardFont));
                    clDescripcion.BorderWidth = 0.5f;
                    clDescripcion.PaddingTop = 7f;
                    clDescripcion.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clDescripcion.VerticalAlignment = PdfPCell.ALIGN_CENTER;


                    clTotal = new PdfPCell(new Phrase("$ " + Total.ToString("#,##0"), _standardFont));
                    clTotal.BorderWidth = 0.5f;
                    clTotal.PaddingTop = 7f;
                    clTotal.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clTotal.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    // Añadimos las celdas a la tabla
                    tblPrueba.AddCell(clItem);
                    tblPrueba.AddCell(clDescripcion);
                    tblPrueba.AddCell(clTotal);

                    doc.Add(tblPrueba);
                    for (int j = 0; j <= 20 - dtb.Rows.Count; j++)
                    {
                        doc.Add(new Paragraph(" "));
                    }

                    PdfPTable tblLineaBlk = new PdfPTable(1);
                    tblLineaBlk.WidthPercentage = 100;

                    PdfPCell LineaBlk = new PdfPCell();
                    LineaBlk.BorderWidth = 0.5f;
                    // LineaBlk.PaddingTop = 10f;
                    //LineaBlk.BorderWidthBottom = 0.25f;

                    tblLineaBlk.AddCell(LineaBlk);
                    //doc.Add(tblLineaBlk);


                    // Escribimos el encabezamiento en el documento

                    PdfPTable tblDatosBlk = new PdfPTable(1);
                    tblDatosBlk.WidthPercentage = 100;


                    PdfPCell CLienteBlk = new PdfPCell(new Phrase("BULKMATIC DE COLOMBIA SAS", _standardFontEncabezado));
                    CLienteBlk.BorderWidth = 0;
                    CLienteBlk.PaddingTop = 2f;
                    CLienteBlk.Left = 0;
                    CLienteBlk.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    PdfPCell NitBlk = new PdfPCell(new Phrase("Nit 900.970.439-5", _standardFont));
                    NitBlk.BorderWidth = 0;
                    NitBlk.PaddingTop = 2f;
                    NitBlk.Left = 0;
                    NitBlk.HorizontalAlignment = PdfPCell.ALIGN_LEFT;


                    PdfPCell DireccionBlk = new PdfPCell(new Phrase("AV 19 # 95 - 20 T SIGMA OF 1001", _standardFont));
                    DireccionBlk.BorderWidth = 0;
                    DireccionBlk.PaddingTop = 2f;
                    DireccionBlk.Left = 0;
                    DireccionBlk.HorizontalAlignment = PdfPCell.ALIGN_LEFT;


                    PdfPCell CiudadBlk = new PdfPCell(new Phrase("Bogota, Bogota DC ", _standardFont));
                    CiudadBlk.BorderWidth = 0;
                    CiudadBlk.PaddingTop = 2f;
                    CiudadBlk.Left = 0;
                    CiudadBlk.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    PdfPCell TelefonoBlk = new PdfPCell(new Phrase("Telefono 3172224756", _standardFont));
                    TelefonoBlk.BorderWidth = 0;
                    TelefonoBlk.PaddingTop = 2f;
                    TelefonoBlk.Left = 0;
                    TelefonoBlk.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    PdfPCell EspacioBlk = new PdfPCell(new Phrase(" ", _standardFont));
                    EspacioBlk.BorderWidth = 0;
                    EspacioBlk.PaddingTop = 2f;
                    EspacioBlk.Left = 0;
                    EspacioBlk.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    tblDatosBlk.AddCell(CLienteBlk);
                    tblDatosBlk.AddCell(NitBlk);
                    tblDatosBlk.AddCell(DireccionBlk);
                    tblDatosBlk.AddCell(CiudadBlk);
                    tblDatosBlk.AddCell(TelefonoBlk);
                    tblDatosBlk.AddCell(EspacioBlk);
                    //doc.Add(new Paragraph(" "));

                    string qrText = "https://bulkmatic.com.co/";
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);

                    // Convertir el Bitmap a byte array
                    byte[] qrCodeBytes;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        qrCodeImage.Save(ms, ImageFormat.Png);
                        qrCodeBytes = ms.ToArray();
                    }

                    // Crear una imagen iTextSharp a partir del byte array
                    iTextSharp.text.Image qrImage = iTextSharp.text.Image.GetInstance(qrCodeBytes);
                    qrImage.ScaleAbsolute(90, 90); // Escalar la imagen al tamaño deseado



                    PdfPTable footer = new PdfPTable(2);
                    footer.WidthPercentage = 100;
                    PdfPCell fot1 = new PdfPCell(qrImage);
                    fot1.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    fot1.BorderWidth = 0;
                    fot1.BorderWidthTop = 0.5f;
                    fot1.Padding = 5f;
                    PdfPCell fot2 = new PdfPCell(tblDatosBlk);
                    fot2.BorderWidth = 0;
                    fot2.BorderWidthTop = 0.5f;
                    fot2.PaddingTop = 8f;
                    footer.AddCell(fot2);
                    footer.AddCell(fot1);
                    // Añadir la imagen QR al documento

                    doc.Add(footer);


                    doc.NewPage();

                    PdfPTable tblEncabezadoCPA = new PdfPTable(2);
                    tblEncabezadoCPA.WidthPercentage = 100;

                    PdfPCell Enc1CPA = new PdfPCell(image1);
                    Enc1CPA.Border = 0;
                    PdfPTable tblSubEncabezadoCPA = new PdfPTable(1);
                    tblSubEncabezadoCPA.WidthPercentage = 100;
                    PdfPCell SubEnc1CPA = new PdfPCell(new Phrase("LIQUIDACION DE ALMTO & C/D", _standardFontEncabezado));
                    SubEnc1CPA.BorderWidth = 0;
                    PdfPCell SubEncClienteCPA = new PdfPCell(new Phrase("Cliente : " + dtb.Rows[0]["Cliente"].ToString(), _standardFont));
                    SubEncClienteCPA.BorderWidth = 0;
                    PdfPCell SubEnc2CPA = new PdfPCell(new Phrase("Periodo : 01/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue + " al " + convertirFecha(ddlYear.SelectedValue,ddlMonth.SelectedValue), _standardFont));
                    SubEnc2CPA.BorderWidth = 0;
                    PdfPCell SubEncPedidoCPA = new PdfPCell(new Phrase("No Pedido : " + "00001", _standardFont));
                    SubEncPedidoCPA.BorderWidth = 0;
                    PdfPCell SubEncTarifaCPA = new PdfPCell(new Phrase("Tarifa Almto : " + txtTarifaAlmacenamiento.Text, _standardFont));
                    SubEncTarifaCPA.BorderWidth = 0;
                    PdfPCell SubEncTarifaDescargaCPA = new PdfPCell(new Phrase("Tarifa  C/D: " + txtTarifaDescarga.Text, _standardFont));
                    SubEncTarifaDescargaCPA.BorderWidth = 0;

                    tblSubEncabezadoCPA.AddCell(SubEnc1CPA);
                    tblSubEncabezadoCPA.AddCell(SubEncClienteCPA);
                    tblSubEncabezadoCPA.AddCell(SubEnc2CPA);
                    tblSubEncabezadoCPA.AddCell(SubEncPedidoCPA);
                    tblSubEncabezadoCPA.AddCell(SubEncTarifaCPA);
                    tblSubEncabezadoCPA.AddCell(SubEncTarifaDescargaCPA);
                    PdfPCell Enc2CPA = new PdfPCell(tblSubEncabezadoCPA);
                    Enc2CPA.BorderWidth = 0;
                    Enc2CPA.PaddingTop = 5f;

                    tblEncabezadoCPA.AddCell(Enc2CPA);
                    tblEncabezadoCPA.AddCell(Enc1CPA);
                    doc.Add(tblEncabezadoCPA);

                    // doc.Add(tblLinea);


                    doc.Add(tblLinea2);

                    //  doc.Add(new Paragraph(" "));

                    PdfPTable tblKardex = new PdfPTable(7);
                    tblKardex.WidthPercentage = 100;
                    tblKardex.PaddingTop = 10f;


                    // Configuramos el título de las columnas de la tabla
                    PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", _standardFontEncTabla));
                    clFecha.BorderWidth = 0.5f;
                    clFecha.BackgroundColor = new BaseColor(250, 98, 21);
                    clFecha.PaddingTop = 7f;
                    clFecha.PaddingBottom = 4f;
                    clFecha.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clFecha.VerticalAlignment = PdfPCell.ALIGN_CENTER;


                    PdfPCell clSaldoInicial = new PdfPCell(new Phrase("Saldo Inicial", _standardFontEncTabla));
                    clSaldoInicial.BorderWidth = 0.5f;
                    clSaldoInicial.BackgroundColor = new BaseColor(250, 98, 21);
                    clSaldoInicial.BorderWidthLeft = 0;
                    clSaldoInicial.PaddingBottom = 4f;
                    clSaldoInicial.PaddingTop = 7f;
                    clSaldoInicial.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clSaldoInicial.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell clEntradas = new PdfPCell(new Phrase("Entradas", _standardFontEncTabla));
                    clEntradas.BorderWidth = 0.5f;
                    clEntradas.BorderWidthLeft = 0;
                    clEntradas.BorderWidthRight = 0;
                    clEntradas.BackgroundColor = new BaseColor(250, 98, 21);
                    clEntradas.PaddingBottom = 4f;
                    clEntradas.PaddingTop = 7f;
                    clEntradas.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clEntradas.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell clSalidas = new PdfPCell(new Phrase("Salidas", _standardFontEncTabla));
                    clSalidas.BorderWidth = 0.5f;
                    clSalidas.BackgroundColor = new BaseColor(250, 98, 21);
                    clSalidas.PaddingBottom = 4f;
                    clSalidas.PaddingTop = 7f;
                    clSalidas.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clSalidas.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell clInvTotal = new PdfPCell(new Phrase("Saldo Total", _standardFontEncTabla));
                    clInvTotal.BorderWidth = 0.5f;
                    clInvTotal.BackgroundColor = new BaseColor(250, 98, 21);
                    clInvTotal.PaddingBottom = 4f;
                    clInvTotal.PaddingTop = 7f;
                    clInvTotal.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clInvTotal.VerticalAlignment = PdfPCell.ALIGN_CENTER;


                    PdfPCell clValorAlmacenamiento = new PdfPCell(new Phrase("Valor Almto", _standardFontEncTabla));
                    clValorAlmacenamiento.BorderWidth = 0.5f;
                    clValorAlmacenamiento.BackgroundColor = new BaseColor(250, 98, 21);
                    clValorAlmacenamiento.PaddingBottom = 4f;
                    clValorAlmacenamiento.PaddingTop = 7f;
                    clValorAlmacenamiento.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clValorAlmacenamiento.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    PdfPCell clValorDescarga = new PdfPCell(new Phrase("Valor C/D", _standardFontEncTabla));
                    clValorDescarga.BorderWidth = 0.5f;
                    clValorDescarga.BackgroundColor = new BaseColor(250, 98, 21);
                    clValorDescarga.PaddingBottom = 4f;
                    clValorDescarga.PaddingTop = 7f;
                    clValorDescarga.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clValorDescarga.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    // Añadimos las celdas a la tabla
                    tblKardex.AddCell(clFecha);
                    tblKardex.AddCell(clSaldoInicial);
                    tblKardex.AddCell(clEntradas);
                    tblKardex.AddCell(clSalidas);
                    tblKardex.AddCell(clInvTotal);
                    tblKardex.AddCell(clValorAlmacenamiento);
                    tblKardex.AddCell(clValorDescarga);

                    doc.Add(new Paragraph(" "));


                    for (int i = 0; i < GridViewLiquidacion.Rows.Count; i++)
                    {
                        GridViewRow row = GridViewLiquidacion.Rows[i];
                        // Llenamos la tabla con información
                        clFecha = new PdfPCell(new Phrase(row.Cells[1].Text, _standardFont));
                        clFecha.BorderWidth = 0.5f;
                        clFecha.PaddingTop = 7f;
                        clFecha.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clFecha.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        clSaldoInicial = new PdfPCell(new Phrase(row.Cells[2].Text, _standardFont));
                        clSaldoInicial.BorderWidth = 0.5f;
                        clSaldoInicial.PaddingTop = 7f;
                        clSaldoInicial.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clSaldoInicial.VerticalAlignment = PdfPCell.ALIGN_CENTER;


                        clEntradas = new PdfPCell(new Phrase(((Label)row.Cells[5].Controls[1]).Text, _standardFont));
                        clEntradas.BorderWidth = 0.5f;
                        clEntradas.PaddingTop = 7f;
                        clEntradas.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clEntradas.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        clSalidas = new PdfPCell(new Phrase(((Label)row.Cells[6].Controls[1]).Text, _standardFont));
                        clSalidas.BorderWidth = 0.5f;
                        clSalidas.PaddingTop = 7f;
                        clSalidas.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clSalidas.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        clInvTotal = new PdfPCell(new Phrase(((Label)row.Cells[7].Controls[1]).Text, _standardFont));
                        clInvTotal.BorderWidth = 0.5f;
                        clInvTotal.PaddingTop = 7f;
                        clInvTotal.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clInvTotal.VerticalAlignment = PdfPCell.ALIGN_CENTER;


                        clValorAlmacenamiento = new PdfPCell(new Phrase(((Label)row.Cells[8].Controls[1]).Text, _standardFont));
                        clValorAlmacenamiento.BorderWidth = 0.5f;
                        clValorAlmacenamiento.PaddingTop = 7f;
                        clValorAlmacenamiento.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clValorAlmacenamiento.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        clValorDescarga = new PdfPCell(new Phrase(((Label)row.Cells[9].Controls[1]).Text, _standardFont));
                        clValorDescarga.BorderWidth = 0.5f;
                        clValorDescarga.PaddingTop = 7f;
                        clValorDescarga.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        clValorDescarga.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        //decimal valorIngreso = Convert.ToDecimal(dtb.Rows[i]["ValorIngreso"].ToString().Replace(",", ""));
                        //string valorIngresoFormateado = "$ " + valorIngreso.ToString("#,##0");

                        //clTotal = new PdfPCell(new Phrase(valorIngresoFormateado, _standardFont));
                        //clTotal.BorderWidth = 0.5f;
                        //clTotal.PaddingTop = 7f;
                        //clTotal.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        //clTotal.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                        //Total += Convert.ToInt64(dtb.Rows[i]["ValorIngreso"].ToString().Replace(",", ""));

                        // Añadimos las celdas a la tabla
                        tblKardex.AddCell(clFecha);
                        tblKardex.AddCell(clSaldoInicial);
                        tblKardex.AddCell(clEntradas);
                        tblKardex.AddCell(clSalidas);
                        tblKardex.AddCell(clInvTotal);
                        tblKardex.AddCell(clValorAlmacenamiento);
                        tblKardex.AddCell(clValorDescarga);
                    }

                    clEntradas = new PdfPCell(new Phrase("", _standardFont));
                    clEntradas.BorderWidth = 0.5f;
                    clEntradas.PaddingTop = 7f;
                    clEntradas.Colspan = 4;



                    clSalidas = new PdfPCell(new Phrase("SubTotal", _standardFont));
                    clSalidas.BorderWidth = 0.5f;
                    clSalidas.PaddingTop = 7f;
                    clSalidas.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clSalidas.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    decimal valorTotalAlmacenamiento = Convert.ToDecimal(txtTotalIngresosAlm.Text.Replace(",", ""));
                    clValorAlmacenamiento = new PdfPCell(new Phrase("$ " + valorTotalAlmacenamiento.ToString("#,##0"), _standardFont));
                    clValorAlmacenamiento.BorderWidth = 0.5f;
                    clValorAlmacenamiento.PaddingTop = 7f;
                    clValorAlmacenamiento.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clValorAlmacenamiento.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    decimal valorTotalDecarga = Convert.ToDecimal(txtTotalIngresosDesc.Text.Replace(",", ""));
                    clValorDescarga = new PdfPCell(new Phrase("$ " + valorTotalDecarga.ToString("#,##0"), _standardFont));
                    clValorDescarga.BorderWidth = 0.5f;
                    clValorDescarga.PaddingTop = 7f;
                    clValorDescarga.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clValorDescarga.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    // Añadimos las celdas a la tabla
                    tblKardex.AddCell(clEntradas);
                    tblKardex.AddCell(clSalidas);
                    tblKardex.AddCell(clValorAlmacenamiento);
                    tblKardex.AddCell(clValorDescarga);

                    doc.Add(tblKardex);
                    // doc.Add(footer);

                    doc.Close();
                    writer.Close();

                    string fileName = Path.GetFileName(relativeFilePath);

                    // Limpiar la respuesta y establecer los encabezados
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                    Response.WriteFile(relativeFilePath);
                    Response.Flush();
                    System.Threading.Thread.Sleep(5000); // Tiempo de espera ajustable
                    File.Delete(relativeFilePath);

                    Response.End();
                    File.Delete(relativeFilePath);
                }
                catch (Exception ex)
                {
                    MostrarMensaje(ex.ToString());
                }
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
                    txtTelefono.Text = dtb.Rows[0]["Telefono"].ToString();
                    txtDireccion.Text = dtb.Rows[0]["Direccion"].ToString();
                    txtCiudad.Text = dtb.Rows[0]["Ciudad"].ToString();
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

            string usuario = Request.QueryString["usuario"];
            string idCierreDetalle = Request.QueryString["IdCierreDetalle"];
            DCL.GFCierreFinancieroDetalle objSumatoria = new DCL.GFCierreFinancieroDetalle();
            objSumatoria.IdCierreDetalle = Convert.ToInt64(idCierreDetalle);
            DataTable dtb = GFCierreFinancieroDetalle_BRL.SelectTable(objSumatoria, 9);
            if (dtb.Rows.Count > 0)
            {

                string idcierre = Request.QueryString["IdCierre"];
                string Terminal = dtb.Rows[0]["Terminal"].ToString();
                Response.Redirect($"FrmCierreCediAlm.aspx?usuario={usuario}&IdCierre={idcierre}&Terminal={Terminal}");
                
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
                int action = 13;
                if (ddl_Terminal.SelectedValue == "BCA")
                {
                    action = 27;
                }

                RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
                {
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

        private DataTable GridViewToDataTable(GridView gridView)
        {
            DataTable dataTable = new DataTable();

            // Crear las columnas en el DataTable según las columnas del GridView
            foreach (DataControlField column in gridView.Columns)
            {
                // Añadir la columna al DataTable
                if (column is BoundField boundField)
                {
                    if (column.Visible)
                    {
                        dataTable.Columns.Add(boundField.DataField);
                    }
                }
                else if (column is TemplateField templateField)
                {
                    dataTable.Columns.Add(templateField.HeaderText);
                }

            }

            // Añadir las filas al DataTable según las filas del GridView
            foreach (GridViewRow row in gridView.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                int columnIndex = 0;
                int columnIndexVisible = 0;
                foreach (DataControlField column in gridView.Columns)
                {
                    if (column.Visible)
                    {
                        if (column is BoundField)
                        {
                            dataRow[columnIndexVisible] = row.Cells[columnIndex].Text.Trim().Replace("$", "");
                        }
                        else if (column is TemplateField)
                        {
                            // Buscar el control en la celda del TemplateField
                            foreach (Control control in row.Cells[columnIndex].Controls)
                            {
                                if (control is Label label)
                                {
                                    dataRow[columnIndexVisible] = label.Text.Trim().Replace("$", "");
                                }
                                else if (control is TextBox textBox)
                                {
                                    dataRow[columnIndexVisible] = textBox.Text.Trim().Replace("$", "");
                                }
                                // Añade más controles según sea necesario (e.g., DropDownList, CheckBox, etc.)
                            }
                        }
                        columnIndexVisible++;
                    }
                    columnIndex++;
                }

                dataTable.Rows.Add(dataRow);

            }

            if (gridView.FooterRow != null)
            {
                DataRow footerRow = dataTable.NewRow();
                int footerColumnIndex = 0;
                int footerColumnIndexVisible = 0;
                foreach (DataControlField column in gridView.Columns)
                {
                    if (column.Visible)
                    {
                        if (column is BoundField)
                        {
                            footerRow[footerColumnIndexVisible] = gridView.FooterRow.Cells[footerColumnIndex].Text.Trim().Replace("$", "");
                        }
                        else if (column is TemplateField)
                        {
                            foreach (Control control in gridView.FooterRow.Cells[footerColumnIndex].Controls)
                            {
                                if (control is Label label)
                                {
                                    footerRow[footerColumnIndexVisible] = label.Text.Trim().Replace("$", "");
                                }
                                else if (control is TextBox textBox)
                                {
                                    footerRow[footerColumnIndexVisible] = textBox.Text.Trim().Replace("$", "");
                                }
                                // Añade más controles según sea necesario (e.g., DropDownList, CheckBox, etc.)
                            }
                        }
                        footerColumnIndexVisible++;
                    }
                    footerColumnIndex++;
                }
                dataTable.Rows.Add(footerRow);
            }

            return dataTable;
        }

        public void GenerarExcel()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string rutarchivo = Server.MapPath("~/InformeLiquidacion_" + timestamp + ".xls");
            string NombreArchivo = "InformeLiquidacion" + timestamp + ".xls";
            DataTable dtb = GridViewToDataTable(GridViewLiquidacion);

            ExportToExcel(dtb, rutarchivo);

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "application/vnd.xls";
            response.AddHeader("Content-Disposition", "attachment; filename=" + NombreArchivo + ";");
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

        private void ExportToExcel(DataTable table, string filePath)
        {
            string relativeImagen = Server.MapPath("~/Img/logo.png");
            StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.GetEncoding(1252));
            sw.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            sw.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            sw.Write("<br/>");
            sw.Write("<table >");
            sw.Write("<tr>");
            sw.Write("<td colspan='5'>");
            sw.Write("<img src='" + relativeImagen + "' alt=\"Descripción de la imagen\">");
            //sw.Write("<img src=\"C:/Users/JeissonFranciscoMont/source/repos/BlkProfessional/BlkProfessional/Img/logo.png\" alt=\"Descripción de la imagen\">");
            sw.Write("</td>");
            sw.Write("<td></td>");
            sw.Write("<td></td>");
            sw.Write("</tr>");
            sw.Write("<tr><td colspan='5'></td><td colspan='2' style='border: 1px solid #000000;'><b>LIQUIDACION DE ALMTO & C/D</b></td><td></td></tr>");
            sw.Write("<tr><td colspan='5'></td><td style='border: 1px solid #000000;'><b>Fecha Actual</b></td><td style='border: 1px solid #000000;'>" + DateTime.Now.ToShortDateString() + "</td></tr>");
            sw.Write("<tr><td colspan='5'></td><td></td><td></td></tr>");
            sw.Write("<tr><td></td><td style='border: 1px solid #000000;'><b>Terminal:</b></td><td style='border: 1px solid #000000; text-align: right;'>" + ddl_Terminal.SelectedValue + "</td><td colspan='2'></td><td style='border: 1px solid #000000;'><b>Bodega:</b></td><td style='border: 1px solid #000000; text-align: right; '>" + ddlLocation.SelectedValue + "</td></tr>");
            sw.Write("<tr><td></td><td style='border: 1px solid #000000;'><b>Inicio Periodo:</b></td><td style='border: 1px solid #000000;  text-align: right;'>01-" + ddlMonth.SelectedValue + "-" + ddlYear.SelectedValue + "</td><td colspan='2'></td><td style='border: 1px solid #000000;'><b>Fin Periodo:</b></td><td style='border: 1px solid #000000;  text-align: right;'>" + convertirFecha(ddlYear.SelectedValue, ddlMonth.SelectedValue) + "</td></tr>");
            sw.Write("<tr><td></td><td style='border: 1px solid #000000;'><b>Tarifa Almacenaje:</b></td><td style='border: 1px solid #000000;  text-align: right;'>" + txtTarifaAlmacenamiento.Text.Replace("$", "") + "</td><td colspan='2'></td><td style='border: 1px solid #000000;'><b>Tarifa C&D:</b></td><td style='border: 1px solid #000000;  text-align: right;'>" + txtTarifaDescarga.Text.Replace("$", "") + "</td></tr>");
            sw.Write("<tr><td></td><td style='border: 1px solid #000000;'><b>Cliente:</b></td><td style='border: 1px solid #000000;  text-align: right;'>" + txtDescripcionCliente.Text + "</td><td colspan='2'></td><td'><b></b></td><td></td></tr>");
            sw.Write("</table>");

            sw.Write("<br/>");
            sw.Write("<br/>");
            sw.Write("<br/>");
            sw.Write("<br/>");
            sw.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            int columnscount = table.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {
                sw.Write("<td style='background-color:#FE6800;color:#FFFFFF;'>");
                sw.Write("<b>");
                sw.Write(table.Columns[j].ToString());
                sw.Write("</b>");
                sw.Write("</td>");
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