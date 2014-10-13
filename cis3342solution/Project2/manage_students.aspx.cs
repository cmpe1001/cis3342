using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CourseRegistrationLibrary;
using System.Text.RegularExpressions;
using Tools;

namespace Project2 {
    public partial class manage_students : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void btnCreateStudent_Click(object sender, EventArgs e) {
            string name = txtName.Text;
            if (InputValidation.checkLetters(name)){
                txtName.Text = "";
                lblCreateStudentOutput.Text = "New student " + name + " has been added with Student ID # " + Student.createStudent(name).ToString();
                lblCreateStudentOutput.Visible = true;
            } else {
                txtName.Text = "Invalid Name";
            }
        }

        protected void btnSearchStudents_Click(object sender, EventArgs e) {
            string searchString = txtStudentName.Text;
            if (InputValidation.checkLetters(searchString)) {
                txtStudentName.Text = "";
                gvStudents.DataSource = Student.searchStudents(searchString);
                gvStudents.DataBind();
            } else {
                txtStudentName.Text = "Invalid Name";
            }
        }

        protected void gvStudents_Click(object sender, EventArgs e) {
            Session["Student"] = gvStudents.SelectedRow;
            Response.Redirect("./edit_student.aspx");
        }

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "deleteStudent") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvStudents.Rows[index];
                int StudentID = int.Parse(row.Cells[2].Text.ToString());
                Student.deleteStudent(StudentID);

                gvStudents.DataSource = null;
                gvStudents.DataBind();
            }
        }
    }
}