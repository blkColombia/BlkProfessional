using System;
using System.Data;
using DAL;
using DCL;

namespace DAL
{
    public class GFCierreFinancieroDetalleFactory : FactoryBase
    {
        public GFCierreFinancieroDetalleFactory() { }

        public GFCierreFinancieroDetalle Load(GFCierreFinancieroDetalle objBan)
        {
            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", 0, ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    objBan = new GFCierreFinancieroDetalle(GetDataReader());
                }
                return objBan;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public GFCierreFinancieroDetalleCollection SelectByParams(GFCierreFinancieroDetalle objBan, int Action)
        {
            GFCierreFinancieroDetalleCollection Collection = new GFCierreFinancieroDetalleCollection();

            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    Collection.Add(new GFCierreFinancieroDetalle(GetDataReader()));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Collection;
        }

        public DataTable SelectTable(GFCierreFinancieroDetalle objBan, int Action)
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

        public int InsertarOrUpdate(GFCierreFinancieroDetalle objBan, int Action)
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

        private void AddParameters(GFCierreFinancieroDetalle objBan)
        {
            CreateCommand("Sp_GFCierreFinancieroDetalle", true);
            AddCmdParameter("@IdCierreDetalle", objBan.IdCierreDetalle, ParameterDirection.Input);
            AddCmdParameter("@IdCierre", objBan.IdCierre, ParameterDirection.Input);
            AddCmdParameter("@Terminal", objBan.Terminal, ParameterDirection.Input);
            AddCmdParameter("@Almacen", objBan.Almacen, ParameterDirection.Input);
            AddCmdParameter("@CodCliente", objBan.CodCliente, ParameterDirection.Input);
            AddCmdParameter("@IdConcepto", objBan.IdConcepto, ParameterDirection.Input);
            AddCmdParameter("@ValorConcepto", objBan.ValorConcepto, ParameterDirection.Input);
            AddCmdParameter("@Estado", objBan.Estado, ParameterDirection.Input);
            AddCmdParameter("@FechaCreacion", objBan.FechaCreacion, ParameterDirection.Input);
            AddCmdParameter("@UsuarioCreacion", objBan.UsuarioCreacion, ParameterDirection.Input);
            AddCmdParameter("@FechaActualizacion", objBan.FechaActualizacion, ParameterDirection.Input);
            AddCmdParameter("@UsuarioActualizacion", objBan.UsuarioActualizacion, ParameterDirection.Input);
            AddCmdParameter("@FechaFinalizacion", objBan.FechaFinalizacion, ParameterDirection.Input);
            AddCmdParameter("@UsuarioFinalizacion", objBan.UsuarioFinalizacion, ParameterDirection.Input);
        }
    }
}


