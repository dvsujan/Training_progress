using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        public Customer AddCustomer(Customer customer);
        public Customer GetCustomer(int id);
        public ICollection<Customer> GetAllCustomers();
        public Customer UpdateCustomer(Customer customer);
        public Customer DeleteCustomer(int id);
    }
}
