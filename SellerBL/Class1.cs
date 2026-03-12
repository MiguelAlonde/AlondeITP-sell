using System;

namespace SellerBL
{
    public class InventoryLogic
    {
        public string GetSellerName()
        {
            Console.WriteLine("Enter your full name");
            return Console.ReadLine();
        }

        public int GetItemCount()
        {
            Console.WriteLine("How many Items do you want to add?");
            return int.Parse(Console.ReadLine());
        }

        public void InputItems(string[] items, string[] values, int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine("Enter the Item: " + (i + 1));
                items[i] = Console.ReadLine();

                Console.WriteLine("Enter the Price: " + (i + 1));
                values[i] = Console.ReadLine();
            }
        }
    }
}