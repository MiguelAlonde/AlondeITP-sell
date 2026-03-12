using System;

namespace SellerDL
{
    public class SellerReceipt
    {
        public void DisplayInventory(string name, string[] items, string[] values, int limit)
        {
            Console.WriteLine();
            Console.WriteLine("Inventory:");
            Console.WriteLine("Seller: " + name);

            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine("Item " + (i + 1) + ": " + items[i]);
                Console.WriteLine("Price " + (i + 1) + ": " + values[i]);
            }
        }
    }
}