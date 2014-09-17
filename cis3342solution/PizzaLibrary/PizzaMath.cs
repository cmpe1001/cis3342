using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Utilities;

namespace PizzaLibrary{
    class PizzaMath{
        public static double getPrice(string pizzaType, int size) {
            double price = queryPrice(pizzaType) * size;
            return price;
        }

        private static double queryPrice(string pizzaType){
            DBConnect database = new DBConnect();
            string sqlQuery = "SELECT BasePrice FROM Pizzas WHERE PizzaType='" + pizzaType + "'";
            DataSet dataset = database.GetDataSet(sqlQuery);
            database.CloseConnection();
            double basePrice = double.Parse(dataset.Tables[0].Rows[0][0].ToString());
            return basePrice;
        }
    }
}
