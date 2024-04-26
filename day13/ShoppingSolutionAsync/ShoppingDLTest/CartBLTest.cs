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
        public async Task TestAddCart()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };  
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            Cart addedCart = await cartService.AddCart(cart);
            Assert.AreEqual(cart, addedCart);
        }
        [Test]
        public async Task TestGetCartDetails()
        {
            Customer c = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(c);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 2, Price = 1010 };
            Cart getCart = await cartService.GetCartDetails(1);
            Assert.IsNotNull(getCart.Items);
        }
        [Test]
        public async Task TestUpdateCart()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            Cart updatedCart = new Cart { Id = 1, CustomerId = 1 };
            Cart updateCart = await cartService.UpdateCart(updatedCart);
            Cart getCart = await cartService.GetCartDetails(1);
            Assert.IsNotNull(getCart);
        }
        
        [Test]
        public async Task TestDeleteCart()
        {

            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };  
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            Cart deletedCart = await cartService.DeleteCart(1);
            Assert.ThrowsAsync<NoCartWithGivenIdException>(() => cartService.GetCartDetails(1));
        }

        [Test]
        public async Task TestGetAllCarts()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);

            Customer customer2 = new Customer { Id = 2, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer2);
            Cart cart1 = new Cart { Id = 1, CustomerId = 1 };
            Cart cart2 = new Cart { Id = 2, CustomerId = 2 };
            await cartService.AddCart(cart1);
            await cartService.AddCart(cart2);
            ICollection<Cart> carts = await cartService.GetAllCarts();
            Assert.AreEqual(2, carts.Count);
        }
        [Test]
        public async Task TestAddCartException()
        {

            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };  
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            Assert.ThrowsAsync<CartAlreadyExistsException>(async() => await cartService.AddCart(cart));
        }
        [Test]
        public async Task TestGetCartException()
        {
            Assert.ThrowsAsync<NoCartWithGivenIdException>(async () => await cartService.GetCartDetails(1));
        }
        
        [Test]
        public async Task TestUpdateCartException()
        {
            Assert.ThrowsAsync<NoCartWithGivenIdException>(async () => await cartService.UpdateCart(new Cart { Id = 1, CustomerId = 1 }));
        }
        [Test]
        public async Task TestDeleteCartException()
        {
            Assert.ThrowsAsync<NoCartWithGivenIdException>(async() => await cartService.DeleteCart(1));
        }
        [Test]
        public async Task TestGetAllCartsException()
        {
            Customer customer1 = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer1);
            Customer customer2 = new Customer { Id = 2, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer2);
            Cart cart1 = new Cart { Id = 1, CustomerId = 1 };
            Cart cart2 = new Cart { Id = 2, CustomerId = 2 };
            await cartService.AddCart(cart1);
            await cartService.AddCart(cart2);
            await cartService.DeleteCart(1);
            await cartService.DeleteCart(2);
            var count = await cartService.GetAllCarts(); 
            Assert.AreEqual(0, count.Count);
        }
        [Test]
        public async Task TestAddCartItem()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };  
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id=1, CustomerId = 1 };
            await cartService.AddCart(cart);
            CartItem cartItem = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2};
            CartItem addedCartItem = await cartService.AddCartItem(cartItem);
            Assert.AreEqual(cartItem, addedCartItem);
        }
        [Test]
        public async Task TestGetCartItem()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id=1, CustomerId=1 };
            await cartService.AddCart(cart);
            CartItem cartItem = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2};
            await cartService.AddCartItem(cartItem);
            CartItem getCartItem = await cartService.GetCartItem(1);
            Assert.AreEqual(cartItem, getCartItem);
        }
        [Test]
        public async Task TestGetAllCartItems()
        {

            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };  
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2};
            await cartService.AddCartItem(cartItem1);
            ICollection<CartItem> cartItems = await cartService.GetAllCartItems();
            Assert.IsNotNull(cartItems);
        }
        [Test]
        public async Task TestCheckout()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id=1, CustomerId=1 };
            await cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2 };
            await cartService.AddCartItem(cartItem1);
            double totalAmount = await cartService.Checkout(1);
            Assert.IsNotNull(totalAmount);
        }
        [Test]
        public async Task TestCheckoutDiscount()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id=1, CustomerId=1 };
            await cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2, Discount=0.10d };
            double totalAmount = await cartService.Checkout(1);
            Assert.AreEqual(p.Price*cartItem1.Discount*cartItem1.Quantity, totalAmount);
        }
        [Test]
        public void TestAddCartItemException()
        {
            Assert.ThrowsAsync<NoCartWithGivenIdException>(async () => await cartService.AddCartItem(new CartItem { CartId = 3, ProductId = 1, Quantity = 4 }));
        }
        [Test]
        public void TestGetCartItemException()
        {
            Assert.ThrowsAsync<NoCartItemWithGivenIdException>(async () => await cartService.GetCartItem(1));
        }
        [Test]
        public void TestDeleteCartItemException()
        {
            Assert.ThrowsAsync<NoCartItemWithGivenIdException>(async () => await cartService.DeleteCartItem(1));
        }
        [Test]
        public void TestCheckoutException()
        {
            Assert.ThrowsAsync<NoCartWithGivenIdException>(async () => await cartService.Checkout(1));
        }
        [Test]
        public async Task TestGetAllCartItemsException()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart {  Id = 1 , CustomerId = 1 };
            await cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 2 };
            await cartService.AddCartItem(cartItem1);
            Assert.IsNotNull(cartService.GetAllCartItems());
        }
        [Test]
        public async Task TestCheckoutDiscountFifteenHundred()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id=1 ,  CustomerId = 1 };
            await cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 1 };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1 };
            CartItem cartItem3 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1};
            await cartService.AddCartItem(cartItem1);
            await cartService.AddCartItem(cartItem2);
            await cartService.AddCartItem(cartItem3);
            double totalAmount = await cartService.Checkout(1);
            Assert.AreEqual((1500d-(1500d*0.05d)), totalAmount);
        }
        [Test]
        public async Task TestCheckoutDiscountException()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart {Id=1,  CustomerId = 1 };
            await cartService.AddCart(cart);
            CartItem cartItem1 = new CartItem {  CartId = 1, ProductId = 1, Quantity = 1 };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1 };
            CartItem cartItem3 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1 };
            await cartService.AddCartItem(cartItem1);
            await cartService.AddCartItem(cartItem2);
            await cartService.AddCartItem(cartItem3);
            await cartService.DeleteCartItem(1);
            Assert.IsNotNull(cartService.Checkout(1));
        }
        [Test]
        public async Task TestCartAlreadyExistExceptionAddCartItem()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            Assert.ThrowsAsync<CartAlreadyExistsException>(async() => await cartService.AddCart(cart));
        }
        [Test]
        public void TestNoCustomerWithGivenIdExcptionAddCart()
        {
            Cart cart = new Cart { Id=1, CustomerId = 1 };
            Assert.ThrowsAsync<NoCustomerWithGiveIdException>(async () => await cartService.AddCart(cart));
        }
        [Test]
        public void testNoCartWithGivenIdExceptionAddCartItem()
        {
            Assert.ThrowsAsync<NoCartWithGivenIdException>(async () => await cartService.AddCartItem(new CartItem { CartId = 1, ProductId = 1, Quantity = 2, Price = 1010 }));
        }
        [Test]
        public async Task CartItemQuantityExceededException()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            CartItem cartItem = new CartItem { CartId = 1, ProductId = 1, Quantity = 4};
            await cartService.AddCartItem(cartItem);
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 1, Quantity = 1};
            await cartService.AddCartItem(cartItem1);
            Assert.ThrowsAsync<CartItemQuantityExceededException>(async () => await cartService.AddCartItem(new CartItem { CartId = 1, ProductId = 1, Quantity = 1 }));
        }
        [Test]
        public async Task TestDeliveryCharge()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            Product pp = new Product { Id = 11, Name = "Product1", Price = 50, stock = 10 };
            await productRepository.Add(pp);
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 11, Quantity = 1 };
            await cartService.AddCartItem(cartItem1);
            double totalAmount = await cartService.Checkout(1);
            Assert.AreEqual((50+100), totalAmount);
        }
        
        [Test]
        public async Task TestProductNotFoundException()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            Assert.ThrowsAsync<ProductNoutFoundException>(async () => await cartService.AddCartItem(new CartItem { CartId = 1, ProductId = 2, Quantity = 2 }));
        }
        
        [Test]
        public async Task TestProductOutOfStockException()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            Product pp = new Product() { Id = 111, Name = "Product2", Price = 50, stock = 1 };
            await productRepository.Add(pp);
            Assert.ThrowsAsync<ProductOutOfStockException>(async () => await cartService.AddCartItem(new CartItem { CartId = 1, ProductId = 111, Quantity = 2 }));
        }
        
        [Test]
        public async Task TestProductOutOfStockExceptionInCheckout()
        {
            Customer customer = new Customer { Id = 1, Phone = "123131313", Age = 20 };
            await customerRepository.Add(customer);
            Cart cart = new Cart { Id = 1, CustomerId = 1 };
            await cartService.AddCart(cart);
            Product pp = new Product() { Id = 111, Name = "Product2", Price = 50, stock = 2 };
            await productRepository.Add(pp);
            CartItem cartItem1 = new CartItem { CartId = 1, ProductId = 111, Quantity = 1 };
            CartItem cartItem2 = new CartItem { CartId = 1, ProductId = 111, Quantity = 2 };
            await cartService.AddCartItem(cartItem1);
            await cartService.AddCartItem(cartItem2);
            Assert.ThrowsAsync<ProductOutOfStockException>(async () => await cartService.Checkout(1));
        }
    }
}
