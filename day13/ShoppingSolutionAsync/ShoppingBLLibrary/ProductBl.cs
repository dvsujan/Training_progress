using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLLibrary
{
    public class ProductBl:IProductService 
    {
        IRepository<int, Product> _productrepository;
        public ProductBl(IRepository<int, Product> productrepository)
        {
            _productrepository = productrepository;
        }
        
        public async Task<Product> AddProduct(Product product)
        {
            var p = await _productrepository.Add(product);
            return p;
        }
        public async Task<Product> GetProduct(int id)
        {
            try
            {
                Product p = await _productrepository.GetByKey(id);
                return p;
            }
            catch
            {
                throw new ProductNoutFoundException();
            }
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                return await _productrepository.Update(product);
            }
            catch
            {
                throw new ProductNoutFoundException();
            }
        }
        public async Task<Product> DeleteProduct(int id)
        {
            try
            {
                return await _productrepository.Delete(id);
            }
            catch
            {
                throw new ProductNoutFoundException();
            }
        }
        public async Task<ICollection<Product>> GetAllProducts()
        {
            return await _productrepository.GetAll();
        }
    }
}
