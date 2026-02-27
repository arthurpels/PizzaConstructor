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
        public PizzaSize Size {get; set;} = PizzaSize.Medium;
        public List<Ingredient> Ingredients{get; private set;}

        public PizzaBorder Border {get; set;}
        public decimal Price
        {
            get
            {
                decimal ingredientsCost = Ingredients.Sum(i => i.Price);
                decimal borderCost = Border != null ? Border.Price : 0;
                return Base.Price + ingredientsCost + borderCost;
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
            string sizeStr = Size == PizzaSize.Small ? "Маленькая" : Size == PizzaSize.Medium ? "Средняя" : "Большая";

            string ingredientNames = Ingredients.Count > 0 ? string.Join(", ", Ingredients.Select(i => i.Name)) : "нет дополнительных ингредиентов";

            string borderInfo = Border != null ? $" | {Border.Name}" : " | без бортика";
        
            return $"Пицца «{Name}» | Основа: {Base.Name}{borderInfo} | Ингредиенты: {ingredientNames} | Итого: {Price} руб.";
        }

        public Pizza Clone()
        {
            Pizza copy = new Pizza(this.Name, this.Base);
            copy.Border = this.Border;
            copy.Size = this.Size;

            foreach(var ing in this.Ingredients)
            {
                copy.AddIngredient(ing);
            }
            return copy;
        }
    }
}