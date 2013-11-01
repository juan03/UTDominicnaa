using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTDOMINICANA.Models
{
    public class TransaccionModel
    {
        public string DATE { get; set; }
        public string TYPE { get; set; }
        public string PRODUCT { get; set; }
        public string SOURCE { get; set; }
        public string Monto_Balance { get; set; }
        public string AUTH_NUMBER { get; set; }
        public string AMOUNT { get; set; }
        public string Description { get; set; }
        public TransaccionModel()
        {

        }




    }
}