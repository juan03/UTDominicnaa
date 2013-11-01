using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTDOMINICANA.Models
{
    public class Vendors
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int identificacion { get; set; }
        public string estatus { get; set; }
        public int telefono { get; set; }
        public string email { get; set; }
        public int idFactura { get; set; }
        public string organizacion { get; set; }
        public string distribuidor { get; set; }
        public Vendors() { }
       

    }
}