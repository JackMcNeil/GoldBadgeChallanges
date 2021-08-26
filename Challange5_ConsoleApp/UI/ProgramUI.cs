using Challange5_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange5_ConsoleApp.UI
{
    class ProgramUI
    {
        private CustomerRepo _repo = new CustomerRepo();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            Customer jake = new Customer("Jake", "Smith", TypeOfCustomer.Potential);
            Customer james = new Customer("James", "Smith", TypeOfCustomer.Current);
            Customer jane = new Customer("Jane", "Smith", TypeOfCustomer.Past);
            Customer jack = new Customer("Jack", "McNeil", TypeOfCustomer.Current);

            _repo.AddCustomer(jake);
            _repo.AddCustomer(james);
            _repo.AddCustomer(jane);
            _repo.AddCustomer(jack);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu:\n" +
                    "1. Add a new customer\n" +
                    "2. See all Customers\n" +
                    "3. See Customers by Type\n" +
                    "4. Update a Customer\n" +
                    "5. Delete a Customer\n" +
                    "6. Exit");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "1":
                    case "add":
                        AddNewCustomer();
                        break;
                    case "2":
                    case "see":
                        SeeAllCustomers();
                        break;
                    case "3":
                    case "type":
                        SeeCustomersByType();
                        break;
                    case "4":
                    case "update":
                        UpdateExistentCustomers();
                        break;
                    case "5":
                    case "delete":
                        DeleteExistingCustomer();
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

        public void AddNewCustomer()
        {
            Console.Clear();
            Customer cust = new Customer();
            //Name
            Console.Write("Enter Customers First Name: ");
            string firstName = GetProperString();
            cust.FirstName = firstName;
            Console.Write("Enter Customers Last Name: ");
            string lastName = GetProperString();
            cust.LastName = lastName;
            //Type
            bool valid = false;
            while (!valid)
            {
                Console.Write("Enter Customer type (1. Potential / 2. Current / 3. Past): ");
                string claimType = Console.ReadLine().ToLower();
                switch (claimType)
                {
                    case "1":
                    case "potential":
                        cust.CustomerType = TypeOfCustomer.Potential;
                        valid = true;
                        break;
                    case "2":
                    case "current":
                        cust.CustomerType = TypeOfCustomer.Current;
                        valid = true;
                        break;
                    case "3":
                    case "past":
                        cust.CustomerType = TypeOfCustomer.Past;
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("Not a valid entry");
                        ContinueMessage();
                        break;
                }
            }
            _repo.AddCustomer(cust);
        }



        public void SeeAllCustomers()
        {
            Console.Clear();
            Console.WriteLine("Full Name       Type          Email\n");
            List<Customer> allCustomers = _repo.GetAllCustomers();
            PrintCustomers(allCustomers);
        }

        public void PrintCustomers(List<Customer> lists)
        {
            List<Customer> sortedList = lists.OrderBy(o => o.FullName).ToList();
            foreach (Customer custy in sortedList)
            {
                Console.WriteLine($"{custy.FullName,-15} {custy.CustomerType,-13} {custy.Email,-10}");
            }
            ContinueMessage();
        }

        public void SeeCustomersByType()
        {
            List<Customer> listOfType = new List<Customer>();
            Console.Clear();
            bool valid = false;
            while (!valid)
            {
                Console.Write("Which type do you want to look at? (1. Potential / 2. Current / 3. Past): ");
                string claimType = Console.ReadLine().ToLower();
                switch (claimType)
                {
                    case "1":
                    case "potential":
                        listOfType = _repo.GetCustomersByType(TypeOfCustomer.Potential);
                        valid = true;
                        break;
                    case "2":
                    case "current":
                        listOfType = _repo.GetCustomersByType(TypeOfCustomer.Current);
                        valid = true;
                        break;
                    case "3":
                    case "past":
                        listOfType = _repo.GetCustomersByType(TypeOfCustomer.Past);
                        valid = true;
                        break;
                    default:
                        Console.WriteLine("Not a valid entry");
                        ContinueMessage();
                        break;
                }
            }
            PrintCustomers(listOfType);
        }

        public void UpdateExistentCustomers()
        {
            Console.Clear();
            Customer custy = new Customer();
            List<Customer> printList = new List<Customer>();
            Console.Write("What is the name of the customer you want to change? ");
            string name = Console.ReadLine();
            Customer result = _repo.GetCustomerByName(name);
            if (result != null)
            {
                Console.WriteLine($"Here is the info for {name}\n");
                printList.Add(result);
                PrintCustomers(printList);
                Console.Write("Enter new first name: ");
                custy.FirstName = GetProperString();
                Console.Write("Enter new last name: ");
                custy.LastName = GetProperString();
                //Type
                bool valid = false;
                while (!valid)
                {
                    Console.Write("Enter New Customer type (1. Potential / 2. Current / 3. Past): ");
                    string claimType = Console.ReadLine().ToLower();
                    switch (claimType)
                    {
                        case "1":
                        case "potential":
                            custy.CustomerType = TypeOfCustomer.Potential;
                            valid = true;
                            break;
                        case "2":
                        case "current":
                            custy.CustomerType = TypeOfCustomer.Current;
                            valid = true;
                            break;
                        case "3":
                        case "past":
                            custy.CustomerType = TypeOfCustomer.Past;
                            valid = true;
                            break;
                        default:
                            Console.WriteLine("Not a valid entry");
                            ContinueMessage();
                            break;
                    }
                }
                _repo.UpdateCustomer(custy, name);
            }
            else
            {
                Console.WriteLine("Person not found");
                ContinueMessage();
            }

        }

        public void DeleteExistingCustomer()
        {
            Console.Clear();
            Console.Write("What is the name of the customer you want to delete? ");
            string name = Console.ReadLine();
            Customer customerToDelete = _repo.GetCustomerByName(name);
            if (customerToDelete != null)
            {
                Console.WriteLine("Customer Deleted");
                _repo.DeleteCustomer(customerToDelete);
            }
            else
            {
                Console.WriteLine("Person Not Found");
            }
            ContinueMessage();
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
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
