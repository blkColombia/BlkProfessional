using System;
using System.Data;
using DAL;
using DCL;


namespace DAL
{
    public class WeeklyFactory :FactoryBase
    {
        public WeeklyFactory() { }

        public Weekly Load(Weekly objBan)
        {
            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", 0, ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    objBan = new Weekly(GetDataReader());
                }
                return objBan;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public WeeklyCollection SelectByParams(Weekly objBan, int Action)
        {
            WeeklyCollection Collection = new WeeklyCollection();

            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    Collection.Add(new Weekly(GetDataReader()));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Collection;
        }

        public DataTable SelectTable(Weekly objBan, int Action)
        {
            DataTable dt = new DataTable();
            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                dt = GetDataSet().Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public int InsertarOrUpdate(Weekly objBan, int Action)
        {
            int i;
            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                ExecuteNonQuery();
                i = 1;
            }
            catch (Exception e)
            {
                i = -1;
                throw e;
            }
            return i;
        }

        private void AddParameters(Weekly objBan)
        {
            CreateCommand("Sp_Weekly", true);
            AddCmdParameter("@WeeklyId", objBan.WeeklyId, ParameterDirection.Input);
            AddCmdParameter("@Terminal", objBan.Terminal, ParameterDirection.Input);
            AddCmdParameter("@LocationCode", objBan.LocationCode, ParameterDirection.Input);
            AddCmdParameter("@TipoLiquidacion", objBan.TipoLiquidacion, ParameterDirection.Input);
            AddCmdParameter("@Clase", objBan.Clase, ParameterDirection.Input);
            AddCmdParameter("@Mes", objBan.Mes, ParameterDirection.Input);
            AddCmdParameter("@Cliente", objBan.Cliente, ParameterDirection.Input);
            AddCmdParameter("@SubCliente", objBan.SubCliente, ParameterDirection.Input);
            AddCmdParameter("@TipoCuenta", objBan.TipoCuenta, ParameterDirection.Input);
            AddCmdParameter("@Cuenta", objBan.Cuenta, ParameterDirection.Input);
            AddCmdParameter("@SubCuenta", objBan.SubCuenta, ParameterDirection.Input);
            AddCmdParameter("@Observacion", objBan.Observacion, ParameterDirection.Input);
            AddCmdParameter("@PresupuestoMes", objBan.PresupuestoMes, ParameterDirection.Input);
            AddCmdParameter("@TotalEjecutadoMes", objBan.TotalEjecutadoMes, ParameterDirection.Input);
            AddCmdParameter("@UsuarioCreacion", objBan.UsuarioCreacion, ParameterDirection.Input);
            AddCmdParameter("@FechaInicio", objBan.FechaInicio, ParameterDirection.Input);
            AddCmdParameter("@FechaFin", objBan.FechaFin, ParameterDirection.Input);
            AddCmdParameter("@DesCliente", objBan.DesCliente, ParameterDirection.Input);
            AddCmdParameter("@Year", objBan.Year, ParameterDirection.Input);

        }
    }
}

