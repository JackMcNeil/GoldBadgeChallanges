using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange5_ClassLibrary
{
    public enum TypeOfCustomer { Potential, Current, Past}

    public class Customer
    {
        Dictionary<TypeOfCustomer, string> emailDictionary = new Dictionary<TypeOfCustomer, string>()
        {
            {TypeOfCustomer.Potential, "We currently have the lowest rates on Helicopter Insurance!"},
            {TypeOfCustomer.Current, "Thank you for your work with us. We appreciate your loyalty. Here's a coupon" },
            {TypeOfCustomer.Past, "It's been a long time since we've heard from you, we want you back" }
        };
 
        public Customer() { }
        public Customer(string firstName, string lastName, TypeOfCustomer customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + LastName;
            }
        }
        public TypeOfCustomer CustomerType { get; set; }
        public string Email
        {
            get
            {
                return emailDictionary[CustomerType];
            }
        }
    }
}
