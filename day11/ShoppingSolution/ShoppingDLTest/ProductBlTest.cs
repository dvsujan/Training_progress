using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions; 

namespace ShoppingBLTest
{
    public class Tests
    {
        IRepository<int, Product> productRepo; 
        IProductService productService;

        [SetUp]
        public void Setup()
        {
            productRepo = new ProductRepository();
            productService = new ProductBl(productRepo);
        }
        // test cases to get 100  % code coverage in productbl

        [Test]
        public void TestAddProduct()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            Product addedProduct = productService.AddProduct(product);
            Assert.AreEqual(product, addedProduct);
        }
        [Test]
        public void TestGetProduct()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            productService.AddProduct(product);
            Product getProduct = productService.GetProduct(1);
            Assert.AreEqual(product, getProduct);
        }
        [Test]
        public void TestUpdateProduct()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            productService.AddProduct(product);
            Product updatedProduct = new Product { Id = 1, Name = "Laptop", Price = 60000 };
            Product updateProduct = productService.UpdateProduct(updatedProduct);
            Assert.AreEqual(updatedProduct, updateProduct);
        }
        [Test]
        public void TestDeleteProduct()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            productService.AddProduct(product);
            Product deletedProduct = productService.DeleteProduct(1);
            Assert.Throws<ProductNoutFoundException>(() => productService.GetProduct(1));
        }
        [Test]
        public void TestGetAllProducts()
        {
            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            Product product2 = new Product { Id = 2, Name = "Mobile", Price = 20000 };
            productService.AddProduct(product1);
            productService.AddProduct(product2);
            ICollection<Product> products = productService.GetAllProducts();
            Assert.AreEqual(2, products.Count);
        }
        [Test]
        public void TestAddProductException()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            productService.AddProduct(product);
            Assert.Throws<ProductAlreadyExistsException>(() => productService.AddProduct(new Product { Id = 1, Name = "Laptop", Price = 50000 }));
        }
        [Test]
        public void TestGetProductException()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            productService.AddProduct(product);
            Assert.Throws<ProductNoutFoundException>(() => productService.GetProduct(2));
        }
        [Test]
        public void TestUpdateProductException()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            productService.AddProduct(product);
            Assert.Throws<ProductNoutFoundException>(() => productService.UpdateProduct(new Product { Id = 2, Name = "Laptop", Price = 50000 }));
        }
        [Test]
        public void TestDeleteProductException()
        {
            Product product = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            productService.AddProduct(product);
            Assert.Throws<ProductNoutFoundException>(() => productService.DeleteProduct(2));
        }
        [Test]
        public void TestGetAllProductsException()
        {
            Product product1 = new Product { Id = 1, Name = "Laptop", Price = 50000 };
            Product product2 = new Product { Id = 2, Name = "Mobile", Price = 20000 };
            productService.AddProduct(product1);
            productService.AddProduct(product2);
            productService.DeleteProduct(1);
            productService.DeleteProduct(2);
            Assert.AreEqual(0, productService.GetAllProducts().Count);
        }
        
    }
}