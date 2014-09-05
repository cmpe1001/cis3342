using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;

namespace Project1{
    public partial class WebForm1 : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){
            DBConnect database = new DBConnect();
            string sql = "SELECT * FROM Pizzas";
            DataSet dataset = database.GetDataSet(sql);
            gvPizzas.DataSource = dataset;
            gvPizzas.DataBind();
        }
    }
}