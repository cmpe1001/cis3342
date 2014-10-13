using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1{
    public partial class webform01 : System.Web.UI.Page{
        protected void Page_Load(object sender, EventArgs e){
        }

        protected void Button1_Click(object sender, EventArgs e){
            double input1, input2;
            try{
                input1 = Convert.ToDouble(txtInput1.Text);
                input2 = Convert.ToDouble(txtInput2.Text);
            }catch{
                Response.Write("Please enter only numerical values!");
                return;
            }

            
            string function = dropFunction.SelectedValue;
            Object output = null;

            calculator calc = new calculator();

            if (function == "add"){
                output = calc.add(input1, input2);
            }else if (function == "subtract"){
                output = calc.subtract(input1, input2);
            }else if (function == "multiply"){
                output = calc.multiply(input1, input2);
            }else if (function == "divide"){
                output = calc.divide(input1, input2);
            }

            if (output == null){
                txtOutput.Text = "Something has gone terribly wrong";
            }else{
                txtOutput.Text = Convert.ToString(output);
            }
        }
    }
}