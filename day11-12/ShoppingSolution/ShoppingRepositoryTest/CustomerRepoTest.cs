using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingRepositoryTest
{
    public class CustomerRepoTest
    {
        IRepository<int, Customer> customerRepo; 
        [SetUp]
        public void Setup()
        {
            customerRepo = new CustomerRepository();
        }
        [Test]
        public void TestAdd()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            Customer addedCustomer = customerRepo.Add(customer);
            Assert.AreEqual(customer, addedCustomer);
        }
        [Test]
        public void TestGetByKey()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerRepo.Add(customer);
            Customer getCustomer = customerRepo.GetByKey(1);
            Assert.AreEqual(customer, getCustomer);
        }
        [Test]
        public void TestUpdate()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerRepo.Add(customer);
            Customer updatedCustomer = new Customer { Id = 1, Phone = "1234567890", Age = 30 };
            Customer updateCustomer = customerRepo.Update(updatedCustomer);
            Customer getCustomer = customerRepo.GetByKey(1);
            Assert.AreEqual(updatedCustomer, getCustomer);
            Assert.Throws<NoCustomerWithGiveIdException>(() => customerRepo.Update(new Customer { Id = 2, Phone = "1234567890", Age = 30 }));
            
        }
        [Test]
        public void TestDelete()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            customerRepo.Add(customer);
            Customer deletedCustomer = customerRepo.Delete(1);
            Assert.Throws<NoCustomerWithGiveIdException>(() => customerRepo.GetByKey(1));
        }
        [Test]
        public void TestGetAll()
        {
            Customer customer1 = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            Customer customer2 = new Customer { Id = 2, Phone = "1234567890", Age = 30 };
            customerRepo.Add(customer1);
            customerRepo.Add(customer2);
            ICollection<Customer> customers = customerRepo.GetAll();
            Assert.AreEqual(2, customers.Count);
        }
    }
}
