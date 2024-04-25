using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override Customer Add(Customer item)
        {
            try
            {
                GetByKey(item.Id);
                throw new CustomerAlreadyExistsException();
            }
            catch (NoCustomerWithGiveIdException)
            {
                items.Add(item);
                return item;
            }
        }
        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            if(customer != default(Customer)) 
            { 
                items.Remove(customer);
            }
            return customer;
        }

        public override Customer GetByKey(int key)
        {
            Customer customer = items.FirstOrDefault(c => c.Id == key);
            if (customer == default(Customer))
            {
                throw new NoCustomerWithGiveIdException();
            }
            return customer;
        }

        public override Customer Update(Customer item)
        {
            Customer customer = GetByKey(item.Id);
            if (customer != default(Customer))
            {
                customer = item;
            }
            return customer;
        }
    }
}
