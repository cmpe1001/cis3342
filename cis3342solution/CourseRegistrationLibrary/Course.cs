using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tools;

namespace CourseRegistrationLibrary {
    public class Course {
        public static int createCourse(string courseTitle, string deptID, string section, string professor, string dayCode, DateTime timecode, DateTime timecodeend, float credits, int maxSeats) {
            string sql = "INSERT INTO Course (CourseTitle, DeptID, Section, Professor, DayCode, TimeCode, TimeCodeEnd, Credits, MaxSeats) VALUES ('" + courseTitle + "','" + deptID + "','" + section + "','" + professor + "','" + dayCode + "','" + timecode.ToString() + "','" + timecodeend.ToString() + "','" + credits.ToString() + "','" + maxSeats.ToString() + "')";
            return DBAccess.DBUpdate(sql);
        }

        public static int deleteCourse(int CRN) {
            string sql = "DELETE FROM Course WHERE CRN='" + CRN + "'; DELETE FROM CourseRegistration WHERE CRN='" + CRN + "'";
            return DBAccess.DBUpdate(sql);
        }

        public static DataSet searchCourse(string department) {
            string sql = "SELECT * FROM Course WHERE DeptID LIKE '%" + department + "%'";
            DataSet results = DBAccess.DBCall(sql);
            return results;
        }

        public static DataSet searchCourse(string department, string dayCode) {
            string sql = "SELECT * FROM Course WHERE DeptID LIKE '%" + department + "%' AND DayCode LIKE '%" + dayCode + "%'";
            DataSet results = DBAccess.DBCall(sql);
            return results;
        }

        public static int editCourse(string CourseTitle, string DeptID, string Section, string Prof, string DayCode, string StartTime, string EndTime, string Credits, string MaxSeats, string CRN) {
            string sql = "UPDATE Course SET CourseTitle='" + CourseTitle + "', DeptID='" + DeptID + "', Section='" + Section + "', Professor='" + Prof + "', DayCode='" + DayCode + "', TimeCode='" + StartTime + "', TimeCodeEnd='" + EndTime + "', Credits='" + Credits + "', MaxSeats='" + MaxSeats + "' WHERE CRN='" + CRN + "'";
            return DBAccess.DBUpdate(sql);
        }

        public static int seatsAvailable(int CRN) {
            string sql = "select (select MaxSeats from Course where CRN = '" + CRN + "') - (select count(*) from CourseRegistration where CRN = '" + CRN + "')";
            DataSet dataset = DBAccess.DBCall(sql);
            return int.Parse(dataset.Tables[0].Rows[0][0].ToString());
        }
    }
}