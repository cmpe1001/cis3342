using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tools;
using Utilities;

namespace MLSLib{
    public class Realtor{
        public static DataSet getRealtor(int clientID){
            string sql = "select * from Realtors where realtorID='"+ clientID.ToString() +"'";
            return DBAccess.DBCall(sql);
        }

        public static DataSet getRealtors(){
            string sql = "select RealtorID, Name from Realtors";
            return DBAccess.DBCall(sql);
        }

        public static int createRealtor(string name, string email, string phone){
            DBConnect database = new DBConnect();
            string sql = "INSERT INTO Realtors (Name, email, Phone) VALUES ('" + name + "','" + email + "', '" + phone + "')";
            database.DoUpdate(sql);
            sql = "SELECT SCOPE_IDENTITY() AS realtorID";
            database.GetDataSet(sql);
            return int.Parse(database.GetField("realtorID", 0).ToString());
        }

        public static int modifyRealtor(string name, string email, string phone, int realtorID){
            string sql = "update Realtors set Name='" + name + "', email='" + email + "', Phone='" + phone + "' where realtorID=" + realtorID.ToString() + "";
            return DBAccess.DBUpdate(sql);
        }

        public static int deleteRealtor(int realtorID){
            string sql = "delete from Realtors where realtorID='" + realtorID.ToString() + "'";
            return DBAccess.DBUpdate(sql);
        }

        public static DataSet showListings(int realtorID){
            string sql = "select Date, Homes.homeID, Address, City, State, Clients.Name, hsrID from HomeShowingRequests left join Homes on Homes.homeID=HomeShowingRequests.homeID left join Clients on Clients.clientID=HomeShowingRequests.clientID where realtorID='"+realtorID.ToString()+"'" ;
            return DBAccess.DBCall(sql);
        }
    }
}
