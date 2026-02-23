using System;

namespace PizzaConstructor{
    public class Ingredient
    {
        public Guid Id {get; private set;}
        public string Name {get; set;}
        public decimal Price {get; set; }

        public Ingredient(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} (Стоимость: {Price} руб.)";
        }
    }
}