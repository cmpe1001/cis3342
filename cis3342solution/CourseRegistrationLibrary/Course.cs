using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CourseRegistrationLibrary {
    public class Course {

        public Course(string courseTitle, string deptID, string section, string professor, string dayCode, DateTime timecode, DateTime timecodeend, float credits, int maxSeats) {
            string sql = "INSERT INTO Course (CourseTitle, DeptID, Section, Professor, DayCode, TimeCode, TimeCodeEnd, Credits, MaxSeats) VALUES ('" + courseTitle + "','" + deptID + "','" + section + "','" + professor + "','" + dayCode + "','" + timecode.ToString() + "','" + timecodeend.ToString() + "','" + credits.ToString() + "','" + maxSeats.ToString() + "')";
            tools.DBCall(sql);
        }

        public static void deleteCourse(int CRN) {
            string sql = "DELETE FROM Course WHERE CRN='" + CRN + "'";
            tools.DBCall(sql);
        }

        public static DataSet searchCourse(string searchString) {
            string sql = "SELECT * FROM Course WHERE DeptID LIKE '%" + searchString + "%'";
            DataSet results = tools.DBCall(sql);
            return results;
        }

        public static void editCourse(string sql) {
            tools.DBUpdate(sql);
        }
    }
}