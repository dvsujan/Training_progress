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
        IRepository<int, Product> productRepository;
        Product p; 
        
        ICartService cartService;
        [SetUp]
        public void Setup()
        {
            cartRepository = new CartRepository();
            customerRepository = new CustomerRepository();
            cartItemRepository = new CartItemsRepository();
            productRepository= new ProductRepository();
            cartService = new CartBL(cartRepository, cartItemRepository, customerRepository, productRepository);
            p = new Product { Id = 1, Name = "Product1", Price = 500, stock=10 };
            productRepository.Add(p);
        }
        [Test]
        public void TestAddCart()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };  
            customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            Cart addedCart = cartService.AddCart(cart);
            Assert.AreEqual(cart, addedCart);
        }
        [Test]
        public void TestGetCartDetails()
        {
            Customer c = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(c);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 2, Price = 1010 };
            Cart getCart = cartService.GetCartDetails(1);
            Assert.IsNotNull(getCart.Items);
        }
        [Test]
        public void TestUpdateCart()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
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

            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };  
            customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            Cart deletedCart = cartService.DeleteCart(1);
            Assert.Throws<NoCartWithGivenIdException>(() => cartService.GetCartDetails(1));
        }

        [Test]
        public void TestGetAllCarts()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);

            Customer customer2 = new Customer { Id = 2, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer2);
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

            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };  
            customerRepository.Add(customer);
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
            Customer customer1 = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer1);
            Customer customer2 = new Customer { Id = 2, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer2);
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

            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };  
            customerRepository.Add(customer);
            Cart cart = new Cart { Id=1, CustomerId = 1 };
            cartService.AddCart(cart);
            CartItem cartItem = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2};
            CartItem addedCartItem = cartService.AddCartItem(cartItem);
            Assert.AreEqual(cartItem, addedCartItem);
        }
        [Test]
        public void TestGetCartItem()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart { Id=1, CustomerId=1 };
            cartService.AddCart(cart);
            CartItem cartItem = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2};
            cartService.AddCartItem(cartItem);
            CartItem getCartItem = cartService.GetCartItem(1);
            Assert.AreEqual(cartItem, getCartItem);
        }
        [Test]
        public void TestGetAllCartItems()
        {

            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };  
            customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2};
            cartService.AddCartItem(cartItem1);
            ICollection<CartItem> cartItems = cartService.GetAllCartItems();
            Assert.IsNotNull(cartItems);
        }
        [Test]
        public void TestCheckout()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart { Id=1, CustomerId=1 };
            cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2 };
            cartService.AddCartItem(cartItem1);
            double totalAmount = cartService.Checkout(1);
            Assert.IsNotNull(totalAmount);
        }
        [Test]
        public void TestCheckoutDiscount()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart { Id=1, CustomerId=1 };
            cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2, Discount=0.10d };
            double totalAmount = cartService.Checkout(1);
            Assert.AreEqual(p.Price*cartItem1.Discount*cartItem1.Quantity, totalAmount);
        }
        [Test]
        public void TestAddCartItemException()
        {
            Assert.Throws<NoCartWithGivenIdException>(() => cartService.AddCartItem(new CartItem { CartId = 3, ProductId = 1, Quantity = 4 }));
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
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart {  Id = 1 , CustomerId = 1 };
            cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2 };
            cartService.AddCartItem(cartItem1);
            Assert.IsNotNull(cartService.GetAllCartItems());
        }
        [Test]
        public void TestCheckoutDiscountFifteenHundred()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart { Id=1 ,  CustomerId = 1 };
            cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 1 };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1 };
            CartItem cartItem3 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1};
            cartService.AddCartItem(cartItem1);
            cartService.AddCartItem(cartItem2);
            cartService.AddCartItem(cartItem3);
            double totalAmount = cartService.Checkout(1);
            Assert.AreEqual((1500d-(1500d*0.05d)), totalAmount);
        }
        [Test]
        public void TestCheckoutDiscountException()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart {Id=1,  CustomerId = 1 };
            cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 1 };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1 };
            CartItem cartItem3 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1 };
            cartService.AddCartItem(cartItem1);
            cartService.AddCartItem(cartItem2);
            cartService.AddCartItem(cartItem3);
            cartService.DeleteCartItem(1);
            Assert.IsNotNull(cartService.Checkout(1));
        }
        [Test]
        public void TestCartAlreadyExistExceptionAddCartItem()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            Assert.Throws<CartAlreadyExistsException>(() => cartService.AddCart(cart));
        }
        [Test]
        public void TestNoCustomerWithGivenIdExcptionAddCart()
        {
            Cart cart = new Cart { Id=1, CustomerId = 1 };
            Assert.Throws<NoCustomerWithGiveIdException>(() => cartService.AddCart(cart));
        }
        [Test]
        public void testNoCartWithGivenIdExceptionAddCartItem()
        {
            Assert.Throws<NoCartWithGivenIdException>(() => cartService.AddCartItem(new CartItem { CartId = 1, ProductId = 1, Quantity = 2, Price = 1010 }));
        }
        [Test]
        public void CartItemQuantityExceededException()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 4};
            cartService.AddCartItem(cartItem);
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1};
            cartService.AddCartItem(cartItem1);
            Assert.Throws<CartItemQuantityExceededException>(() => cartService.AddCartItem(new CartItem { CartId = 1, ProductId = 1, Quantity = 1 }));
        }
        [Test]
        public void TestDeliveryCharge()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            Product pp = new Product { Id = 11, Name = "Product1", Price = 50, stock = 10 };
            productRepository.Add(pp);
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 11, Quantity = 1 };
            cartService.AddCartItem(cartItem1);
            double totalAmount = cartService.Checkout(1);
            Assert.AreEqual((50+100), totalAmount);
        }
        [Test]
        public void TestProductNotFoundException()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            Assert.Throws<ProductNoutFoundException>(() => cartService.AddCartItem(new CartItem { CartId = 1, ProductId = 2, Quantity = 2 }));
                  
        }

        [Test]
        public void TestProductOutOfStockException()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            Product pp = new Product() { Id = 111, Name = "Product2", Price = 50, stock = 1 };
            productRepository.Add(pp);
            Assert.Throws<ProductOutOfStockException>(() => cartService.AddCartItem(new CartItem { CartId = 1, ProductId = 111, Quantity = 2 }));
        }

        [Test]
        public void TestProductOutOfStockExceptionInCheckout()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            cartService.AddCart(cart);
            Product pp = new Product() { Id = 111, Name = "Product2", Price = 50, stock = 2 };
            productRepository.Add(pp);
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 111, Quantity = 1 };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 111, Quantity = 2 };
            cartService.AddCartItem(cartItem1);
            cartService.AddCartItem(cartItem2);
            Assert.Throws<ProductOutOfStockException>(() => cartService.Checkout(1));
        }
    }
}
