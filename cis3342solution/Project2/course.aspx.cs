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
    public partial class create_course : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DBConnect database = new DBConnect();
            string courses_sql = "SELECT * from Course";
            DataSet courses_dataset = database.GetDataSet(courses_sql);
            database.CloseConnection();

            gvCourses.DataSource = courses_dataset;
            gvCourses.DataBind();
        }

        protected void btnCreateCourse_Click(object sender, EventArgs e) {
            CourseRegistrationLibrary.Course course = new Course(txtCourseTitle.Text, txtDeptIDCourse.Text, txtSection.Text, txtProf.Text, txtDayCode.Text, DateTime.Parse(txtTime.Text), DateTime.Parse(txtTimeEnd.Text), float.Parse(txtCredits.Text), int.Parse(txtMaxSeats.Text));
            Page_Load(this, e);
        }

        protected void btnDeleteCourse_Click(object sender, EventArgs e) {
            CourseRegistrationLibrary.Course.deleteCourse(int.Parse(txtCourseCRNtoDelete.Text));
            Page_Load(this, e);
        }

        protected void btnCourseSearch_Click(object sender, EventArgs e) {
            DataSet results = CourseRegistrationLibrary.Course.searchCourse(txtSearch.Text);

            gvSearchResults.DataSource = results;
            gvSearchResults.DataBind();
        }

        protected void gvSearchResults_Click(object sender, EventArgs e) {
            string CRN = gvSearchResults.SelectedRow.Cells[1].Text;
            string sql = "SELECT * FROM Course WHERE CRN='" + CRN + "'";
            Session["Course"] = tools.DBCall(sql);
            Response.Redirect("./edit_course.aspx");
        }
    }
}