using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class CustomerBLTest
    {
        IRepository<int, Customer> repository;
        ICustomerService customerBL;
        [SetUp]
        public void Setup()
        {
            repository = new CustomerRepository();
            customerBL = new CustomerBL(repository);
        }
        [Test]
        public void TestAddCustomer()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            Customer addedCustomer = customerBL.AddCustomer(customer);
            Assert.AreEqual(customer, addedCustomer);
        }
        [Test]
        public void TestGetCustomer()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerBL.AddCustomer(customer);
            Customer getCustomer = customerBL.GetCustomer(1);
            Assert.AreEqual(customer, getCustomer);
        }
        [Test]
        public void TestUpdateCustomer()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerBL.AddCustomer(customer);
            Customer updatedCustomer = new Customer { Id = 1, Phone = "1234567890", Age = 30 };
            Customer updateCustomer = customerBL.UpdateCustomer(updatedCustomer);
            Customer getCustomer = customerBL.GetCustomer(1);
            Assert.AreEqual(updatedCustomer, getCustomer);
            Assert.Throws<NoCustomerWithGiveIdException>(() => customerBL.UpdateCustomer(new Customer { Id = 2, Phone = "1234567890", Age = 30 }));
        }
        [Test]
        public void TestDeleteCustomer()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerBL.AddCustomer(customer);
            Customer deletedCustomer = customerBL.DeleteCustomer(1);
            Assert.Throws<NoCustomerWithGiveIdException>(() => customerBL.GetCustomer(1));
        }
        [Test]
        public void TestGetAllCustomers()
        {
            Customer customer1 = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            Customer customer2 = new Customer { Id = 2, Phone = "1234567890", Age = 30 };
            customerBL.AddCustomer(customer1);
            customerBL.AddCustomer(customer2);
            ICollection<Customer> customers = customerBL.GetAllCustomers();
            Assert.AreEqual(2, customers.Count);
        }
        [Test]
        public void TestAddCustomerException()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerBL.AddCustomer(customer);
            Assert.Throws<CustomerAlreadyExistsException>(() => customerBL.AddCustomer(customer));
        }
        [Test]
        public void TestGetCustomerException()
        {
            Assert.Throws<NoCustomerWithGiveIdException>(() => customerBL.GetCustomer(1));
        }
        [Test]
        public void TestUpdateCustomerException()
        {
            Assert.Throws<NoCustomerWithGiveIdException>(() => customerBL.UpdateCustomer(new Customer { Id = 1, Phone = "1234567890", Age = 20 }));
        }
        [Test]
        public void TestDeleteCustomerException()
        {
            Assert.Throws<NoCustomerWithGiveIdException>(() => customerBL.DeleteCustomer(1));
        }
        [Test]
        public void TestGetAllCustomersException()
        {
            Customer customer1 = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            Customer customer2 = new Customer { Id = 2, Phone = "1234567890", Age = 30 };
            customerBL.AddCustomer(customer1);
            customerBL.AddCustomer(customer2);
            customerBL.DeleteCustomer(1);
            customerBL.DeleteCustomer(2);
            Assert.AreEqual(0, customerBL.GetAllCustomers().Count);
        }
    }
}
