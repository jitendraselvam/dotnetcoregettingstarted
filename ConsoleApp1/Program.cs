using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        public static List<Item> shoppingCart = new List<Item>();
        public static List<Item> superMarket;

        static void Main(string[] args)
        {
            var exit = true;
            InitilizeSuperMarket();

            Console.WriteLine("----------------Super Market----------------");
            while (exit)
            {
                DisplayOptions();
                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    {
                        DisplayItems();
                        Console.Write("\nEnter item number to add: ");
                        int ch = Int32.Parse(Console.ReadLine());
                        shoppingCart.Add(superMarket[--ch]);
                        Console.WriteLine("\nAdded "+superMarket[ch].Name);
                        break;
                    }
                    case 2:
                    {
                        DisplayShoppingCart();
                        Console.Write("\nEnter item number to remove: ");
                        int ch = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("\nRemoved " + shoppingCart[--ch].Name);
                        shoppingCart.Remove(shoppingCart[ch]);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("\n***Your shopping cart***\n");
                        DisplayShoppingCart();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(shoppingCart));
                        break;
                    }
                    default:
                    {
                        exit = false;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Displays all the items in the shopping cart along with the total cost
        /// </summary>
        private static void DisplayShoppingCart()
        {
            var i = 1;
            var total = 0;
            shoppingCart.ForEach(item =>
            {
                Console.WriteLine(i + " ." + item.Name + " \t" + "Cost: $" + item.Cost);
                i++;
                total += item.Cost;
            });
            Console.WriteLine("\t \tTotal: $"+total);
        }

        /// <summary>
        /// Displays the various operations
        /// </summary>
        private static void DisplayOptions()
        {
            Console.WriteLine("\n\n1. Add items to cart");
            Console.WriteLine("2. Remove items from cart");
            Console.WriteLine("3. Display cart");
            Console.WriteLine("4. JSON Convert the cart");
            Console.WriteLine("Any other number to exit\n\n");
        }

        /// <summary>
        /// Display all the available items in the super market
        /// </summary>
        private static void DisplayItems()
        {
            var i = 1;
            superMarket.ForEach(item =>
            {
                Console.WriteLine(i+" ."+item.Name+" \t"+"Cost: $"+ item.Cost);
                i++;
            });
        }

        /// <summary>
        /// Initilizes the super market
        /// </summary>
        private static void InitilizeSuperMarket()
        {
            superMarket =  new List<Item>()
            {
                new Item(){Name = "Chocolate", Cost = 5},
                new Item(){Name = "Candy", Cost = 2},
                new Item(){Name = "Chicken", Cost = 4},
                new Item(){Name = "Chips", Cost = 7},
                new Item(){Name = "Cookies", Cost = 10}
            };
        }
    }
}
