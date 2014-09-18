using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Utilities;
using PizzaLibrary;

namespace Project1{
    public partial class pizzaShop : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){
            if (!IsPostBack){
                DBConnect database = new DBConnect();
                string sql = "SELECT * FROM Pizzas";
                DataSet dataset = database.GetDataSet(sql);
                database.CloseConnection();

                gvMenu.DataSource = dataset;
                gvMenu.DataBind();
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e){
            int counter = 0;
            List<Pizza> pizzas = new List<Pizza>();

            for (int i = 0; i < gvMenu.Rows.Count; i++){
                CheckBox checkbox = (CheckBox)gvMenu.Rows[i].FindControl("cbBox");
                TextBox txtQuantity = (TextBox)gvMenu.Rows[i].FindControl("txtQuantity");
                DropDownList drpSize = (DropDownList)gvMenu.Rows[i].FindControl("drpSize");
                
                if (txtQuantity.Text == ""){
                    txtQuantity.Text = "0";
                }

                int size = int.Parse(drpSize.SelectedValue);
                int quantity = int.Parse(txtQuantity.Text);

                if (checkbox.Checked && quantity == 0){
                    quantity = 1;
                    String type = gvMenu.Rows[i].Cells[1].Text;
                    Pizza pizza = new Pizza(size,type, quantity);
                    pizzas.Add(pizza);
                    counter = counter + quantity;
                } else if (checkbox.Checked){
                    String type = gvMenu.Rows[i].Cells[1].Text;
                    Pizza pizza = new Pizza(size, type, quantity);
                    pizzas.Add(pizza);
                    counter = counter + quantity;
                }
            }

            double grandTotal = 0;
            foreach (Pizza pizza in pizzas){
                grandTotal += pizza.getTotal();
                PizzaMath.updateDB(pizza.PizzaType, pizza.Quantity, pizza.getTotal());
            }

            gvOutput.DataSource = pizzas;
            gvOutput.Columns[0].FooterText = "Total:";
            gvOutput.Columns[2].FooterText = counter.ToString();
            gvOutput.Columns[4].FooterText = grandTotal.ToString("C2");
            gvOutput.DataBind();

            lblOutputName.Text = txtName.Text;
            lblOutputAddress.Text = txtAddress.Text;
            lblOutputPhone.Text = txtPhone.Text;
        }

        protected void btnGenerateReport(object sender, EventArgs e){
            DBConnect database = new DBConnect();
            string sql = "SELECT PizzaType, TotalSales, TotalQuantityOrdered FROM Pizzas ORDER BY 'TotalSales' DESC";
            DataSet dataset = database.GetDataSet(sql);
            database.CloseConnection();

            gvReport.DataSource = dataset;
            gvReport.DataBind();
        }
    }
}