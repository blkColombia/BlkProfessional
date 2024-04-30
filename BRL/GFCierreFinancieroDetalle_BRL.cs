using DAL;
using DCL;
using System.Data;

namespace BRL
{
    public class GFCierreFinancieroDetalle_BRL
    {
        public static GFCierreFinancieroDetalle Load(GFCierreFinancieroDetalle objBAN, int Action)
        {
            GFCierreFinancieroDetalleFactory objBANf = new GFCierreFinancieroDetalleFactory();
            return objBANf.Load(objBAN);
        }

        public static GFCierreFinancieroDetalleCollection SelectByParams(GFCierreFinancieroDetalle objBAN, int Action)
        {
            GFCierreFinancieroDetalleFactory objBANf = new GFCierreFinancieroDetalleFactory();
            return objBANf.SelectByParams(objBAN, Action);
        }

        public static DataTable SelectTable(GFCierreFinancieroDetalle objBAN, int Action)
        {
            GFCierreFinancieroDetalleFactory objBANf = new GFCierreFinancieroDetalleFactory();
            return objBANf.SelectTable(objBAN, Action);
        }

        public static int InsertarOrUpdate(GFCierreFinancieroDetalle objBAN, int Action)
        {
            GFCierreFinancieroDetalleFactory objBANf = new GFCierreFinancieroDetalleFactory();
            return objBANf.InsertarOrUpdate(objBAN, Action);
        }
    }
}



