using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Utilities;

namespace PizzaLibrary{
    public class PizzaMath{
        public static double getPrice(string pizzaType, int size) {
            double price = queryPrice(pizzaType) * size;
            return price;
        }

        private static double queryPrice(string pizzaType){
            string sqlQuery = "SELECT BasePrice FROM Pizzas WHERE PizzaType='" + pizzaType + "'";
            double basePrice = double.Parse(DBCall(sqlQuery).Tables[0].Rows[0][0].ToString());
            return basePrice;
        }

        public static void updateDB(string pizzaType, int quantityOrdered, double money){
            DBConnect database = new DBConnect();
            quantityOrdered += getTotalQuantityOrdered(pizzaType);
            money += getTotalSales(pizzaType);
            string sqlQuery = "UPDATE Pizzas SET TotalSales='" + money + "', TotalQuantityOrdered='" + quantityOrdered + "' WHERE PizzaType='" + pizzaType + "'";
            DataSet dataset = database.GetDataSet(sqlQuery);
            database.CloseConnection();
        }

        public static double getTotalSales(string pizzaType) {
            string sqlQuery = "SELECT TotalSales FROM Pizzas WHERE PizzaType='" + pizzaType + "'";
            double totalSales = double.Parse(DBCall(sqlQuery).Tables[0].Rows[0][0].ToString());
            return totalSales;
        }

        public static int getTotalQuantityOrdered(string pizzaType) {
            string sqlQuery = "SELECT TotalQuantityOrdered FROM Pizzas WHERE PizzaType='" + pizzaType + "'";
            int totalQuantityOrdered = int.Parse(DBCall(sqlQuery).Tables[0].Rows[0][0].ToString());
            return totalQuantityOrdered;
        }

        private static DataSet DBCall(string SQL) {
            DBConnect database = new DBConnect();
            DataSet dataset = database.GetDataSet(SQL);
            database.CloseConnection();
            return dataset;
        }
    }
}
