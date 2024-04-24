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
        public void TestAdd()
        {
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) };
            CartItem addedCartItem = cartItemRepo.Add(cartItem);
            Assert.AreEqual(cartItem, addedCartItem);
        }
        [Test]
        public void TestGetByKey()
        {
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) };
            cartItemRepo.Add(cartItem);
            CartItem getCartItem = cartItemRepo.GetByKey(1);
            Assert.AreEqual(cartItem, getCartItem);
        }
        [Test]
        public void TestUpdate()
        {
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) };
            cartItemRepo.Add(cartItem);
            CartItem updatedCartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 2, Price = 200, Discount = 20, PriceExpiryDate = DateTime.Now.AddDays(2) };
            CartItem updateCartItem = cartItemRepo.Update(updatedCartItem);
            CartItem getCartItem = cartItemRepo.GetByKey(1);
            Assert.IsNotNull(updateCartItem);
        }
        [Test]
        public void TestDelete()
        {
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) };
            cartItemRepo.Add(cartItem);
            CartItem deletedCartItem = cartItemRepo.Delete(1);
            Assert.Throws<NoCartItemWithGivenIdException>(() => cartItemRepo.GetByKey(1));
        }
        [Test]
        public void TestGetAll()
        {
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 100, Discount = 10, PriceExpiryDate = DateTime.Now.AddDays(1) };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 2, Quantity = 2, Price = 200, Discount = 20, PriceExpiryDate = DateTime.Now.AddDays(2) };
            cartItemRepo.Add(cartItem1);
            cartItemRepo.Add(cartItem2);
            ICollection<CartItem> cartItems = cartItemRepo.GetAll();
            Assert.AreEqual(2, cartItems.Count);
        }
    }
}
