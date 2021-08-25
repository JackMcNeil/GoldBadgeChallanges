using Challange2_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClaimTypes = Challange2_ClassLibrary.ClaimTypes;

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
                        DealWithClaim();
                        break;
                    case "3":
                    case "enter":
                    case "enter a new claim":
                        EnterNewClaim();
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

        public void DealWithClaim()
        {
            Console.Clear();
            //Getting queue to print
            Queue<Claims> queueClaims = _repo.GetAllClaims();
            Claims theQueue = queueClaims.Peek();
            // Printing queue
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine($"ClaimID: {theQueue.ClaimId}\nType: {theQueue.ClaimType}\nDescription: {theQueue.Description}\nAmount: {theQueue.ClaimAmount}\nDateOfAccident: {theQueue.DateOfClaim.ToShortDateString()}\nDateOfClaim: {theQueue.DateOfIncident.ToShortDateString()}\nIsValid: {theQueue.IsValid}\n\n");
            //Asking to deal with claim 
            bool validResponse = false;
            //Dealing with claim
            while (!validResponse)
            {
                Console.Write("Do you want to deal with this claim now(y/n)? ");
                string ans = Console.ReadLine().ToLower();
                if (ans == "y" || ans == "yes")
                {
                    _repo.DeleteClaim();
                    Console.WriteLine("Claim was dealt with!");
                    ContinueMessage();
                    validResponse = true;
                }
                else if (ans == "n")
                {
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine("Not a valid repsonse");
                    ContinueMessage();
                }
            }
        }

        public void EnterNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();
            //ID
            newClaim.ClaimId = _id;
            _id++;
            //Type
            bool valid = false;
            while (!valid)
            {
                Console.Write("Enter the claim type (Car / Theft / Home): ");
                string claimType = Console.ReadLine().ToLower();
                switch (claimType)
                {
                    case "car":
                        newClaim.ClaimType = ClaimTypes.Car;
                        valid = true;
                        break;
                    case "theft":
                        newClaim.ClaimType = ClaimTypes.Theft;
                        valid = true;
                        break;
                    case "home":
                        newClaim.ClaimType = ClaimTypes.Home;
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("Not a valid entry");
                        ContinueMessage();
                        break;
                }
            }
            //Description
            Console.Write("Enter a claim description: ");
            string description = GetProperString();
            newClaim.Description = description;
            //Amount
            Console.Write("Enter the amount of damage: ");
            bool validAmount = false;
            double amount = 0;
            while (!validAmount)
                try
                {
                    amount = Math.Round(Convert.ToDouble(Console.ReadLine()),2);
                    validAmount = true;
                }
                catch
                {
                    Console.WriteLine("Not a valid number.");
                }
            newClaim.ClaimAmount = amount;
            //Date of accident
            Console.Write("Date of Accident(mm/dd/yy): ");
            DateTime accident = DateMaker();
            newClaim.DateOfIncident = accident;
            //Date of Claim
            Console.Write("Date of Claim(mm/dd/yy): ");
            DateTime claim = DateMaker();
            newClaim.DateOfClaim = claim;
            //Add to repo
            _repo.AddClaim(newClaim);
        }

        public DateTime DateMaker()
        {
            DateTime date;
            bool validDate = false;
            while (!validDate)
            {
                try
                {
                    string pattern = "M/dd/y";
                    date = DateTime.ParseExact(Console.ReadLine(), pattern, null);
                    validDate = true;
                    return date;
                }
                catch
                {
                    Console.WriteLine("Not a valid date. Enter date in accordance with the format given");
                    ContinueMessage();
                }
            }
            return new DateTime(0, 0, 0);
        }

        public string GetProperString()
        {
            bool valid = false;
            while (!valid)
            {
                string response = Console.ReadLine();
                bool nullOr = string.IsNullOrEmpty(response);
                if (nullOr)
                {
                    Console.WriteLine("Please input a valid Answer");
                }
                else
                {
                    return response;
                }
            }
            return null;
        }

        public void ContinueMessage()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
