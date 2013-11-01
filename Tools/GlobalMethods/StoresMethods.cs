using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTDOMINICANA.Tools.GlobalMethods
{
    public static class StoresMethods
    {
        public static void getStoresAll()
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            var result = UTDWSClient.WSClient.StoresGetAll(r.SESSION);
            GlobalVariables.storesAll = result.STORES;
            GlobalVariables.lasRequestResult = "" + result.RSP_CODE + " " + result.RSP_MESSAGE;
        }
        public static void getStoreByParam(UTDWSClient.Interfaces.RspStores store)
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            var result = UTDWSClient.WSClient.StoresGetByParam(r.SESSION, store);
            GlobalVariables.storesAll = result.STORES;
            GlobalVariables.lasRequestResult = "" + result.RSP_CODE + " " + result.RSP_MESSAGE;
        }
        public static void getStoreById(int id)
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            GlobalVariables.storeByID = UTDWSClient.WSClient.StoreGet(r.SESSION, id);
            
        }
        public static void storeAdd(UTDWSClient.Interfaces.RspStores parameters)
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            var result= UTDWSClient.WSClient.StoreNew(r.SESSION,parameters);
            GlobalVariables.lasRequestResult=""+result.RSP_CODE+" "+result.RSP_MESSAGE;
        }
        public static void StoreEdit(UTDWSClient.Interfaces.RspStores parameters)
        {
            UTDWSClient.Interfaces.RspLogin r = new UTDWSClient.Interfaces.RspLogin();
            r = (UTDWSClient.Interfaces.RspLogin)System.Web.HttpContext.Current.Session["Login"];
            var result = UTDWSClient.WSClient.StoreNew(r.SESSION, parameters);
            GlobalVariables.lasRequestResult = "" + result.RSP_CODE + " " + result.RSP_MESSAGE;

        }

    }
}