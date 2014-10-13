using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CourseRegistrationLibrary;
using System.Data;

namespace Project2 {
    public partial class edit_student : System.Web.UI.Page {
        GridViewRow student;
        protected void Page_Load(object sender, EventArgs e) {
            student = (GridViewRow)Session["Student"];
            string name = student.Cells[1].Text.ToString();
            int studentID = int.Parse(student.Cells[2].Text.ToString());
            if (!IsPostBack) {
                txtName.Text = name;
                txtStudentID.Text = studentID.ToString();
            }
            lblRegistered.Text = "Current Registrations for " + lblName.Text + ".";

            updateRegistrations(studentID);
            updateTuition(studentID);
        }

        protected void btnEditStudent_Click(object sender, EventArgs e) {
            Student.modifyStudent(txtName.Text, int.Parse(txtStudentID.Text));
            Response.Redirect("./manage_students.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("./manage_students.aspx");
        }

        protected void gvRegistered_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "dropClass") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvRegistered.Rows[index];
                int CRN = int.Parse(row.Cells[0].Text);
                int StudentID = int.Parse(txtStudentID.Text);
                Registration.dropClass(StudentID, CRN);

                updateRegistrations(StudentID);
                updateTuition(StudentID);
            }
        }

        protected void updateTuition(int studentID) {
            lblTuitionOwed.Text = "You owe : $" + Student.calculateTuition(studentID).ToString();
        }

        protected void updateRegistrations(int StudentID) {
            gvRegistered.DataSource = Registration.currentRegistrations(StudentID);
            gvRegistered.DataBind();
        }

    }
}