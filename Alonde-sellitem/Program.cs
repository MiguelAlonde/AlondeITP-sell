using System;
using SellerBL;
using SellerDL;

namespace Alonde_sellitem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryLogic logic = new InventoryLogic();
            SellerReceipt receipt = new SellerReceipt();

            string name = logic.GetSellerName();
            int limit = logic.GetItemCount();

            string[] items = new string[limit];
            string[] values = new string[limit];

            logic.InputItems(items, values, limit);

            receipt.DisplayInventory(name, items, values, limit);

            Console.ReadKey();
        }
    }
}