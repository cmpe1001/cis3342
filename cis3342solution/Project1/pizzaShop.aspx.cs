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
            ordering.Visible = true;
            orderInfo.Visible = false;
            managementReport.Visible = false;
            lblOrderError.Visible = false;
        }

        protected bool inputValidation() {
            bool output = true;
            if (txtName.Text == ""){
                lblErrorName.Visible = true;
                output = false;
            } else { lblErrorName.Visible = false; }

            if (txtAddress.Text == ""){
                lblErrorAddress.Visible = true;
                output = false;
            } else { lblErrorAddress.Visible = false; }

            if (txtPhone.Text  == ""){
                lblErrorPhone.Visible = true;
                output = false;
            } else { lblErrorPhone.Visible = false; }

            return output;
        }

        protected void btnOrder_Click(object sender, EventArgs e){
            if (!inputValidation()) {
                Page_Load(this, e);
                return;
            }

            ordering.Visible = false;
            orderInfo.Visible = true;
            managementReport.Visible = false;

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

                if (checkbox.Checked && quantity != 0){
                    String type = gvMenu.Rows[i].Cells[1].Text;
                    Pizza pizza = new Pizza(size,type, quantity);
                    pizzas.Add(pizza);
                    counter = counter + quantity;
                } else if (checkbox.Checked && quantity == 0) {
                    Page_Load(this, e);
                    lblOrderError.Text = "You selected a pizza but not a quantity!";
                    lblOrderError.Visible = true;
                    return;
                }
            }

            if (counter < 1) {
                lblOrderError.Text = "You didn't order any pizzas!";
                Page_Load(this, e);
                lblOrderError.Visible = true;
                return;
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

            ordering.Visible = false;
            orderInfo.Visible = false;
            managementReport.Visible = true;
        }

        protected void btnGoHome(object sender, EventArgs e){
            DBConnect database = new DBConnect();
            string sql = "SELECT * FROM Pizzas";
            DataSet dataset = database.GetDataSet(sql);
            database.CloseConnection();

            gvMenu.DataSource = dataset;
            gvMenu.DataBind();

            txtAddress.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            Page_Load(this, e);
        }
    }
}