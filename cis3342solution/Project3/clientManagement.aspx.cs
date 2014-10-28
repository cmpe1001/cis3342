using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project3{
    public partial class clientManagement : System.Web.UI.Page {
        svcMLS.MLS_API MLS_API = new svcMLS.MLS_API();
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnNewClient_Click(object sender, EventArgs e) {
            clientFields.Visible=true;
            clientTable.Visible=false;
            errorField.Visible=false;
        }

        protected void btnShowClients_Click(object sender, EventArgs e) {
            getClients();
            clientTable.Visible=true;
            clientFields.Visible=false;
            errorField.Visible=false;
        }

        protected void getClients(){
            DataSet clients = MLS_API.getClients();
            gvClients.DataSource=clients;
            gvClients.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            string clientName = txtClientName.Text;
            string clientNumber = txtClientPhone.Text;
            MLS_API.createClient(clientName, clientNumber);
            errorField.Visible=true;
            lblErrors.Text="Client Creation Successful";
            clearFields();
        }

        protected void clearFields(){
            txtClientName.Text="";
            txtClientPhone.Text="";
        }
    }
}