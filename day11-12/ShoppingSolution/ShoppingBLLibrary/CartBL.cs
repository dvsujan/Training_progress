using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingDALLibrary;
using System.Diagnostics.CodeAnalysis;

namespace ShoppingBLLibrary
{
    public class CartBL:ICartService
    {
        private IRepository<int, Cart> cartRepository;
        private IRepository<int, CartItem> cartItemRepository;
        private IRepository<int, Customer> customerRepository;
        private IRepository<int, Product> productRepository; 
        
        public CartBL(IRepository<int, Cart> cartRepository, IRepository<int, CartItem> cartItemRepository, IRepository<int, Customer> customerRepository, IRepository<int, Product> productRepository)
        {
            this.cartRepository = cartRepository;
            this.cartItemRepository = cartItemRepository;
            this.customerRepository = customerRepository;
            this.productRepository = productRepository;
        }

        public Cart AddCart(Cart cart)
        {
                try { customerRepository.GetByKey(cart.CustomerId); }
                catch{
                    throw new NoCustomerWithGiveIdException();
                }
                if (cartRepository.GetAll().Where(c => c.CustomerId == cart.CustomerId).Count() > 0)
                {
                    throw new CartAlreadyExistsException();
                }
                return cartRepository.Add(cart);
        }
        public Cart GetCartDetails(int id)
        {
            try
            {
                Cart c = cartRepository.GetByKey(id);
                c.Items = cartItemRepository.GetAll().Where(c => c.CartId == id).ToList();
                return c;
            }
            catch 
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
            catch 
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
            catch 
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
                Product pp;
                
                if (cartItemRepository.GetAll().Where(c => c.CartId == cartItem.CartId).Sum(c => c.Quantity) + cartItem.Quantity > 5)
                {
                    throw new CartItemQuantityExceededException();
                }
                try {
                     pp = productRepository.GetByKey(cartItem.ProductId);
                    
                }
                catch
                {
                    throw new ProductNoutFoundException();
                }
                if (pp.stock < cartItem.Quantity)
                    {
                        throw new ProductOutOfStockException();
                    }
                try { cartRepository.GetByKey(cartItem.CartId); }
                catch{ 
                    throw new NoCartWithGivenIdException();
                }
                var price = pp.Price*cartItem.Quantity;
                cartItem.Price = price;
                return cartItemRepository.Add(cartItem);    
        }
        public double Checkout(int cartId)
        {
            Cart cart;
            try
            {
                cart = cartRepository.GetByKey(cartId);
            }
            catch
            {
                throw new NoCartWithGivenIdException();
            }
            double totalAmount = 0;
            var items = cartItemRepository.GetAll().Where(c => c.CartId == cartId);

            foreach (var item in items)
            {
                var product = productRepository.GetByKey(item.ProductId);
                if (product.stock < item.Quantity)
                {
                    throw new ProductOutOfStockException();
                }
                product.stock -= item.Quantity;
                productRepository.Update(product);
            }
            foreach (var item in items)
            {
                var itempriceafterdiscount = item.Price * item.Discount ;
                totalAmount += itempriceafterdiscount* item.Quantity;
            }
            if (totalAmount < 100)
            {
                totalAmount += 100;
            }
            if (cartItemRepository.GetAll().Where(c => c.CartId == cartId).Count() == 3 && totalAmount >= 1500)
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
            catch 
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
            catch 
            {
                throw new NoCartItemWithGivenIdException();
            }
        }
    }
}
