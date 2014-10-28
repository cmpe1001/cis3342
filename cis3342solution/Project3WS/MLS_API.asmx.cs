using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using MLSLib;

namespace Project3WS{
    /// <summary>
    /// Summary description for MLS_API
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MLS_API : System.Web.Services.WebService{
        [WebMethod]
        public static DataSet searchHomes(string address, string city, string state, float maxPrice, int sqft, string availability, int bedrooms, float bathrooms, string type){
            return Home.searchHomes(address, city, state, maxPrice, sqft, availability, bedrooms, bathrooms, type);
        }

        [WebMethod]
        public static DataSet getHome(int homeID){
            return Home.getHome(homeID);
        }

        [WebMethod]
        public static int deleteHome(int homeID){
            return Home.deleteHome(homeID);
        }

        [WebMethod]
        public static int modifyHome(string address, string city, string state, float listPrice, int sqft, string availability, int bedrooms, double bathrooms, string type, int realtorID, int homeID){
            return Home.modifyHome(address, city, state, listPrice, sqft, availability, bedrooms, bathrooms, type, realtorID, homeID);
        }

        [WebMethod]
        public static int createHome(string address, string city, string state, float listPrice, int sqft, string availability, int bedrooms, double bathrooms, string type, int realtorID){
            return Home.createHome(address, city, state, listPrice, sqft, availability, bedrooms, bathrooms, type, realtorID);
        }

        [WebMethod]
        public static bool createViewings(List<List<object>> homesAndDates, int clientID){
            return HomeShowingRequest.createViewings(homesAndDates, clientID);
        }

        [WebMethod]
        public static int deleteViewing(int hsrID){
            return HomeShowingRequest.deleteViewing(hsrID);
        }

        [WebMethod]
        public static DataSet getRealtors(){
            return Realtor.getRealtors();
        }

        [WebMethod]
        public static DataSet showListings(int realtorID){
            return Realtor.showListings(realtorID);
        }

        [WebMethod]
        public static DataSet getClients(){
            return Client.getClients();
        }
    }
}
