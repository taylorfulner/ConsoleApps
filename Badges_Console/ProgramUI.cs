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

            List<string> doors = new List<string>();

            bool isYes = true;
            while (isYes)
            {
                Console.WriteLine("Do you want to add door access?(y/n)?");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.WriteLine("Enter a door for access:");
                    string ans = Console.ReadLine().ToUpper();
                    doors.Add(ans);
                }
                else
                {
                    isYes = false;
                }
            }
            newBadge.DoorName = doors;
            _repo.CreateNewBadge(newBadge.BadgeID, newBadge.DoorName);
            Menu();
        }

        public void EditBadge()
        {
            Console.Clear();
            ListAllBadges();

            Console.WriteLine("What is the number on the badge you want to update?");
            int idNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Would you like to ADD or REMOVE a door?");
            string edit = Console.ReadLine();

            if (edit == "add".ToLower())
            {
                Console.WriteLine("What door do you want to add?");
                string ans = Console.ReadLine().ToUpper();

                _repo.AddDoor(idNumber, ans);
                Console.WriteLine($"You've added Door {ans} to the badge information");
                Console.ReadLine();
            }
            else if (edit == "remove".ToLower())
            {
                Console.WriteLine("What door do you want to delete?");
                string ans = Console.ReadLine().ToUpper();

                _repo.DeleteDoor(idNumber, ans);
                Console.WriteLine($"You've deleted Door {ans} frpm the badge information");
                Console.ReadLine();
            }
            Menu();
        }

        public void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> allBadges = _repo.GetBadgeAccess();
            Console.WriteLine($"   {"Badge ID",-10} {"Door Access List"}");
            foreach (KeyValuePair<int, List<string>> badge in allBadges)
            {
                Console.WriteLine($"   {badge.Key,-10} {string.Join(",", badge.Value)}");
            }
            Console.ReadLine();
        }
    }
}
