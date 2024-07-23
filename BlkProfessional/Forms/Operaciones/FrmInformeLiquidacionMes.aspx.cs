using BlkProfessional.Servicios;
using BRL;
using ClosedXML.Excel;
using DCL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using OfficeOpenXml;
using QRCoder;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;


namespace BlkProfessional.Forms.Operaciones
{
    public partial class FrmInformeLiquidacionMes : System.Web.UI.Page
    {
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

        }

        protected void Page_Load(object sender, EventArgs e)
        {

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


        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(txtDescripcionCliente.Text))
                {
                    MostrarMensaje("por favor seleccione un cliente valido");
                    return;
                }
                if (ddl_Terminal.SelectedIndex < 0)
                {
                    MostrarMensaje("Debe ingresar una Terminal");
                    return;
                }

                string rutarchivo = Server.MapPath("~/InformeLiquidacion.xls");
                // ExportToExcel(dtb, rutarchivo);

                using (var workbook = new XLWorkbook())
                {

                    RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
                    {
                        Terminal = ddl_Terminal.SelectedValue,
                        //LocationCode = ddlLocation.SelectedValue,
                        CodigoCliente = ddlCliente.SelectedValue,
                        Fecha = convertirFecha(ddlYear.SelectedValue, ddlMonth.SelectedValue),
                        Action = 6
                    };
                    string jsonString = JsonConvert.SerializeObject(objeto);
                    var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
                    ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
                    DataTable dtbRegsiter = listaObjetos.data;


                    if (dtbRegsiter.Rows.Count > 0)
                    {

                        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                        response.ClearContent();
                        response.Clear();
                        //response.ContentType = "application/vnd.xls";
                        response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        response.AddHeader("content-disposition", "attachment; filename=" + "InformeLiquidacion" + ".xls" + ";");

                        // Crea una nueva hoja en el libro
                        for (int i = 0; i < dtbRegsiter.Rows.Count; i++)
                        {
                            var worksheet = workbook.Worksheets.Add(dtbRegsiter.Rows[i][0].ToString());

                            RequesItemLedgerEntry objetos = new RequesItemLedgerEntry
                            {
                                Terminal = ddl_Terminal.SelectedValue,
                                // LocationCode = ddlLocation.SelectedValue,
                                CodigoCliente = ddlCliente.SelectedValue,
                                SourceNo = dtbRegsiter.Rows[i][0].ToString(),
                                Fecha = convertirFecha(ddlYear.SelectedValue, ddlMonth.SelectedValue),
                                Action = 11
                            };
                            string jsonStrings = JsonConvert.SerializeObject(objetos);
                            var mensajes = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonStrings);
                            ResponseItemLedgerEntry listaObjetosL = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensajes);
                            DataTable dtb = listaObjetosL.data;
                            if (listaObjetosL.data.Rows.Count > 0)
                            {
                                if (dtb.Rows.Count > 0)
                                {
                                    // Rellena la hoja con los datos del DataTable
                                    worksheet.Cell(1, 1).InsertTable(dtb);
                                }   // Guarda el archivo Excel
                            }
                        }

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            workbook.SaveAs(memoryStream);
                            memoryStream.WriteTo(response.OutputStream);
                        }

                        response.End();
                    }
                    else
                    {
                        MostrarMensaje("el cliente no tiene importaciones");
                    }
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje("Por favor contacte al administrador del sistema :  " + ex.Message.ToString());
            }
        }

        private string convertirFecha(string year, string mes)
        {

            string fecha = "";
            int dia = DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(mes));
            fecha = mes + "/" + dia.ToString() + "/" + year;
            return fecha;
        }

        private void WriteSheet(StreamWriter sw, string sheetName, DataTable table)
        {
            // Escribe la estructura de una hoja
            sw.WriteLine($"<Worksheet ss:Name=\"{sheetName}\">");
            // sw.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
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
            sw.WriteLine("</Table>");



            sw.WriteLine("</Worksheet>");
        }

        private void ExportToExcel(DataTable table, string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);

            sw.WriteLine($"# Hoja1");
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

        protected void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedValue == "0")
            {
                MostrarMensaje("por favor debe seleccionar un año");
                return;
            }
            if (ddlMonth.SelectedValue == "0")
            {
                MostrarMensaje("por favor debe seleccionar un mes");
                return;
            }
            if (String.IsNullOrEmpty(txtDescripcionCliente.Text))
            {
                MostrarMensaje("por favor seleccione un cliente valido");
                return;
            }
            if (ddl_Terminal.SelectedIndex < 0)
            {
                MostrarMensaje("Debe ingresar una Terminal");
                return;
            }
            if (String.IsNullOrEmpty(txtPedido.Text))
            {
                MostrarMensaje("por favor escriba un numero de pedido");
                return;
            }

            string fecha = convertirFecha(ddlYear.SelectedValue, ddlMonth.SelectedValue);
            Int64 Total = 0;

            DCL.Weekly obj = new DCL.Weekly();
            obj.FechaInicio = fecha;
            obj.Cliente = ddlCliente.SelectedValue;
            obj.Terminal = ddl_Terminal.SelectedValue;
            DataTable dtb = Weekly_BRL.SelectTable(obj, 4);
            if (dtb.Rows.Count > 0)
            {
                // Creamos el documento con el tamaño de página tradicional
                Document doc = new Document(PageSize.LETTER);
                // Indicamos donde vamos a guardar el documento
                PdfWriter writer = PdfWriter.GetInstance(doc,
                                            new FileStream(@"C:\Users\JeissonFranciscoMont\Documents\PDF\PRuebass.pdf", FileMode.Create));



                // Le colocamos el título y el autor
                // **Nota: Esto no será visible en el documento
                doc.AddTitle("Liquidacion");
                doc.AddCreator("Jeison Montaño");

                // Abrimos el archivo
                doc.Open();




                iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(@"C:\Users\JeissonFranciscoMont\source\repos\BlkProfessional\BlkProfessional\Img\logo.png");
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

                PdfPTable tblSubEncabezado = new PdfPTable(1);
                tblSubEncabezado.WidthPercentage = 100;
                PdfPCell SubEnc1 = new PdfPCell(new Phrase("INFORME DE LIQUIDACION", _standardFontEncabezado));
                SubEnc1.BorderWidth = 0;
                PdfPCell SubEnc2 = new PdfPCell(new Phrase("Periodo : " + DateTime.Now.ToShortDateString(), _standardFont));
                SubEnc2.BorderWidth = 0;
                PdfPCell SubEncPedido = new PdfPCell(new Phrase("No Pedido : " + txtPedido.Text, _standardFont));
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


                PdfPCell Direccion = new PdfPCell(new Phrase("Direccion :  Calle 12 4 46 ", _standardFont));
                Direccion.BorderWidth = 0;
                Direccion.PaddingTop = 2f;
                Direccion.Left = 0;
                Direccion.HorizontalAlignment = PdfPCell.ALIGN_LEFT;


                PdfPCell Ciudad = new PdfPCell(new Phrase("Ciudad :     Bogota ", _standardFont));
                Ciudad.BorderWidth = 0;
                Ciudad.PaddingTop = 2f;
                Ciudad.Left = 0;
                Ciudad.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                PdfPCell Telefono = new PdfPCell(new Phrase("Telefono :   3153263468", _standardFont));
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
                tblDatos.AddCell(Nit);
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

                    decimal valorIngreso = Convert.ToDecimal(dtb.Rows[i]["ValorIngreso"].ToString().Replace(",",""));
                    string valorIngresoFormateado = "$ " + valorIngreso.ToString("#,##0");

                    clTotal = new PdfPCell(new Phrase(valorIngresoFormateado, _standardFont));
                    clTotal.BorderWidth = 0.5f;
                    clTotal.PaddingTop = 7f;
                    clTotal.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    clTotal.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    Total += Convert.ToInt64(dtb.Rows[i]["ValorIngreso"].ToString().Replace(",",""));

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

                string qrText = "Este es un ejemplo de código QR";
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
                qrImage.ScaleAbsolute(100, 100); // Escalar la imagen al tamaño deseado



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


                doc.Close();
                writer.Close();

            }
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
    }
}