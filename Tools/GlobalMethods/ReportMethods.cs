using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTDWSClient;

namespace UTDOMINICANA.Tools.GlobalMethods
{
    public static class ReportMethods
    {
        public static string sessionResponse;
        public static string sessionID;
        public static string rspCode;
      
        /// <summary>
        /// gets the report from utdwsclient to populate the grids
        /// </summary>
        /// <param name="start">The star date</param>
        /// <param name="end">The end date</param>
        /// <param name="tiendaID">the id of the store</param>
        /// <returns>Returns a list of type {UTDWSClient.Interfaces.RspPaymentReport}</returns>
        public static UTDWSClient.Interfaces.RspPaymentReport getPaymentReports(DateTime start, DateTime end,string storeId="")
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = UTDWSClient.WSClient.Login("00008475", "00008475");
            UTDWSClient.Interfaces.ReportPaymentParams recparam = new UTDWSClient.Interfaces.ReportPaymentParams();
           
            start = start.Subtract(start.TimeOfDay);
            recparam.START = start;
            recparam.END = end.AddHours(23);
            recparam.ENTITY_ID = storeId;
            UTDWSClient.Interfaces.RspPaymentReport reporte = UTDWSClient.Methods.Payment.Report(r.SESSION, recparam);
   
            return reporte;
        }
        /// <summary>
        /// Gets the the sales report from the utdwsclient to populate the tables
        /// </summary>
        /// <param name="start">the start date</param>
        /// <param name="end">the end Date</param>
        /// <param name="productTypeID">the product type id</param>
        /// <param name="productID">the id of the product</param>
        /// <param name="providerID">id of the provider</param>
        /// <param name="chain">the name of the chain</param>
        /// <param name="merchant">the merchant</param>
        /// <returns>Returns a list of type {UTDWSClient.Interfaces.SalesReport_Result}</returns>
        public static List<UTDWSClient.Interfaces.SalesReport_Result> getSalesReport(DateTime start, DateTime end, string productTypeID="0", string productID="0", string providerID="0",string chain="0",string merchant="0")
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = UTDWSClient.WSClient.Login("00008475", "00008475");
            if (r.RSP_CODE is String && r.SESSION is String)
            {
                UTDWSClient.Interfaces.ReportParameters recparam = new UTDWSClient.Interfaces.ReportParameters();
                start = start.Subtract(start.TimeOfDay);
                recparam.START = start;
                recparam.END = end.AddHours(23.99);
                recparam.PRODUCT_TYPE_ID = Convert.ToInt32(productTypeID);
                recparam.PRODUCT_ID = Convert.ToInt32(productID);
                recparam.PROVIDER_ID = Convert.ToInt32(providerID);
                recparam.NUMRECORDS = 50;
                UTDWSClient.Interfaces.RspReportSales report = new UTDWSClient.Interfaces.RspReportSales();
                report = WSClient.ReportSales(r.SESSION, recparam);
                List<UTDWSClient.Interfaces.SalesReport_Result> result = report.RESULT;
           
                if (result.Count > 0)
                {
                    return result;
                }
                
            }
            return null;
        }
        /// <summary>
        /// Gets the the sales report summarized by date from the utdwsclient to populate the tables
        /// </summary>
        /// <param name="start">the start date</param>
        /// <param name="end">the end date</param>
        /// <returns>Returns a list of type {UTDWSClient.Interfaces.SalesReportByDate_Result}</returns>
        public static List<UTDWSClient.Interfaces.SalesReportByDate_Result> getSalesReportBydate(DateTime start ,DateTime end)
        {
            try
            {
                UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
                r = UTDWSClient.WSClient.Login("00008475", "00008475");
                if (r.RSP_CODE is String && r.SESSION is String)
                {
                    UTDWSClient.Interfaces.ReportParameters recparam = new UTDWSClient.Interfaces.ReportParameters();

                    start = start.Subtract(start.TimeOfDay);
                    recparam.START = start;
                    recparam.END = end.AddHours(23.99);


                    UTDWSClient.Interfaces.RspReportSalesByDate report = new UTDWSClient.Interfaces.RspReportSalesByDate();
                    report = WSClient.ReportSalesByDate(r.SESSION, recparam);
                    List<UTDWSClient.Interfaces.SalesReportByDate_Result> result = report.RESULT;
                    return result;
                }
                else
                {
                    return null;
                }
               
            }catch(Exception)
            {
                return null;
            }
        
        }
        /// <summary>
        /// Gets the the sales report summarized by product from the utdwsclient to populate the tables
        /// </summary>
        /// <param name="start">the start date</param>
        /// <param name="end">the end date</param>
        /// <returns>Returns a list of type {UTDWSClient.Interfaces.SalesReportByProduct_Result}</returns>
        public static List<UTDWSClient.Interfaces.SalesReportByProduct_Result> getSalesReportByproduct(DateTime start,DateTime end)
        {

            try
            {
                UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
                r = UTDWSClient.WSClient.Login("00008475", "00008475");
                if (r.RSP_CODE is String && r.SESSION is String)
                {
                    UTDWSClient.Interfaces.ReportParameters recparam = new UTDWSClient.Interfaces.ReportParameters();

                    start = start.Subtract(start.TimeOfDay);
                    recparam.START = start;
                    recparam.END = end.AddHours(23.99);


                    UTDWSClient.Interfaces.RspReportSalesByProduct report = new UTDWSClient.Interfaces.RspReportSalesByProduct();
                    report = WSClient.ReportSalesByProduct(r.SESSION, recparam);
                    List<UTDWSClient.Interfaces.SalesReportByProduct_Result> result = report.RESULT;
                    return result;
                }
                else
                {
                    return null;
                }
              
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <summary>
        /// Gets the the sales report summarized by product Type from the utdwsclient to populate the tables
        /// </summary>
        /// <param name="start">The start date</param>
        /// <param name="end">The end date</param>
        /// <returns>Returns a list of type {UTDWSClient.Interfaces.SalesReportByProductType_Result}</returns>

        public static List<UTDWSClient.Interfaces.SalesReportByProductType_Result> getSalesReportByProductType(DateTime start, DateTime end)
        {


            try
            {
                UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
                r = UTDWSClient.WSClient.Login("00008475", "00008475");
                if (r.RSP_CODE is String && r.SESSION is String)
                {
                    UTDWSClient.Interfaces.ReportParameters recparam = new UTDWSClient.Interfaces.ReportParameters();

                    start = start.Subtract(start.TimeOfDay);
                    recparam.START = start;
                    recparam.END = end.AddHours(23.99);


                    UTDWSClient.Interfaces.RspReportSalesByProductType report = new UTDWSClient.Interfaces.RspReportSalesByProductType();
                    report = WSClient.ReportSalesByProductType(r.SESSION, recparam);
                    List<UTDWSClient.Interfaces.SalesReportByProductType_Result> result = report.RESULT ;
                    return result;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }

            

        }
        /// <summary>
        ///  Gets the the sales report summarized by provider Type from the utdwsclient to populate the tables
        /// </summary>
        /// <param name="start">The start date</param>
        /// <param name="end">The end date</param>
        /// <returns>Returns a list of type {UTDWSClient.Interfaces.SalesReportByProvider_Result} </returns>
        public static List<UTDWSClient.Interfaces.SalesReportByProvider_Result> getSalesReportByProvider(DateTime start, DateTime end)
        {
            try
            {
                UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
                r = UTDWSClient.WSClient.Login("00008475", "00008475");
                if (r.RSP_CODE is String && r.SESSION is String)
                {
                    UTDWSClient.Interfaces.ReportParameters recparam = new UTDWSClient.Interfaces.ReportParameters();
                    start = start.Subtract(start.TimeOfDay);
                    recparam.START = start;
                    recparam.END = end.AddHours(23.99);
                    UTDWSClient.Interfaces.RspReportSalesByProvider report = new UTDWSClient.Interfaces.RspReportSalesByProvider();
                    report = WSClient.ReportSalesByProvider(r.SESSION, recparam);
                    List<UTDWSClient.Interfaces.SalesReportByProvider_Result> result = report.RESULT;
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Gets the the transaccions Report by provider Type from the utdwsclient to populate the tables
        /// </summary>
        /// <param name="start">The start date</param>
        /// <param name="end">The end date</param>
        /// <param name="productId">the id of the product</param>
        /// <param name="type">The type of the product</param>
        /// <param name="numRecords">The number of records</param>
        /// <param name="phonePin">The phone pin</param>
        /// <param name="response">the Response code generate in the transaccion</param>
        /// <param name="authNumber">The number of authentification generated in the transaccion</param>
        /// <returns>returns a list of transaccion of type {UTDWSClient.Interfaces.TransactionList} </returns>
        public static List<UTDWSClient.Interfaces.TransactionList> transaccionsReport(DateTime start, DateTime end, int productId, string type, int numRecords, string phonePin, string response, string authNumber)
        {
             try
            {   UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
                r = UTDWSClient.WSClient.Login("00008475", "00008475");

                if (r.RSP_CODE is String && r.SESSION is String)
                {
                    start = start.Subtract(start.TimeOfDay);
                    UTDWSClient.Interfaces.RecordParameters recparam = new UTDWSClient.Interfaces.RecordParameters() { START = start, END = end.AddHours(23.99), PRODUCT_ID = productId, TYPE = type,
                    NUMRECORDS = numRecords, PHONE_PIN = phonePin, RESPONSE = response, AUTH_NUMBER = authNumber };
                    UTDWSClient.Interfaces.RspReportTransaction trans = new UTDWSClient.Interfaces.RspReportTransaction();
                    trans = WSClient.ReportTransactions(r.SESSION, recparam);
                    List<UTDWSClient.Interfaces.TransactionList> list = trans.TRANSACTION;
                    if (list.Count > 0)
                    {
                        return list;
                    }
                    return null;

                }
                 return null;
            
                } catch (Exception)
                 {

                     return null;
                
                }
        }
        /// <summary>
        /// Gets the the transaccions Report by provider Type from the utdwsclient to populate the tables
        /// </summary>
        /// <returns>Returns a list of products of (utdwsclient.interfaces.product) type</returns>
        public static List<UTDWSClient.Interfaces.Product> getProductsReport()
        {
            try
            {
                UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
                r = UTDWSClient.WSClient.Login("00008475", "00008475");
                UTDWSClient.Interfaces.RspProduct product = WSClient.ProductList(r.SESSION);
                List<UTDWSClient.Interfaces.Product> pList = product.PRODUCT;
                if (pList.Count > 0)
                {
                    return pList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}