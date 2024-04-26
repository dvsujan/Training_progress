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
        public async Task TestAdd()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            Customer addedCustomer = await customerRepo.Add(customer);
            Assert.That(addedCustomer, Is.EqualTo(customer));
        }
        [Test]
        public async Task TestGetByKey()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            await customerRepo.Add(customer);
            Customer getCustomer = await customerRepo.GetByKey(1);
            Assert.AreEqual(customer, getCustomer);
        }
        [Test]
        public async Task TestUpdate()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            await customerRepo.Add(customer);
            Customer updatedCustomer = new Customer { Id = 1, Phone = "1234567890", Age = 30 };
            Customer updateCustomer = await customerRepo.Update(updatedCustomer);
            Customer getCustomer = await customerRepo.GetByKey(1);
            Assert.AreEqual(updatedCustomer, getCustomer);
            Assert.ThrowsAsync<NoCustomerWithGiveIdException>(async () => await customerRepo.Update(new Customer { Id = 2, Phone = "1234567890", Age = 30 }));
            
        }
        [Test]
        public async Task TestDelete()
        {
            Customer customer = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            await customerRepo.Add(customer);
            Customer deletedCustomer = await customerRepo.Delete(1);
            Assert.ThrowsAsync<NoCustomerWithGiveIdException>(async() => await customerRepo.GetByKey(1));
        }
        [Test]
        public async Task TestGetAll()
        {
            Customer customer1 = new Customer { Id = 1, Phone = "1234567890", Age = 20 };
            Customer customer2 = new Customer { Id = 2, Phone = "1234567890", Age = 30 };
            await customerRepo.Add(customer1);
            await customerRepo.Add(customer2);
            ICollection<Customer> customers = await customerRepo.GetAll();
            Assert.AreEqual(2, customers.Count);
        }
    }
}
