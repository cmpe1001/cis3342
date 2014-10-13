using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tools;

namespace CourseRegistrationLibrary {
    public class Registration {
        public static void register(int CRN, int studentID){
            string sql = "INSERT INTO CourseRegistration (StudentID, CRN) VALUES ('" + studentID + "','" + CRN + "')";
            DBAccess.DBCall(sql);
        }

        public static DataSet currentRegistrations(int StudentID){
            string sql = "select Students.Name, Course.CRN, Course.CourseTitle, Course.DeptID, Course.Section, Course.Professor, Course.DayCode, Course.TimeCode, Course.TimeCodeEnd, Course.Credits from Students left join CourseRegistration on CourseRegistration.StudentID = Students.StudentID left join Course on CourseRegistration.CRN = Course.CRN where Students.StudentID='"+StudentID+"' and CourseTitle is not null";
            DataSet dataset = DBAccess.DBCall(sql);
            return dataset;
        }

        public static DataSet availableClasses(string DayCode, string DeptID){
            string sql = "select * from Course where DayCode like '%" + DayCode +"%' and DeptID like '%" + DeptID +"%'";
            DataSet dataset = DBAccess.DBCall(sql);
            return dataset;
        }

        public static DataSet availableClasses(int StudentID, string DayCode, string DeptID) {
            string sql = "select * from Course where CRN not in (select Course.CRN from Students left join CourseRegistration on CourseRegistration.StudentID = Students.StudentID left join Course on CourseRegistration.CRN = Course.CRN where Students.StudentID!='" + StudentID + "' and CourseTitle is not null) and DayCode like '%" + DayCode + "%' and DeptID like '%" + DeptID + "%'";
            DataSet dataset = DBAccess.DBCall(sql);
            return dataset;
        }

        public static void dropClass(int StudentID, int CRN) {
            string sql = "delete from CourseRegistration where StudentID='"+StudentID+"' and CRN='"+CRN+"'";
            DBAccess.DBUpdate(sql);
        }
    }
}
