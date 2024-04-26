using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override async Task<Customer> Delete(int key)
        {
            Customer customer = await GetByKey(key);
            if(customer != default(Customer)) 
            { 
                items.Remove(customer);
            }
            return customer;
        }

        public override async Task<Customer> GetByKey(int key)
        {
            Customer customer = items.FirstOrDefault(c => c.Id == key);
            if (customer == default(Customer))
            {
                throw new NoCustomerWithGiveIdException();
            }
            return customer;
        }

        public override async Task<Customer> Update(Customer item)
        {
            Customer customer = await GetByKey(item.Id);
            if (customer != default(Customer))
            {
                customer = item;
            }
            return customer;
        }
    }
}
