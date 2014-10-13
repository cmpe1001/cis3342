using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;
using System.Data;
using CourseRegistrationLibrary;

namespace Project2 {
    public partial class manage_courses : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                DataSet departments = Department.departmentList();

                drpSearchList.DataSource = departments;
                drpSearchList.DataTextField = "DeptName";
                drpSearchList.DataValueField = "DeptID";
                drpSearchList.DataBind();
            }
        }

        protected void btnCourseSearch_Click(object sender, EventArgs e) {
            string searchCourse = drpSearchList.SelectedValue.ToString();
            DataSet results = CourseRegistrationLibrary.Course.searchCourse(searchCourse);

            gvSearchResults.DataSource = results;
            gvSearchResults.DataBind();
        }

        protected void gvSearchResults_Click(object sender, EventArgs e) {
            string CRN = gvSearchResults.SelectedRow.Cells[1].Text;
            string sql = "SELECT * FROM Course WHERE CRN='" + CRN + "'";
            Session["Course"] = DBAccess.DBCall(sql);
            Response.Redirect("./edit_course.aspx");
        }

        protected void btnCreateNewCourse_Click(object sender, EventArgs e) {
            Session["Course"] = null;
            Response.Redirect("./edit_course.aspx");
        }

        protected void gvSearchResults_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "deleteCourse") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvSearchResults.Rows[index];
                int CRN = int.Parse(row.Cells[1].Text.ToString());
                Course.deleteCourse(CRN);

                gvSearchResults.DataSource = Course.searchCourse(drpSearchList.SelectedValue);
                gvSearchResults.DataBind();
            }
        }
    }
}