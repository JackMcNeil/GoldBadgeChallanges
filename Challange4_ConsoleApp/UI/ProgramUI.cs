using Challange4_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange4_ConsoleApp.UI
{
    public class ProgramUI
    {
        private readonly OutingsRepo _repo = new OutingsRepo();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            Outings outing1 = new Outings(EventTypes.Golf, 14, new DateTime(2020, 4, 26), 435.67);
            Outings outing2 = new Outings(EventTypes.Bowling, 50, new DateTime(2021, 4, 26), 230.56);
            Outings outing3 = new Outings(EventTypes.AmusementPark, 5, new DateTime(2021, 6, 15), 500.14);
            Outings outing4 = new Outings(EventTypes.Golf, 8, new DateTime(2021, 6, 12), 300.57);
            Outings outing5 = new Outings(EventTypes.Golf, 14, new DateTime(2021, 4, 29), 354.98);

            _repo.AddToCollection(outing1);
            _repo.AddToCollection(outing2);
            _repo.AddToCollection(outing3);
            _repo.AddToCollection(outing4);
            _repo.AddToCollection(outing5);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu:\n" +
                    "1. Display list of all outings\n" +
                    "2. Add indiviual outing to list\n" +
                    "3. Calculations\n" +
                    "4. Exit");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "1":
                    case "display":
                    case "display list of all outings":
                        DisplayAllOutings();
                        break;
                    case "2":
                    case "add":
                    case "add individual outing to list":
                        AddOutingToList();
                        break;
                    case "3":
                    case "calc":
                    case "calculations":
                        Calculations();
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

        public void DisplayAllOutings()
        {
            Console.Clear();
            List<Outings> outings = _repo.GetAllOutings();
            Console.WriteLine("Event Type    Attendees       Date        Cost      Cost/Person");
            foreach(Outings item in outings)
            {
                Console.WriteLine($"{item.Event, -17} {item.Attendees, -8} {item.Date.ToShortDateString(), -13} ${item.TotalCost, -10} ${item.TotalCostPerPerson, -10}");
            }
            ContinueMessage();
        }

        public void AddOutingToList()
        {
            Console.Clear();
            Outings newOuting = new Outings();
            //EventType
            bool valid = false;
            while (!valid)
            {
                Console.Write("Enter the Event type (Golf (G) / Bowling (B) / AmusementPark (AP) / Concert (C): ");
                string claimType = Console.ReadLine().ToLower();
                switch (claimType)
                {
                    case "g":
                    case "golf":
                        newOuting.Event = EventTypes.Golf;
                        valid = true;
                        break;
                    case "b":
                    case "bowling":
                        newOuting.Event = EventTypes.Bowling;
                        valid = true;
                        break;
                    case "amusementpark":
                    case "ap":
                        newOuting.Event = EventTypes.AmusementPark;
                        valid = true;
                        break;
                    case "c":
                    case "concert":
                        newOuting.Event = EventTypes.Concert;
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("Not a valid entry");
                        ContinueMessage();
                        break;
                }
            }
            // Attendees
            bool validNumber = false;
            int amount = 0;
            while (!validNumber)
                try
                {
                    Console.Write("How many attendees were there? ");
                    amount = Convert.ToInt32(Console.ReadLine());
                    validNumber = true;
                }
                catch
                {
                    Console.WriteLine("Not a valid number.");
                }
            newOuting.Attendees = amount;

            //Date
            DateTime date = DateMaker();
            newOuting.Date = date;

            //Amount
            bool validAmount = false;
            double totalCost = 0;
            while (!validAmount)
                try
                {
                    Console.Write("What was the amount? ");
                    totalCost = Math.Round(Convert.ToDouble(Console.ReadLine()),2);
                    validAmount = true;
                }
                catch
                {
                    Console.WriteLine("Not a valid number.");
                }
            newOuting.TotalCost = totalCost;

            _repo.AddToCollection(newOuting);
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
                    Console.Write("Date of Event(mm/dd/yy): ");
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

        public void Calculations()
        {
            Console.Clear();
            Console.WriteLine("Which Calculation would you like to see?\n" +
                "1. Combined cost for all outings\n" +
                "2. See outing costs by type\n" +
                "3. See an individual type");
            bool calcValid = false;
            while (!calcValid)
            {
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "1":
                    case "all":
                        CombinedCost();
                        calcValid = true;
                        break;
                    case "2":
                    case "type":
                        TypeCost();
                        calcValid = true;
                        break;
                    case "3":
                    case "individual":
                        TypeCostIndividual();
                        calcValid = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        ContinueMessage();
                        break;
                }
            }
        }

        public void CombinedCost()
        {
            List<Outings> outings = _repo.GetAllOutings();
            double totalCost = 0;
            foreach (Outings item in outings)
            {
                totalCost += item.TotalCost;
            }
            Console.WriteLine($"All outings cost add up to: ${totalCost}");
            ContinueMessage();
        }

        public void TypeCost()
        {
            Console.Clear();
            double golfTotal = 0;
            double bowlingTotal = 0;
            double amusementTotal = 0;
            double concertTotal = 0;
            List<Outings> allOutings = _repo.GetAllOutings();
            foreach(Outings outing in allOutings)
            {
                if (outing.Event == EventTypes.Golf)
                {
                    golfTotal += outing.TotalCost;
                }
                else if (outing.Event == EventTypes.Bowling)
                {
                    bowlingTotal += outing.TotalCost;
                }
                else if (outing.Event == EventTypes.AmusementPark)
                {
                    amusementTotal += outing.TotalCost;
                }
                else
                {
                    concertTotal += outing.TotalCost;
                }
            }

            Console.WriteLine($"All golf outings costs are ${golfTotal}." +
                $"\nAll bowling outings costs are ${bowlingTotal}." +
                $"\nAll amusement park outings costs are ${amusementTotal}." +
                $"\nAll concert outings costs are ${concertTotal}.");
            ContinueMessage();
        }

        public void ContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        /* Most likely unnesscary code but commenting out in case I need it later */
        public void TypeCostIndividual()
        {
            string theEventType = null;
            List<Outings> outingsByType = new List<Outings>();
            double typeAmount = 0;
            bool getType = false;
            while (!getType)
            {
                Console.Write("Enter the Event type you would like to check (Golf (G) / Bowling (B) / AmusementPark (AP) / Concert (C): ");
                string claimType = Console.ReadLine().ToLower();
                switch (claimType)
                {
                    case "g":
                    case "golf":
                        outingsByType = _repo.GetOutingByType(EventTypes.Golf);
                        theEventType = "Golf";
                        getType = true;
                        break;
                    case "b":
                    case "bowling":
                        outingsByType = _repo.GetOutingByType(EventTypes.Bowling);
                        theEventType = "Bowling";
                        getType = true;
                        break;
                    case "amusementpark":
                    case "ap":
                        outingsByType = _repo.GetOutingByType(EventTypes.AmusementPark);
                        theEventType = "Amusement park";
                        getType = true;
                        break;
                    case "c":
                    case "concert":
                        outingsByType = _repo.GetOutingByType(EventTypes.Concert);
                        theEventType = "Concert";
                        getType = true;
                        break;
                    default:
                        Console.WriteLine("Not a valid entry");
                        ContinueMessage();
                        break;
                }
            }
            foreach(Outings item in outingsByType)
            {
                typeAmount += item.TotalCost;
            }
            Console.WriteLine($"All {theEventType} outings costs are ${typeAmount}");
            ContinueMessage();
        }
    }
}
