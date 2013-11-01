using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UTDOMINICANA.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index(string username, string password,string messague)
        {
            if (username == "" || username == null ||password=="" ||password==null)
            {
                return View();
            }
            else
            {
                UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
                r = UTDWSClient.WSClient.Login(username, password);
                if (r.RSP_CODE == "00")
                {
                    Session["Login"] = r;
                    return Redirect("/Distribuitors");
                }
                else
                {
                    TempData["loginMessague"] = "Combinacion usuar. contra. no son correctas";
                    return View();
                }
            }
        }
        [HttpPost]
        public JsonResult logOut()
        {
            Session["Login"] = null;
            string trues = "true";
            var istrue = trues;
            return Json(istrue);
        }

    }
}
