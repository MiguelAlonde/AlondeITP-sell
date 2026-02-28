using System;

namespace Alonde_sellitem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = GetSellerName();
            int limit = GetItemCount();
            string[] items = new string[limit];
            string[] values = new string[limit];

            InputItems(items, values, limit);
            DisplayInventory(name, items, values, limit);
        }

        static string GetSellerName()
        {
            Console.WriteLine("Enter your full name");
            return Console.ReadLine();
        }

        static int GetItemCount()
        {
            Console.WriteLine("How many Items do you want to add? ");
            return int.Parse(Console.ReadLine());
        }

        static void InputItems(string[] items, string[] values, int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine("Enter the Item: " + (i + 1));
                items[i] = Console.ReadLine();
                Console.WriteLine("Enter the Price: " + (i + 1));
                values[i] = Console.ReadLine();
            }
        }

        static void DisplayInventory(string name, string[] items, string[] values, int limit)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Inventory: ");
            Console.WriteLine("\n Seller: " + name);
            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine("item:  " + (i + 1) + "  : " + items[i]);
                Console.WriteLine("price:  " + (i + 1) + "  : " + values[i]);
            }
        }
    }
}