using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange5_ClassLibrary
{
    public class CustomerRepo
    {
        protected readonly List<Customer> _customerDirectory = new List<Customer>();

        //Crud
        //C

        public bool AddCustomer(Customer custy)
        {
            int startingCount = _customerDirectory.Count();
            _customerDirectory.Add(custy);
            return _customerDirectory.Count() > startingCount;
        }

        //R
        public List<Customer> GetAllCustomers()
        {
            return _customerDirectory;
        }

        public Customer GetCustomerByName(string Name)
        {
            List<Customer> customers = GetAllCustomers();
            Customer newCustomer = new Customer();
            foreach (Customer custy in customers)
            {
                if (custy.FullName == Name)
                {
                    return newCustomer;
                }
            }
            Console.WriteLine("No customer found with that name");
            return null;
        }

        //U
        public bool UpdateCustomer(Customer custy, string name)
        {
            Customer customer = GetCustomerByName(name);
            if (customer != null)
            {
                customer.FirstName = custy.FirstName;
                customer.LastName = custy.LastName;
                customer.CustomerType = custy.CustomerType;
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(Customer custy)
        {
            return _customerDirectory.Remove(custy);
        } 
    }
}
