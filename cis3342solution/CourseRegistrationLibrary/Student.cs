using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tools;
using Utilities;

namespace CourseRegistrationLibrary{
    public class Student{
        public static int createStudent(string name){
            DBConnect database = new DBConnect();
            string sql = "INSERT INTO Students (Name) VALUES ('" + name + "')";
            database.DoUpdate(sql);
            sql = "SELECT SCOPE_IDENTITY() AS StudentID";
            database.GetDataSet(sql);
            return int.Parse(database.GetField("StudentID", 0).ToString());
        }

        public static int deleteStudent(int StudentID) {
            string sql = "DELETE FROM Students WHERE StudentID='" + StudentID + "'";
            return DBAccess.DBUpdate(sql);
        }

        public static float calculateTuition(int StudentID){
            string sql = "select 300 * (select sum(Credits) from Course where CRN in (select CourseRegistration.CRN from Students left join CourseRegistration on CourseRegistration.StudentID = Students.StudentID left join Course on CourseRegistration.CRN = Course.CRN where Students.StudentID='" + StudentID + "' and CourseTitle is not null))";
            DataSet dataset = DBAccess.DBCall(sql);
            string value = dataset.Tables[0].Rows[0][0].ToString();
            if (value == "") {
                float tuition = 0;
                return tuition;
            } else {
                float tuition = float.Parse(dataset.Tables[0].Rows[0][0].ToString());
                return tuition;
            }
        }

        public static DataSet searchStudents(string SearchString) {
            string sql = "select * from Students where Name like '%" + SearchString + "%'";
            DataSet dataset = DBAccess.DBCall(sql);
            return dataset;
        }

        public static void modifyStudent(string name, int StudentID) {
            string sql = "update Students set Name = '" + name + "' where StudentID = '" + StudentID + "'";
            DBAccess.DBUpdate(sql);
        }

        public static DataRow getStudent(int studentID) {
            string sql = "select * from Students where StudentID='" + studentID + "'";
            DataSet dataset = DBAccess.DBCall(sql);
            return dataset.Tables[0].Rows[0];
        }

        public static DataSet getIDs(){
            string sql = "select StudentID from Students";
            DataSet dataset = DBAccess.DBCall(sql);
            return dataset;
        }
    }
}