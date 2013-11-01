using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace UTDOMINICANA.Tools
{
    public static class GlobalVariables
    {

        public static List<UTDWSClient.Interfaces.pDistributorList_Result> distribuitorAll;
        public static List<UTDWSClient.Interfaces.pDistributorList_Result> distribuitorById;
        public static List<UTDWSClient.Interfaces.RspCity> cityList;
        public static List<UTDWSClient.Interfaces.nStoreNewResult> listResult;
        public static List<UTDWSClient.Interfaces.Country> countryList;
        public static List<UTDWSClient.Interfaces.RspState> stateList;
        public static List<UTDWSClient.Interfaces.RspSector> sectorList;
        public static List<UTDWSClient.Interfaces.rspEntitycategory> categories;
        public static List<UTDWSClient.Interfaces.RspEntityType> Entitytypes;
        public static List<UTDWSClient.Interfaces.RspBilling> Billingtypes;
        public static UTDWSClient.Interfaces.RspAccount accountInfo;
        public static List<UTDWSClient.Interfaces.RspStores> storesAll;
        public static UTDWSClient.Interfaces.RspStoresResult storeByID;
        public static string lasRequestResult;
        public static int numPages;
    }
  
    
}