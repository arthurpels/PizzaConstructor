using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaConstructor
{
    public class PizzaBorder
    {
        public Guid Id {get; private set;}
        public string Name {get; set;}
        public List<Ingredient> Ingredients{get; private set;}
        public List<Pizza> AllowedPizzas {get; private set;}

        public decimal Price
        {
            get {return Ingredients.Sum(i => i.Price);}
        }

        public PizzaBorder(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Ingredients = new List<Ingredient>();
            AllowedPizzas = new List<Pizza>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AllowForPizza(Pizza pizza)
        {
            if (!AllowedPizzas.Contains(pizza))
            {
                AllowedPizzas.Add(pizza);
            }
        }
        public bool IsAllowedFor(Pizza pizza)
        {
            if (AllowedPizzas.Count == 0) return true;
            return AllowedPizzas.Contains(pizza);
        }

        public override string ToString()
        {
            string ingNames = Ingredients.Count > 0 ? string.Join(", ", Ingredients.Select(i => i.Name)) 
                : "без ингредиентов";
            return $"Бортик «{Name}» ({ingNames}) | Стоимость: {Price} руб.";
        }
    }
}