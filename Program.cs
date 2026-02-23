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