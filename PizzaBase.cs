using System;

namespace PizzaConstructor{
    public class PizzaBase : Product
    {

        public bool IsClassic { get; set; }
        
        public PizzaBase(string name, decimal price, bool isClassic = false) : base(name, price) {}

        public override string ToString()
        {
            return $"Основа: {Name} (Стоимость: {Price} руб.)";
        }
    }
}