using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTDOMINICANA.Models;
using UTDOMINICANA.Tools;
using PagedList;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Web.UI;
using UTDOMINICANA.Tools.GlobalMethods;

namespace UTDOMINICANA.Controllers
{
    public class DistribuitorsController : Controller
    {
        //
        // GET: /Distribuitors/
       
        List<UTDWSClient.Interfaces.pDistributorList_Result> distri;
        public ActionResult Index(string distributor, string ID, string estatus,int page=1,int resulbypage=10)
        {
            try
            {
                if (Session["Login"] != null)
                {
                    if (GlobalVariables.distribuitorAll == null || GlobalVariables.distribuitorAll.Count() <= 0)
                    {
                        DistributorMethods.getDistributors(1);
                    }

                    if (distributor == "") { distributor = null; } if (estatus == null) { estatus = null; }
                    if (ID == "") { ID = null; }

                    DistributorMethods.getDistributorByParam(page, distributor, ID, estatus);
                    distri = GlobalVariables.distribuitorById;
                    DistributorMethods.getCountrys(); DistributorMethods.getCitys(); DistributorMethods.getStates();
                    DistributorMethods.getEntityCategories();
                    GlobalVariables.numPages = resulbypage;
                    var result = distri;
                    return View(result.ToPagedList(page, resulbypage));
                }
                else
                {
                    return Redirect("~/login");
                }
                
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        
        [HttpPost]
        public JsonResult getDistributorByid(string ID)
        {
            var view = new UTDWSClient.Interfaces.pDistributorList_Result();

            string[] result = { "", "" };
            try
            {
                
                var toquery = GlobalVariables.distribuitorAll;
                if (toquery == null) { DistributorMethods.getReports(); }
                var query = from list in toquery where list.DISTRIBUTOR_ID == Convert.ToInt32(ID) select list;
                if (query.FirstOrDefault().ENTITY_TYPE_ID == null)
                {
                    query.FirstOrDefault().ENTITY_TYPE_ID = 0;
                }
                view = query.FirstOrDefault();
                return Json(view);
            }
            catch
            {
                return Json("");
            }

        }
        
        public class distribuitor
        {
            public string distributor { get; set; }
            public string Representative { get; set; }
            public string PHONE { get; set; }
            public string STATE { get; set; }
            public distribuitor() { }
        }
       
        public FileResult GetExcel()
        {

            if (GlobalVariables.distribuitorById == null)
            {
                DistributorMethods.getDistributors(1);
            }
            List<UTDWSClient.Interfaces.pDistributorList_Result> inret = GlobalVariables.distribuitorById;
            inret = inret.GetRange(0, GlobalVariables.numPages);
            var stream = new MemoryStream();
            var serializar = new XmlSerializer(typeof(List<UTDWSClient.Interfaces.pDistributorList_Result>));
            serializar.Serialize(stream, inret);
            stream.Position = 0;
            return File(stream, "application/vnd.ms-excel", "ReporteDistribuidors.xls");
        }  

        /// <summary>
        ///
        /// </summary>
        /// <param name="nameAdd"></param>
        /// <param name="RepresentateAdd"></param>
        /// <param name="cellAdd"></param>
        /// <param name="AdressAdd"></param>
        /// <param name="AdressAdd2"></param>
        /// <param name="CountryComboAdd"></param>
        /// <param name="StateComboAdd"></param>
        /// <param name="cityComboAdd"></param>
        /// <param name="sectorComboAdd"></param>
        /// <param name="phoneAdd"></param>
        /// <param name="faxAdd"></param>
        /// <param name="emailAdd"></param>
        /// <param name="distributor"></param>
        /// <param name="category"></param>
        /// <param name="userAdd"></param>
        /// <param name="passwordAdd"></param>
        /// <param name="PinAdd"></param>
        /// <param name="nameUserAdd"></param>
        /// <param name="apellidoAdd"></param>
        /// <returns></returns>
       [HttpPost]
        public JsonResult addDistributor(string nameAdd, string RepresentateAdd, string cellAdd, string AdressAdd, string AdressAdd2, string CountryComboAdd, string StateComboAdd, string cityComboAdd, string sectorComboAdd, string phoneAdd, string faxAdd, string emailAdd, string distributor, string category, string userAdd, string passwordAdd, string PinAdd, string nameUserAdd, string apellidoAdd)
        {
            string[] result = {"",""};
           
            try{
                result = DistributorMethods.add(nameAdd, RepresentateAdd, cellAdd, AdressAdd, AdressAdd2, CountryComboAdd, StateComboAdd, cityComboAdd, sectorComboAdd, phoneAdd, faxAdd, emailAdd, distributor, category, userAdd, passwordAdd, PinAdd, nameUserAdd, apellidoAdd);
                modalResult results = new modalResult() { Rcode = result[0], Rmessague = result[1] };
                return Json(results);
            }
            catch (Exception e)
            {
                result[0] = e.Message; result[1] = e.Source;
                modalResult results = new modalResult() { Rcode = result[0], Rmessague = result[1] };
                return Json(results);
            }
        }
        [HttpPost]
       public JsonResult editDistributor(string ID,string nameAdd, string RepresentateAdd, string cellAdd, string AdressAdd, string AdressAdd2, string CountryComboAdd, string StateComboAdd, string cityComboAdd, string sectorComboAdd, string phoneAdd, string faxAdd, string emailAdd, string distributor, string category)
       {

            string[] result = { "", "" };
            try
            {
                result = DistributorMethods.edit(ID, nameAdd, RepresentateAdd, cellAdd, AdressAdd, AdressAdd2, CountryComboAdd, StateComboAdd, cityComboAdd, sectorComboAdd, phoneAdd, faxAdd, emailAdd, distributor, category);
                modalResult results = new modalResult() { Rcode = result[0], Rmessague = result[1] };
                DistributorMethods.getReports();
                return Json(results);
            }
            catch(Exception e)
            {
                result[0] = e.Message; result[1] = e.Source;
                modalResult results = new modalResult() { Rcode = result[0], Rmessague = result[1] };
                return Json(results);
            }
        }
        [HttpPost]
        public JsonResult getCountryList()
        {
            try
            {
                if (GlobalVariables.countryList==null)
                {
                    DistributorMethods.getCountrys();
                }
                var value = GlobalVariables.countryList;
                return Json(value);
            }
            catch
            {
                return Json("");
            }
        }

        [HttpPost]
        public JsonResult getEntyCategories()
        {
            try
            {
                if (GlobalVariables.categories == null)
                {
                    DistributorMethods.getEntityCategories();
                }
                var value = from categories in GlobalVariables.categories where categories.ENTITY_TYPE_ID == 20 select categories;
                return Json(value);
            }
            catch
            {
                return Json("");
            }
        }
        [HttpPost]
        public JsonResult getEntyTypes()
        {
            try
            {
                if (GlobalVariables.Entitytypes == null)
                {
                    DistributorMethods.getEntityTypes();
                }
                var value = from types in GlobalVariables.Entitytypes where types.ENTITY_TYPE_ID == 20 select types;
                return Json(value);
            }
            catch
            {
                return Json("");
            }
        }
        [HttpPost]
        public JsonResult getBillingTypes()
        {
            try
            {
                if (GlobalVariables.Billingtypes == null)
                {
                    DistributorMethods.getBillingTypes();
                }
                var value = from types in GlobalVariables.Billingtypes where types.ENTITY_TYPE_ID == 20 select types;
                return Json(value);
            }
            catch
            {
                return Json("");
            }
        }
        [HttpPost]
        public JsonResult getCategoryTypes()
        {
            try
            {
                if (GlobalVariables.categories == null)
                {
                    DistributorMethods.getEntityCategories();
                }

                var value = from types in GlobalVariables.categories where types.ENTITY_TYPE_ID == 20 select types;
                return Json(value);
            }
            catch
            {
                return Json("");
            }
        }
        
    
        [HttpPost]
        public JsonResult getStateList(int countryID)
        {
            try
            {
                if (GlobalVariables.stateList == null)
                {
                    DistributorMethods.getStates();
                }
                if (countryID == 0)
                {
                    UTDWSClient.Interfaces.RspState state = new UTDWSClient.Interfaces.RspState() { COUNTRY="Elija", COUNTRY_ID=0 };
                    return Json(state);
                }
                var query = from key in GlobalVariables.stateList where key.COUNTRY_ID == countryID select key;
                var value = GlobalVariables.stateList;
                return Json(query);
            }
            catch
            {
                return Json("");
            }
        }
        [HttpPost]
        public JsonResult EditValidation(string name, string representant, string cell, string Address, string Address2, string country, string state, string city, string sector, string phone, string email, string distributor, string category, string user, string paswword, string pin, string nameUser, string lastname)
        {
            string forname="sucessOnLabel", forrepresentant="sucessOnLabel", forcell="sucessOnLabel", fordireccion="sucessOnLabel", forcountry="sucessOnLabel", forstate="sucessOnLabel", forcity="sucessOnLabel", forsector="sucessOnLabel", forphone="sucessOnLabel", foremail="sucessOnLabel", fordistributor="sucessOnLabel", forcategory="sucessOnLabel", foruser="sucessOnLabel", forpaswword="sucessOnLabel", forpin="sucessOnLabel", fornameUser="sucessOnLabel", forlastaname="sucessOnLabel";
            if (name == "" || System.Text.RegularExpressions.Regex.IsMatch(name, @"\d"))
            {
                forname = "errorOnLabel";
            }
            if (cell == "" || !System.Text.RegularExpressions.Regex.IsMatch(cell, @"\d"))
            {
                forcell = "errorOnLabel";
            } if (Address == "" || System.Text.RegularExpressions.Regex.IsMatch(Address, @"\d"))
            {
                fordireccion = "errorOnLabel";
            } if (country == "0")
            {
                forcountry = "errorOnLabel";
            } if (state == "0")
            {
                forstate = "errorOnLabel";
            } if (city == "0")
            {
                forcity = "errorOnLabel";
            } if (email == "" || System.Text.RegularExpressions.Regex.IsMatch(email, @"\d") || !System.Text.RegularExpressions.Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                foremail = "errorOnLabel";
            } if (user == "" || System.Text.RegularExpressions.Regex.IsMatch(user, @"\d"))
            {
                foruser = "errorOnLabel";
            } if (paswword == "" || System.Text.RegularExpressions.Regex.IsMatch(paswword, @"\d"))
            {
                forpaswword = "errorOnLabel";
            } if (pin == "" || !System.Text.RegularExpressions.Regex.IsMatch(pin, @"\d") || !(pin.Count() == 4))
            {
                forpin = "errorOnLabel";
            } if (name == "" || System.Text.RegularExpressions.Regex.IsMatch(name, @"\d"))
                fornameUser = "errorOnLabel"; 
            {
            } if (lastname == "" || System.Text.RegularExpressions.Regex.IsMatch(lastname, @"\d"))
            {
                forlastaname = "errorOnLabel"; 
            }
            if (category == "" || category == "0")
            {
                forcategory = "errorOnLabel";
            }
            if (distributor == "0" || distributor == "")
            {
                fordistributor = "errorOnLabel";
            }

            
            
            string[] styles = { forname, forrepresentant, forcell, fordireccion, forcountry, forstate, forcity, forsector, forphone, foremail, fordistributor, forcategory, foruser, forpaswword, forpin, fornameUser, forlastaname,""};
            foreach (var key in styles) { if (key == "errorOnLabel") { styles[17] ="true"; break; } }
            return Json(styles);
        }
        [HttpPost]
        public JsonResult EditValidation2(string name, string representant, string cell, string Address, string Address2, string country, string state, string city, string sector, string phone, string email, string distributor, string category)
        {
            try
            {
                string forname = "sucessOnLabel", forrepresentant = "sucessOnLabel", forcell = "sucessOnLabel", fordireccion = "sucessOnLabel", forcountry = "sucessOnLabel", forstate = "sucessOnLabel", forcity = "sucessOnLabel", forsector = "sucessOnLabel", forphone = "sucessOnLabel", foremail = "sucessOnLabel", fordistributor = "sucessOnLabel", forcategory = "sucessOnLabel"; /*foruser = "sucessOnLabel", forpaswword = "sucessOnLabel", forpin = "sucessOnLabel", fornameUser = "sucessOnLabel", forlastaname = "sucessOnLabel";*/
                if (name == "" || System.Text.RegularExpressions.Regex.IsMatch(name, @"\d"))
                {
                    forname = "errorOnLabel";
                }
                if (cell == "" || !System.Text.RegularExpressions.Regex.IsMatch(cell, @"^\d+$"))
                {
                    forcell = "errorOnLabel";
                } if (Address == "")
                {
                    fordireccion = "errorOnLabel";
                } if (country == "0" || country=="")
                {
                    forcountry = "errorOnLabel";
                } if (state == "0" || state=="")
                {
                    forstate = "errorOnLabel";
                }
                if (city == "0" || city=="")
                {
                    forcity = "errorOnLabel";
                } if (email == "" || System.Text.RegularExpressions.Regex.IsMatch(email, @"\d") || !System.Text.RegularExpressions.Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    foremail = "errorOnLabel";
                }
                if (category == "" || category == "0")
                {
                    forcategory = "errorOnLabel";
                }
                if (distributor == "0" || distributor == "")
                {
                    fordistributor = "errorOnLabel";
                }

                string[] styles = { forname, forrepresentant, forcell, fordireccion, forcountry, forstate, forcity, forsector, forphone, foremail, fordistributor, forcategory, "" };
                foreach (var key in styles) { if (key == "errorOnLabel") { styles[12] = "true"; break; } }
                return Json(styles);
            }
            catch
            {
                return Json("");
            }
        }
        [HttpPost]
        public JsonResult getSectorList(int stateID)
        {
            if (stateID == 0) { stateID = 1; }
            try
            {
                if (GlobalVariables.sectorList == null)
                {
                    DistributorMethods.getSectors();
                }
                var result = from key in GlobalVariables.sectorList where key.STATE_ID == stateID select key;
                var value = result;
                return Json(value);
            }
            catch
            {
                return Json("");
            }
        }
        [HttpPost]
        public JsonResult getCityList()
        {
            try
            {
                if (GlobalVariables.cityList == null)
                {
                    DistributorMethods.getCitys();
                }
                var value = GlobalVariables.cityList;
                return Json(value);
            }
            catch
            {
                return Json("");
            }
        }



        [HttpPost]
        public JsonResult deleteDistributor(string idDistributor)
        {
           
            return Json("");
        }
    }
    public partial class modalResult
        {
        public string Rcode {get; set;}
         public string Rmessague{get; set;}

        public modalResult()
        {
        }

        }

}
