using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaConstructor
{
    public class Order : IIdentifiable
    {
        public Guid Id {get; private set;}
        public int OrderNumber{get; private set;}
        public List<Pizza> Pizzas {get; private set;}
        public string Comment {get; set;}
        public DateTime OrderTime {get; private set;}
        public DateTime? DelayedTime {get; set;}

        public decimal TotalPrice
        {
            get{return Pizzas.Sum(p => p.Price);}
        }
        private static int _orderCounter = 1;

        public Order(string comment = "")
        {
            Id = Guid.NewGuid();
            OrderNumber = _orderCounter++;
            Pizzas = new List<Pizza>();
            Comment = comment;
            OrderTime = DateTime.Now;
        }

        public void AddPizza(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }
        public override string ToString()
        {
            string timeStr = DelayedTime.HasValue 
                ? $"Отложен на: {DelayedTime.Value.ToString("dd.MM.yyyy HH:mm")}" 
                : $"Время заказа: {OrderTime.ToString("dd.MM.yyyy HH:mm")}";

            return $"Заказ №{OrderNumber} | {timeStr} | Пицц: {Pizzas.Count} | Общая стоимость: {TotalPrice} руб.\nКомментарий: {Comment}";
        }
    }
}