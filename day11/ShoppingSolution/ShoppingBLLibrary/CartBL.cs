using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingDALLibrary; 

namespace ShoppingBLLibrary
{
    public class CartBL:ICartService
    {
        private IRepository<int, Cart> cartRepository;
        private IRepository<int, CartItem> cartItemRepository;
        private IRepository<int, Customer> customerRepository; 

        public CartBL(IRepository<int, Cart> cartRepository, IRepository<int, CartItem> cartItemRepository, IRepository<int , Customer> customerRepository)
        {
            this.cartRepository = cartRepository;
            this.cartItemRepository = cartItemRepository;
            this.customerRepository = customerRepository;
        }
        public Cart AddCart(Cart cart)
        {
            try
            {
                if (cartRepository.GetAll().Where(c => c.CustomerId == cart.CustomerId).Count() > 0)
                {
                    throw new CartAlreadyExistsException();
                }
                return cartRepository.Add(cart);

            }
            catch (Exception ex)
            {
                throw new CartAlreadyExistsException();
            }
        }
        public Cart GetCartDetails(int id)
        {
            try
            {
                return cartRepository.GetByKey(id);
            }
            catch (Exception ex)
            {
                throw new NoCartWithGivenIdException();
            }
        }
        public Cart UpdateCart(Cart cart)
        {
            try
            {
                return cartRepository.Update(cart);
            }
            catch (Exception ex)
            {
                throw new NoCartWithGivenIdException();
            }
        }
        public Cart DeleteCart(int id)
        {
            try
            {
                return cartRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new NoCartWithGivenIdException();
            }
        }
        public ICollection<Cart> GetAllCarts()
        {
            return cartRepository.GetAll();
        }
        public CartItem AddCartItem(CartItem cartItem)
        {
                if (cartItemRepository.GetAll().Where(c => c.CartId == cartItem.CartId).Count() >= 5)
                {
                    throw new CartItemQuantityExceededException();
                }
                if (cartRepository.GetByKey(cartItem.CartId) == null)
                {
                    throw new NoCartWithGivenIdException();
                }
                return cartItemRepository.Add(cartItem);    
        }
        
        public double Checkout(int cartId)
        {
            Cart cart = cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                throw new NoCartWithGivenIdException();
            }
            double totalAmount = 0;
            var items = cartItemRepository.GetAll();
            foreach (var item in items)
            {
                totalAmount += item.Price*item.Quantity;
 
            }

            if (totalAmount < 100)
            {
                totalAmount += 100;
            }
            if (cartItemRepository.GetAll().Where(c => c.CartId == cartId).Count() == 3 && totalAmount == 1500)
            {
                totalAmount -= totalAmount * 0.05;
            }
            return totalAmount;
        }
        public CartItem GetCartItem(int id)
        {
            try
            {
                return cartItemRepository.GetByKey(id);
            }
            catch (Exception ex)
            {
                throw new NoCartItemWithGivenIdException();
            }
        }

        public ICollection<CartItem> GetAllCartItems()
        {
            return cartItemRepository.GetAll();
        }

        public void DeleteCartItem(int id)
        {
            try
            {
                cartItemRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new NoCartItemWithGivenIdException();
            }
        }
    }
}
