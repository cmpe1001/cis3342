using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tools;
using Utilities;

namespace MLSLib{
    public class Client{
        public static DataSet getClient(int clientID){
            string sql = "select * from Clients where clientID='"+ clientID.ToString() +"'";
            return DBAccess.DBCall(sql);
        }

        public static int createClient(string name, string phone){
            DBConnect database = new DBConnect();
            string sql = "INSERT INTO Clients (Name, Number) VALUES ('" + name + "','" + phone + "')";
            database.DoUpdate(sql);
            sql = "SELECT SCOPE_IDENTITY() AS clientID";
            database.GetDataSet(sql);
            return int.Parse(database.GetField("clientID", 0).ToString());
        }

        public static int modifyClient(string name, string phone, int clientID){
            string sql = "update Clients set Name='" + name + "', Number='" + phone + "' where clientID=" + clientID.ToString() + "";
            return DBAccess.DBUpdate(sql);
        }

        public static int deleteClient(int clientID){
            string sql = "delete from Clients where clientID='" + clientID.ToString() + "'";
            return DBAccess.DBUpdate(sql);
        }

        public static DataSet getClients(){
            string sql = "select clientID, Name from Clients";
            return DBAccess.DBCall(sql);
        }
    }
}
