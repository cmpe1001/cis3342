using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MLSLib;
using System.Data;

namespace MLS_API
{
    /// <summary>
    /// Summary description for MLS_API
    /// </summary>
    [WebService(Namespace = "http://cis-iis2.temple.edu/Fall2014/cis3342_tuf01657/Project3WS/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MLS_API : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet searchHomes(string address, string city, string state, float maxPrice, int sqft, string availability, int bedrooms, float bathrooms, string type){
            return Home.searchHomes(address, city, state, maxPrice, sqft, availability, bedrooms, bathrooms, type);
        }

        [WebMethod]
        public DataSet getHome(int homeID){
            return Home.getHome(homeID);
        }

        [WebMethod]
        public int deleteHome(int homeID){
            return Home.deleteHome(homeID);
        }

        [WebMethod]
        public int modifyHome(string address, string city, string state, float listPrice, int sqft, string availability, int bedrooms, double bathrooms, string type, int realtorID, int homeID){
            return Home.modifyHome(address, city, state, listPrice, sqft, availability, bedrooms, bathrooms, type, realtorID, homeID);
        }

        [WebMethod]
        public int createHome(string address, string city, string state, float listPrice, int sqft, string availability, int bedrooms, double bathrooms, string type, int realtorID){
            return Home.createHome(address, city, state, listPrice, sqft, availability, bedrooms, bathrooms, type, realtorID);
        }

        [WebMethod]
        public bool createViewings(object[] homesAndDates, int clientID){
            return HomeShowingRequest.createViewings(homesAndDates, clientID);
        }

        [WebMethod]
        public int deleteViewing(int hsrID){
            return HomeShowingRequest.deleteViewing(hsrID);
        }

        [WebMethod]
        public DataSet getRealtors(){
            return Realtor.getRealtors();
        }

        [WebMethod]
        public DataSet showListings(int realtorID){
            return Realtor.showListings(realtorID);
        }

        [WebMethod]
        public DataSet getClients(){
            return Client.getClients();
        }

        [WebMethod]
        public int createClient(string name, string phone){
            return Client.createClient(name, phone);
        }
    }
}
