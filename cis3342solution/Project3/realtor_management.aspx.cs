using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project3{
    public partial class realtor_management : System.Web.UI.Page {
        svcMLS.MLS_API MLS_API = new svcMLS.MLS_API();

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack){
                getRealtors();
            }
        }

        protected void getRealtors(){
            DataSet realtors = MLS_API.getRealtors();
            ddlRealtors.DataSource = realtors;
            ddlRealtors.DataTextField = "Name";
            ddlRealtors.DataValueField = "RealtorID";
            ddlRealtors.DataBind();
        }

        protected void btnShowListings_Click(object sender, EventArgs e) {
            int realtorID = int.Parse(ddlRealtors.SelectedValue.ToString());
            DataSet listings = MLS_API.showListings(realtorID);
            gvListings.DataSource=listings;
            gvListings.DataBind();
        }

        protected void gvListings_RowCommand(object sender, GridViewCommandEventArgs e){
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvListings.Rows[index];
            int hsrID = int.Parse(row.Cells[6].Text);

            if (e.CommandName == "cancelViewing") {
                MLS_API.deleteViewing(hsrID);
                btnShowListings_Click(this, e);
            }
        }
    }
}