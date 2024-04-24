using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTest
{
    public class CartBLTest
    {
        IRepository<int, Cart> cartRepository;
        IRepository<int, Customer> customerRepository;
        IRepository<int, CartItem> cartItemRepository;
        ICartService cartService;
        [SetUp]
        public void Setup()
        {
            cartRepository = new CartRepository();
            customerRepository = new CustomerRepository();
            cartItemRepository = new CartItemsRepository();
            cartService = new CartBL(cartRepository, cartItemRepository, customerRepository);
        }
        [Test]
        public void TestAddCart()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            Cart addedCart = cartService.AddCart(cart);
            Assert.AreEqual(cart, addedCart);
        }
        [Test]
        public void TestGetCartDetails()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            Cart getCart = cartService.GetCartDetails(1);
            Assert.AreEqual(cart, getCart);
        }
        [Test]
        public void TestUpdateCart()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            Cart updatedCart = new Cart { Id = 1, CustomerId = 1 };
            Cart updateCart = cartService.UpdateCart(updatedCart);
            Cart getCart = cartService.GetCartDetails(1);
            Assert.IsNotNull(getCart);
        }
        [Test]
            
        public void TestDeleteCart()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            Cart deletedCart = cartService.DeleteCart(1);
            Assert.Throws<NoCartWithGivenIdException>(() => cartService.GetCartDetails(1));
        }
        [Test]
        public void TestGetAllCarts()
        {
            Cart cart1 = new Cart { Id = 1, CustomerId = 1 };
            Cart cart2 = new Cart { Id = 2, CustomerId = 2 };
            cartService.AddCart(cart1);
            cartService.AddCart(cart2);
            ICollection<Cart> carts = cartService.GetAllCarts();
            Assert.AreEqual(2, carts.Count);
        }
        [Test]
        public void TestAddCartException()
        {
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            Assert.Throws<CartAlreadyExistsException>(() => cartService.AddCart(cart));
        }
        [Test]
        public void TestGetCartException()
        {
            Assert.Throws<NoCartWithGivenIdException>(() => cartService.GetCartDetails(1));
        }
        [Test]
        public void TestUpdateCartException()
        {
            Assert.Throws<NoCartWithGivenIdException>(() => cartService.UpdateCart(new Cart { Id = 1, CustomerId = 1 }));
        }
        [Test]
        public void TestDeleteCartException()
        {
            Assert.Throws<NoCartWithGivenIdException>(() => cartService.DeleteCart(1));
        }
        [Test]
        public void TestGetAllCartsException()
        {
            Cart cart1 = new Cart { Id = 1, CustomerId = 1 };
            Cart cart2 = new Cart { Id = 2, CustomerId = 2 };
            cartService.AddCart(cart1);
            cartService.AddCart(cart2);
            cartService.DeleteCart(1);
            cartService.DeleteCart(2);
            Assert.AreEqual(0, cartService.GetAllCarts().Count);
        }
        [Test]
        public void TestAddCartItem()
        {
            Cart cart = new Cart { Id=1, CustomerId = 1 };
            cartService.AddCart(cart);
            CartItem cartItem = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2, Price=1010 };
            CartItem addedCartItem = cartService.AddCartItem(cartItem);
            Assert.AreEqual(cartItem, addedCartItem);
        }
        [Test]
        public void TestGetCartItem()
        {
            Cart cart = new Cart { Id=1 };
            cartService.AddCart(cart);
            CartItem cartItem = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2, Price = 1010 };
            cartService.AddCartItem(cartItem);
            CartItem getCartItem = cartService.GetCartItem(1);
            Assert.AreEqual(cartItem, getCartItem);
        }
        [Test]
        public void TestGetAllCartItems()
        {
            Cart cart = new Cart { Id=1 };
            cartService.AddCart(cart);

            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2, Price = 1010 };
            cartService.AddCartItem(cartItem1);
            ICollection<CartItem> cartItems = cartService.GetAllCartItems();
            Assert.IsNotNull(cartItems);
        }
        [Test]
        public void TestCheckout()
        {
            Cart cart = new Cart { Id=1 };
            cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2, Price = 1010 };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 2, Quantity = 3, Price = 2020 };
            cartService.AddCartItem(cartItem1);
            cartService.AddCartItem(cartItem2);
            double totalAmount = cartService.Checkout(1);
            Assert.IsNotNull(totalAmount);
        }
        [Test]
        public void TestAddCartItemException()
        {
            Cart cart = new Cart {  Id = 1 };
            cartService.AddCart(cart);
            CartItem cartItem = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2, Price = 1010 };
            cartService.AddCartItem(cartItem);
            Assert.Throws<NoCartWithGivenIdException>(() => cartService.AddCartItem(new CartItem { CartId = 3, ProductId = 3, Quantity = 4, Price = 3030 }));
        }
        [Test]
        public void TestGetCartItemException()
        {
            Assert.Throws<NoCartItemWithGivenIdException>(() => cartService.GetCartItem(1));
        }
        [Test]
        public void TestDeleteCartItemException()
        {
            Assert.Throws<NoCartItemWithGivenIdException>(() => cartService.DeleteCartItem(1));
        }
        [Test]
        public void TestCheckoutException()
        {
            Assert.Throws<NoCartWithGivenIdException>(() => cartService.Checkout(1));
        }
        [Test]
        public void TestGetAllCartItemsException()
        {
            Cart cart = new Cart {  Id = 1 };
            cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2, Price = 1010 };
            cartService.AddCartItem(cartItem1);
            Assert.IsNotNull(cartService.GetAllCartItems());
        }
        [Test]
        public void TestCheckoutDiscount()
        {
            Cart cart = new Cart { Id=1 ,  CustomerId = 1 };
            cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2, Price = 500 };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 2, Quantity = 3, Price = 500 };
            CartItem cartItem3 = new CartItem { CartId = 1, ProductId = 3, Quantity = 3, Price = 500 };
            cartService.AddCartItem(cartItem1);
            cartService.AddCartItem(cartItem2);
            cartService.AddCartItem(cartItem3);
            double totalAmount = cartService.Checkout(1);
            Assert.IsNotNull(totalAmount);
        }
        [Test]
        public void TestCheckoutDiscountException()
        {
            Cart cart = new Cart {Id=1,  CustomerId = 1 };
            cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2, Price = 500 };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 2, Quantity = 3, Price = 500 };
            CartItem cartItem3 = new CartItem { CartId = 1, ProductId = 3, Quantity = 3, Price = 500 };
            cartService.AddCartItem(cartItem1);
            cartService.AddCartItem(cartItem2);
            cartService.AddCartItem(cartItem3);
            cartService.DeleteCartItem(1);
            Assert.IsNotNull(cartService.Checkout(1));
        }
     }
}
