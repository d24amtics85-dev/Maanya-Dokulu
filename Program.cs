using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, (string Name, decimal Price)> menu = new Dictionary<int, (string, decimal)>
        {
            { 1, ("Pizza", 250m) },
            { 2, ("Burger", 120m) },
            { 3, ("Pasta", 150m) },
            { 4, ("Fries", 80m) },
            { 5, ("Coke", 40m) }
        };

        List<(string Name, decimal Price, int Quantity)> cart = new List<(string, decimal, int)>();

        Console.WriteLine("\n==== Welcome to QuickEats ====\n");
        Console.WriteLine("MENU:");
        foreach (var item in menu)
        {
            Console.WriteLine($"{item.Key}. {item.Value.Name} - ₹{item.Value.Price}");
        }

        while (true)
        {
            Console.Write("\nEnter item number to order (0 to checkout): ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || (choice != 0 && !menu.ContainsKey(choice)))
            {
                Console.WriteLine("Invalid choice! Try again.");
                continue;
            }

            if (choice == 0) break;

            Console.Write($"Enter quantity for {menu[choice].Name}: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity!");
                continue;
            }

            cart.Add((menu[choice].Name, menu[choice].Price, qty));
        }

        Console.WriteLine("\n==== ORDER SUMMARY ====");
        decimal total = 0;
        foreach (var item in cart)
        {
            decimal cost = item.Price * item.Quantity;
            total += cost;
            Console.WriteLine($"{item.Name} x {item.Quantity} = ₹{cost}");
        }

        decimal deliveryCharge = 40m;
        total += deliveryCharge;
        Console.WriteLine($"\nDelivery Charges: ₹{deliveryCharge}");
        Console.WriteLine($"TOTAL: ₹{total}");

        Console.Write("\nConfirm order? (yes/no): ");
        string confirm = Console.ReadLine()?.Trim().ToLower();
        if (confirm == "yes")
        {
            Console.WriteLine("\nYour order has been placed! 🚚");
            Console.WriteLine("Estimated delivery time: 30 minutes.");
        }
        else
        {
            Console.WriteLine("\nOrder cancelled.");
        }
    }
}