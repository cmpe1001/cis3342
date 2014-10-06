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
    public partial class department : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DBConnect database = new DBConnect();
            string departments_sql = "SELECT * from Department";
            DataSet departments_dataset = database.GetDataSet(departments_sql);
            database.CloseConnection();

            gvDepartments.DataSource = departments_dataset;
            gvDepartments.DataBind();
        }

        protected void btnCreateDepartment_Click(object sender, EventArgs e) {
            CourseRegistrationLibrary.Department department = new Department(txtDeptIDDept.Text, txtDeptName.Text, txtLocation.Text);
            Page_Load(this, e);
        }
    }
}