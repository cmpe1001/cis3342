using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationLibrary {
    public class Department {
        string deptID;
        string deptName;
        string location;

        public Department(string deptID, string deptName, string location) {
            this.deptID = deptID;
            this.deptName = deptName;
            this.location = location;
            string sql = "INSERT INTO Department (DeptID, DeptName, Location) VALUES ('" + deptID + "','" + deptName + "','" + location + "')";
            tools.DBCall(sql);
        }
    }
}
