using Challange7_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange7_ConsoleApp
{
    public class ProgramUI
    {
        private readonly PartyRepo _repo = new PartyRepo();
        public void Run()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu:\n" +
                    "1. See all parties\n" +
                    "2. Add a party\n" +
                    "3. Exit");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "1":
                    case "all":
                    case "see all cars":
                        SeeAllParties(); 
                        break;
                    case "2":
                    case "add":
                    case "add a party":
                        AddNewParty();
                        break;
                    case "3":
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
        
        public void AddNewParty()
        {
            Console.Clear();
            Party newParty = new Party();
            Console.Write("How many tickets did you have at the Burger Booth: ");
            int burgerTickets = Convert.ToInt32(GetValidDouble());
            newParty.BurgerTickets = burgerTickets;
            Console.Write("How many tickets did you have at the Ice Cream Booth: ");
            newParty.IceCreamTickets = Convert.ToInt32(GetValidDouble());
            Console.Write("What was the cost of the supplies at the Burger Booth? ");
            newParty.BurgerBooth = GetValidDouble();
            Console.Write("What was the cost of the supplies at the Ice Cream Booth? ");
            newParty.IceCreamBooth = GetValidDouble();

            _repo.AddParty(newParty);
            Console.WriteLine("Party Added");
            ContinueMessage();
        }

        public void SeeAllParties()
        {
            Console.Clear();
            List<Party> listOfParties = _repo.GetAllParties();

            foreach (Party item in listOfParties)
            {
                Console.WriteLine($"Total Tickets: {item.TotalTickets} ({item.BurgerTickets} Burger / {item.IceCreamTickets} Ice Crean)\n" +
                    $"Total Cost: ${item.TotalCost} (${item.BurgerBooth} Burger / ${item.IceCreamBooth} Ice Cream)\n" +
                    $"Cost per Ticket: Burger = {Math.Round(item.BurgerBooth / item.BurgerTickets, 2)}  Ice Cream = {Math.Round(item.IceCreamBooth / item.IceCreamTickets,2)}");
            }
            ContinueMessage();
        }

        public double GetValidDouble()
        {
            bool validNum = false;
            double number;
            while (!validNum)
            {
                bool parse = double.TryParse(Console.ReadLine(), out number);
                if (parse)
                {
                    return number;
                }
                else
                {
                    Console.Write("Invalid Input. Enter another number: ");
                }
            }
            return 0;
        }
        

        public void ContinueMessage()
        {
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
