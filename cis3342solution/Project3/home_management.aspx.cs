using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Tools;

namespace Project3 {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void btnCreate_Click(object sender, EventArgs e) {
            getRealtors();
            clearHomeFields();
            createModify.Visible = true;
            home_fields.Visible=true;
            search.Visible=false;
            txtHomeID.Enabled=false;
            errorField.Visible=false;
            searchResults.Visible=false;
        }

        protected void btnModify_Click(object sender, EventArgs e) {
            getRealtors();
            createModify.Visible = true;
            errorField.Visible=false;
            modify.Visible=false;
        }

        protected void btnDelete_Click(object sender, EventArgs e) {
            createModify.Visible = false;
            errorField.Visible=false;
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            clearHomeFields();
            createModify.Visible=false;
            home_fields.Visible=true;
            search.Visible=true;
            lblRealtor.Visible=false;
            ddlRealtors.Visible=false;
            searchResults.Visible=false;
            txtHomeID.Enabled=true;
            errorField.Visible=false;
        }

        protected void btnStartSearch_Click(object sender, EventArgs e) {
            errorField.Visible=false;
            searchResults.Visible=true;
            bool error = false;

            getClients();

            int homeID = 0;
            string errorString = "";
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string state = ddlState.SelectedValue.ToString();
            float maxPrice = 0;
            int sqft = 0;
            int bedrooms = 0;
            float bathrooms = 0;
            string type = ddlHomeType.SelectedValue;
            
            if(txtHomeID.Text!="" && InputValidation.checkNumbers(txtHomeID.Text)){
                homeID = int.Parse(txtHomeID.Text);
            }

            if(txtListPrice.Text==""){
                maxPrice = 999999999999;
            }else if(InputValidation.checkDecimals(txtListPrice.Text)){
                maxPrice = float.Parse(txtListPrice.Text);
            }else{
                error = true;
                errorString += "List Price Invalid\n";
            }

            if(txtSqft.Text == ""){
                sqft = 0;
            }else if(InputValidation.checkNumbers(txtSqft.Text)){
                sqft = int.Parse(txtSqft.Text);
            }else{
                error = true;
                errorString += "Square Footage Invalid\n";
            }

            string availability = ddlAvailabilty.SelectedValue.ToString();
            
            if(txtBedrooms.Text == ""){
                bedrooms = 0;
            }else if(InputValidation.checkNumbers(txtBedrooms.Text)){
                bedrooms = int.Parse(txtBedrooms.Text);
            }else{
                error = true;
                errorString += "Bedrooms Invalid\n";
            }

            if(txtBathrooms.Text == ""){
                bathrooms = 0;
            }else if(InputValidation.checkNumbers(txtBathrooms.Text)){
                bathrooms = float.Parse(txtBathrooms.Text);
            }else{
                error = true;
                errorString += "Bathrooms Invalid\n";
            }

            if(!error && homeID==0){
                DataSet searchResultData = MLS_API.searchHomes(address, city, state, maxPrice, sqft, availability, bedrooms, bathrooms, type);
                gvSearchResults.DataSource=searchResultData;
                gvSearchResults.DataBind();
            }else if(homeID!=0){
                DataSet searchResultsData = MLS_API.getHome(homeID);
                gvSearchResults.DataSource = searchResultsData;
                gvSearchResults.DataBind();
            }else{
                errorField.Visible=true;
                lblErrors.Text="These things have gone wrong: \n" + errorString;
                Response.Write(@"<script language='javascript'>alert('"+errorString+"')</script>");
            }
        }

        protected void getRealtors(){
            DataSet realtors = MLS_API.getRealtors();
            ddlRealtors.DataSource = realtors;
            ddlRealtors.DataTextField = "Name";
            ddlRealtors.DataValueField = "RealtorID";
            ddlRealtors.DataBind();
        }

        protected void getClients(){
            DataSet clients = MLS_API.getClients();
            ddlClients.DataSource=clients;
            ddlClients.DataTextField="Name";
            ddlClients.DataValueField="clientID";
            ddlClients.DataBind();
        }

        protected void btnCreateNewListing_Click(object sender, EventArgs e){
            string errorString = "";
            string address = "";
            string city = "";
            string state = "";
            float listPrice = 0;
            int sqft = 0;
            string availability ="";
            int bedrooms = 0;
            float bathrooms = 0;
            string type = "";
            int realtorID = 0;

            if(txtAddress.Text == ""){
                errorString += "Please Enter an Address. \n";
            }else{
                address=txtAddress.Text;
            }

            if(txtCity.Text == ""){
                errorString += "Please enter a City. \n";
            }else{
                city=txtCity.Text;
            }

            if(ddlState.SelectedValue==""){
                errorString += "Please select a State. \n";
            }else{
                state=ddlState.SelectedValue.ToString();
            }

            if(txtListPrice.Text=="" || !InputValidation.checkDecimals(txtListPrice.Text)){
                errorString += "Please enter a Valid Price. \n";
            }else{
                listPrice=float.Parse(txtListPrice.Text);
            }

            if(txtSqft.Text=="" || !InputValidation.checkNumbers(txtSqft.Text)){
                errorString += "Please enter a valid Square Footage. \n";
            }else{
                sqft=int.Parse(txtSqft.Text);
            }

            if(ddlAvailabilty.SelectedValue==""){
                errorString += "Please select an Availability. \n";
            }else{
                availability=ddlAvailabilty.SelectedValue.ToString();
            }

            if(txtBedrooms.Text=="" || !InputValidation.checkNumbers(txtBedrooms.Text)){
                errorString += "Please enter a Valid number of Bedrooms. \n";
            }else{
                bedrooms=int.Parse(txtBedrooms.Text);
            }

            if(txtBathrooms.Text=="" || !InputValidation.checkDecimals(txtBathrooms.Text)){
                errorString += "Please enter a Valid number of Bathrooms. \n";
            }else{
                bathrooms=float.Parse(txtBathrooms.Text);
            }

            if(ddlHomeType.SelectedValue==""){
                errorString += "Please Select a Home Type. \n";
            }else{
                type=ddlHomeType.SelectedValue.ToString();
            }

            realtorID=int.Parse(ddlRealtors.SelectedValue);

            if(errorString.Length == 0){
                int homeID = MLS_API.createHome(address, city, state, listPrice, sqft, availability, bedrooms, bathrooms, type, realtorID);
                errorField.Visible=true;
                lblErrors.Text="Home created with ID# " + homeID.ToString();
                clearHomeFields();
                home_fields.Visible=false;
                searchResults.Visible=true;
                createModify.Visible=false;
                modify.Visible=false;

                DataSet searchResultsData = MLS_API.getHome(homeID);
                gvSearchResults.DataSource = searchResultsData;
                gvSearchResults.DataBind();
            }else{
                errorField.Visible=true;
                lblErrors.Text = "These things have gone wrong: \n" + errorString;
            }
        }

        protected void btnSchedule_Click(object sender, EventArgs e){
            string errorString = "";
            int clientID = int.Parse(ddlClients.SelectedValue);
            List<List<object>> homesAndDates = new List<List<object>>();

            foreach(GridViewRow row in gvSearchResults.Rows){
                CheckBox checkbox = (CheckBox)row.FindControl("chkScheduleViewing");
                DropDownList ddlHour = (DropDownList)row.FindControl("ddlHour");
                DropDownList ddlMinute = (DropDownList)row.FindControl("ddlMinute");
                DropDownList ddlAMPM = (DropDownList)row.FindControl("ddlAMPM");
                DropDownList ddlMonth = (DropDownList)row.FindControl("ddlMonth");
                DropDownList ddlDay = (DropDownList)row.FindControl("ddlDay");
                DropDownList ddlYear = (DropDownList)row.FindControl("ddlYear");

                if(checkbox.Checked){
                    string hour = (int.Parse(ddlHour.SelectedValue) + int.Parse(ddlAMPM.SelectedValue)).ToString();
                    string minute = ddlMinute.SelectedValue;
                    string day = ddlDay.SelectedValue;
                    string month = ddlMonth.SelectedValue;
                    string year = ddlYear.SelectedValue;
                    int homeID = int.Parse(row.Cells[2].Text);
                    string datetime = hour + ":" + minute + "," + month + "/" + day + "/" + year;

                    DateTime dateTime;
                    if(!DateTime.TryParse(datetime, out dateTime)){
                        errorString += "Invalid Date:" + datetime + "  ";
                    }else{
                        List<object> homeAndDate = new List<object>();
                        homeAndDate.Add(homeID);
                        homeAndDate.Add(dateTime);
                        homesAndDates.Add(homeAndDate);
                    }
                }
            }

            if(errorString.Length!=0){
                lblErrors.Text = "You have some errors: " + errorString;
                errorField.Visible=true;
            }else if(!MLS_API.createViewings(homesAndDates, clientID)){
                errorString += "Scheduling did not complete successfully!";
                lblErrors.Text=errorString;
                errorField.Visible=true;
            }else{
                errorString +="Scheduling Successful!";
                lblErrors.Text=errorString;
                errorField.Visible=true;
                foreach(GridViewRow row in gvSearchResults.Rows){
                    CheckBox checkbox = (CheckBox)row.FindControl("chkScheduleViewing");
                    checkbox.Checked=false;
                }
            }
        }

        protected void clearHomeFields(){
            txtAddress.Text = "";
            txtBathrooms.Text = "";
            txtBedrooms.Text = "";
            txtCity.Text = "";
            txtHomeID.Text = "";
            txtListPrice.Text = "";
            txtSqft.Text = "";
            ddlAvailabilty.SelectedValue="";
            ddlHomeType.SelectedValue="";
            ddlState.SelectedValue="";
        }

        protected void gvSearchResults_RowCommand(object sender, GridViewCommandEventArgs e) {
            getRealtors();
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvSearchResults.Rows[index];

            if (e.CommandName == "editListing") {
                txtHomeID.Enabled=false;

                txtHomeID.Text = row.Cells[2].Text;
                txtAddress.Text = row.Cells[3].Text;
                txtCity.Text = row.Cells[4].Text;
                ddlState.SelectedValue=row.Cells[5].Text;
                txtListPrice.Text=row.Cells[6].Text;
                txtSqft.Text=row.Cells[7].Text;
                ddlAvailabilty.SelectedValue=row.Cells[8].Text;
                txtBedrooms.Text=row.Cells[9].Text;
                txtBathrooms.Text=row.Cells[10].Text;
                ddlHomeType.SelectedValue=row.Cells[11].Text;
                ddlRealtors.SelectedValue=row.Cells[12].Text;

                lblRealtor.Visible=true;
                ddlRealtors.Visible=true;
                search.Visible=false;
                searchResults.Visible=false;
                modify.Visible=true;
            }

            if (e.CommandName == "deleteListing"){
                int homeID = int.Parse(row.Cells[2].Text);
                MLS_API.deleteHome(homeID);
                btnSearch_Click(this, e);
            }
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e){
            int homeID = int.Parse(txtHomeID.Text);
            string errorString = "";
            string address = "";
            string city = "";
            string state = "";
            float listPrice = 0;
            int sqft = 0;
            string availability ="";
            int bedrooms = 0;
            float bathrooms = 0;
            string type = "";
            int realtorID = 0;

            if(txtAddress.Text == ""){
                errorString += "Please Enter an Address. \n";
            }else{
                address=txtAddress.Text;
            }

            if(txtCity.Text == ""){
                errorString += "Please enter a City. \n";
            }else{
                city=txtCity.Text;
            }

            if(ddlState.SelectedValue==""){
                errorString += "Please select a State. \n";
            }else{
                state=ddlState.SelectedValue.ToString();
            }

            if(txtListPrice.Text=="" || !InputValidation.checkDecimals(txtListPrice.Text)){
                errorString += "Please enter a Valid Price. \n";
            }else{
                listPrice=float.Parse(txtListPrice.Text);
            }

            if(txtSqft.Text=="" || !InputValidation.checkNumbers(txtSqft.Text)){
                errorString += "Please enter a valid Square Footage. \n";
            }else{
                sqft=int.Parse(txtSqft.Text);
            }

            if(ddlAvailabilty.SelectedValue==""){
                errorString += "Please select an Availability. \n";
            }else{
                availability=ddlAvailabilty.SelectedValue.ToString();
            }

            if(txtBedrooms.Text=="" || !InputValidation.checkNumbers(txtBedrooms.Text)){
                errorString += "Please enter a Valid number of Bedrooms. \n";
            }else{
                bedrooms=int.Parse(txtBedrooms.Text);
            }

            if(txtBathrooms.Text=="" || !InputValidation.checkDecimals(txtBathrooms.Text)){
                errorString += "Please enter a Valid number of Bathrooms. \n";
            }else{
                bathrooms=float.Parse(txtBathrooms.Text);
            }

            if(ddlHomeType.SelectedValue==""){
                errorString += "Please Select a Home Type. \n";
            }else{
                type=ddlHomeType.SelectedValue.ToString();
            }

            realtorID=int.Parse(ddlRealtors.SelectedValue);

            if(errorString.Length == 0){
                MLS_API.modifyHome(address, city, state, listPrice, sqft, availability, bedrooms, bathrooms, type, realtorID, homeID);
                errorField.Visible=true;
                lblErrors.Text="Listing Updated.";
                clearHomeFields();
                home_fields.Visible=false;
                searchResults.Visible=true;
                createModify.Visible=false;
                modify.Visible=false;

                DataSet searchResultsData = MLS_API.getHome(homeID);
                gvSearchResults.DataSource = searchResultsData;
                gvSearchResults.DataBind();
            }else{
                errorField.Visible=true;
                lblErrors.Text = "These things have gone wrong: \n" + errorString;
            }
        }
    }
}