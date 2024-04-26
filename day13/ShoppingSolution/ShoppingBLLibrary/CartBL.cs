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
        
        public async Task<Cart> AddCart(Cart cart)
        {
                try { await customerRepository.GetByKey(cart.CustomerId); }
                catch{
                    throw new NoCustomerWithGiveIdException();
                }
                var allcarts = await cartRepository.GetAll();
                if (allcarts.Where(c => c.CustomerId == cart.CustomerId).Count() > 0)
                {
                    throw new CartAlreadyExistsException();
                }
                return await cartRepository.Add(cart);
        }
        public async Task<Cart> GetCartDetails(int id)
        {
            try
            {
                Cart c = await cartRepository.GetByKey(id);
                var all = await cartItemRepository.GetAll();
                c.Items = all.Where(c => c.CartId == id).ToList();
                return c;
            }
            catch 
            {
                throw new NoCartWithGivenIdException();
            }
        }
        public async Task<Cart> UpdateCart(Cart cart)
        {
            try
            {
                return await cartRepository.Update(cart);
            }
            catch 
            {
                throw new NoCartWithGivenIdException();
            }
        }
        public async Task<Cart> DeleteCart(int id)
        {
            try
            {
                return await cartRepository.Delete(id);
            }
            catch 
            {
                throw new NoCartWithGivenIdException();
            }
        }
        public async Task<ICollection<Cart>> GetAllCarts()
        {
            return await cartRepository.GetAll();
        }

        public async Task<CartItem> AddCartItem(CartItem cartItem)
        {
                Product pp;
                var cartItemall = await cartItemRepository.GetAll();
                
                if (cartItemall.Where(c => c.CartId == cartItem.CartId).Sum(c => c.Quantity) + cartItem.Quantity > 5)
                {
                    throw new CartItemQuantityExceededException();
                }
                try {
                     pp = await productRepository.GetByKey(cartItem.ProductId);
                    
                }
                catch
                {
                    throw new ProductNoutFoundException();
                }
                if (pp.stock < cartItem.Quantity)
                    {
                        throw new ProductOutOfStockException();
                    }
                try { await cartRepository.GetByKey(cartItem.CartId); }
                catch{ 
                    throw new NoCartWithGivenIdException();
                }
                var price = pp.Price*cartItem.Quantity;
                cartItem.Price = price;
                return await cartItemRepository.Add(cartItem);    
        }
        public async Task<double> Checkout(int cartId)
        {
            Cart cart;
            try
            {
                cart = await cartRepository.GetByKey(cartId);
            }
            catch
            {
                throw new NoCartWithGivenIdException();
            }
            double totalAmount = 0;
            var allitems = await cartItemRepository.GetAll();
            var items = allitems.Where(c => c.CartId == cartId);

            foreach (var item in items)
            {
                var product = await productRepository.GetByKey(item.ProductId);
                if (product.stock < item.Quantity)
                {
                    throw new ProductOutOfStockException();
                }
                product.stock -= item.Quantity;
                await productRepository.Update(product);
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
            if (allitems.Where(c => c.CartId == cartId).Count() == 3 && totalAmount >= 1500)
            {
                totalAmount -= totalAmount * 0.05;
            }
            return totalAmount;
        }
        public async Task<CartItem> GetCartItem(int id)
        {
            try
            {
                return await cartItemRepository.GetByKey(id);
            }
            catch 
            {
                throw new NoCartItemWithGivenIdException();
            }
        }

        public async Task<ICollection<CartItem>> GetAllCartItems()
        {
            return await cartItemRepository.GetAll();
        }

        public async Task DeleteCartItem(int id)
        {
            try
            {
                await cartItemRepository.Delete(id);
            }
            catch 
            {
                throw new NoCartItemWithGivenIdException();
            }
        }
    }
}
