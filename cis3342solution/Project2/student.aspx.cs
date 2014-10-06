using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using CourseRegistrationLibrary;

namespace Project2 {
    public partial class create_student : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DBConnect database = new DBConnect();
            string students_sql = "SELECT * from Students";
            DataSet students_dataset = database.GetDataSet(students_sql);
            database.CloseConnection();

            gvStudents.DataSource = students_dataset;
            gvStudents.DataBind();
        }

        protected void btnCreateStudent_Click(object sender, EventArgs e) {
            lblNewStudentID.Text = "New Student Name: " + Student.createStudent(txtName.Text).ToString();
            lblNewStudentName.Text = "New Student ID: " + txtName.Text;
            lblNewStudentName.Visible = true;
            lblNewStudentID.Visible = true;
            txtName.Text = "";
        }

        protected void btnDeleteStudent_Click(object sender, EventArgs e) {
            if (Student.deleteStudent(int.Parse(txtStudentIDtoDelete.Text)) == 1) {
                lblDeleteOutput.Text = "Student #" + txtStudentIDtoDelete.Text + " has been deleted.";
                lblDeleteOutput.Visible = true;
            }
        }
    }
}