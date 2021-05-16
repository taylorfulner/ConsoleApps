using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class ProgramUI
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

            Console.WriteLine("Choose the ingredients from the list below");
            StartingIngredientsList();
            string ing = Console.ReadLine();

        }

        public void SeeMenu()
        {

        }

        public void UpdateItem()
        {

        }

        public void DeleteItem()
        {

        }

        private void StartingIngredientsList()
        {
            MenuItem newIngredient = new MenuItem();
            newIngredient.Ingredients.Add("Buns");
            newIngredient.Ingredients.Add("Cheese");
            newIngredient.Ingredients.Add("Beef");
            newIngredient.Ingredients.Add("Lettuce");
            newIngredient.Ingredients.Add("Onion");
            newIngredient.Ingredients.Add("Ketchup");

            foreach (string i in newIngredient.Ingredients)
            {
                Console.WriteLine(i);
            }
        }

        private void SeedItems() //FINISH
        {
            MenuItem cheeseburger = new MenuItem();
            MenuItem hamburger = new MenuItem();
            MenuItem fries = new MenuItem();
            MenuItem soda = new MenuItem();
        }

    }
}
