using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Utilities;

namespace CourseRegistrationLibrary{
    public class Student{
        int studentID;
        string name;
        float tuitionOwed;

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
            return tools.DBUpdate(sql);
        }

        private static float calculateTuition(int StudentID){
            float tuition = 0;
            string sql = "";
            return tuition;
        }
    }
}