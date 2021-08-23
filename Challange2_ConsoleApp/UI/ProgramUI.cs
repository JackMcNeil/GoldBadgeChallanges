using Challange2_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Challange2_ConsoleApp.UI
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _repo = new ClaimsRepository();
        private int _id = 4;

        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            Claims car = new Claims(1, Challange2_ClassLibrary.ClaimTypes.Car, "Car Accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claims home = new Claims(2, Challange2_ClassLibrary.ClaimTypes.Home, "House fire in kitchen", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claims theft = new Claims(3, Challange2_ClassLibrary.ClaimTypes.Theft, "Stolen Pancakes", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));

            _repo.AddClaim(car);
            _repo.AddClaim(home);
            _repo.AddClaim(theft);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:\n" +
                        "1. See all claims\n" +
                        "2. Take care of next claim\n" +
                        "3. Enter a new claim\n" +
                        "4. Exit\n");
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                    case "see":
                    case "see all claims":
                        SeeAllItems();
                        break;
                    case "2":
                    case "take car of next claim":
                        //ShowAllItems();
                        break;
                    case "3":
                    case "enter":
                    case "enter a new claim":
                        //DeleteItem();
                        break;
                    case "4":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        ContinueMessage();
                        break;
                }
            }
        }
        public void SeeAllItems()
        {
            Console.Clear();
            Console.WriteLine("  ClaimID       Type         Description            Amount      DateOfAccident      DateOfClaim         IsValid\n");
            Queue<Claims> allClaims = _repo.GetAllClaims();
            foreach (Claims claim in allClaims)
            {
                string value = "$"+string.Format("{0:0.00}", claim.ClaimAmount);
                Console.WriteLine($"{claim.ClaimId, -15} {claim.ClaimType, -10} {claim.Description, -24}" +
                    $" {value, -15} {claim.DateOfIncident.ToShortDateString(), -15} {claim.DateOfClaim.ToShortDateString(), -20} {claim.IsValid, 2}\n");
            }
            ContinueMessage();
        }


        public void ContinueMessage()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
