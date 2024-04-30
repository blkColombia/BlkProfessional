using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BlkProfessional.Servicios
{
    public class ResponseItemLedgerEntry
    {
        public bool isError { get; set; }
        public string message { get; set; }
        public DataTable data { get; set; }

    }
}