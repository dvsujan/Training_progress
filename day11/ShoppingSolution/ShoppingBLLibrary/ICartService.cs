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
        public Cart AddCart(Cart cart);
        public Cart GetCartDetails(int id);
        public ICollection<Cart> GetAllCarts();
        public Cart UpdateCart(Cart cart);
        public Cart DeleteCart(int id);

        public CartItem AddCartItem(CartItem cartItem);
        public CartItem GetCartItem(int id);
        public ICollection<CartItem> GetAllCartItems();
        public void DeleteCartItem(int id);
        public double Checkout(int cartId);
    }
}
