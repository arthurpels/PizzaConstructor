using System;
using System.Collections.Generic;
using System.Linq;

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

        private bool ValidateBasePrice(decimal price, bool isClassic)
        {
            if (isClassic) return true;

            var classicBase = Bases.FirstOrDefault(b => b.IsClassic);

            if (classicBase != null)
            {
                var maxPrice = classicBase.Price * 1.20m;
                if (price > maxPrice)
                {
                    Console.WriteLine($"[Ошибка] Стоимость неклассической основы не может быть больше {maxPrice} руб. (на 20% больше от классической).");
                    return false;
                }
            }

            return true;
        }

        public void CreatePizzaBase(string name, decimal price, bool isClassic)
        {
            if (ValidateBasePrice(price, isClassic))
            {
                PizzaBase newBase = new PizzaBase(name, price, isClassic);
                Bases.Add(newBase);
                Console.WriteLine($"[Успешно] Основа '{name}' добавлена!");
            }
        }

        public void PrintBases()
        {
            Console.WriteLine("\n--- Список основ для пиццы ---");
            if (Bases.Count == 0) { Console.WriteLine("Список пока пуст."); return; }
            for (int i = 0; i < Bases.Count; i++)
            {
                string type = Bases[i].IsClassic ? "[Классика]" : "[Неклассика]";
                Console.WriteLine($"{i + 1}. {type} {Bases[i].ToString()}");
            }
            Console.WriteLine("------------------------------");
        }

        public void EditPizzaBase(int index, string newName, decimal newPrice, bool isClassic)
        {
            if (index >= 0 && index <= Bases.Count)
            {
                if (ValidateBasePrice(newPrice, isClassic))
                {
                    Bases[index].Name = newName;
                    Bases[index].Price = newPrice;
                    Bases[index].IsClassic = isClassic;
                    Console.WriteLine($"[Успешно] Основа изменена на '{newName}' ({newPrice} руб.)!");
                }
            }
            else { Console.WriteLine("[Ошибка] Основа не найдена."); }
        }

        public void DeletePizzaBase(int index)
        {
            if (index >= 0 && index <= Bases.Count)
            {
                Console.WriteLine($"[Успешно] Основа '{Bases[index].Name}' удалена!");
                Bases.RemoveAt(index);
            }
            else { Console.WriteLine("[Ошибка] Основа не найдена."); }
        }
    }
}