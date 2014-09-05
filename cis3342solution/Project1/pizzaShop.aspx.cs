using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilities;

namespace Project1
{
    public partial class pizzaShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                DBConnect database = new DBConnect();
                string sql = "SELECT * FROM Pizzas";
                DataSet dataset = database.GetDataSet(sql);

                gvMenu.DataSource = dataset;
                gvMenu.DataBind();
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}