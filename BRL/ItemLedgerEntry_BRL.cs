using DAL;
using DCL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public class ItemLedgerEntry_BRL
    {
        public static ItemLedgerEntry Load(ItemLedgerEntry objBAN, int Action)
        {
            ItemLedgerEntryFactory objBANf = new ItemLedgerEntryFactory();
            return objBANf.Load(objBAN);
        }

        public static ItemLedgerEntryCollection SelectByParams(ItemLedgerEntry objBAN, int Action)
        {
            ItemLedgerEntryFactory objBANf = new ItemLedgerEntryFactory();
            return objBANf.SelectByParams(objBAN, Action);
        }

        public static DataTable SelectTable(ItemLedgerEntry objBAN, int Action)
        {
            ItemLedgerEntryFactory objBANf = new ItemLedgerEntryFactory();
            return objBANf.SelectTable(objBAN, Action);
        }

        public static int InsertarOrUpdate(ItemLedgerEntry objBAN, int Action)
        {
            ItemLedgerEntryFactory objBANf = new ItemLedgerEntryFactory();
            return objBANf.InsertarOrUpdate(objBAN, Action);
        }

    }
}
