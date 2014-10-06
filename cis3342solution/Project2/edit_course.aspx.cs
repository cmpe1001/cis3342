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
    public partial class edit_course : System.Web.UI.Page {
        DataSet course;
        int CRN;
        string courseTitle;
        string deptID;
        string section;
        string professor;
        string dayCode;
        string timecode;
        string timecodeend;
        float credits;
        int maxSeats;

        protected void Page_Load(object sender, EventArgs e) {
            course = (DataSet)Session["Course"];
            CRN = (int)course.Tables[0].Rows[0][0];
            courseTitle = (string)course.Tables[0].Rows[0][1];
            deptID = (string)course.Tables[0].Rows[0][2];
            section = (string)course.Tables[0].Rows[0][3];
            professor = (string)course.Tables[0].Rows[0][4];
            dayCode = (string)course.Tables[0].Rows[0][5];
            timecode = course.Tables[0].Rows[0][6].ToString();
            timecodeend = course.Tables[0].Rows[0][7].ToString();
            credits = float.Parse(course.Tables[0].Rows[0][8].ToString());
            maxSeats = (int)course.Tables[0].Rows[0][9];

            if (!IsPostBack) {
                txtCRN.Text = CRN.ToString();
                txtCourseTitle.Text = courseTitle;
                txtDeptIDCourse.Text = deptID;
                txtSection.Text = section;
                txtProf.Text = professor;
                txtDayCode.Text = dayCode;
                txtTime.Text = timecode;
                txtTimeEnd.Text = timecodeend;
                txtCredits.Text = credits.ToString();
                txtMaxSeats.Text = maxSeats.ToString();
            }
        }

        protected void btnEditCourse_Click(object sender, EventArgs e){
            lblMaxSeats.Text = txtMaxSeats.Text;
            if (txtCourseTitle.Text != courseTitle
                || txtDeptIDCourse.Text != deptID
                || txtSection.Text != section
                || txtProf.Text != professor
                || txtDayCode.Text != dayCode
                || txtTime.Text != timecode
                || txtTimeEnd.Text != timecodeend
                || txtCredits.Text != credits.ToString()
                || txtMaxSeats.Text != maxSeats.ToString()) {
                    string sql = "UPDATE Course SET CourseTitle='" + txtCourseTitle.Text + "', DeptID='" + txtDeptIDCourse.Text + "', Section='" + txtSection.Text + "', Professor='" + txtProf.Text + "', DayCode='" + txtDayCode.Text + "', TimeCode='" + txtTime.Text + "', TimeCodeEnd='" + txtTimeEnd.Text + "', Credits='" + txtCredits.Text + "', MaxSeats='" + txtMaxSeats.Text + "' WHERE CRN='" + txtCRN.Text + "'";
                Course.editCourse(sql);
            }
            Response.Redirect("./course.aspx");
        } 
    }
}