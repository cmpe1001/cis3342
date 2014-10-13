using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
        string dayCodeNew = "";
        string timeCodeStart = "00:00";
        string timeCodeEnd = "0:00";
        float credits;
        int maxSeats;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Course"] != null) {
                course = (DataSet)Session["Course"];
                CRN = (int)course.Tables[0].Rows[0][0];
                courseTitle = (string)course.Tables[0].Rows[0][1];
                deptID = (string)course.Tables[0].Rows[0][2];
                section = (string)course.Tables[0].Rows[0][3];
                professor = (string)course.Tables[0].Rows[0][4];
                dayCode = (string)course.Tables[0].Rows[0][5];
                timeCodeStart = course.Tables[0].Rows[0][6].ToString();
                timeCodeEnd = course.Tables[0].Rows[0][7].ToString();
                credits = float.Parse(course.Tables[0].Rows[0][8].ToString());
                maxSeats = (int)course.Tables[0].Rows[0][9];
                Array dayCodeSplit = dayCode.Split(',');
                string[] timeCodeStartSplit = timeCodeStart.Split(':');
                string[] timeCodeEndSplit = timeCodeEnd.Split(':');

                if(!IsPostBack){
                    drpStartHours.SelectedValue = timeCodeStartSplit[0];
                    drpStartMinutes.SelectedValue = timeCodeStartSplit[1];
                    if(int.Parse(timeCodeStartSplit[0]) > 12){
                        drpStartAMPM.SelectedValue = "12";
                    }

                    drpEndHours.SelectedValue = timeCodeEndSplit[0];
                    drpEndMinutes.SelectedValue = timeCodeEndSplit[1];
                    if(int.Parse(timeCodeEndSplit[0]) > 12){
                        drpEndAMPM.SelectedValue = "12";
                    }

                }

                if (!IsPostBack){
                    foreach (string item in dayCodeSplit) {
                        foreach (ListItem checkBox in chkDayCode.Items) {
                            if (item == checkBox.Value) {
                                checkBox.Selected = true;
                            }
                        }
                    }
                }
            }

            if (!IsPostBack) {
                DataSet departments = Department.departmentList();

                drpDeptID.DataSource = departments;
                drpDeptID.DataTextField = "DeptName";
                drpDeptID.DataValueField = "DeptID";
                drpDeptID.DataBind();

                txtCRN.Text = CRN.ToString();
                txtCourseTitle.Text = courseTitle;
                drpDeptID.SelectedValue = deptID;
                txtSection.Text = section;
                txtProf.Text = professor;
                
                string[] timeCodeStartSplit = timeCodeStart.Split(':');
                string[] timeCodeEndSplit = timeCodeEnd.Split(':');
                
                drpStartHours.SelectedValue = timeCodeStartSplit[0];
                drpStartMinutes.SelectedValue = timeCodeStartSplit[1];
                if(int.Parse(timeCodeStartSplit[0]) > 12){
                    drpStartAMPM.SelectedValue = "12";
                    drpStartHours.SelectedValue = (int.Parse(timeCodeStartSplit[0]) - 12).ToString();
                }

                drpEndHours.SelectedValue = timeCodeEndSplit[0];
                drpEndMinutes.SelectedValue = timeCodeEndSplit[1];
                if(int.Parse(timeCodeEndSplit[0]) > 12){
                    drpEndAMPM.SelectedValue = "12";
                    drpEndHours.SelectedValue = (int.Parse(timeCodeEndSplit[0]) - 12).ToString();
                }

                txtCredits.Text = credits.ToString();
                txtMaxSeats.Text = maxSeats.ToString();
            }

        }

        protected void btnEditCourse_Click(object sender, EventArgs e){
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

            string timeEnd = (int.Parse(drpEndAMPM.SelectedValue)+int.Parse(drpEndHours.SelectedValue)).ToString() + ":" + drpEndMinutes.SelectedValue;
            string timeStart = (int.Parse(drpStartAMPM.SelectedValue)+int.Parse(drpStartHours.SelectedValue)).ToString() + ":" + drpStartMinutes.SelectedValue;

            DateTime endTime;
            if (!DateTime.TryParse(timeEnd, out endTime)) {
                Page_Load(this, e);
            }

            DateTime startTime;
            if (!DateTime.TryParse(timeStart, out startTime)) {
                Page_Load(this, e);
            }

            float creditsNew;
            if(!float.TryParse(txtCredits.Text, out creditsNew)){
                Page_Load(this, e);
            }

            int maxSeatsNew;
            if (!int.TryParse(txtMaxSeats.Text, out maxSeatsNew)) {
                Page_Load(this, e);
            }

            lblMaxSeats.Text = txtMaxSeats.Text;
            if (txtCourseTitle.Text != courseTitle
                || drpDeptID.SelectedValue != deptID
                || txtSection.Text != section
                || txtProf.Text != professor
                || dayCodeNew != dayCode
                || startTime.ToString() != timeCodeStart
                || endTime.ToString() != timeCodeEnd
                || credits.ToString() != credits.ToString()
                || maxSeatsNew.ToString() != maxSeats.ToString()) {
                    if (Session["Course"] == null) {
                        Course.createCourse(txtCourseTitle.Text, drpDeptID.SelectedValue, txtSection.Text, txtProf.Text, dayCodeNew, startTime, endTime, creditsNew, maxSeatsNew);
                    } else {
                        Course.editCourse(txtCourseTitle.Text, drpDeptID.SelectedValue, txtSection.Text, txtProf.Text, dayCodeNew, timeStart, timeEnd, txtCredits.Text, txtMaxSeats.Text, CRN.ToString());
                    }
            }
            Response.Redirect("./manage_courses.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("./manage_courses.aspx");
        }
    }
}