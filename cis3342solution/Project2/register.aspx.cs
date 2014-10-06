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
    public partial class register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DBConnect database = new DBConnect();
            string reg_sql = "SELECT * from CourseRegistration";
            string prettyReg_sql = "select Students.StudentID, Students.Name, CourseRegistration.CRN, Course.CourseTitle from Students left join CourseRegistration on CourseRegistration.StudentID = Students.StudentID left join Course on CourseRegistration.CRN = Course.CRN where Name is not null and CourseTitle is not null";
            DataSet prettyReg_dataset = database.GetDataSet(prettyReg_sql);
            DataSet reg_dataset = database.GetDataSet(reg_sql);
            database.CloseConnection();
            
            gvPrettyRegs.DataSource = prettyReg_dataset;
            gvPrettyRegs.DataBind();

            gvRegistrations.DataSource = reg_dataset;
            gvRegistrations.DataBind();
        }

        protected void btnRegCourse_Click(object sender, EventArgs e) {
            CourseRegistrationLibrary.Registration.register(int.Parse(txtCRNReg.Text), int.Parse(txtStudentIDReg.Text));
            Page_Load(this, e);
        }
    }
}