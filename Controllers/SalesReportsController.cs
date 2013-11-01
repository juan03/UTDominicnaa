using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTDOMINICANA.Models;

using UTDOMINICANA.Tools.GlobalMethods;
namespace UTDOMINICANA.Controllers
{
    public class SalesReportsController : Controller
    {
        public int reportType;
        //
        // GET: /Sales/

        public ActionResult Index(string start = "", string end = "", string product = "0", string productType = "0", string vendor = "0", string merchant = "0", string chain = "0", string Reporte = "0")
        {
            try
            {
                if (start == "" || end == "" || start == "Fecha")
                {
                    start = Convert.ToString(DateTime.Now.AddDays(-1));
                    end = Convert.ToString(DateTime.Now.AddHours(5));
                }
                if (Reporte == "0")
                {

                    return getSalesReportGeneral(start, end, productType, product, chain, merchant);
                }
                else if (Reporte == "1")
                {
                    return getSalesReportBydate(start, end);
                }
                else if (Reporte == "2")
                {
                    return getSalesReportByProduct(start, end);
                }
                else if (Reporte == "3")
                {
                    return getSalesReportByProductType(start, end);
                }
                else if (Reporte == "4")
                {
                    return getSalesReportByProvider(start, end);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }

        }
        public ActionResult getSalesReportGeneral(string start,string end,string productType,string product,string chain,string merchant)
        {
            List<UTDWSClient.Interfaces.SalesReport_Result> report = ReportMethods.getSalesReport(Convert.ToDateTime(start), Convert.ToDateTime(end), productType, product, "0", chain, merchant);
            List<SalesReport> listaSales = new List<SalesReport>();

            foreach (var key in report)
            {
                SalesReport sals = new SalesReport() { DATE = Convert.ToString(key.TXNDATE), AMOUNT = Convert.ToString(key.AMOUNT), PRODUCT_TYPE = key.PRODUCT_TYPE, PRODUCT = key.PRODUCT, MERCHANT = key.MERCHANT, MCOMM_COMMISSION = Convert.ToString(key.MCOMM_COMMISSION), NET_AMOUNT = Convert.ToString(key.NET_AMOUNT), AUTH_NUMBER = Convert.ToString(key.AUTH_NUMBER), MCOMM_PERCENTAGE = Convert.ToString((key.MCOMM_PERCENTAGE) * 100 + "%"), REFERENCE = Convert.ToString(key.REFERENCE) };
                sals.ReportType = 0;
                listaSales.Add(sals);
            }
            var resulList = listaSales;
            return View(resulList);
        }
        public ActionResult getSalesReportBydate(string start,string end)
        {

            List<UTDWSClient.Interfaces.SalesReportByDate_Result> report = ReportMethods.getSalesReportBydate(Convert.ToDateTime(start), Convert.ToDateTime(end));
            List<SalesReport> listaSales = new List<SalesReport>();
            foreach (var key in report)
            {
                SalesReport sales = new SalesReport()
                {
                    DATE = key.DAY,
                    MCOMM_COMMISSION = Convert.ToString(key.M_COMMISSION),
                    AMOUNT = Convert.ToString(key.GROSS_TOTAL),
                    NET_AMOUNT = Convert.ToString(key.NET_AMOUNT)
                    ,
                    V_COMISSION = Convert.ToString(key.V_COMMISSION),
                    QUANTITY = Convert.ToString(key.QUANTITY),
                    D_COMISSION = Convert.ToString(key.D_COMMISSION)
                };
                sales.ReportType = 1;
                listaSales.Add(sales);
            }
            var resultList = listaSales;
            return View(resultList);
        }
        public ActionResult getSalesReportByProduct(string start, string end)
        {
            List<UTDWSClient.Interfaces.SalesReportByProduct_Result> report = ReportMethods.getSalesReportByproduct(Convert.ToDateTime(start), Convert.ToDateTime(end));
            List<SalesReport> listaSales = new List<SalesReport>();
            foreach (var key in report)
            {
                SalesReport sales = new SalesReport()
                {
                    D_COMISSION = Convert.ToString(key.D_COMMISSION),
                    AMOUNT = Convert.ToString(key.GROSS_TOTAL),
                    MCOMM_COMMISSION = Convert.ToString(key.M_COMMISSION),
                    NET_AMOUNT = Convert.ToString(key.NET_AMOUNT),
                    PRODUCT = Convert.ToString(key.PRODUCT),
                    PRODUCT_TYPE = Convert.ToString(key.PRODUCT_TYPE),
                    PROVIDER = Convert.ToString(key.PROVIDER)
                };
                sales.ReportType = 2;
                listaSales.Add(sales);
            }
            return View(listaSales);
        }
        public ActionResult getSalesReportByProductType(string start,string end)
        {
            List<UTDWSClient.Interfaces.SalesReportByProductType_Result> report = ReportMethods.getSalesReportByProductType(Convert.ToDateTime(start), Convert.ToDateTime(end));
            List<SalesReport> listaSales = new List<SalesReport>();
            foreach (var key in report)
            {
                SalesReport sales = new SalesReport()
                {
                    PRODUCT_TYPE = Convert.ToString(key.PRODUCT_TYPE),
                    QUANTITY = Convert.ToString(key.QUANTITY),
                    AMOUNT = Convert.ToString(key.GROSS_TOTAL),
                    MCOMM_COMMISSION = Convert.ToString(key.M_COMMISSION),
                    NET_AMOUNT = Convert.ToString(key.NET_AMOUNT)
                };
                sales.ReportType = 3;
                listaSales.Add(sales);
            }
            var result = listaSales;
            return View(result);
        }
        public ActionResult getSalesReportByProvider(string start, string end)
        {
             List<UTDWSClient.Interfaces.SalesReportByProvider_Result> report = ReportMethods.getSalesReportByProvider(Convert.ToDateTime(start), Convert.ToDateTime(end));
                List<SalesReport> listaReportes = new List<SalesReport>();
                foreach (var key in report)
                {
                    SalesReport sales = new SalesReport()
                    {
                        PROVIDER = key.PROVIDER,
                        AMOUNT = Convert.ToString(key.GROSS_TOTAL),
                        MCOMM_COMMISSION = Convert.ToString(key.M_COMMISSION),
                        NET_AMOUNT = Convert.ToString(key.NET_AMOUNT),
                        QUANTITY = Convert.ToString(key.QUANTITY)


                    };
                    sales.ReportType = 4;
                    listaReportes.Add(sales);
                }
                var result = listaReportes;
                return View(result);
        }
    }
 
}
