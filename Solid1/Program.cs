using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solid1
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    class Order
    {
        private List<Item> itemList = new List<Item>();

        public void AddItem(Item item)
        {
            itemList.Add(item);
            Console.WriteLine($"Товар {item.Name} додано до замовлення.");
        }

        public void DeleteItem(Item item)
        {
            itemList.Remove(item);
            Console.WriteLine($"Товар {item.Name} видалено з замовлення.");
        }

        public List<Item> GetItems()
        {
            return itemList;
        }

        public int GetItemCount()
        {
            return itemList.Count;
        }

        public decimal CalculateTotalSum()
        {
            return itemList.Sum(item => item.Price);
        }
    }

    class PrintManager
    {
        public void PrintOrder(Order order)
        {
            Console.WriteLine("Друк замовлення:");
            foreach (var item in order.GetItems())
            {
                Console.WriteLine($"Товар: {item.Name}, Ціна: {item.Price:C}");
            }
            Console.WriteLine($"Загальна сума: {order.CalculateTotalSum():C}");
        }

        public void ShowOrder(Order order)
        {
            Console.WriteLine("Перегляд замовлення:");
            foreach (var item in order.GetItems())
            {
                Console.WriteLine($"Товар: {item.Name}, Ціна: {item.Price:C}");
            }
            Console.WriteLine($"Загальна сума: {order.CalculateTotalSum():C}");
        }
    }

    class OrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine("Замовлення збережено.");
        }

        public Order Load(int orderId)
        {
            Console.WriteLine($"Замовлення з ID {orderId} завантажено.");
            return new Order();
        }

        public void Update(Order order)
        {
            Console.WriteLine("Замовлення оновлено.");
        }

        public void Delete(int orderId)
        {
            Console.WriteLine($"Замовлення з ID {orderId} видалено.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Order order1 = new Order();
            order1.AddItem(new Item("Монополія", 600m));
            order1.AddItem(new Item("Бункер", 1200.5m));
            order1.AddItem(new Item("Ініш", 2700m));

            PrintManager printManager = new PrintManager();
            printManager.ShowOrder(order1);

            Item itemToDelete = order1.GetItems().FirstOrDefault(item => item.Name == "Бункер");
            if (itemToDelete != null)
            {
                order1.DeleteItem(itemToDelete);
            }

            printManager.ShowOrder(order1);

            Console.WriteLine($"Кількість товарів у замовленні: {order1.GetItemCount()}");


            OrderRepository orderRepository = new OrderRepository();
            orderRepository.Save(order1);

            Order order2 = new Order();
            order2.AddItem(new Item("Містеріум", 300m));
            order2.AddItem(new Item("Імаджинаріум", 200m));
            order2.AddItem(new Item("Вибухові кошенята", 600m));

            Order loadedOrder = orderRepository.Load(1);

            orderRepository.Update(order1);

            orderRepository.Delete(1);

            printManager.ShowOrder(order2);

            Console.ReadKey();
        }
    }
}
