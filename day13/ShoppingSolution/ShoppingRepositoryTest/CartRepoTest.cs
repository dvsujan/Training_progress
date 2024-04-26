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
        public async Task TestAdd()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            Cart addedCart = await cartRepo.Add(cart);
            Assert.AreEqual(cart, addedCart);
        }

        [Test]
        public async Task TestGetByKey()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartRepo.Add(cart);
            Cart getCart = await cartRepo.GetByKey(1);
            Assert.AreEqual(cart, getCart);
        }

        [Test]
        public async Task TestUpdate()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartRepo.Add(cart);
            Cart updatedCart = new Cart { Id = 1, CustomerId = 2 };
            Cart updateCart = await cartRepo.Update(updatedCart);
            Assert.IsNotNull(updateCart);
        }

        [Test]
        public async Task TestDelete()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartRepo.Add(cart);
            Cart deletedCart = await cartRepo.Delete(1);
            Assert.ThrowsAsync<NoCartWithGivenIdException>(async () => await cartRepo.GetByKey(1));
        }
        [Test]
        public async Task TestGetAll()
        {
            Cart cart1 = new Cart { Id = 1, CustomerId = 1 };
            Cart cart2 = new Cart { Id = 2, CustomerId = 2 };
            await cartRepo.Add(cart1);
            await cartRepo.Add(cart2);
            ICollection<Cart> carts = await cartRepo.GetAll();
            Assert.AreEqual(2, carts.Count);
        }
    }
}
