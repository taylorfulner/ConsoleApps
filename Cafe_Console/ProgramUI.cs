using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class ProgramUI //RUN TESTS
    {
        private MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            SeedItems();
            Menu();
        }

        public void Menu()
        {
            bool keepMenu = true;
            while (keepMenu)
            {
                Console.Clear();
                Console.WriteLine($"Enter a number from the menu below:\n" +
                    $"  1. Create a New Menu Item\n" +
                    $"  2. See All Menu Items\n" +
                    $"  3. Update a Menu Item\n" +
                    $"  4. Delete a Menu Item\n" +
                    $"  5. Exit\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateItem();
                        break;
                    case "2":
                        SeeMenu();
                        break;
                    case "3":
                        UpdateItem();
                        break;
                    case "4":
                        DeleteItem();
                        break;
                    case "5":
                        keepMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        public void CreateItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            Console.WriteLine("Item Number?");
            newItem.Number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Item Name?");
            newItem.Name = Console.ReadLine();

            Console.WriteLine("Item Description?");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Choose the ingredients from the list below. Seperate each ingredient with a ','.");
            foreach (string i in newItem.Ingredients)
            {
                Console.WriteLine($"  {i}");
            }
            string ing = Console.ReadLine().ToLower();
            List<string> result = ing.Split(',').ToList();
            newItem.Ingredients = result;

            Console.WriteLine("Price?");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            bool wasAdded = _repo.AddItemToMenu(newItem);
            if(wasAdded == true)
            {
                Console.WriteLine($"You added {newItem.Name} to the menu");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Item could not be added. Please reenter the information.");
                Console.ReadLine();
            }
        } 

        public void SeeMenu()
        {
            Console.Clear();
            List<MenuItem> allItems = _repo.GetMenuItems();
            foreach (MenuItem item in allItems)
            {
                Console.ForegroundColor = (ConsoleColor.Blue);
                Console.WriteLine($"Item: {item.Number}. {item.Name}");
                Console.ResetColor();
                Console.WriteLine($"  Description: {item.Description}\n" +
                    $"  Ingredients:");
                foreach(string i in item.Ingredients)
                {
                    Console.WriteLine($"      {i}");
                }
                Console.WriteLine($"  Price: ${item.Price}\n");
            }
            Console.ReadLine();
        }

        public void UpdateItem()
        {
            SeeMenu();

            Console.WriteLine("What is the name of the item would you like to update?");
            string oldItem = Console.ReadLine();
            MenuItem newItem = new MenuItem();

            Console.WriteLine("Item Number?");
            newItem.Number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Item Name?");
            newItem.Name = Console.ReadLine();

            Console.WriteLine("Item Description?");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Choose the ingredients from the list below");
            foreach (string i in newItem.Ingredients)
            {
                Console.WriteLine($"  {i}");
            }
            string ing = Console.ReadLine().ToLower();
            List<string> result = ing.Split(',').ToList();
            newItem.Ingredients = result;

            Console.WriteLine("Price?");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            bool wasAdded = _repo.UpdateMenuItem(oldItem, newItem);
            if (wasAdded == true)
            {
                Console.WriteLine($"You added {newItem.Name} to the menu");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Item could not be added. Please reenter the information.");
                Console.ReadLine();
            }
        }

        public void DeleteItem()
        {
            Console.Clear();
            SeeMenu();

            Console.WriteLine("enter the name of the item you want to delete.");

            bool wasDeleted = _repo.DeleteMenuItem(Console.ReadLine());

            if (wasDeleted)
            {
                Console.WriteLine("The item has been deleted.");
            }
            else
            {
                Console.WriteLine("The item could not be deleted.");
            }
            Console.ReadLine();
        }

        private void SeedItems()
        {
            MenuItem cheeseburger = new MenuItem(1, "cheeseburger", "cheeseburger", new List<string> { "buns", "cheese", "beef"}, 2.50);
            MenuItem hamburger = new MenuItem(2, "hamburger", "hamburger", new List<string> { "buns", "beef" }, 2);
            MenuItem fries = new MenuItem(3, "fries", "fries", new List<string> { "potatoes", "salt" }, 2);
            MenuItem soda = new MenuItem(4, "soda", "soda", new List<string> { "soda" }, 1.50);

            _repo.AddItemToMenu(cheeseburger);
            _repo.AddItemToMenu(hamburger);
            _repo.AddItemToMenu(fries);
            _repo.AddItemToMenu(soda);
        }

    }
}
