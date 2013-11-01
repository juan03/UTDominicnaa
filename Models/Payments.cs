using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UTDOMINICANA.Models
{
    public class Payments
    {

        [Required]
        [MaxLength]
        public DateTime FECHA { get; set; }
        [Required]
        public string MONTO { get; set; }
        [Required]
        public string TIPO_ENTIDAD { get; set; }
        [Required]
        public string ENTIDAD { get; set; }
        [Required]
        public string DE { get; set; }
        [Required]
        public string PARA { get; set; }
        [Required]
        public string VIEJO_BALANCE { get; set; }
        [Required]
        public string NUEVO_BALANCE { get; set; }
        [Required]
        public string NOTA { get; set; }
        [Required]
        public string USUARIO { get; set; }
        [Required]
        
        public Dictionary<string, int> Tiendas { get; set; }
        public Payments()
        {
        }

    }
}