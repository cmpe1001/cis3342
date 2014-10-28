using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tools;
using Utilities;

namespace MLSLib{
    public class HomeShowingRequest{
        public static DataSet getViewing(int hsrID){
            string sql = "select * from HomeShowingRequests where hsrID='" + hsrID.ToString() + "'";
            return DBAccess.DBCall(sql);
        }

        public static int createViewing(int homeID, int clientID, DateTime date, int realtorID){
            DBConnect database = new DBConnect();
            string sql = "INSERT INTO HomeShowingRequests (homeID, realtorID, clientID, Date) VALUES ('" + homeID.ToString() + "','" + realtorID.ToString() + "', '" + clientID.ToString() + "', '" + date.ToString() + "')";
            database.DoUpdate(sql);
            sql = "SELECT SCOPE_IDENTITY() AS hsrID";
            database.GetDataSet(sql);
            return int.Parse(database.GetField("hsrID", 0).ToString());
        }

        public static int deleteViewing(int hsrID){
            string sql = "delete from HomeShowingRequests where hsrID='"+hsrID.ToString()+"'";
            return DBAccess.DBUpdate(sql);
        }

        public static int modifyViewing(int hsrID, int realtorID, int clientID, DateTime date){
            string sql = "update HomeShowingRequests set realtorID='"+realtorID.ToString()+"', clientID='"+clientID.ToString()+"', Date='"+date.ToString()+"' where hsrID='"+hsrID.ToString()+"'";
            return DBAccess.DBUpdate(sql);
        }

        public static bool createViewings(object[] homesAndDates, int clientID){
            bool output = false;
            foreach(object[] homeAndDate in homesAndDates){
                int homeID = int.Parse(homeAndDate[0].ToString());
                DateTime date = DateTime.Parse(homeAndDate[1].ToString());
                int realtorID = Home.getRealtor(homeID);
                if (createViewing(homeID, clientID, date, realtorID) > 0){
                    output = true;
                }else{
                    output = false;
                    break;
                }
            }
            return output;
        }
    }
}
