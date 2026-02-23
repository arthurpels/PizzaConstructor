using System;

namespace PizzaConstructor{
    public class PizzaBase
    {
        public Guid Id {get; private set;}
        public string Name {get; set;}
        public decimal Price{get; set;}
        public bool IsClassic{get; set;}

        public PizzaBase(string name, decimal price, bool isClassic = false)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            IsClassic = isClassic;
        }

        public override string ToString()
        {
            return $"Основа: {Name} (Стоимость: {Price} руб.)";
        }
    }
}