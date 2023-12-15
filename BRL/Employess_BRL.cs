
using DAL;
using DCL;
using System.Data;

namespace BRL
{
    public class Employess_BRL
    {
        public static Employees Load(Employees objBAN, int Action)
        {
            EmployeesFactory objBANf = new EmployeesFactory();
            return objBANf.Load(objBAN);
        }

        public static EmployeesCollection SelectByParams(Employees objBAN, int Action)
        {
            EmployeesFactory objBANf = new EmployeesFactory();
            return objBANf.SelectByParams(objBAN, Action);
        }

        public static DataTable SelectTable(Employees objBAN, int Action)
        {
            EmployeesFactory objBANf = new EmployeesFactory();
            return objBANf.SelectTable(objBAN, Action);
        }

        public static int InsertarOrUpdate(Employees objBAN, int Action)
        {
            EmployeesFactory objBANf = new EmployeesFactory();
            return objBANf.InsertarOrUpdate(objBAN, Action);
        }
    }
}


