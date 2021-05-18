using Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    public class ProgramUI
    {
        private ClaimsRepository _repo = new ClaimsRepository();

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
                Console.WriteLine($"Choose a menu item by entering the number:\n" +
                    $"1. See All Claims\n" +
                    $"2. Take Care of Next Claim\n" +
                    $"3. Enter a New Claim");

                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        GetClaim();
                        break;
                    case "2":
                        ClaimQueue();
                        break;
                    case "3":
                        CreateClaim();
                        break;
                    default:
                        Console.WriteLine("please try again and enter a valid number");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        public void GetClaim()
        {
            Console.Clear();
            Queue<Claims> claimQueue = _repo.GetClaims();

            Console.WriteLine($"   {"ID",-4} {"Type",-9} {"Description",-25} {"Amount",-7} {"Incident Date",-20} {"Claim Date",-15} {"Claim is Valid?",-25}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (Claims claim in claimQueue)
            {
                Console.WriteLine($"   {claim.ClaimID,-4} {claim.ClaimType,-9} {claim.Description, -25} ${claim.ClaimAmount, -6} {claim.DateOfIncident.ToString("MM/dd/yyyy"), -20} {claim.DateOfClaim.ToString("MM/dd/yyyy"), -15} {claim.IsValid, -25}");
            }
            Console.ReadLine();
        }

        public void ClaimQueue()
        {

        }

        public void CreateClaim()
        {

        }

        public void SeedItems()
        {
            Claims car = new Claims(1, ClaimType.car, "car accident on 465", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 28));
            Claims home = new Claims(2, ClaimType.home, "house fire in kitchen", 4000.00, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            Claims theft = new Claims(3, ClaimType.theft, "stolen pancakes", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));

            _repo.CreateClaim(car);
            _repo.CreateClaim(home);
            _repo.CreateClaim(theft);
        }
    }
}
