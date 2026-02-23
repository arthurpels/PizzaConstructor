using System;
using System.Collections.Generic;

namespace PizzaConstructor
{
    public class MenuManager
    {
        public List<Ingredient> Ingredients {get; private set;}
        public List<PizzaBase> Bases {get; private set;}
        public MenuManager()
        {
            Ingredients = new List<Ingredient>();
            Bases = new List<PizzaBase>();
        }

        public void CreateIngredient(string name, decimal price)
        {
            Ingredient newIngredient = new Ingredient(name, price);
            Ingredients.Add(newIngredient);
            Console.WriteLine($"[Успешно] Ингредиент «{name}» добавлен в систему.");
        }

        public void PrintIngredients()
        {
            Console.WriteLine("\n--- Список ингредиентов ---");
            if (Ingredients.Count == 0)
            {
                Console.WriteLine("Список ингредиентов пока пуст.");
                return;
            }

            for (int i = 0; i < Ingredients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Ingredients[i].ToString()}");
            }
            Console.WriteLine("---------------------------");
        }

        public void EditIngredient(int index, string newName, decimal newPrice)
        {
            if (index >= 0 && index <= Ingredients.Count)
            {
                Ingredients[index].Name = newName;
                Ingredients[index].Price = newPrice;
                Console.WriteLine($"[Успешно] Ингредиент изменен на «{newName}» ({newPrice} руб.)");
            }
            else
            {
                Console.WriteLine("[Ошибка] Ингредиент с таким номером не найден.");
            }
        }

        public void DeleteIngredient(int index)
        {
            if (index >= 0 && index < Ingredients.Count)
            {
                string name = Ingredients[index].Name;
                Ingredients.RemoveAt(index); 
                Console.WriteLine($"[Успешно] Ингредиент '{name}' удален.");
            }
            else
            {
                Console.WriteLine("[Ошибка] Ингредиент с таким номером не найден.");
            }
        }
    }
}