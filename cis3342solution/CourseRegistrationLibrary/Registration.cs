using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationLibrary {
    public class Registration {
        public static void register(int CRN, int studentID){
            string sql = "INSERT INTO CourseRegistration (StudentID, CRN) VALUES ('" + studentID + "','" + CRN + "')";
            tools.DBCall(sql);
        }
    }
}
