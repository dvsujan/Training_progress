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
    public class CartRepoTest
    {
        IRepository<int, Cart> cartRepo; 

        [SetUp]
        public void Setup()
        {
            cartRepo = new CartRepository();
        }

        [Test]
        public void TestAdd()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            Cart addedCart = cartRepo.Add(cart);
            Assert.AreEqual(cart, addedCart);
        }

        [Test]
        public void TestGetByKey()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartRepo.Add(cart);
            Cart getCart = cartRepo.GetByKey(1);
            Assert.AreEqual(cart, getCart);
        }

        [Test]
        public void TestUpdate()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartRepo.Add(cart);
            Cart updatedCart = new Cart { Id = 1, CustomerId = 2 };
            Cart updateCart = cartRepo.Update(updatedCart);
            Assert.IsNotNull(updateCart);
        }

        [Test]
        public void TestDelete()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartRepo.Add(cart);
            Cart deletedCart = cartRepo.Delete(1);
            Assert.Throws<NoCartWithGivenIdException>(() => cartRepo.GetByKey(1));
        }
        [Test]
        public void TestGetAll()
        {
            Cart cart1 = new Cart { Id = 1, CustomerId = 1 };
            Cart cart2 = new Cart { Id = 2, CustomerId = 2 };
            cartRepo.Add(cart1);
            cartRepo.Add(cart2);
            ICollection<Cart> carts = cartRepo.GetAll();
            Assert.AreEqual(2, carts.Count);
        }
    }
}
