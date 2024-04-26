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
        public async Task  TestAdd()
        {
            Product product = new Product(1, 100, "Laptop", 10);
            Product addedProduct = await productRepository.Add(product);
            Assert.AreEqual(product, addedProduct);
        }
        [Test]
        public async Task TestGetByKey()
        {
            Product product = new Product(1, 100, "Laptop", 10);
            await productRepository.Add(product);
            Product getProduct = await productRepository.GetByKey(1);
            Assert.AreEqual(product, getProduct);
        }
        [Test]
        public async Task TestUpdate()
        {
            Product product = new Product(1, 100, "Laptop", 10);
            productRepository.Add(product);
            Product updatedProduct = new Product(1, 200, "Laptop", 10);
            Product updateProduct = await productRepository.Update(updatedProduct);
            Product getProduct = await productRepository.GetByKey(1);
            Assert.AreEqual(updatedProduct, getProduct);
        }
        [Test]
        public async Task TestDelete()
        {
            Product product = new Product(1, 100, "Laptop", 10);
            productRepository.Add(product);
            Product deletedProduct = await productRepository.Delete(1);
            Assert.ThrowsAsync<ProductNoutFoundException>(async () => await productRepository.GetByKey(1));
        }
        [Test]
        public async Task TestGetAll()
        {
            Product product1 = new Product(1, 100, "Laptop", 10);
            Product product2 = new Product(2, 200, "Mobile", 20);
            await productRepository.Add(product1);
            await productRepository.Add(product2);
            ICollection<Product> products = await productRepository.GetAll();
            Assert.AreEqual(2, products.Count);
        }

    }
}