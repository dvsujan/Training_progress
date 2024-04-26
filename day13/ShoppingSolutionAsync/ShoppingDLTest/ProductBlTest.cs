using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingBLTest
{
    public class ProductBLTest 
    {
        IRepository<int, Product> productRepo; 
        IProductService productService;

        [SetUp]
        public void Setup()
        {
            productRepo = new ProductRepository();
            productService = new ProductBl(productRepo);
        }
        [Test]
        public async Task TestAddProduct()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            Product addedProduct = await productService.AddProduct(product);
            Assert.AreEqual(product, addedProduct);
        }
        [Test]
        public async Task TestGetProduct()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            productService.AddProduct(product);
            Product getProduct = await productService.GetProduct(1);
            Assert.AreEqual(product, getProduct);
        }
        [Test]
        public async Task  TestUpdateProduct()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            await productService.AddProduct(product);
            Product updatedProduct = new Product { Id = 1, Name = "Laptop", Price = 60000 };
            Product updateProduct = await productService.UpdateProduct(updatedProduct);
            Assert.AreEqual(updatedProduct, updateProduct);
        }
        [Test]
        public async Task TestDeleteProduct()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            await productService.AddProduct(product);
            Product deletedProduct = await productService.DeleteProduct(1);
            Assert.ThrowsAsync<ProductNoutFoundException>(async () =>  await productService.GetProduct(1));
        }
        [Test]
        public async Task  TestGetAllProducts()
        {
            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            Product product2 = new Product { Id = 2, Name = "Mobile", Price = 20000 };
            await productService.AddProduct(product1);
            await productService.AddProduct(product2);
            ICollection<Product> products = await productService.GetAllProducts();
            Assert.AreEqual(2, products.Count);
        }
        [Test]
        public async Task  TestGetProductException()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            await productService.AddProduct(product);
            Assert.ThrowsAsync<ProductNoutFoundException>(async  () => await productService.GetProduct(2));
        }
        [Test]
        public async Task  TestUpdateProductException()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            await productService.AddProduct(product);
            Assert.ThrowsAsync<ProductNoutFoundException>(async () => await productService.UpdateProduct(new Product { Id = 2, Name = "Laptop", Price = 50000 }));
        }
        [Test]
        public async Task  TestDeleteProductException()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            await productService.AddProduct(product);
            Assert.ThrowsAsync<ProductNoutFoundException>(async () => await productService.DeleteProduct(2));
        }
        [Test]
        public async Task  TestGetAllProductsException()
        {
            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            Product product2 = new Product { Id = 2, Name = "Mobile", Price = 20000 };
            await productService.AddProduct(product1);
            await productService.AddProduct(product2);
            await productService.DeleteProduct(1);
            await productService.DeleteProduct(2);
            var allProducts = await productService.GetAllProducts();
            Assert.AreEqual(0, allProducts.Count);
        }
        [Test]
        public async Task TestProductNotFoundException()
        {
            Assert.ThrowsAsync<ProductNoutFoundException>(async () => await productService.GetProduct(1));
        }
        
    }
}