using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTDOMINICANA.Models
{
    public class Chains
    {
        public int idGroup { get; set; }
        public string descriptcin { get; set; }
        public string vendor { get; set; }
        public string name { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public double phone { get; set; }
        public string adress { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string rnc { get; set; }
        public double billingId { get; set; }

        public Chains()
        {
        }

    }
}