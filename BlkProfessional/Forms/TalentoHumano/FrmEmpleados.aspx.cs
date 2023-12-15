using DCL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlkProfessional.Forms.TalentoHumano
{
    public partial class FrmEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object BuscarEmpleados()
        {
            try
            {
                Employees objData = new DCL.Employees();
                DataTable dtlistaDocumentos = BRL.Employess_BRL.SelectTable(objData, 0);
                var retVal = new List<object>();
                if (dtlistaDocumentos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtlistaDocumentos.Rows.Count; i++)
                    {
                        retVal.Add(new
                        {
                            EmployeeId = dtlistaDocumentos.Rows[i]["EmployeeId"].ToString(),
                            IdTipoIdentificacion = dtlistaDocumentos.Rows[i]["IdTipoIdentificacion"].ToString(),
                            TipoIdentificacion = dtlistaDocumentos.Rows[i]["TipoIdentificacion"].ToString(),
                            NumeroIdentificacion = dtlistaDocumentos.Rows[i]["NumeroIdentificacion"].ToString(),
                            Nombres = dtlistaDocumentos.Rows[i]["Nombres"].ToString(),
                            Apellidos = dtlistaDocumentos.Rows[i]["Apellidos"].ToString(),
                            CargoId = dtlistaDocumentos.Rows[i]["CargoId"].ToString(),
                            Cargo = dtlistaDocumentos.Rows[i]["Cargo"].ToString(),
                            Correo = dtlistaDocumentos.Rows[i]["Correo"].ToString(),
                            Telefono = dtlistaDocumentos.Rows[i]["Telefono"].ToString(),
                        });
                    }
                }
                return retVal;
            }
            catch (Exception ex)
            {
                return new { Error = true, Message = ex.ToString() };
            }

        }

        [WebMethod]
        public static object GuardarEmpleado(string idEmpresa, string idTipoIdentificacion, string identificacion, string nombres, string apellidos, string cargo, string correo, string telefono)
        {
            try
            {
                DCL.Employees obj = new DCL.Employees();
                obj.IdentificationTypeId = Convert.ToInt32(idTipoIdentificacion);
                obj.CompanyId = Convert.ToInt32(idEmpresa);
                obj.IdentificationNumber = identificacion;
                obj.Names = nombres;
                obj.LastNames = apellidos;
                obj.ChargeId = Convert.ToInt32(cargo);
                obj.Email = correo;
                obj.PhoneNumber = telefono;
                obj.UserCreation = 1;
                BRL.Employess_BRL.InsertarOrUpdate(obj, 1);


                DCL.Employees objData = new DCL.Employees();
                DataTable dtlistaDocumentos = BRL.Employess_BRL.SelectTable(objData, 0);
                var retVal = new List<object>();
                if (dtlistaDocumentos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtlistaDocumentos.Rows.Count; i++)
                    {
                        retVal.Add(new
                        {
                            EmployeeId = dtlistaDocumentos.Rows[i]["EmployeeId"].ToString(),
                            //  IdTipoIdentificacion = dtlistaDocumentos.Rows[i]["IdTipoIdentificacion"].ToString(),
                            TipoIdentificacion = dtlistaDocumentos.Rows[i]["TipoIdentificacion"].ToString(),
                            NumeroIdentificacion = dtlistaDocumentos.Rows[i]["NumeroIdentificacion"].ToString(),
                            Nombres = dtlistaDocumentos.Rows[i]["Nombres"].ToString(),
                            Apellidos = dtlistaDocumentos.Rows[i]["Apellidos"].ToString(),
                            //  CargoId = dtlistaDocumentos.Rows[i]["CargoId"].ToString(),
                            Cargo = dtlistaDocumentos.Rows[i]["Cargo"].ToString(),
                            Correo = dtlistaDocumentos.Rows[i]["Correo"].ToString(),
                            Telefono = dtlistaDocumentos.Rows[i]["Telefono"].ToString(),
                        });
                    }
                }
                return retVal;
            }
            catch (Exception ex)
            {
                return new { Error = true, Message = ex.ToString() };
            }
        }


        [WebMethod]
        public static object ActualizarEmpleado(string idEmpresa, string idTipoIdentificacion, string identificacion, string nombres, string apellidos, string cargo, string correo, string telefono, string idEmpleado)
        {
            try
            {
                DCL.Employees obj = new DCL.Employees();
                obj.EmployeeId = Convert.ToInt32(idEmpleado);
                obj.IdentificationTypeId = Convert.ToInt32(idTipoIdentificacion);
                obj.CompanyId = Convert.ToInt32(idEmpresa);
                obj.IdentificationNumber = identificacion;
                obj.Names = nombres;
                obj.LastNames = apellidos;
                obj.ChargeId = Convert.ToInt32(cargo);
                obj.Email = correo;
                obj.PhoneNumber = telefono;
                BRL.Employess_BRL.InsertarOrUpdate(obj, 2);


                DCL.Employees objData = new DCL.Employees();
                DataTable dtlistaDocumentos = BRL.Employess_BRL.SelectTable(objData, 0);
                var retVal = new List<object>();
                if (dtlistaDocumentos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtlistaDocumentos.Rows.Count; i++)
                    {
                        retVal.Add(new
                        {
                            EmployeeId = dtlistaDocumentos.Rows[i]["EmployeeId"].ToString(),
                            //  IdTipoIdentificacion = dtlistaDocumentos.Rows[i]["IdTipoIdentificacion"].ToString(),
                            TipoIdentificacion = dtlistaDocumentos.Rows[i]["TipoIdentificacion"].ToString(),
                            NumeroIdentificacion = dtlistaDocumentos.Rows[i]["NumeroIdentificacion"].ToString(),
                            Nombres = dtlistaDocumentos.Rows[i]["Nombres"].ToString(),
                            Apellidos = dtlistaDocumentos.Rows[i]["Apellidos"].ToString(),
                            //  CargoId = dtlistaDocumentos.Rows[i]["CargoId"].ToString(),
                            Cargo = dtlistaDocumentos.Rows[i]["Cargo"].ToString(),
                            Correo = dtlistaDocumentos.Rows[i]["Correo"].ToString(),
                            Telefono = dtlistaDocumentos.Rows[i]["Telefono"].ToString(),
                        });
                    }
                }
                return retVal;
            }
            catch (Exception ex)
            {
                return new { Error = true, Message = ex.ToString() };
            }
        }

    }
}