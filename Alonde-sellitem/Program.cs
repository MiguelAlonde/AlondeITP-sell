using System;
using sellModels;
using sellItemBL;

namespace Alonde_sellitem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sellBusiness sellbusiness = new sellBusiness();

            while (true)
            {
                Console.WriteLine("\n==== MENU ====");
                Console.WriteLine("1. Add Seller Items");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Update Item Price");
                Console.WriteLine("4. Delete Item");
                Console.WriteLine("5. Receipt per Seller");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");

                int choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.Write("Enter seller name: ");
                        string sellername = Console.ReadLine();

                        Console.Write("How many items? ");
                        int limits = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < limits; i++)
                        {
                            Console.Write("Item " + (i + 1) + ": ");
                            string items = Console.ReadLine();

                            Console.Write("Price: ");
                            int price = Convert.ToInt32(Console.ReadLine());

                            sellbusiness.AddItems(sellername, items, price);
                        }
                        break;

                    case 2:
                        var inv = sellbusiness.GetInventory();
                        foreach (var i in inv)
                        {
                            Console.WriteLine("\nSeller: " + i.sellerName);
                            Console.WriteLine("Item: " + i.Items);
                            Console.WriteLine("Price: " + i.Price);
                        }
                        break;

                    case 3:
                        Console.Write("Enter seller name: ");
                        string sname = Console.ReadLine();

                        var itemsList = sellbusiness.GetBySeller(sname);

                        for (int i = 0; i < itemsList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {itemsList[i].Items} - {itemsList[i].Price}");
                        }

                        Console.Write("Choose item number to update: ");
                        int index = Convert.ToInt32(Console.ReadLine()) - 1;

                        Console.Write("New Price: ");
                        int newPrice = Convert.ToInt32(Console.ReadLine());

                        sellbusiness.UpdatePrice(itemsList[index].ItemId, newPrice);
                        break;

                    case 4:
                        Console.Write("Enter seller name: ");
                        string delSeller = Console.ReadLine();

                        var delItems = sellbusiness.GetBySeller(delSeller);

                        for (int i = 0; i < delItems.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {delItems[i].Items}");
                        }

                        Console.Write("Select item to delete: ");
                        int delIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                        sellbusiness.DeleteItem(delItems[delIndex].ItemId);
                        break;

                    case 5:
                        Console.Write("Enter seller name: ");
                        string receiptSeller = Console.ReadLine();

                        var receipt = sellbusiness.GetBySeller(receiptSeller);

                        Console.WriteLine("\n=== RECEIPT ===");
                        Console.WriteLine("Seller: " + receiptSeller);

                        int total = 0;

                        foreach (var i in receipt)
                        {
                            Console.WriteLine($"{i.Items} - {i.Price}");
                            total += i.Price;
                        }

                        Console.WriteLine("Total: " + total);
                        break;

                    case 0:
                        return;
                }
            }
        }
    }
}