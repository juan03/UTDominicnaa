using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTDOMINICANA.Models
{
    public class User
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string Email { get; set; }
        public string EntityType { get; set; }
        public string Entity { get; set; }
        public string Estatus { get; set; }

        public User()
        {

        }
    }
}