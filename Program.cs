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
                Console.WriteLine("12. Создать бортик");
                Console.WriteLine("13. Показать бортики");
                Console.WriteLine("14. Добавить/изменить бортик у готовой пиццы");
                Console.WriteLine("15. Оформить заказ");
                Console.WriteLine("16. Показать все заказы");
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
                        Console.Write("Это классическая основа? (y/n): ");
                        string answer = Console.ReadLine().Trim().ToLower();
                        bool isClassic = (answer == "да" || answer == "д" || answer == "1" || answer == "y" || answer == "yes");
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
                            Console.Write("Это классическая основа? (y/n): ");
                            string answer = Console.ReadLine().Trim().ToLower();
                            bool isClassic = (answer == "да" || answer == "д" || answer == "1" || answer == "y" || answer == "yes");
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
                else if (choice == "12")
                {
                    Console.Write("Введите название бортика: ");
                    string borderName = Console.ReadLine();

                    List<Ingredient> borderIngredients = new List<Ingredient>();
                    if (manager.Ingredients.Count > 0)
                    {
                        manager.PrintIngredients();
                        Console.WriteLine("Вводите номера ингредиентов для бортика (0 для завершения):");
                        while (true)
                        {
                            Console.Write("Номер ингредиента: ");
                            if (int.TryParse(Console.ReadLine(), out int ingIndex) && ingIndex == 0) break;
                            if (ingIndex > 0 && ingIndex <= manager.Ingredients.Count)
                            {
                                borderIngredients.Add(manager.Ingredients[ingIndex - 1]);
                                Console.WriteLine($"  + Добавлен: {manager.Ingredients[ingIndex - 1].Name}");
                            }
                        }
                    }

                    List<Pizza> allowedPizzas = new List<Pizza>();
                    if (manager.Pizzas.Count > 0)
                    {
                        manager.PrintPizzas();
                        Console.WriteLine("Для каких пицц разрешен этот бортик? Вводите номера (0 - разрешить для всех):");
                        while (true)
                        {
                            Console.Write("Номер пиццы: ");
                            if (int.TryParse(Console.ReadLine(), out int pIndex) && pIndex == 0) break;
                            if (pIndex > 0 && pIndex <= manager.Pizzas.Count)
                            {
                                allowedPizzas.Add(manager.Pizzas[pIndex - 1]);
                                Console.WriteLine($"  + Разрешено для: {manager.Pizzas[pIndex - 1].Name}");
                            }
                        }
                    }

                    manager.CreateBorder(borderName, borderIngredients, allowedPizzas);
                }
                else if (choice == "13") manager.PrintBorders();
                else if (choice == "14")
                {
                    manager.PrintPizzas();
                    if (manager.Pizzas.Count == 0) continue;
                    Console.Write("Введите номер пиццы: ");
                    if (int.TryParse(Console.ReadLine(), out int pIndex) && pIndex > 0 && pIndex <= manager.Pizzas.Count)
                    {
                        manager.PrintBorders();
                        if (manager.Borders.Count == 0) continue;
                        Console.Write("Введите номер бортика для этой пиццы: ");
                        if (int.TryParse(Console.ReadLine(), out int bIndex) && bIndex > 0 && bIndex <= manager.Borders.Count)
                        {
                            manager.SetBorderForPizza(pIndex - 1, manager.Borders[bIndex - 1]);
                        }
                    }
                }
                // --- БЛОК ЗАКАЗОВ ---
                else if (choice == "15")
                {
                    if (manager.Pizzas.Count == 0)
                    {
                        Console.WriteLine("[Ошибка] В меню пока нет ни одной пиццы! Сначала создайте пиццу (пункт 9).");
                        continue;
                    }

                    Console.Write("Введите комментарий к заказу (или нажмите Enter, чтобы пропустить): ");
                    string comment = Console.ReadLine();
                    
                    Order newOrder = new Order(comment);

                    Console.Write("Сделать заказ отложенным? (нажмите 1 - ДА, любую другую клавишу - НЕТ): ");
                    if (Console.ReadKey().KeyChar == '1')
                    {
                        Console.WriteLine(); // перенос строки
                        Console.Write("Введите дату и время (например, 03.05.2026 15:30): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime delayedTime))
                        {
                            newOrder.DelayedTime = delayedTime;
                        }
                        else
                        {
                            Console.WriteLine("[Ошибка] Неверный формат времени. Заказ будет оформлен на текущее время.");
                        }
                    }
                    else { Console.WriteLine(); }

                    // Главный цикл: выбираем пиццы для заказа
                    while (true)
                    {
                        manager.PrintPizzas();
                        Console.Write("Введите номер пиццы для добавления в заказ (или 0 для завершения сборки заказа): ");
                        if (int.TryParse(Console.ReadLine(), out int pIndex))
                        {
                            if (pIndex == 0) break; // Нажали 0 - выходим из цикла выбора пицц

                            if (pIndex > 0 && pIndex <= manager.Pizzas.Count)
                            {
                                // Клонируем пиццу, чтобы не сломать меню
                                Pizza orderedPizza = manager.Pizzas[pIndex - 1].Clone();

                                // 1. Выбор размера
                                Console.WriteLine("\nВыберите размер пиццы:");
                                Console.WriteLine("1 - Маленькая\n2 - Средняя\n3 - Большая");
                                Console.Write("Ваш выбор: ");
                                string sizeChoice = Console.ReadLine();
                                if (sizeChoice == "1") orderedPizza.Size = PizzaSize.Small;
                                else if (sizeChoice == "3") orderedPizza.Size = PizzaSize.Large;
                                else orderedPizza.Size = PizzaSize.Medium; 

                                // 2. Удвоение конкретных ингредиентов
                                if (orderedPizza.Ingredients.Count > 0)
                                {
                                    Console.Write("Хотите удвоить какие-нибудь ингредиенты в этой пицце? (нажмите 1 - ДА, любую другую - НЕТ): ");
                                    if (Console.ReadKey().KeyChar == '1')
                                    {
                                        Console.WriteLine(); 
                                        while (true) // Внутренний цикл для удвоения
                                        {
                                            var distinctIngredients = orderedPizza.Ingredients.Distinct().ToList();
                                            
                                            Console.WriteLine("\n--- Доступные для удвоения ингредиенты ---");
                                            for (int i = 0; i < distinctIngredients.Count; i++)
                                            {
                                                Console.WriteLine($"{i + 1}. {distinctIngredients[i].Name} (+{distinctIngredients[i].Price} руб.)");
                                            }
                                            
                                            Console.Write("Введите номер ингредиента для удвоения (или 0 для продолжения): ");
                                            if (int.TryParse(Console.ReadLine(), out int doubleIndex))
                                            {
                                                if (doubleIndex == 0) break; // Нажали 0 - заканчиваем удваивать
                                                
                                                if (doubleIndex > 0 && doubleIndex <= distinctIngredients.Count)
                                                {
                                                    Ingredient ingToDouble = distinctIngredients[doubleIndex - 1];
                                                    orderedPizza.AddIngredient(ingToDouble);
                                                    Console.WriteLine($"[Успешно] Порция '{ingToDouble.Name}' удвоена!");
                                                }
                                                else { Console.WriteLine("[Ошибка] Такого номера нет."); }
                                            }
                                        }
                                    }
                                    else { Console.WriteLine(); }
                                }

                                // ВАЖНО: Добавляем готовую пиццу в заказ! (именно эта строчка, скорее всего, пропала)
                                newOrder.AddPizza(orderedPizza);
                                Console.WriteLine($"\n  + Пицца '{orderedPizza.Name}' добавлена в корзину!");
                            }
                            else { Console.WriteLine("[Ошибка] Такого номера пиццы нет."); }
                        }
                    }

                    // После того как мы нажали 0 и вышли из главного цикла, сохраняем заказ в систему
                    if (newOrder.Pizzas.Count > 0)
                    {
                        manager.AddOrder(newOrder);
                    }
                    else
                    {
                        Console.WriteLine("\n[Отмена] Вы не добавили ни одной пиццы. Заказ отменен.");
                    }
                }
                else if (choice == "16")
                {
                    manager.PrintOrders();
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