using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTDOMINICANA.Models;
using UTDOMINICANA.Tools.GlobalMethods;
namespace UTDOMINICANA.Controllers
{
    public class TransactionsReportController : Controller
    {
        //
        // GET: /TransactionsReport/

        public ActionResult Index(string start = "", string end = "", string productID = "0", string type = "", string phone_pin = "", string response = "", string auth_number = "")
        {
            if (end==""||start==""||start == "Fecha" || end == "Fecha") { start = Convert.ToString(DateTime.Now.AddDays(-1)); end = Convert.ToString(DateTime.Now.AddHours(10)); }
            
            var list =ReportMethods.transaccionsReport(Convert.ToDateTime(start),Convert.ToDateTime(end),Convert.ToInt32(productID),type,50,phone_pin,response,auth_number);
            var listTransaccions =  new List<TransaccionModel>();
           if(list!=null){
               foreach (var key in list)
            {
                TransaccionModel trm = new TransaccionModel()
                { DATE = Convert.ToString(key.DATE),
                  TYPE= key.TYPE,
                  PRODUCT = key.PRODUCT,
                  SOURCE = key.SOURCE,
                  AMOUNT = Convert.ToString(key.AMOUNT),
                  AUTH_NUMBER= key.AUTH_NUMBER,
                  Monto_Balance = ("Monto: "+key.AMOUNT+"\n Balance: "+key.BALANCE),
                  Description = "Telefono : "+key.PHONE_PIN+"\n Respuesta: "+key.RESPONSE
                };
                listTransaccions.Add(trm);
            }
            var result = listTransaccions;
            
            return View(result);
        }else{
            var result = listTransaccions;
            return View(result);
    }
        }

    }
}
