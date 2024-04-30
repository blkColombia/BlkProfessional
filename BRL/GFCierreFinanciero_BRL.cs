
using DAL;
using DCL;
using System.Data;

namespace BRL
{
    public class GFCierreFinanciero_BRL
    {
        public static GFCierreFinanciero Load(GFCierreFinanciero objBAN, int Action)
        {
            GFCierreFinancieroFactory objBANf = new GFCierreFinancieroFactory();
            return objBANf.Load(objBAN);
        }

        public static GFCierreFinancieroCollection SelectByParams(GFCierreFinanciero objBAN, int Action)
        {
            GFCierreFinancieroFactory objBANf = new GFCierreFinancieroFactory();
            return objBANf.SelectByParams(objBAN, Action);
        }

        public static DataTable SelectTable(GFCierreFinanciero objBAN, int Action)
        {
            GFCierreFinancieroFactory objBANf = new GFCierreFinancieroFactory();
            return objBANf.SelectTable(objBAN, Action);
        }

        public static int InsertarOrUpdate(GFCierreFinanciero objBAN, int Action)
        {
            GFCierreFinancieroFactory objBANf = new GFCierreFinancieroFactory();
            return objBANf.InsertarOrUpdate(objBAN, Action);
        }
    }
}


