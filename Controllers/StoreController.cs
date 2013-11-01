using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTDOMINICANA.Tools;
using UTDOMINICANA.Tools.GlobalMethods;
namespace UTDOMINICANA.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Index()
        {
            if (Session["Login"] != null)
            {
                if (GlobalVariables.cityList == null)
                {
                    UTDOMINICANA.Tools.GlobalMethods.DistributorMethods.getCitys();
                }
                ViewBag.Cities = new SelectList(GlobalVariables.cityList, "ID", "NAME");
                if (GlobalVariables.countryList == null)
                {
                    UTDOMINICANA.Tools.GlobalMethods.DistributorMethods.getCountrys();
                }
                ViewBag.Countries = new SelectList(GlobalVariables.countryList, "ID", "NAME");
                if (GlobalVariables.Billingtypes == null)
                {
                    UTDOMINICANA.Tools.GlobalMethods.DistributorMethods.getBillingTypes();
                }
                ViewBag.BillingTypes = new SelectList(GlobalVariables.Billingtypes, "BILLING_TYPE_ID", "BILLING_TYPE");
                if (GlobalVariables.categories == null)
                {
                    UTDOMINICANA.Tools.GlobalMethods.DistributorMethods.getEntityCategories();
                }
                ViewBag.categories = new SelectList(GlobalVariables.categories, "CATEGORY_ID", "CATEGORY");
                List<SelectListItem> list = new List<SelectListItem>{ new SelectListItem{ Value="1", Text="Activo"}, new SelectListItem(){ Value="2", Text="inactivo"}, new SelectListItem(){Value="3"}};
                ViewBag.status = list;
                if (GlobalVariables.storesAll == null)
                {
                    UTDOMINICANA.Tools.GlobalMethods.StoresMethods.getStoresAll();
                }
                ViewBag.storeList = GlobalVariables.storesAll;
                
                if (GlobalVariables.distribuitorAll == null)
                {
                    UTDOMINICANA.Tools.GlobalMethods.DistributorMethods.getReports();
                }
                ViewBag.distributorList = new SelectList(GlobalVariables.distribuitorAll,"DISTRIBUTOR_ID","DISTRIBUTOR");
                if (GlobalVariables.stateList == null)
                {
                    UTDOMINICANA.Tools.GlobalMethods.DistributorMethods.getStates();
                }
                ViewBag.states = new SelectList(GlobalVariables.stateList,"STATE_ID","STATE");
                if (GlobalVariables.sectorList == null)
                {
                    UTDOMINICANA.Tools.GlobalMethods.DistributorMethods.getSectors();
                }
                ViewBag.sectors = new SelectList(GlobalVariables.sectorList, "SECTOR_ID", "SECTOR");
                return View();
            }
            else
            {
                return Redirect("~/login");
            }
        }
        [HttpPost]
        public JsonResult getStoreByParam(string ID, string NAME, string PHONE, string CITY, string COUNTRY, string PAYMENT_TYPE, string MCATEGORY, string STATUS, string CHAIN, string VENDOR, string DISTRIBUTOR, string RNC)
        {
             UTDWSClient.Interfaces.RspStores store = new UTDWSClient.Interfaces.RspStores() { ID = ID, NAME = NAME, PHONE = PHONE, CITY = CITY, COUNTRY = COUNTRY, PAYMENT_TYPE = PAYMENT_TYPE, MCATEGORY = MCATEGORY, STATUS = STATUS, CHAIN = CHAIN, VENDOR = VENDOR, DISTRIBUTOR = DISTRIBUTOR, RNC = RNC };
             UTDOMINICANA.Tools.GlobalMethods.StoresMethods.getStoreByParam(store);
             if (GlobalVariables.lasRequestResult.Contains("00"))
             {
                 return Json(GlobalVariables.storesAll);
             }
             else
             {
                 return Json("");
             }
            
        }
        [HttpPost]
        public JsonResult getStoreByID(int ID)
        {
             UTDOMINICANA.Tools.GlobalMethods.StoresMethods.getStoreById(ID);
             if (UTDOMINICANA.Tools.GlobalVariables.storeByID != null)
             {
                 return Json(UTDOMINICANA.Tools.GlobalVariables.storeByID);
             }
             else
             {
                 return Json("");
             }
        }
         [HttpPost]
        public JsonResult addStore(string NAME,
            string STATUS,
            string CELL,
            string PHONE,
            string ADDRESS,
            string ADDRESS2,
            string COUNTRY,
            string CITY,
            string DISTRIBUTOR,
            string VENDOR,
            string TERMINAL_TYPE,
            string SLSDAY_LIMIT,
            string SLSWEK_LIMIT,
            string SLSMON_LIMIT,
            string RNC,
            string password,
            string modelpos,
            string serial,
            string rnc,
            string state,
            string sector, 
            string category,
            string codFact,
            string minBalance,
            string CHAIN,
            string lastname,
            string key)
        {
            UTDWSClient.Interfaces.RspStores store = new UTDWSClient.Interfaces.RspStores() {
                NAME = NAME, STATUS = STATUS,
                CELL = CELL, PHONE = PHONE,
                ADDRESS = ADDRESS,
                ADDRESS2 = ADDRESS2,
                COUNTRY = COUNTRY,
                CITY = CITY,
                DISTRIBUTOR = DISTRIBUTOR,
                VENDOR = VENDOR,
                CHAIN = CHAIN,
                TERMINAL_TYPE = TERMINAL_TYPE,
                SLSDAY_LIMIT = Convert.ToDecimal(SLSDAY_LIMIT),
                SLSWEK_LIMIT = Convert.ToDecimal(SLSWEK_LIMIT),
                SLSMON_LIMIT = Convert.ToDecimal(SLSMON_LIMIT),
                RNC = RNC };
           
            UTDOMINICANA.Tools.GlobalMethods.StoresMethods.getStoreByParam(store);
            return Json(GlobalVariables.lasRequestResult);
        }
    }
}
