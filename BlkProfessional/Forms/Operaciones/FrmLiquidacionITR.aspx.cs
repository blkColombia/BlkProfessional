using BlkProfessional.Servicios;
using BRL;
using ClosedXML.Excel;
using DCL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace BlkProfessional.Forms.Operaciones
{
    public partial class FrmLiquidacionITR : System.Web.UI.Page
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
                if (String.IsNullOrEmpty(txtCliente.Text)) {
                    MostrarMensaje("Debe ingresar un cliente");
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
                if (ddlLocation.SelectedIndex < 0)
                {
                    MostrarMensaje("Debe ingresar un almacen");
                    return;
                }
                string rutarchivo = Server.MapPath("~/InformeLiquidacion.xls");
                // ExportToExcel(dtb, rutarchivo);
            
                using (var workbook = new XLWorkbook())
                {

                    RequesItemLedgerEntry objeto = new RequesItemLedgerEntry
                    {
                        Terminal = ddl_Terminal.SelectedValue,
                        LocationCode = ddlLocation.SelectedValue,
                        CodigoCliente = txtCliente.Text,
                        Fecha = convertirFecha(ddlYear.SelectedValue, ddlMonth.SelectedValue),
                        Action = 6
                    };
                    string jsonString = JsonConvert.SerializeObject(objeto);
                    var mensaje = Servicios.ServicesNavisionIntegracion.InvokeService("DatosCliente", jsonString);
                    ResponseItemLedgerEntry listaObjetos = JsonConvert.DeserializeObject<ResponseItemLedgerEntry>(mensaje);
                   
                    if (listaObjetos.data != null)
                    {
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
                                    LocationCode = ddlLocation.SelectedValue,
                                    CodigoCliente = txtCliente.Text,
                                    SourceNo = dtbRegsiter.Rows[i][0].ToString(),
                                    Fecha = convertirFecha(ddlYear.SelectedValue, ddlMonth.SelectedValue),
                                    Action = 5
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
                    else {
                        MostrarMensaje("el cliente seleccionado no tiene importaciones");
                    }
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje("Por favor contacte al administrador del sistema :  " + ex.Message.ToString());
            }
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
            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@"C:\Users\JeissonFranciscoMont\Documents\PDF\PRuebass.pdf", FileMode.Create));



            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Liquidacion ITR");
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

            PdfPTable tblEncabezado = new PdfPTable(2);
            tblEncabezado.WidthPercentage = 100;

            PdfPCell Enc1 = new PdfPCell(image1);

            PdfPTable tblSubEncabezado = new PdfPTable(1);
            tblSubEncabezado.WidthPercentage = 100;
            PdfPCell SubEnc1 = new PdfPCell(new Phrase("Informe de Liquidacion ITR ", _standardFontEncabezado));
            SubEnc1.BorderWidth = 0;
            PdfPCell SubEnc2 = new PdfPCell(new Phrase("Fecha : " + DateTime.Now.ToShortDateString(), _standardFont));
            SubEnc2.BorderWidth = 0;
            tblSubEncabezado.AddCell(SubEnc1);
            tblSubEncabezado.AddCell(SubEnc2);


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
            Linea1.BorderWidthBottom = 0.25f;

            tblLinea.AddCell(Linea1);
            doc.Add(tblLinea);

            doc.Add(Chunk.NEWLINE);
            // Escribimos el encabezamiento en el documento

            PdfPTable tblDatos = new PdfPTable(6);
            tblLinea.WidthPercentage = 100;


            PdfPCell CLiente = new PdfPCell(new Phrase("Cliente : ", _standardFont));
            CLiente.BorderWidth = 0;
            CLiente.Colspan = 1;
            CLiente.PaddingTop = 10f;

            PdfPCell ValorCLiente = new PdfPCell(new Phrase("EMPRESA COLOMBIANA DE PETROLEOS S.A. - ECOPETROL ECOPETROL", _standardFont));
            ValorCLiente.BorderWidth = 0;
            ValorCLiente.Colspan = 4;




            PdfPCell Col3 = new PdfPCell(new Phrase("", _standardFont));
            Col3.BorderWidth = 0;
            Col3.Colspan = 1;

            tblDatos.AddCell(CLiente);
            tblDatos.AddCell(ValorCLiente);
            tblDatos.AddCell(Col3);

            doc.Add(tblDatos);



            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;


            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            // Llenamos la tabla con información
            clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
            clNombre.BorderWidth = 0;

            clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
            clApellido.BorderWidth = 0;

            clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
            clPais.BorderWidth = 0;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();


        }
    }
}