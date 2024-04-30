using System;
using System.Data;
using DAL;
using DCL;

namespace DAL
{
    public class GFCierreFinancieroFactory : FactoryBase
    {
        public GFCierreFinancieroFactory() { }

        public GFCierreFinanciero Load(GFCierreFinanciero objBan)
        {
            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", 0, ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    objBan = new GFCierreFinanciero(GetDataReader());
                }
                return objBan;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public GFCierreFinancieroCollection SelectByParams(GFCierreFinanciero objBan, int Action)
        {
            GFCierreFinancieroCollection Collection = new GFCierreFinancieroCollection();

            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    Collection.Add(new GFCierreFinanciero(GetDataReader()));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Collection;
        }

        public DataTable SelectTable(GFCierreFinanciero objBan, int Action)
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

        public int InsertarOrUpdate(GFCierreFinanciero objBan, int Action)
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

        private void AddParameters(GFCierreFinanciero objBan)
        {
            CreateCommand("Sp_GFCierreFinanciero", true);
            AddCmdParameter("@IdCierre", objBan.IdCierre, ParameterDirection.Input);            
            AddCmdParameter("@FechaInicial", objBan.FechaInicial, ParameterDirection.Input);
            AddCmdParameter("@FechaFinal", objBan.FechaFinal, ParameterDirection.Input);            
            AddCmdParameter("@Terminal", objBan.Terminal, ParameterDirection.Input);
            AddCmdParameter("@Estado", objBan.Estado, ParameterDirection.Input);            
            AddCmdParameter("@FechaCreacion", objBan.FechaCreacion, ParameterDirection.Input);
            AddCmdParameter("@UsuarioCreacion", objBan.UsuarioCreacion, ParameterDirection.Input);
            AddCmdParameter("@FechaActualizacion", objBan.FechaActualizacion, ParameterDirection.Input);
            AddCmdParameter("@UsuarioActualizacion", objBan.UsuarioActualizacion, ParameterDirection.Input);
            AddCmdParameter("@FechaCierre", objBan.FechaCierre, ParameterDirection.Input);
            AddCmdParameter("@UsuarioCierre", objBan.UsuarioCierre, ParameterDirection.Input);            
        }
    }
}


