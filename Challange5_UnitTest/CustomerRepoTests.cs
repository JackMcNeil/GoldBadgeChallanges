using Challange5_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challange5_UnitTest
{
    [TestClass]
    public class CustomerRepoTests
    {
        private CustomerRepo _repo;
        private Customer _customer1;
        private Customer _customer2;
        private Customer _customer3;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CustomerRepo();
            _customer1 = new Customer("Jack", "McNeil", TypeOfCustomer.Current);
            _customer2 = new Customer("Elon", "Musk", TypeOfCustomer.Potential);
            _customer3 = new Customer("Elton", "John", TypeOfCustomer.Past);

            _repo.AddCustomer(_customer1);
            _repo.AddCustomer(_customer2);
            _repo.AddCustomer(_customer3);
        }

        [TestMethod]
        public void AddCustomerTest()
        {
            Customer custy = new Customer();
            bool add = _repo.AddCustomer(custy);

            Assert.IsTrue(add);
        }

        [TestMethod]
        public void ReadMethodsTests()
        {
            List<Customer> customer = _repo.GetAllCustomers();
            bool contains = customer.Contains(_customer1);
            Customer joe = _repo.GetCustomerByName("joe");
            Customer jack = _repo.GetCustomerByName("Jack McNeil");

            Assert.IsTrue(contains);
            Assert.AreEqual(TypeOfCustomer.Current, jack.CustomerType);
            Assert.IsNull(joe);
        }

        [TestMethod]
        public void UpdateCustomer_ShouldGetNewCustomerData()
        {
            Customer newElon = new Customer("Elon", "Musk", TypeOfCustomer.Current);
            _repo.UpdateCustomer(newElon, "Elon Musk");
            Customer elon = _repo.GetCustomerByName("Elon Musk");
            

            Assert.AreEqual(TypeOfCustomer.Current, elon.CustomerType);
        }

        [TestMethod]
        public void RemoveCustomer_MethodShouldReturnTrue()
        {
            bool remove = _repo.DeleteCustomer(_customer2);

            Assert.IsTrue(remove);
        }
    }
}
