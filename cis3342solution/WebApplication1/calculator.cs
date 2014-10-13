using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1{
    public class calculator{
        public calculator() { }

        public double add(double input1, double input2){
            return (input1 + input2);
        }

        public double subtract(double input1, double input2){
            return (input1 - input2);
        }

        public double multiply(double input1, double input2){
            return (input1 * input2);
        }

        public double divide(double input1, double input2){
            return (input1 / input2);
        }
    }
}