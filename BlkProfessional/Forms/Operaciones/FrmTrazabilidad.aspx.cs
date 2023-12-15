using BRL;
using DCL;
using System;
using System.Data;
using System.IO;

namespace BlkProfessional.Forms.Operaciones
{
    public partial class FrmTrazabilidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(txtFechaInicio.Text) > Convert.ToDateTime(txtFechaFin.Text))
                {
                    MostrarMensaje("La fecha Inicio no puede ser mayor a la fecha fin");
                    return;
                }
                ItemLedgerEntry obj = new ItemLedgerEntry();
                obj.PostingDate = txtFechaInicio.Text;
                obj.DocumentDate = txtFechaFin.Text;
                obj.CustomerNo = txtCliente.Text;
                obj.EntryType = Convert.ToInt32(ddlMovimientos.SelectedItem.Value);
                obj.GlobalDimension2Code = ddlSegmentos.SelectedItem.Value; 
                DataTable dtb = ItemLedgerEntry_BRL.SelectTable(obj, 0);
                if (dtb.Rows.Count > 0)
                {

                    string rutarchivo = Server.MapPath("~/Informes.xls");
                    ExportToExcel(dtb, rutarchivo);

                    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                    response.ClearContent();
                    response.Clear();
                    response.ContentType = "application/vnd.xls";
                    response.AddHeader("Content-Disposition", "attachment; filename=" + "Informes" + ".xls" + ";");
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
            catch (Exception ex) {
                MostrarMensaje("Por favor contacte al administrador del sistema :  "+ex.Message.ToString());
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

        protected void txtCliente_TextChanged(object sender, EventArgs e)
            {
            ItemLedgerEntry obj = new ItemLedgerEntry();
            obj.CustomerNo = txtCliente.Text;            
            DataTable dtb = ItemLedgerEntry_BRL.SelectTable(obj, 1);
            if (dtb.Rows.Count > 0)
            {
                txtDescripcionCliente.Text = dtb.Rows[0]["Name"].ToString();
            }
            else {
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