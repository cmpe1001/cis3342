using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary{
    public class Pizza{
        string pizzaType;
        int size;
        double price;
        string textSize;
        int quantity;
        double totalCost;

        public Pizza(int size, string pizzaType, int quantity){
            this.size = size;
            this.pizzaType = pizzaType;
            this.quantity = quantity;
            setPrice();
            getTextSize();
            setTotal();
        }

        public Pizza(string textSize, string pizzaType, int quantity){
            this.textSize = textSize;
            this.pizzaType = pizzaType;
            this.quantity = quantity;
            getSize();
            setPrice();
            setTotal();
        }

        public string PizzaType{
            get { return pizzaType; }
        }

        public double Price{
            get { return price; }
        }

        public int Quantity{
            get { return quantity; }
        }

        public string PizzaSize{
            get { return textSize; }
        }

        public double Total {
            get { return totalCost; }
        }

        public double getTotal() { return totalCost; }

        public void setPizzaType(string pizzaType) { this.pizzaType = pizzaType; }

        public void setPrice(double price) { this.price = price; }

        public void setPizzaTextSize(string textSize) { this.textSize = textSize; }

        public void setPizzaSize(int size) { this.size = size; }

        public override string ToString() {
            string pizza = textSize + " " + pizzaType + " " + price.ToString() + " " + totalCost.ToString();
            return pizza;
        }

        private void setTotal(){ totalCost = price * quantity; }

        private void setPrice() { price = PizzaMath.getPrice(pizzaType, size); }

        private void getTextSize(){
            if (size == 1){
                textSize = "Small";
            }else if (size == 2){
                textSize = "Medium";
            }else{
                textSize = "Large";
            }
        }

        private void getSize(){
            if (textSize == "Small"){
                size = 1;
            }else if (textSize == "Medium"){
                size = 2;
            }else{
                size = 3;
            }
        }
    }
}
