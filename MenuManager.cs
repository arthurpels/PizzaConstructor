using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaConstructor
{
    public class MenuManager
    {
        public List<Ingredient> Ingredients {get; private set;}
        public List<PizzaBase> Bases {get; private set;}
        public List<Pizza> Pizzas {get; private set;}
        public List<PizzaBorder> Borders {get; private set;}
        public List<Order> Orders {get; private set;}
        public MenuManager()
        {
            Ingredients = new List<Ingredient>();
            Bases = new List<PizzaBase>();
            Pizzas = new List<Pizza>();
            Borders = new List<PizzaBorder>();
            Orders = new List<Order>();
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
                else
                {
                    Console.WriteLine("[Внимание] В системе пока нет классической основы. Правило 20% не применено, но лучше сначала добавить классику!");
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

        public void CreatePizza(string name, PizzaBase pizzaBase, List<Ingredient> selectedIngredients)
        {
            Pizza newPizza = new Pizza(name, pizzaBase);

            foreach(var ingredient in selectedIngredients)
            {
                newPizza.AddIngredient(ingredient);
            }
            Pizzas.Add(newPizza);
            Console.WriteLine($"[Успешно] Пицца '{name}' создана и добавлена в меню!");
        }

        public void PrintPizzas()
        {
            Console.WriteLine("\n--- Список готовых пицц ---");
            if (Pizzas.Count == 0) { Console.WriteLine("Список пока пуст."); return; }
            for (int i = 0; i < Pizzas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Pizzas[i].ToString()}");
            }
            Console.WriteLine("---------------------------");
        }

       public void DeletePizza(int index)
        {
            if (index >= 0 && index < Pizzas.Count)
            {
                Console.WriteLine($"[Успешно] Пицца '{Pizzas[index].Name}' удалена!");
                Pizzas.RemoveAt(index);
            }
            else { Console.WriteLine("[Ошибка] Пицца не найдена."); }
        }

        public void CreateBorder(string name, List<Ingredient> borderIngredients, List<Pizza> allowedPizzas)
        {
            PizzaBorder newBorder = new PizzaBorder(name);
            foreach (var ing in borderIngredients) newBorder.AddIngredient(ing);
            foreach (var p in allowedPizzas) newBorder.AllowForPizza(p);
            
            Borders.Add(newBorder);
            Console.WriteLine($"[Успешно] Бортик '{name}' создан!");
        }

        public void PrintBorders()
        {
            Console.WriteLine("\n--- Список бортиков ---");
            if (Borders.Count == 0) { Console.WriteLine("Список пока пуст."); return; }
            for (int i = 0; i < Borders.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Borders[i].ToString()}");
            }
            Console.WriteLine("-----------------------");
        }

        public void SetBorderForPizza(int pizzaIndex, PizzaBorder border)
        {
            if (pizzaIndex >= 0 && pizzaIndex < Pizzas.Count)
            {
                Pizza targetPizza = Pizzas[pizzaIndex];
                
                if (border.IsAllowedFor(targetPizza))
                {
                    targetPizza.Border = border;
                    Console.WriteLine($"[Успешно] Бортик '{border.Name}' добавлен к пицце '{targetPizza.Name}'!");
                }
                else
                {
                    Console.WriteLine($"[Ошибка] Этот бортик не разрешено использовать с пиццей '{targetPizza.Name}'.");
                }
            }
            else { Console.WriteLine("[Ошибка] Пицца не найдена."); }
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
            Console.WriteLine($"\n[Успешно] Заказ №{order.OrderNumber} успешно оформлен!");
            Console.WriteLine($"Итого к оплате: {order.TotalPrice} руб.");
        }

        public void PrintOrders()
        {
            Console.WriteLine("\n--- Список всех заказов ---");
            if (Orders.Count == 0) { Console.WriteLine("Заказов пока нет."); return; }
            for (int i = 0; i < Orders.Count; i++)
            {
                Console.WriteLine($"{Orders[i].ToString()}");
                Console.WriteLine("Состав заказа:");
                foreach (var pizza in Orders[i].Pizzas)
                {
                    Console.WriteLine($"  - {pizza.ToString()}");
                }
                Console.WriteLine("---------------------------");
            }
        }
    }
}