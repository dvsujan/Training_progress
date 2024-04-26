using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingRepositoryTest
{
    public class CartItemRepoTest
    {
        IRepository<int, CartItem> cartItemRepo;
        [SetUp]
        public void Setup()
        {
            cartItemRepo = new CartItemsRepository();
        }
        [Test]
        public async Task TestAdd()
        {
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) };
            CartItem addedCartItem = await cartItemRepo.Add(cartItem);
            Assert.AreEqual(cartItem, addedCartItem);
        }
        [Test]
        public async Task TestGetByKey()
        {
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) };
            cartItemRepo.Add(cartItem);
            CartItem getCartItem = await cartItemRepo.GetByKey(1);
            Assert.AreEqual(cartItem, getCartItem);
        }
        [Test]
        public async Task TestUpdate()
        {
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) };
            await cartItemRepo.Add(cartItem);
            CartItem updatedCartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 2, Price = 200, Discount = 20, PriceExpiryDate = DateTime.Now.AddDays(2) };
            CartItem updateCartItem = await cartItemRepo.Update(updatedCartItem);
            CartItem getCartItem = await cartItemRepo.GetByKey(1);
            Assert.IsNotNull(updateCartItem);
        }
        [Test]
        public async Task TestDelete()
        {
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) };
            await cartItemRepo.Add(cartItem);
            CartItem deletedCartItem = await cartItemRepo.Delete(1);
            Assert.ThrowsAsync<NoCartItemWithGivenIdException>(async () => await cartItemRepo.GetByKey(1));
        }
        [Test]
        public async Task TestGetAll()
        {
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 2, Quantity = 2, Price = 200, Discount = 20, PriceExpiryDate = DateTime.Now.AddDays(2) };
            await cartItemRepo.Add(cartItem1);
            await cartItemRepo.Add(cartItem2);
            ICollection<CartItem> cartItems = await cartItemRepo.GetAll();
            Assert.AreEqual(2, cartItems.Count);
        }
        [Test]
        public async Task TestUpdateException()
        {
            Assert.ThrowsAsync<NoCartItemWithGivenIdException>(async () => await cartItemRepo.Update(new CartItem { CartId = 2, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) }));
        }
    }
}
