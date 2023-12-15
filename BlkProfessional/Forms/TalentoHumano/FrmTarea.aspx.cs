using BRL;
using DCL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlkProfessional.Forms.TalentoHumano
{
    public partial class FrmTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Simulación de datos: Puedes obtener estos datos de una base de datos u otra fuente.
                List<Empleado> empleados = new List<Empleado>
                {
                    new Empleado { Id = 1, Nombre = "Juan Pérez", Cargo = "Desarrollador" },
                    new Empleado { Id = 2, Nombre = "María Gómez", Cargo = "Diseñador" },
                    // Agrega más empleados según sea necesario
                };

              
                Employees obj = new Employees();
                DataTable dtb = Employess_BRL.SelectTable(obj,1);                
                // Vincula el GridView a la lista de empleados
                GridViewEmpleados.DataSource = dtb;
                GridViewEmpleados.DataBind();
            }
        }


        protected void GridViewEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Visualizar")
            {
                // Aquí puedes obtener el CommandArgument que es el IdTarea
                int idTarea = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"FrmTareaDetalle.aspx?IdTarea={idTarea}");
                // Puedes realizar acciones adicionales aquí según el IdTarea seleccionado
                // Por ejemplo, puedes redirigir a una nueva página o realizar alguna lógica específica.
            }
        }

        public class Empleado
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Cargo { get; set; }
        }
    }
}