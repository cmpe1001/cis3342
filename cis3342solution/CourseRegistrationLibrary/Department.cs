using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tools;

namespace CourseRegistrationLibrary {
    public static class Department {
        public static void createDepartment(string deptID, string deptName, string location) {
            string sql = "INSERT INTO Department (DeptID, DeptName, Location) VALUES ('" + deptID + "','" + deptName + "','" + location + "')";
            DBAccess.DBUpdate(sql);
        }

        public static DataSet departmentList() {
            string sql = "select DeptID, DeptName from Department";
            DataSet dataset = DBAccess.DBCall(sql);
            return dataset;
        }
    }
}
