using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace UTDOMINICANA.Tools.GlobalMethods
{
    public static class DistributorMethods
    {
        public static void accountGet()
        {
            UTDWSClient.Interfaces.RspAccount account = new UTDWSClient.Interfaces.RspAccount();
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            account = UTDWSClient.WSClient.AccountGet(r.SESSION);
            GlobalVariables.accountInfo = account;
        }

        public static void sessionLogOut()
        {
            System.Web.HttpContext.Current.Session["Login"] = null;
        }

        public static string[] edit(string ID, string nameAdd, string RepresentateAdd, string cellAdd, string AdressAdd, string AdressAdd2, string CountryComboAdd, string StateComboAdd, string cityComboAdd, string sectorComboAdd, string phoneAdd, string faxAdd, string emailAdd, string distributor, string category)
        {

            if (ID == "") { ID = "0"; }
            if (CountryComboAdd == "") { CountryComboAdd = "0"; }
            if (StateComboAdd == "") { StateComboAdd = "0"; }
            if (cityComboAdd == "") { cityComboAdd = "0"; }
            if (sectorComboAdd == "") { sectorComboAdd = "0"; }
            if (category == "") { category = "0"; }
            if (distributor == "") { distributor = "0"; }
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            UTDWSClient.Interfaces.RspDistributorParam parameters = new UTDWSClient.Interfaces.RspDistributorParam()
            {

                DISTRIBUTOR = nameAdd,
                REPRESENTATIVE = RepresentateAdd,
                ADDRESS = (AdressAdd),
                ADDRESS2 = (AdressAdd2),
                COUNTRY_ID = Int32.Parse(CountryComboAdd),
                CITY_ID = Int32.Parse(cityComboAdd),
                STATE_ID = Int32.Parse(StateComboAdd),
                SECTOR_ID = Int32.Parse(sectorComboAdd),
                ENTITY_CATEGORY_ID = Int32.Parse(category),
                ENTITY_TYPE_ID = Int32.Parse(distributor),
                FAX = faxAdd,
                EMAIL = (emailAdd),
                PHONE = (phoneAdd),
                CELL = cellAdd,
                MODIFIED_DATE = DateTime.Now,

                DISTRIBUTOR_ID = Int32.Parse(ID)

            };
            UTDWSClient.Interfaces.RspDistribuitorEdit result = UTDWSClient.WSClient.DistribuitorEdit(r.SESSION, parameters);
            string[] array = { Convert.ToString(result.RSP_CODE), Convert.ToString(result.RSP_MESSAGE) };
            return array;

        }
        public static void getDistributorByParam(int? page_size, string distributor, string id, string state)
        {

            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            if (distributor != null && id != null && state != null)
            {
                UTDWSClient.Interfaces.RspDistributorListParam param = new UTDWSClient.Interfaces.RspDistributorListParam() { PAGE_SIZE = page_size ?? 10, DISTRIBUTOR = distributor, STATE_ID = Convert.ToInt32(state), DISTRIBUTOR_ID = Convert.ToInt32(id) };

                GlobalVariables.distribuitorById = UTDWSClient.WSClient.FilterDistributor(r.SESSION, param).DISTRIBUTORS;

            }
            if (distributor == null && id != null && state != null)
            {
                UTDWSClient.Interfaces.RspDistributorListParam param = new UTDWSClient.Interfaces.RspDistributorListParam() { PAGE_SIZE = page_size ?? 10, STATE_ID = Convert.ToInt32(state), DISTRIBUTOR_ID = Convert.ToInt32(id) };

                GlobalVariables.distribuitorById = UTDWSClient.WSClient.FilterDistributor(r.SESSION, param).DISTRIBUTORS;
            }
            if (distributor != null && id == null && state != null)
            {
                UTDWSClient.Interfaces.RspDistributorListParam param = new UTDWSClient.Interfaces.RspDistributorListParam() { PAGE_SIZE = page_size ?? 10, DISTRIBUTOR = distributor, STATE_ID = Convert.ToInt32(state) };

                GlobalVariables.distribuitorById = UTDWSClient.WSClient.FilterDistributor(r.SESSION, param).DISTRIBUTORS;
            }
            if (distributor == null && id == null && state == null)
            {
                UTDWSClient.Interfaces.RspDistributorListParam param = new UTDWSClient.Interfaces.RspDistributorListParam() { PAGE_SIZE = page_size ?? 10 };

                GlobalVariables.distribuitorById = UTDWSClient.WSClient.FilterDistributor(r.SESSION, param).DISTRIBUTORS;
            }
            if (distributor == null && id == null && state != null)
            {
                UTDWSClient.Interfaces.RspDistributorListParam param = new UTDWSClient.Interfaces.RspDistributorListParam() { STATE_ID = Convert.ToInt32(state) };

                GlobalVariables.distribuitorById = UTDWSClient.WSClient.FilterDistributor(r.SESSION, param).DISTRIBUTORS;

            } if (distributor == null && id != null && state == null)
            {
                UTDWSClient.Interfaces.RspDistributorListParam param = new UTDWSClient.Interfaces.RspDistributorListParam() { DISTRIBUTOR_ID = Convert.ToInt32(id) };

                GlobalVariables.distribuitorById = UTDWSClient.WSClient.FilterDistributor(r.SESSION, param).DISTRIBUTORS;

            }




        }
        public static List<UTDWSClient.Interfaces.pDistributorList_Result> getDistributorByID(int id)
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            return UTDWSClient.WSClient.DistributorGet(r.SESSION, id).DISTRIBUTORS;
        }

        public static string[] add(string nameAdd, string RepresentateAdd, string cellAdd, string AdressAdd, string AdressAdd2, string CountryComboAdd, string StateComboAdd, string cityComboAdd, string sectorComboAdd, string phoneAdd, string faxAdd, string emailAdd, string distributor, string category, string userAdd, string passwordAdd, string PinAdd, string nameUserAdd, string apellidoAdd)
        {
            if (string.IsNullOrEmpty(nameAdd)) { nameAdd = null; } if (RepresentateAdd == "") { RepresentateAdd = null; }
            if (string.IsNullOrEmpty(cellAdd)) { cellAdd = null; }
            if (string.IsNullOrEmpty(AdressAdd)) { AdressAdd = null; }
            if (string.IsNullOrEmpty(AdressAdd2)) { AdressAdd2 = null; }
            if (string.IsNullOrEmpty(CountryComboAdd)) { CountryComboAdd = null; }
            if (string.IsNullOrEmpty(StateComboAdd)) { StateComboAdd = null; }
            if (string.IsNullOrEmpty(cityComboAdd)) { cityComboAdd = null; }
            if (sectorComboAdd == "") { sectorComboAdd = null; }
            if (phoneAdd == "") { phoneAdd = null; }
            if (faxAdd == "") { faxAdd = null; }
            if (emailAdd == "") { emailAdd = null; }
            if (distributor == "") { distributor = null; }
            if (category == "") { category = null; }

            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            UTDWSClient.Interfaces.RspDistributorParam parameters = new UTDWSClient.Interfaces.RspDistributorParam()
            {

                DISTRIBUTOR = nameAdd,
                REPRESENTATIVE = RepresentateAdd,
                ADDRESS = (AdressAdd),
                ADDRESS2 = (AdressAdd2),
                COUNTRY_ID = Int32.Parse(CountryComboAdd),
                CITY_ID = Int32.Parse(cityComboAdd),
                STATE_ID = Int32.Parse(StateComboAdd),
                SECTOR_ID = Int32.Parse(sectorComboAdd),
                ENTITY_CATEGORY_ID = Int32.Parse(category),
                ENTITY_TYPE_ID = Int32.Parse(distributor),
                FAX = faxAdd,
                EMAIL = (emailAdd),
                PHONE = (phoneAdd),
                CELL = cellAdd,
                CREATION_DATE = DateTime.Now

            };
            UTDWSClient.Interfaces.rspDistributorResultNew result = UTDWSClient.WSClient.DistribuitorNew(r.SESSION, parameters);
            string[] array = { Convert.ToString(result.RSP_CODE), Convert.ToString(result.RSP_MESSAGE) };
            return array;

        }


        public static List<UTDWSClient.Interfaces.pDistributorList_Result> getReports()
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            GlobalVariables.distribuitorAll = UTDWSClient.Methods.Distribuitor.List(r.SESSION).DISTRIBUTORS;
            return GlobalVariables.distribuitorAll;
        }
        public static List<UTDWSClient.Interfaces.pDistributorList_Result> getDistributors(int id)
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            GlobalVariables.distribuitorAll = UTDWSClient.Methods.Distribuitor.ListByID(r.SESSION, id).DISTRIBUTORS;
            return GlobalVariables.distribuitorById;
        }
        public static string[] getEntityCategories()
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            var categoriesMain = UTDWSClient.WSClient.getCategories(r.SESSION);
            GlobalVariables.categories = categoriesMain.ENTITY_CATEGORIES;
            string[] result = { categoriesMain.RSP_CODE, categoriesMain.RSP_MESSAGE };
            return result;
        }
        public static string[] getEntityTypes()
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            var categoriesMain = UTDWSClient.WSClient.getEntityTypes(r.SESSION);
            GlobalVariables.Entitytypes = categoriesMain.ENTITY_TYPES;
            string[] result = { categoriesMain.RSP_CODE, categoriesMain.RSP_MESSAGE };
            return result;
        }
        public static string[] getBillingTypes()
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            var categoriesMain = UTDWSClient.WSClient.getBillingTypes(r.SESSION);
            GlobalVariables.Billingtypes = categoriesMain.BILLING_TYPES;
            string[] result = { categoriesMain.RSP_CODE, categoriesMain.RSP_MESSAGE };
            return result;
        }
        public static string[] getStates()
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            GlobalVariables.stateList = UTDWSClient.WSClient.getStates(r.SESSION).STATES;
            string[] result = { UTDWSClient.WSClient.getStates(r.SESSION).RSP_CODE, UTDWSClient.WSClient.getStates(r.SESSION).RSP_MESSAGE };
            return result;
        }
        public static string[] getSectors()
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            var sectors = UTDWSClient.WSClient.getSectors(r.SESSION);
            GlobalVariables.sectorList = sectors.SECTORS;
            string[] result = { sectors.RSP_CODE, sectors.RSP_MESSAGE };
            return result;
        }



        public static UTDWSClient.Interfaces.RspDistribuitorsList getReports(string name, int DEALER_STATUS_ID = 0, string adress = "", string adress2 = "", string billingID = "", string cell = "", int cityID = 0, int COUNTRY_ID = 0)
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            UTDWSClient.Interfaces.DistributorParams parameters = new UTDWSClient.Interfaces.DistributorParams()
            {
                NAME = name,
                ADDRESS = adress,
                ADDRESS2 = adress2,
                BILLING_ID = billingID,
                CELL = cell,
                CITY_ID = cityID,
                COUNTRY_ID = COUNTRY_ID,
                DEALER_STATUS_ID = DEALER_STATUS_ID,
            };
            UTDWSClient.Interfaces.RspDistribuitorsList list = new UTDWSClient.Interfaces.RspDistribuitorsList();
            list = UTDWSClient.Methods.Distribuitor.get(r.SESSION, parameters);
            return list;
        }

        public static void getCitys()
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            GlobalVariables.cityList = UTDWSClient.WSClient.getCities(r.SESSION).Cities;
        }
        public static void getCountrys()
        {
            try
            {
                UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
                r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
                GlobalVariables.countryList = UTDWSClient.WSClient.getCountries(r.SESSION).Countries;
            }
            catch
            {

            }
        }

        public static List<UTDWSClient.Interfaces.pDistributorList_Result> getDistributorByName_ID_Status(string name, string id, string status)
        {
            if (name != null && id != null && status != null)
            {
                var result = from distributors in GlobalVariables.distribuitorAll
                             where distributors.DISTRIBUTOR_ID.ToString().Contains(id) && distributors.DISTRIBUTOR.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0 && distributors.ENTITY_STATUS_ID == Convert.ToInt32(status)
                             select distributors;
                return (List<UTDWSClient.Interfaces.pDistributorList_Result>)result;
            }
            if (name == null && id != null && status != null)
            {
                var result = from distributors in GlobalVariables.distribuitorAll
                             where distributors.DISTRIBUTOR_ID.ToString().Contains(id) && distributors.ENTITY_STATUS_ID == Convert.ToInt32(status)
                             select distributors;
                return (List<UTDWSClient.Interfaces.pDistributorList_Result>)result;
            }
            if (name != null && id == null && status != null)
            {
                var result = from distributors in GlobalVariables.distribuitorAll
                             where distributors.DISTRIBUTOR.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0 && distributors.ENTITY_STATUS_ID == Convert.ToInt32(status)
                             select distributors;
                return (List<UTDWSClient.Interfaces.pDistributorList_Result>)result;
            }
            if (name == null && id == null && status == null)
            {
                var result = from distributors in GlobalVariables.distribuitorAll
                             select distributors;
                return (List<UTDWSClient.Interfaces.pDistributorList_Result>)result;
            }
            if (name == null && id == null && status != null)
            {
                var result = from distributors in GlobalVariables.distribuitorAll
                             where distributors.ENTITY_STATUS_ID == Convert.ToInt32(status)
                             select distributors;
                return (List<UTDWSClient.Interfaces.pDistributorList_Result>)result;

            }
            return null;


        }

    }
}