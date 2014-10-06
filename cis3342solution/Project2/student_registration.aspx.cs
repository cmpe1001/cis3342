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
    public partial class student_registration : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                string sql = "select Students.StudentID, Students.Name, CourseRegistration.CRN, Course.CourseTitle from Students left join CourseRegistration on CourseRegistration.StudentID = Students.StudentID left join Course on CourseRegistration.CRN = Course.CRN where Name is not null and CourseTitle is not null";
                DataSet dataset = tools.DBCall(sql);

                gvRegistrations.DataSource = dataset;
                gvRegistrations.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e) {
            string available_sql = "select * from Course where DayCode like '%" + txtDayCode.Text +"%' and DeptID like '%" + txtDeptID.Text +"%'";
            string registered_sql = "select CourseRegistration.CRN from Students left join CourseRegistration on CourseRegistration.StudentID = Students.StudentID left join Course on CourseRegistration.CRN = Course.CRN where Students.StudentID!='" + txtStudentID.Text + "' and CourseTitle is not null";
            DataSet availableCourses = tools.DBCall(available_sql);
            DataSet registeredCourses = tools.DBCall(registered_sql);

            List<Course> courses = new List<Course>();
            foreach (DataTable table in availableCourses.Tables){
                foreach (DataRow row in table.Rows) {
                    if ((int)row[0] == 7) {
                    }
                }
            }
        }
    }
}