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

            Console.WriteLine($"   {"ID",-4} {"Type",-9} {"Description",-25} {"Amount",-7} {"Incident Date",-15} {"Claim Date",-15} {"Claim is Valid?",-25}");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            foreach (Claims claim in claimQueue)
            {
                Console.WriteLine($"   {claim.ClaimID,-4} {claim.ClaimType,-9} {claim.Description, -25} ${claim.ClaimAmount, -6} {claim.DateOfIncident.ToString("MM/dd/yyyy"), -15} {claim.DateOfClaim.ToString("MM/dd/yyyy"), -15} {claim.IsValid, -25}");
            }
            Console.ReadLine();
        }

        public void ClaimQueue()
        {
            Console.Clear();

            Queue<Claims> claimQueue = _repo.GetClaimFromQueue();
            var claim = claimQueue.Peek();

            Console.WriteLine($"   {"ID",-4} {"Type",-9} {"Description",-25} {"Amount",-7} {"Incident Date",-15} {"Claim Date",-15} {"Claim is Valid?",-25}");
            Console.WriteLine($"   {claim.ClaimID,-4} {claim.ClaimType,-9} {claim.Description,-25} ${claim.ClaimAmount,-6} {claim.DateOfIncident.ToString("MM/dd/yyyy"),-15} {claim.DateOfClaim.ToString("MM/dd/yyyy"),-15} {claim.IsValid,-25}\n\n" +
                $"Do you want to deal with this claim now(y/n)?");
            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.WriteLine("Would you like to UPDATE or DELETE this claim?");
                string answer = Console.ReadLine();
                if (answer == "update")
                {
                    Claims newInfo = new Claims();

                    Console.WriteLine($"   {"ID",-4} {"Type",-9} {"Description",-25} {"Amount",-7} {"Incident Date",-15} {"Claim Date",-15} {"Claim is Valid?",-25}");
                    Console.WriteLine($"   {claim.ClaimID,-4} {claim.ClaimType,-9} {claim.Description,-25} ${claim.ClaimAmount,-6} {claim.DateOfIncident.ToString("MM/dd/yyyy"),-15} {claim.DateOfClaim.ToString("MM/dd/yyyy"),-15} {claim.IsValid,-25}\n\n" +
                        $"ID Number?");

                    newInfo.ClaimID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Is the claim type car, home or theft?");
                    string type = Console.ReadLine();
                    if (type == "car")
                    {
                        newInfo.ClaimType = (ClaimType)0;
                    }
                    else if (type == "home")
                    {
                        newInfo.ClaimType = (ClaimType)1;
                    }
                    else if(type == "theft")
                    {
                        newInfo.ClaimType = (ClaimType)2;
                    }
                    else
                    {
                        Console.WriteLine("please enter a valid claim type");
                        Console.ReadLine();
                        ClaimQueue();
                    }

                    Console.WriteLine("Claim description?");
                    newInfo.Description = Console.ReadLine();

                    Console.WriteLine("Claim Amount?");
                    newInfo.ClaimAmount = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Incident Date? Format: YYYY/MM/DD");
                    newInfo.DateOfIncident = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Claim Date? Format: YYYY/MM/DD");
                    newInfo.DateOfClaim = DateTime.Parse(Console.ReadLine());

                    _repo.UpdateClaim(claim, newInfo);

                    Console.WriteLine("the claim has been updated");
                    Console.ReadLine();
                    Menu();

                }
                else if (answer == "delete")
                {
                    Queue<Claims> delete = _repo.DeleteClaimFromQueue();
                    var claimDelete = delete.Dequeue();
                    Console.WriteLine("this claim has been deleted");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("you will be sent back to the main menu now.");
                    Console.ReadLine();
                }
            }
            else if (input == "n")
            {
                Menu();
            }
            else
            {
                Console.WriteLine($"please enter either 'y' or 'n'");
                Console.ReadLine();
                ClaimQueue();
            }
        }

        public void CreateClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("ID number?");

            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Is the claim type car, home or theft?");
            string type = Console.ReadLine();
            if (type == "car")
            {
                newClaim.ClaimType = (ClaimType)0;
            }
            else if (type == "home")
            {
                newClaim.ClaimType = (ClaimType)1;
            }
            else if (type == "theft")
            {
                newClaim.ClaimType = (ClaimType)2;
            }
            else
            {
                Console.WriteLine("please enter a valid claim type");
                Console.ReadLine();
                ClaimQueue();
            }

            Console.WriteLine("Claim description?");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Claim Amount?");
            newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Incident Date? Format: YYYY/MM/DD");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Claim Date? Format: YYYY/MM/DD");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"Valid claim? {newClaim.IsValid}\n");

            _repo.CreateClaim(newClaim);

            Console.WriteLine("the claim has been created");
            Console.ReadLine();
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
