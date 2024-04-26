using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        public Task<Cart> AddCart(Cart cart);
        public Task<Cart> GetCartDetails(int id);
        public Task<ICollection<Cart>> GetAllCarts();
        public Task<Cart> UpdateCart(Cart cart);
        public Task<Cart> DeleteCart(int id);

        public Task<CartItem> AddCartItem(CartItem cartItem);
        public Task<CartItem> GetCartItem(int id);
        public Task<ICollection<CartItem>> GetAllCartItems();
        public Task DeleteCartItem(int id);
        public Task<double> Checkout(int cartId);
    }
}
