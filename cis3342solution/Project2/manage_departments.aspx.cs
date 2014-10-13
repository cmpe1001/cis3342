using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseRegistrationLibrary;
using Tools;

namespace Project2 {
    public partial class manage_departments : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            updateDepts();
            lblErrorOutput.Visible = false;
        }

        protected void btnCreateDept_Click(object sender, EventArgs e) {
            string name = txtName.Text;
            string id = txtDeptID.Text;
            string location = txtLocation.Text;
            string error = "";

            if(!InputValidation.checkLetters(name)){
                error += "Invalid Name<br />";
            }
            
            if (!InputValidation.checkLetters(id) || id.Length > 3){
                error += "Invalid Department ID<br />";
            }
            
            if (!InputValidation.checkLetters(location)){
                error += "Invalid Location<br />";
            }

            if(error.Length != 0){
                lblErrorOutput.Text = error;
                lblErrorOutput.Visible = true;
            } else {
                Department.createDepartment(id, name, location);
                updateDepts();
            }
        }

        protected void updateDepts(){
            gvDepts.DataSource = Department.departmentList();
            gvDepts.DataBind();
        }
    }
}