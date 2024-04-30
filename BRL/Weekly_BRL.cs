using DAL;
using DCL;
using System.Data;

namespace BRL
{
    public class Weekly_BRL
    {
        public static Weekly Load(Weekly objBAN, int Action)
        {
            WeeklyFactory objBANf = new WeeklyFactory();
            return objBANf.Load(objBAN);
        }

        public static WeeklyCollection SelectByParams(Weekly objBAN, int Action)
        {
            WeeklyFactory objBANf = new WeeklyFactory();
            return objBANf.SelectByParams(objBAN, Action);
        }

        public static DataTable SelectTable(Weekly objBAN, int Action)
        {
            WeeklyFactory objBANf = new WeeklyFactory();
            return objBANf.SelectTable(objBAN, Action);
        }

        public static int InsertarOrUpdate(Weekly objBAN, int Action)
        {
            WeeklyFactory objBANf = new WeeklyFactory();
            return objBANf.InsertarOrUpdate(objBAN, Action);
        }
    }
}


