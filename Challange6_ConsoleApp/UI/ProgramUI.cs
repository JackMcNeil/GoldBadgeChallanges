using Challange6_ClassLibrary;
using Challange6_ClassLibrary.CarTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange6_ConsoleApp.UI
{
    public class ProgramUI
    {
        private readonly GreenPlanRepo _repo = new GreenPlanRepo();
        private int _id = 4;
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            Electric electric = new Electric("Porsche", "Taycan", 2021, 1, 5, 280);
            Gas gas = new Gas("Honda", "CRV", 2015, 2, 31.2, 14);
            Hybrid hybrid = new Hybrid("Toyota", "Camry", 2022, 3, 51, 2);

            _repo.AddCarToDirectory(electric);
            _repo.AddCarToDirectory(gas);
            _repo.AddCarToDirectory(hybrid);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu:\n" +
                    "1. See all cars\n" +
                    "2. See Cars by Type\n" +
                    "3. Add a Car\n" +
                    "4. Update a Car\n" +
                    "5. Delete a Car\n" +
                    "6. Exit");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "1":
                    case "all":
                    case "see all cars":
                        SeeAllCars();
                        break;
                    case "2":
                    case "type":
                    case "see cars by type":
                        SeeCarByType();
                        break;
                    case "3":
                    case "add":
                        AddACar();
                        break;
                    case "4":
                    case "update":
                        UpdateACar();
                        break;
                    case "5":
                    case "delete":
                        DeleteACar();
                        break;
                    case "6":
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

        public void SeeAllCars()
        {
            Console.Clear();
            Console.WriteLine("Make      Model       Year      Type          ID\n");
            List<Car> allCars = _repo.GetAllCars();
            foreach (Car item in allCars)
            {
                Console.WriteLine($"{item.Make, -10}{item.Model, -12}{item.Year, -10}{item.GetType().Name,-15}{item.Id,-10}");
            }
            ContinueMessage();
        }

        public void SeeCarByType()
        {
            Console.Clear();
            string type = AskForType();
            Console.Clear();
            if (type == "electric")
            {
                List<Electric> allElectric = _repo.GetAllElectric();
                Console.WriteLine("Make      Model       Year      Charge Time      Miles/Charge     ID\n");
                foreach (Electric car in allElectric)
                {
                    PrintElectric(car);
                }
            }
            else if(type == "hybrid")
            {
                Console.WriteLine("Make      Model       Year      Charge Time      Miles/Gallon     ID\n");
                List<Hybrid> allHybrid = _repo.GetAllHybrid();
                foreach(Hybrid car in allHybrid)
                {
                    PrintHybrid(car);
                }
            }
            else
            {
                Console.WriteLine("Make      Model       Year      Miles/Gallon      Tank Size     ID\n");
                List<Gas> allGas = _repo.GetAllGas();
                foreach (Gas car in allGas)
                {
                    PrintGas(car);
                }
            }
            ContinueMessage();
        }

        public void PrintElectric(Electric car)
        {
            Console.WriteLine($"{car.Make,-10}{car.Model,-12}{car.Year,-5}{car.HoursToCharge, 7} Hours {car.MilesOnCharge,10} Miles{car.Id,10}\n");
        }
        
        public void PrintHybrid(Hybrid car)
        {
            Console.WriteLine($"{car.Make,-10}{car.Model,-12}{car.Year,-5}{car.HoursToCharge, 7} Hours {car.MilesPerGallon,10} MPG{car.Id, 12}\n");
        }

        public void PrintGas(Gas car)
        {
            Console.WriteLine($"{car.Make,-10}{car.Model,-12}{car.Year,-5}{car.MilesPerGallon,10} MPG {car.TankSize, 10} Gallons{car.Id,6}\n");
        }

        public string AskForType()
        {
            Console.Write("Which Car Type do you want to see? (1. Electric 2. Hybrid 3. Gas): ");
            bool validInput = false;
            while (!validInput)
            {
                string ans = Console.ReadLine().ToLower();
                switch(ans)
                {
                    case "1":
                    case "electric":
                        return "electric";
                    case "2":
                    case "hybrid":
                        return "hybrid";
                    case "3":
                    case "gas":
                        return "gas";
                    default:
                        Console.WriteLine("Invalid Input");
                        ContinueMessage();
                        break;
                }
            }
            return null;
        }

        public int GetValidInt()
        {
            bool validNum = false;
            int number;
            while (!validNum)
            {
                bool parse = int.TryParse(Console.ReadLine(), out number);
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

        public void AddACar()
        {
            Console.Clear();
            string type = AskForType();
            Console.Clear();
            if (type == "electric")
            {
                Electric electric = new Electric();
                Console.Write("Make: ");
                electric.Make = Console.ReadLine();
                Console.Write("Model: ");
                electric.Model = Console.ReadLine();
                Console.Write("Year: ");
                electric.Year = GetValidInt();
                electric.Id = _id;
                _id++;
                Console.Write("Hours to Charge: ");
                electric.HoursToCharge = GetValidInt();
                Console.Write("Miles/Charge: ");
                electric.MilesOnCharge = GetValidInt();
                Console.WriteLine("Car added");
                _repo.AddCarToDirectory(electric);
            }
            else if (type == "hybrid")
            {
                Hybrid hybrid = new Hybrid();
                Console.Write("Make: ");
                hybrid.Make = Console.ReadLine();
                Console.Write("Model: ");
                hybrid.Model = Console.ReadLine();
                Console.Write("Year: ");
                hybrid.Year = GetValidInt();
                hybrid.Id = _id;
                _id++;
                Console.Write("Hours to Charge: ");
                hybrid.HoursToCharge = GetValidInt();
                Console.Write("Miles/Gallon: ");
                hybrid.MilesPerGallon = GetValidInt();
                Console.WriteLine("Car added");
                _repo.AddCarToDirectory(hybrid);
            }
            else
            {
                Gas gas = new Gas();
                Console.Write("Make: ");
                gas.Make = Console.ReadLine();
                Console.Write("Model: ");
                gas.Model = Console.ReadLine();
                Console.Write("Year: ");
                gas.Year = GetValidInt();
                gas.Id = _id;
                _id++;
                Console.Write("Tank Size: ");
                gas.TankSize = GetValidInt();
                Console.Write("Miles/Gallon: ");
                gas.MilesPerGallon = GetValidInt();
                Console.WriteLine("Car added");
                _repo.AddCarToDirectory(gas);
            }
            ContinueMessage();
        }

        public void UpdateACar()
        {
            Console.Clear();
            string type = AskForType();
            Console.Clear();
            if (type == "electric")
            {
                List<Electric> allElectric = _repo.GetAllElectric();
                Console.WriteLine("Make      Model       Year      Charge Time      Miles/Charge     ID\n");
                foreach (Electric car in allElectric)
                {
                    PrintElectric(car);
                }
                Console.Write("What is the Id number of the car you want to update? ");
                int idToUpdate = GetValidInt();
                Electric carToUpdate = _repo.GetElectricById(idToUpdate);
                if (carToUpdate == null)
                {
                    Console.WriteLine("No car with that Id found in the electric car list");
                }
                else
                {
                    Electric electric = new Electric();
                    Console.Write("Make: ");
                    electric.Make = Console.ReadLine();
                    Console.Write("Model: ");
                    electric.Model = Console.ReadLine();
                    Console.Write("Year: ");
                    electric.Year = GetValidInt();
                    electric.Id = carToUpdate.Id;
                    Console.Write("Hours to Charge: ");
                    electric.HoursToCharge = GetValidInt();
                    Console.Write("Miles/Charge: ");
                    electric.MilesOnCharge = GetValidInt();
                    Console.WriteLine("Car Updated");

                    _repo.UpdateElectric(electric);
                }
            }
            else if (type == "hybrid")
            {
                List<Hybrid> allHybrid = _repo.GetAllHybrid();
                Console.WriteLine("Make      Model       Year      Charge Time      Miles/Gallon     ID\n");
                foreach (Hybrid car in allHybrid)
                {
                    PrintHybrid(car);
                }
                Console.Write("What is the Id number of the car you want to update? ");
                int idToUpdate = GetValidInt();
                Hybrid carToUpdate = _repo.GetHybridById(idToUpdate);
                if (carToUpdate == null)
                {
                    Console.WriteLine("No car with that Id found in the Hybrid car list");
                }
                else
                {
                    Hybrid hybrid = new Hybrid();
                    Console.Write("Make: ");
                    hybrid.Make = Console.ReadLine();
                    Console.Write("Model: ");
                    hybrid.Model = Console.ReadLine();
                    Console.Write("Year: ");
                    hybrid.Year = GetValidInt();
                    hybrid.Id = carToUpdate.Id;
                    Console.Write("Hours to Charge: ");
                    hybrid.HoursToCharge = GetValidInt();
                    Console.Write("Miles/Gallon: ");
                    hybrid.MilesPerGallon = GetValidInt();
                    Console.WriteLine("Car Updated");

                    _repo.UpdateHybird(hybrid);
                }
            }
            else
            {
                List<Gas> allGas = _repo.GetAllGas();
                Console.WriteLine("Make      Model       Year      Miles/Gallon      Tank Size     ID\n");
                foreach (Gas car in allGas)
                {
                    PrintGas(car);
                }
                Console.Write("What is the Id number of the car you want to update? ");
                int idToUpdate = GetValidInt();
                Gas carToUpdate = _repo.GetGasById(idToUpdate);
                if (carToUpdate == null)
                {
                    Console.WriteLine("No car with that Id found in the Gas car list");
                }
                else
                {
                    Gas gas = new Gas();
                    Console.Write("Make: ");
                    gas.Make = Console.ReadLine();
                    Console.Write("Model: ");
                    gas.Model = Console.ReadLine();
                    Console.Write("Year: ");
                    gas.Year = GetValidInt();
                    gas.Id = carToUpdate.Id;
                    Console.Write("Tank Size: ");
                    gas.TankSize = GetValidInt();
                    Console.Write("Miles/Gallon: ");
                    gas.MilesPerGallon = GetValidInt();
                    Console.WriteLine("Car added");

                    _repo.UpdateGas(gas);
                }
            }
            ContinueMessage();
        }

        public void DeleteACar()
        {
            Console.Clear();
            Console.Write("What is the Id of the car you want to delete? ");
            int idToDelete = GetValidInt();
            Car carToDelete = _repo.GetCarById(idToDelete);
            Console.WriteLine($"{carToDelete.Make, -10}{carToDelete.Model,-10}{carToDelete.Year,-10}{carToDelete.Id,-10} ");
            Console.Write("Are you sure you want to delete? (y/n) ");
            bool validInput = false;
            while (!validInput)
            {
                string ans = Console.ReadLine().ToLower();
                if (ans == "yes" || ans == "y")
                {
                    _repo.DeleteACar(carToDelete);
                    validInput = true;
                }
                else if(ans == "no" || ans == "n")
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Enter a valid answer (y/n)");
                }
            }
            ContinueMessage();
        }

        public void ContinueMessage()
        {
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
