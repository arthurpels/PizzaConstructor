using System;
using System.Text;

namespace PizzaConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            MenuManager manager = new MenuManager();

            while (true)
            {
                Console.WriteLine("\n=== КОНСТРУКТОР ПИЦЦЫ: ГЛАВНОЕ МЕНЮ ===");
                Console.WriteLine("1. Добавить новый ингредиент");
                Console.WriteLine("2. Показать все ингредиенты");
                Console.WriteLine("3. Редактировать ингредиент");
                Console.WriteLine("4. Удалить ингредиент");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("5. Добавить новую основу");
                Console.WriteLine("6. Показать все основы");
                Console.WriteLine("7. Редактировать основу");
                Console.WriteLine("8. Удалить основу");
                Console.WriteLine("9. Создать пиццу");
                Console.WriteLine("10. Показать все пиццы");
                Console.WriteLine("11. Удалить пиццу");
                Console.WriteLine("0. Выйти из программы");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Введите название ингредиента: ");
                    string name = Console.ReadLine();

                    Console.Write("Введите стоимость(число): ");
                    if(decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        manager.CreateIngredient(name, price);
                    }
                    else
                    {
                        Console.WriteLine("[Ошибка] Вводите только число в стоимость.");
                    }
                }
                else if (choice == "2")
                {
                    manager.PrintIngredients();
                }
                else if (choice == "3")
                {
                    manager.PrintIngredients();
                    if (manager.Ingredients.Count == 0) continue;

                    Console.Write("Введите номер ингредиента для редактирования: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        Console.Write("Введите новое название: ");
                        string newName = Console.ReadLine();

                        Console.Write("Введите новую стоимость: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                        {
                            manager.EditIngredient(index - 1, newName, newPrice);
                        }
                        else
                        {
                            Console.WriteLine("[Ошибка] Неверный формат стоимости!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("[Ошибка] Введите корректный номер!");
                    }
                }
                else if (choice == "4")
                {
                    manager.PrintIngredients();
                    if (manager.Ingredients.Count == 0) continue;

                    Console.Write("Введите номер ингредиента для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        manager.DeleteIngredient(index - 1);
                    }
                    else
                    {
                        Console.WriteLine("[Ошибка] Введите корректный номер!");
                    }
                }
                else if (choice == "5")
                {
                    Console.Write("Введите название основы: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите стоимость: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        Console.Write("Это классическая основа? (да/нет): ");
                        bool isClassic = Console.ReadLine().ToLower() == "да";
                        manager.CreatePizzaBase(name, price, isClassic);
                    }
                    else Console.WriteLine("[Ошибка] Неверный формат стоимости!");
                }
                else if (choice == "6") manager.PrintBases();
                else if (choice == "7")
                {
                    manager.PrintBases();
                    if (manager.Bases.Count == 0) continue;
                    Console.Write("Номер для редактирования: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        Console.Write("Новое название: ");
                        string name = Console.ReadLine();
                        Console.Write("Новая стоимость: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal price))
                        {
                            Console.Write("Это классическая основа? (да/нет): ");
                            bool isClassic = Console.ReadLine().ToLower() == "да";
                            manager.EditPizzaBase(index - 1, name, price, isClassic);
                        }
                    }
                }
                else if (choice == "8")
                {
                    manager.PrintBases();
                    if (manager.Bases.Count == 0) continue;
                    Console.Write("Номер для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int index)) manager.DeletePizzaBase(index - 1);
                }
                else if (choice == "9")
                {
                    if (manager.Bases.Count == 0)
                    {
                        Console.WriteLine("[Ошибка] Сначала добавьте хотя бы одну основу для пиццы!");
                        continue; 
                    }

                    Console.Write("Введите название новой пиццы: ");
                    string pizzaName = Console.ReadLine();

                    manager.PrintBases();
                    Console.Write("Введите номер основы для этой пиццы: ");
                    if (!int.TryParse(Console.ReadLine(), out int baseIndex) || baseIndex < 1 || baseIndex > manager.Bases.Count)
                    {
                        Console.WriteLine("[Ошибка] Неверный номер основы!");
                        continue;
                    }
                    PizzaBase selectedBase = manager.Bases[baseIndex - 1];

                    List<Ingredient> pizzaIngredients = new List<Ingredient>();
                    if (manager.Ingredients.Count > 0)
                    {
                        manager.PrintIngredients();
                        Console.WriteLine("Вводите номера ингредиентов по одному и нажимайте Enter.");
                        Console.WriteLine("Когда закончите добавлять ингредиенты, введите 0.");

                        while (true)
                        {
                            Console.Write("Номер ингредиента (или 0 для завершения): ");
                            if (int.TryParse(Console.ReadLine(), out int ingIndex))
                            {
                                if (ingIndex == 0) break; 
                                
                                if (ingIndex > 0 && ingIndex <= manager.Ingredients.Count)
                                {
                                    pizzaIngredients.Add(manager.Ingredients[ingIndex - 1]);
                                    Console.WriteLine($"  + Добавлен: {manager.Ingredients[ingIndex - 1].Name}");
                                }
                                else { Console.WriteLine("  [Ошибка] Такого ингредиента нет."); }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("[Внимание] В системе нет ингредиентов, пицца будет только из основы.");
                    }

                    manager.CreatePizza(pizzaName, selectedBase, pizzaIngredients);
                }
                else if (choice == "10") manager.PrintPizzas();
                else if (choice == "11")
                {
                    manager.PrintPizzas();
                    if (manager.Pizzas.Count == 0) continue;
                    Console.Write("Введите номер пиццы для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int index)) manager.DeletePizza(index - 1);
                }
                else if (choice == "0")
                {
                    Console.WriteLine("До свидания!");
                    break;
                }
                else
                {
                    Console.WriteLine("Неизвестная команда. Попробуйте ещё раз.");
                }
            }
        }
    }
}