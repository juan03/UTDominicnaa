using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTDOMINICANA.Models;
namespace UTDOMINICANA.Controllers
{
    public class ChainController : Controller
    {
        //
        // GET: /Chain/

        public ActionResult Index()
        {
            Chains chain = new Chains() { name="chain", adress="aroundTheCorner",country="Dominican" };
            List<Chains> listChain = new List<Chains>();
            listChain.Add(chain);
            return View(listChain);
        }

    }
}
