﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UTDOMINICANA.Controllers
{
    public class ErrorHandlerController : Controller
    {
        //
        // GET: /ErrorHandler/

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult HttpError500()
        {

            ViewBag.error = "masacote";
            return View();
        }

    }
}
