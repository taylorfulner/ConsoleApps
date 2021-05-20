using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    public class ProgramUI
    {
        public void Run()
        {
            SeedList();
            Menu();
        }

        public void Menu()
        {
            bool keepMenu = true;
            while (keepMenu)
            {
                Console.Clear();
                Console.WriteLine($"Hello Security Admin, What would you like to do?\n" +
                    $"1. Add a Badge\n" +
                    $"2. Edit a Badge\n" +
                    $"3. List all Badges");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                    case "add a badge":
                        AddBadge();
                        break;
                    case "2":
                    case "edit a badge":
                        EditBadge();
                        break;
                    case "3":
                    case "list all badges":
                        ListAllBadges();
                        break;
                    default:
                        break;

                }
            }
        }

        public void AddBadge()
        {

        }

        public void EditBadge()
        {

        }

        public void ListAllBadges()
        {

        }

        public void SeedList()
        {

        }
    }
}
