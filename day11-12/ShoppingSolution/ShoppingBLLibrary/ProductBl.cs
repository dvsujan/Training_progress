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
        
        public Product AddProduct(Product product)
        {
            try
            {
                var p = _productrepository.Add(product);
                return p;
            }
            catch
            {
                throw new ProductAlreadyExistsException();
            }
        }
        public Product GetProduct(int id)
        {
            try
            {
                Product p = _productrepository.GetByKey(id);
                return p;
            }
            catch
            {
                throw new ProductNoutFoundException();
            }
        }
        public Product UpdateProduct(Product product)
        {
            try
            {
                return _productrepository.Update(product);
            }
            catch
            {
                throw new ProductNoutFoundException();
            }
        }
        public Product DeleteProduct(int id)
        {
            try
            {
                return _productrepository.Delete(id);
            }
            catch
            {
                throw new ProductNoutFoundException();
            }
        }
        public ICollection<Product> GetAllProducts()
        {
            return _productrepository.GetAll();
        }

    }
}
