using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTDOMINICANA.Models
{
    public class SalesReport
    {
        public string DATE { get; set; }
        public string PRODUCT_TYPE { get; set; }
        public string PRODUCT { get; set; }
        public string MERCHANT { get; set; }
        public string CASHIER { get; set; }
        public string AMOUNT { get; set; }
        public string MCOMM_COMMISSION { get; set; }
        public string NET_AMOUNT { get; set; }
        public string AUTH_NUMBER { get; set; }
        public string MCOMM_PERCENTAGE { get; set; }
        public string REFERENCE { get; set; }
        public string V_COMISSION { get; set; }
        public string QUANTITY { get; set; }
        public string D_COMISSION { get; set; }
        public int ReportType { get; set; }
        public string PROVIDER { get; set; }

        public SalesReport()
        {

        }


    }
}