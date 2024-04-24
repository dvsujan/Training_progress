using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingRepositoryTest
{
    public class ProductRepoTest 
    {
        IRepository<int, Product> productRepository;
        [SetUp]
        public void Setup()
        {
            productRepository = new ProductRepository();
        }
        [Test]
        public void TestAdd()
        {
            Product product = new Product(1, 100, "Laptop", 10);
            Product addedProduct = productRepository.Add(product);
            Assert.AreEqual(product, addedProduct);
        }
        [Test]
        public void TestGetByKey()
        {
            Product product = new Product(1, 100, "Laptop", 10);
            productRepository.Add(product);
            Product getProduct = productRepository.GetByKey(1);
            Assert.AreEqual(product, getProduct);
        }
        [Test]
        public void TestUpdate()
        {
            Product product = new Product(1, 100, "Laptop", 10);
            productRepository.Add(product);
            Product updatedProduct = new Product(1, 200, "Laptop", 10);
            Product updateProduct = productRepository.Update(updatedProduct);
            Product getProduct = productRepository.GetByKey(1);
            Assert.AreEqual(updatedProduct, getProduct);
        }
        [Test]
        public void TestDelete()
        {
            Product product = new Product(1, 100, "Laptop", 10);
            productRepository.Add(product);
            Product deletedProduct = productRepository.Delete(1);
            Assert.Throws<ProductNoutFoundException>(() => productRepository.GetByKey(1));
        }
        [Test]
        public void TestGetAll()
        {
            Product product1 = new Product(1, 100, "Laptop", 10);
            Product product2 = new Product(2, 200, "Mobile", 20);
            productRepository.Add(product1);
            productRepository.Add(product2);
            ICollection<Product> products = productRepository.GetAll();
            Assert.AreEqual(2, products.Count);
        }

    }
}