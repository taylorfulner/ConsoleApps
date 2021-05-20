using Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    public class ProgramUI
    {
        private BadgesRepository _repo = new BadgesRepository();

        public void Run()
        {
            _repo.SeedList();
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
            Console.Clear();
            Badges newBadge = new Badges();

            Console.WriteLine("What is the number on the badge?");
            newBadge.BadgeID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("List a door the badge needs access to:");
            string ans = Console.ReadLine().ToLower();
            List<string> result = ans.Split(' ').ToList();
            newBadge.DoorName = result;

            bool isYes = true;
            while (isYes)
            {
                Console.WriteLine("any other doors to add(y/n)?");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.WriteLine("list another door:");
                    string yes = Console.ReadLine().ToLower();
                    List<string> resultAgain = yes.Split(' ').ToList();
                    newBadge.DoorName = resultAgain;
                }
                else
                {
                    isYes = false;
                }
            }
            _repo.CreateNewBadge(newBadge.BadgeID, newBadge.DoorName);
            Menu();
        }

        public void EditBadge()
        {

        }

        public void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> allBadges = _repo.GetBadgeAccess();
            foreach (KeyValuePair<int, List<string>> badge in allBadges)
            {
                Console.WriteLine($"Key = {badge.Key}");
                foreach (string door in badge.Value)
                {
                    Console.Write($" {door}\n");
                }
            }
            Console.ReadLine();
        }
    }
}
