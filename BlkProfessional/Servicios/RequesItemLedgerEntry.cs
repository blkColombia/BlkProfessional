using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlkProfessional.Servicios
{
    public class RequesItemLedgerEntry
    {
        public string CodigoCliente { get; set; }
        public int Action { get; set; }
        public string Terminal { get; set; }
        public string LocationCode { get; set; }
        public string Fecha { get; set; }
        public string SourceNo { get; set; }
        
    }
}