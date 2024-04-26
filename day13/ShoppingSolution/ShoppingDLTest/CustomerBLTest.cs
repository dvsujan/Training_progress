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
        public async Task TestAddCustomer()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            Customer addedCustomer = await customerBL.AddCustomer(customer);
            Assert.AreEqual(customer, addedCustomer);
        }
        [Test]
        public async Task TestGetCustomer()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            await customerBL.AddCustomer(customer);
            Customer getCustomer = await customerBL.GetCustomer(1);
            Assert.AreEqual(customer, getCustomer);
        }
        [Test]
        public async Task TestUpdateCustomer()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            await customerBL.AddCustomer(customer);
            Customer updatedCustomer = new Customer { Id = 1, Phone = "1234567890", Age = 30 };
            Customer updateCustomer = await customerBL.UpdateCustomer(updatedCustomer);
            Customer getCustomer = await customerBL.GetCustomer(1);
            Assert.AreEqual(updatedCustomer, getCustomer);
            Assert.ThrowsAsync<NoCustomerWithGiveIdException>(() => customerBL.UpdateCustomer(new Customer { Id = 2, Phone = "1234567890", Age = 30 }));
        }
        [Test]
        public async Task TestDeleteCustomer()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            await customerBL.AddCustomer(customer);
            Customer deletedCustomer = await customerBL.DeleteCustomer(1);
            Assert.ThrowsAsync<NoCustomerWithGiveIdException>(async () => await customerBL.GetCustomer(1));
        }
        [Test]
        public async Task TestGetAllCustomers()
        {
            Customer customer1 = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            Customer customer2 = new Customer { Id = 2, Phone = "1234567890", Age = 30 };
            await customerBL.AddCustomer(customer1);
            await customerBL.AddCustomer(customer2);
            ICollection<Customer> customers = await customerBL.GetAllCustomers();
            Assert.AreEqual(2, customers.Count);
        }
        [Test]
        public async Task TestGetCustomerException()
        {
            Assert.ThrowsAsync<NoCustomerWithGiveIdException>(async () => await customerBL.GetCustomer(1));
        }
        [Test]
        public async Task  TestUpdateCustomerException()
        {
            Assert.ThrowsAsync<NoCustomerWithGiveIdException>(async() => await  customerBL.UpdateCustomer(new Customer { Id = 1, Phone = "1234567890", Age = 20 }));
        }
        [Test]
        public async Task  TestDeleteCustomerException()
        {
            Assert.ThrowsAsync<NoCustomerWithGiveIdException>(async () => await customerBL.DeleteCustomer(1));
        }
        [Test]
        public async Task  TestGetAllCustomersException()
        {
            Customer customer1 = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            Customer customer2 = new Customer { Id = 2, Phone = "1234567890", Age = 30 };
            await customerBL.AddCustomer(customer1);
            await customerBL.AddCustomer(customer2);
            await customerBL.DeleteCustomer(1);
            await customerBL.DeleteCustomer(2);
            var allcustomers = await customerBL.GetAllCustomers();
            Assert.AreEqual(0, allcustomers.Count);
        }
    }
}
