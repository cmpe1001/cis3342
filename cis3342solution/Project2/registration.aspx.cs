using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CourseRegistrationLibrary;

namespace Project2 {
    public partial class create_student : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                DataSet departments = Department.departmentList();
                drpDepartment.DataSource = departments;
                drpDepartment.DataTextField = "DeptName";
                drpDepartment.DataValueField = "DeptID";
                drpDepartment.DataBind();
            }
        }

        protected void gvRegistration_RowCommand(object sender, GridViewCommandEventArgs e) {
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            string dayCodeNew = "";
            foreach (ListItem item in chkDayCode.Items) {
                if (item.Selected) {
                    if (dayCodeNew.Length == 0) {
                        dayCodeNew = item.Value;
                    } else {
                        dayCodeNew += "," + item.Value;
                    }
                }
            }

            List<int> validIDs = new List<int>();
            foreach(DataTable table in Student.getIDs().Tables){
                foreach(DataRow row in table.Rows){
                    foreach(DataColumn column in table.Columns){
                        validIDs.Add(int.Parse(row[column].ToString()));
                    }
                }
            }

            string studentID = txtStudentID.Text;
            if(!Tools.InputValidation.checkNumbers(studentID) || studentID.Length == 0 || !validIDs.Contains(int.Parse(studentID))){
                txtStudentID.Text = "Invalid Input";
                Page_Load(this, e);
                return;
            }

            DataSet results = Course.searchCourse(drpDepartment.SelectedValue, dayCodeNew);
            gvRegistration.DataSource = results;
            gvRegistration.DataBind();

            foreach (GridViewRow row in gvRegistration.Rows){
                Label lblStatus = (Label)row.FindControl("lblStatus");
                Label lblSeats = (Label)row.FindControl("lblSeats");
                CheckBox checkbox = (CheckBox)row.FindControl("chkRegister");
                int CRN = int.Parse(row.Cells[1].Text);
                lblSeats.Text = Course.seatsAvailable(CRN).ToString();
                if (int.Parse(lblSeats.Text) > 0){
                    lblStatus.Text = "Open";
                }else{
                    lblStatus.Text = "Closed";
                    checkbox.Enabled = false;
                }
            }

            lblName.Text = Student.getStudent(int.Parse(txtStudentID.Text))[1].ToString();
            lblDept.Text = drpDepartment.SelectedItem.Text;
            lblName.Visible = true;
            lblDept.Visible = true;
            btnRegister.Visible = true;
        }

        protected void btnRegister_Click(object sender, EventArgs e) {
            int StudentID = int.Parse(txtStudentID.Text);            

            foreach (GridViewRow row in gvRegistration.Rows) {
                CheckBox checkBox = (CheckBox)row.FindControl("chkRegister");
                if (checkBox.Checked) {
                    int CRN = int.Parse(row.Cells[1].Text);
                    checkBox.Checked = false;
                    Registration.register(CRN, StudentID);
                }
            }

            gvRegistration.DataSource = null;
            gvRegistration.DataBind();

            btnRegister.Visible = false;
            lblName.Visible = false;
            lblDept.Visible = false;

            lblRegistered.Text = "Current Registrations for " + lblName.Text + ".";
            lblRegistered.Visible = true;
            gvRegistered.DataSource = Registration.currentRegistrations(StudentID);
            gvRegistered.DataBind();
        }

        protected void gvRegistered_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "dropClass") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvRegistered.Rows[index];
                int CRN = int.Parse(row.Cells[0].Text);
                int StudentID = int.Parse(txtStudentID.Text);
                Registration.dropClass(StudentID, CRN);

                gvRegistration.DataSource = null;
                gvRegistration.DataBind();

                btnRegister.Visible = false;
                lblName.Visible = false;
                lblDept.Visible = false;

                lblRegistered.Text = "Current Registrations for " + lblName.Text + ".";
                lblRegistered.Visible = true;
                gvRegistered.DataSource = Registration.currentRegistrations(StudentID);
                gvRegistered.DataBind();
            }
        }
    }
}