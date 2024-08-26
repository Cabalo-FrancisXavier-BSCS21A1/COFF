using System;
using System.Linq;
using System.Collections.Generic;

namespace kape
{
    public static class Program
    {
        public static void Main()
        {
            bool exit = false;
            var menu = new Dictionary<string, decimal>();
            var order = new Dictionary<string, decimal>();

            while (!exit)
            {
                Console.WriteLine("Welcome to the kape Shop!");
                Console.WriteLine("1. Add Menu Item");
                Console.WriteLine("2. View Menu");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. View Order");
                Console.WriteLine("5. Calculate Total");
                Console.WriteLine("6. Exit");
                Console.Write("Please Select Above: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddMenuItem(menu);
                        break;
                    case "2":
                        ViewMenu(menu);
                        break;
                    case "3":
                        PlaceOrder(menu, order);
                        break;
                    case "4":
                        ViewOrder(order);
                        break;
                    case "5":
                        CalculateTotal(order);
                        break;
                    case "6":
                        Console.WriteLine("Thank you! Come Again!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice! Please select a valid option.");
                        break;
                }
            }
        }

        private static void AddMenuItem(Dictionary<string, decimal> menu)
        {
            Console.Write("Enter Item: ");
            string item = Console.ReadLine();

            Console.Write("Enter Item Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price) && price > 0)
            {
                menu[item] = price;
                Console.WriteLine("Item Added Successfully");
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }
        }

        private static void ViewMenu(Dictionary<string, decimal> menu)
        {
            if (menu.Count == 0)
            {
                Console.WriteLine("No menu items available.");
                return;
            }

            Console.WriteLine("Menu:");
            int i = 1;
            foreach (var item in menu)
            {
                Console.WriteLine($"{i}. {item.Key} - {item.Value:C}");
                i++;
            }
        }

        private static void PlaceOrder(Dictionary<string, decimal> menu, Dictionary<string, decimal> order)
        {
            if (menu.Count == 0)
            {
                Console.WriteLine("No menu items available.");
                return;
            }

            ViewMenu(menu);

            Console.Write("Select Items To Order: ");
            if (int.TryParse(Console.ReadLine(), out int orderNumber) && orderNumber >= 1 && orderNumber <= menu.Count)
            {
                var item = menu.ElementAt(orderNumber - 1);
                if (order.ContainsKey(item.Key))
                {
                    order[item.Key] += item.Value;
                }
                else
                {
                    order[item.Key] = item.Value;
                }
                Console.WriteLine("Item Added!");
            }
            else
            {
                Console.WriteLine("Invalid Order Number.");
            }
        }

        private static void ViewOrder(Dictionary<string, decimal> order)
        {
            if (order.Count == 0)
            {
                Console.WriteLine("No items in the order.");
                return;
            }

            Console.WriteLine("Your Order:");
            foreach (var item in order)
            {
                Console.WriteLine($"{item.Key} - {item.Value:C}");
            }
        }

        private static void CalculateTotal(Dictionary<string, decimal> order)
        {
            if (order.Count == 0)
            {
                Console.WriteLine("No items in the order.");
                return;
            }

            decimal total = order.Values.Sum();
            Console.WriteLine($"Total Amount Payable: {total:C}");
        }
    }
}