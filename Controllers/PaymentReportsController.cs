using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTDOMINICANA.Models;
using UTDOMINICANA.Tools;
using UTDOMINICANA.Tools.GlobalMethods;
namespace UTDOMINICANA.Controllers
{
    public class PaymentReportsController : Controller
    {
        //
        // GET: /PaymentReports/

        public ActionResult Index(string START="9/06/2013", string END="10/03/2013", string TIENDA="1")
        {
           if (START == "Fecha") { START = Convert.ToString(DateTime.Today.AddHours(-10)); } if (END == "Fecha") { END = Convert.ToString(DateTime.Today); }
           UTDWSClient.Interfaces.RspPaymentReport report= ReportMethods.getPaymentReports(Convert.ToDateTime(START),Convert.ToDateTime(END));
           var listaReporte = new List<Payments>();
           if (report.RESULT != null)
           {
               foreach (var key in report.RESULT)
           {
               listaReporte.Add(new Payments() { FECHA = Convert.ToDateTime(key.TXNDATE), MONTO=Convert.ToString(key.AMOUNT), TIPO_ENTIDAD=key.ENTITY_TYPE, DE=key.FROM, VIEJO_BALANCE = Convert.ToString(key.OLD_BALANCE),NUEVO_BALANCE=Convert.ToString(key.NEW_BALANCE),NOTA=key.NOTE,PARA=key.TO,USUARIO=key.Usuario });
           }
           var reporte = listaReporte;
           return View(reporte);
           }
           return View();
        }
        
        public ActionResult GetReports()
        {
            return View();
        }

        //
        // GET: /PaymentReports/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /PaymentReports/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PaymentReports/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PaymentReports/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PaymentReports/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PaymentReports/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PaymentReports/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
