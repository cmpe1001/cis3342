using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tools;
using Utilities;

namespace MLSLib{
    public class Home{
        public static DataSet getHome(int homeID){
            string sql = "select * from Homes join Realtors on Homes.Realtor=Realtors.RealtorID where homeID='"+homeID.ToString()+"'";
            return DBAccess.DBCall(sql);
        }

        public static int createHome(string address, string city, string state, float listPrice, int sqft, string availability, int bedrooms, double bathrooms, string type, int realtorID){
            DBConnect database = new DBConnect();
            string sql = "insert into Homes (Address, City, State, ListPrice, sqft, Availability, Bedrooms, Bathrooms, Type, Realtor) values ('" + address + "','" + city + "','" + state + "','" + listPrice.ToString() + "','" + sqft.ToString() + "','" + availability + "','" + bedrooms.ToString() + "','" + bathrooms.ToString() + "','" + type.ToString() + "','" + realtorID.ToString() + "')";
            database.DoUpdate(sql);
            sql = "select SCOPE_IDENTITY() as homeID";
            database.GetDataSet(sql);
            return int.Parse(database.GetField("homeID", 0).ToString());
        }

        public static int modifyHome(string address, string city, string state, float listPrice, int sqft, string availability, int bedrooms, double bathrooms, string type, int realtorID, int homeID){
            string sql = "update Homes set Address='" + address + "', City='" + city + "', State='" + state + "', ListPrice='" + listPrice + "', sqft='" + sqft + "', Availability='" + availability + "', Bedrooms='" + bedrooms + "', Bathrooms='" + bathrooms + "', Type='" + type + "', Realtor='" + realtorID.ToString() + "' where homeID='" + homeID + "'";
            return DBAccess.DBUpdate(sql);
        }

        public static int deleteHome(int homeID){
            string sql = "delete from Homes where homeID='" + homeID.ToString() + "'";
            return DBAccess.DBUpdate(sql);
        }

        public static DataSet searchHomes(string address, string city, string state, float maxPrice, int sqft, string availability, int bedrooms, float bathrooms, string type){
            string sql = "select HomeID, Address, City, State, ListPrice, sqft, Availability, Bedrooms, Bathrooms, Type, RealtorID, Name, email, Phone from Homes join Realtors on Homes.Realtor=Realtors.RealtorID where Address like '%"+address+"%' and City like '%"+city+"%' and State like '%"+state+"%' and ListPrice<="+maxPrice.ToString()+" and sqft>="+sqft.ToString()+" and Availability like '%"+availability+"%' and Bedrooms>='"+bedrooms.ToString()+"' and Bathrooms>='"+bathrooms.ToString()+"' and Type like '%"+type+"%'";
            return DBAccess.DBCall(sql);
        }

        public static int getRealtor(int homeID){
            string sql = "select Realtor from Homes where homeID='" + homeID.ToString() + "'";
            return int.Parse(DBAccess.DBCall(sql).Tables[0].Rows[0][0].ToString());
        }
    }
}
