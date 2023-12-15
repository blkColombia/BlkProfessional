using System;
using System.Data;
using DAL;
using DCL;

namespace DAL
{
   public class EmployeesFactory : FactoryBase
    {
        public EmployeesFactory() { }

        public Employees Load(Employees objBan)
        {
            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", 0, ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    objBan = new Employees(GetDataReader());
                }
                return objBan;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public EmployeesCollection SelectByParams(Employees objBan, int Action)
        {
            EmployeesCollection Collection = new EmployeesCollection();

            try
            {
                AddParameters(objBan);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    Collection.Add(new Employees(GetDataReader()));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Collection;
        }

        public DataTable SelectTable(Employees objBan, int Action)
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

        public int InsertarOrUpdate(Employees objBan, int Action)
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

        private void AddParameters(Employees objBan)
        {
            CreateCommand("Sp_Employees", true);
            AddCmdParameter("@EmployeeId", objBan.EmployeeId, ParameterDirection.Input);
           // AddCmdParameter("@IdentificationTypeId", objBan.IdentificationTypeId, ParameterDirection.Input);
            AddCmdParameter("@IdentificationNumber", objBan.IdentificationNumber, ParameterDirection.Input);
            AddCmdParameter("@Names", objBan.Names, ParameterDirection.Input);
            //AddCmdParameter("@LastNames", objBan.LastNames, ParameterDirection.Input);
            AddCmdParameter("@ChargeId", objBan.ChargeId, ParameterDirection.Input);
            AddCmdParameter("@Email", objBan.Email, ParameterDirection.Input);
         //   AddCmdParameter("@PhoneNumber", objBan.PhoneNumber, ParameterDirection.Input);
           // AddCmdParameter("@CompanyId", objBan.CompanyId, ParameterDirection.Input);
            AddCmdParameter("@StatusId", objBan.StatusId, ParameterDirection.Input);
           // AddCmdParameter("@DateCreation", objBan.DateCreation, ParameterDirection.Input);
            AddCmdParameter("@UserCreation", objBan.UserCreation, ParameterDirection.Input);
         //   AddCmdParameter("@DateModify", objBan.DateModify, ParameterDirection.Input);
            AddCmdParameter("@UserModify", objBan.UserModify, ParameterDirection.Input);
        }
    }
}


