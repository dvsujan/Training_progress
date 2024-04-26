using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;  


namespace ShoppingBLLibrary
{
    public class CustomerBL:ICustomerService
    {
        private IRepository<int, Customer> repository;
        public CustomerBL(IRepository<int, Customer> repository)
        {
            this.repository = repository;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
                return await repository.Add(customer);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            try
            {
                return await repository.GetByKey(id);
            }
            catch 
            {
                throw new NoCustomerWithGiveIdException();
            }

        }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            return await repository.GetAll();
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            try
            {
                return await repository.Update(customer);
            }
            catch 
            {
                throw new NoCustomerWithGiveIdException();
            }
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            try
            {
                return await repository.Delete(id);
            }
            catch 
            {
                throw new NoCustomerWithGiveIdException();
            }
        }
    }
}
