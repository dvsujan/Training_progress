using azureproductapp.Interfaces;
using azureproductapp.Models;

namespace azureproductapp.services
{
    public class ProductService : IProductService
    {
        private readonly IRepo<int , Product> _productRepo;
        public ProductService(IRepo<int , Product> productRepo) { _productRepo = productRepo; }
        public async Task<IList<Product>> GetAllProducts()
        {
            var products = await _productRepo.GetAll();
            return products.ToList(); 
        }
    }
}
