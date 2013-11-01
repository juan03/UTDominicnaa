using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTDOMINICANA.Models;
using UTDOMINICANA.Tools.GlobalMethods;
namespace UTDOMINICANA.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/

        public ActionResult Index()
        { 
            var products = ReportMethods.getProductsReport();
            var listProducts = new List<Productos>();
            foreach(var key in products)
            {  Productos prt = new Productos() { PRODUCT_DESCRIPTION=key.PRODUCT_DESCRIPTION,MIN_VALUE=Convert.ToString(key.MIN_VALUE)
               ,MAX_VALUE=Convert.ToString(key.MAX_VALUE), PRODUCT_TYPE= key.PRODUCT_TYPE,PROVIDER=key.PROVIDER,COMMISSION_MERCHANT=Convert.ToString(key.COMMISSION_MERCHANT),STATUS=key.STATUS};
               listProducts.Add(prt);
            }
            var result = listProducts;
            return View(result);
        }

    }
}
