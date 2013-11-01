using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UTDOMINICANA.Models
{
    public class Stores
    {
        [Display(Name="DIRECCION")]
        [Required(ErrorMessage = "La Direccion es Requerida")]
        public string ADDRESS { get; set; }
        [Display(Name="DIRECCION N2")]
        public string ADDRESS2 { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Se requiere Contrasena")]
        public string PASSWORD {get;set;}
        [Display(Name="BALANCE")]
        public Nullable<decimal> BALANCE { get; set; }
        
        [Display(Name = "FACTURA")]
        public string BILLING_ID { get; set; }
        
        [Display(Name = "CELULAR")]
        public string CELL { get; set; }
        
        [Display(Name = "CADENA")]
        public string CHAIN { get; set; }
        
        [Display(Name = "ID Cadena")]
        public Nullable<int> CHAIN_ID { get; set; }
        
        [Display(Name = "CIUDAD")]
        public string CITY { get; set; }
        
        [Display(Name = "ID CIUDAD")]
        public string CITY_ID { get; set; }
        
        [Display(Name = "NOMBRE COMERCIAL")]
        public string COMERTIAL_NAME { get; set; }
        
        [Display(Name = "PAIS")]
        public string COUNTRY { get; set; }
        
        [Display(Name = "ID Pais")]
        public Nullable<int> COUNTRY_ID { get; set; }
        
        [Display(Name = "ID FACTURA")]
        public string CREATEDBY { get; set; }
        
        public string CREATEDBY_ID { get; set; }
        
        public string DISTRIBUTOR { get; set; }
        
        public Nullable<int> DISTRIBUTOR_ID { get; set; }
        
        public string EMAIL { get; set; }
        
        public string FAX { get; set; }

        
        [Display(Name = "ID")]
        [Required(ErrorMessage="Se requiere")]
        [MinLength(8, ErrorMessage = "Invalid_MinLength")]
        [MaxLength(64, ErrorMessage = "Invalid_MaxLength")]
        public string ID { get; set; }
        
        [Display(Name = "CATEGORIA")]
        public string MCATEGORY { get; set; }
        
        [Display(Name = "ID CATEGORIA")]
        public string MCATEGORY_ID { get; set; }
        
        [Display(Name = "NOMBRE")]
        public string NAME { get; set; }
        
        [Display(Name = "TIPO PAGO")]
        public string PAYMENT_TYPE { get; set; }
        
        [Display(Name = "TELEFONO")]
        public string PHONE { get; set; }
        
        public string RNC { get; set; }
        
        public Nullable<decimal> SLSDAY_LIMIT { get; set; }
        
        public Nullable<decimal> SLSMON_LIMIT { get; set; }
        
        public Nullable<decimal> SLSWEK_LIMIT { get; set; }
        
        [Display(Name = "STATUS")]
        public string STATUS { get; set; }
        
        [Display(Name = "ID STATUS")]
        public Nullable<int> STATUS_ID { get; set; }
        
        public string TERMINAL_TYPE { get; set; }
        
        public Nullable<int> TERMINAL_TYPE_ID { get; set; }
        
        public string VENDOR { get; set; }
        
        public Nullable<int> VENDOR_ID { get; set; }
  

    }
}