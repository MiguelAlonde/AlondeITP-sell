namespace Alonde_sellitem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your full name");
            string name = Console.ReadLine();
            Console.WriteLine("Do you want to add items? y/n");
            string choice = Console.ReadLine();
            if (choice == "y")
                Console.WriteLine("How many Items do you want to add? ");
            int limit = int.Parse(Console.ReadLine());
            string[] items = new string[limit];
            string[] values = new string[limit];

            for (int i = 0; i < limit; i++)
            {

                Console.WriteLine("Enter the Item: " + (i + 1));
                items[i] = Console.ReadLine();
                Console.WriteLine("Enter the Price: " + (i + 1));
                values[i] = Console.ReadLine();

            }
            Console.WriteLine("Inventory: ");
            Console.WriteLine("\n Seller: " + name);
            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine("item: " + (i + 1) + " : " + items[i]);
                Console.WriteLine("price: " + (i + 1) + " : " + values[i]);
            }
        }

    }
}