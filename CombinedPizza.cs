using System;
using System.Linq;

namespace PizzaConstructor
{
    public class CombinedPizza : Pizza
    {
        public CombinedPizza(string name, PizzaBase pizzaBase) : base(name, pizzaBase)
        {
        }

        public override decimal Price
        {
            get
            {
                decimal ingredientsCost = Ingredients.Sum(i => i.Price) / 2m; 
                
                decimal borderCost = Border != null ? Border.Price : 0;
                
                return Math.Round(Base.Price + ingredientsCost + borderCost, 2);
            }
        }
    }
}