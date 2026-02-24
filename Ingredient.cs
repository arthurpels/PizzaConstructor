using System;

namespace PizzaConstructor{
    public class Ingredient : Product
    {
        public Ingredient(string name, decimal price) : base(name, price){}
        

        public override string ToString()
        {
            return $"{Name} (Стоимость: {Price} руб.)";
        }
    }
}