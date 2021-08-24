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

        public Customer GetCustomerByName(string name)
        {
            List<Customer> customers = GetAllCustomers();
            foreach (Customer custy in customers)
            {
                if (custy.FullName.ToLower() == name.ToLower())
                {
                    return custy;
                }
            }
            Console.WriteLine("No customer found with that name");
            return null;
        }

        public List<Customer> GetCustomersByType(TypeOfCustomer type)
        {
            List<Customer> customers = GetAllCustomers();
            List<Customer> newList = new List<Customer>();
            foreach (Customer custy in customers)
            {
                if (custy.CustomerType == type)
                {
                    newList.Add(custy);
                }
            }
            return newList;
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

        //D
        public bool DeleteCustomer(Customer custy)
        {
            return _customerDirectory.Remove(custy);
        } 
    }
}
