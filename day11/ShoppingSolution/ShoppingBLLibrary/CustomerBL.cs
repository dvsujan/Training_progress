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

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                return repository.Add(customer);
            }
            catch (Exception ex)
            {
                throw new CustomerAlreadyExistsException();
            }
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                return repository.GetByKey(id);
            }
            catch (Exception ex)
            {
                throw new NoCustomerWithGiveIdException();
            }

        }

        public ICollection<Customer> GetAllCustomers()
        {
            return repository.GetAll();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            try
            {
                return repository.Update(customer);
            }
            catch (Exception ex)
            {
                throw new NoCustomerWithGiveIdException();
            }
        }

        public Customer DeleteCustomer(int id)
        {
            try
            {
                return repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new NoCustomerWithGiveIdException();
            }
        }
    }
}
