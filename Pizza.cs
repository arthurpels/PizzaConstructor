using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace PizzaConstructor
{
    public class Pizza
    {
        public Guid Id{get; private set;}
        public string Name {get; set;}
        public PizzaBase Base {get; private set;}
        public List<Ingredient> Ingredients{get; private set;}
        public decimal Price
        {
            get
            {
                decimal ingredientsCost = Ingredients.Sum(i => i.Price);
                return Base.Price + ingredientsCost;
            }
        }
    

        public Pizza(string name, PizzaBase pizzaBase)
            {
                Id = Guid.NewGuid();
                Name = name;
                Base = pizzaBase ?? throw new ArgumentNullException(nameof(pizzaBase), "Основа не может быть пустой.");
                Ingredients = new List<Ingredient>();
            }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
        }

        public override string ToString()
        {
            string ingredientNames = Ingredients.Count > 0 ? string.Join(", ", Ingredients.Select(i => i.Name)) : "нет дополнительных ингредиентов";
            return $"Пицца «{Name}» | Основа: {Base.Name} | Ингредиенты: {ingredientNames} | Итоговая стоимость: {Price} руб. ";
        }
    }
}