using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemsRepository: AbstractRepository<int, CartItem>
    {
        public override async Task<CartItem> Delete(int key)
        {
            CartItem cartItem = await GetByKey(key);
            if (cartItem != default(CartItem))
            {
                items.Remove(cartItem);
            }
            return cartItem;
        }
        
        public override async Task<CartItem> GetByKey(int key)
        {
            CartItem cartItem = items.FirstOrDefault(c => c.CartId == key);
            if (cartItem == default(CartItem))
            {
                throw new NoCartItemWithGivenIdException();
            }
            return cartItem;
        }

       
        public override async Task<CartItem> Update(CartItem item)
        {
            CartItem cartItem = await GetByKey(item.CartId);
            if (cartItem != default(CartItem))
            {
                cartItem = item;
            }
            return cartItem;
        }

    }
}
