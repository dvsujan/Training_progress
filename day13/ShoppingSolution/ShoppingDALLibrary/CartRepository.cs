using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override async Task<Cart> Delete(int key)
        {
            Cart cart = await GetByKey(key);
            if (cart != default(Cart))
            {
                items.Remove(cart);
            }
            return cart;
        }
        
        public override async Task<Cart> GetByKey(int key)
        {
            Cart cart = items.FirstOrDefault(c => c.Id == key);
            if (cart == default(Cart))
            {
                throw new NoCartWithGivenIdException();
            }
            return cart;
        }
        
        public override async Task<Cart>Update(Cart item)
        {
            Cart cart = await GetByKey(item.Id);
            if (cart != null)
            {
                cart = item;
            }
            return cart;
        }
    }
}
