using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingModelLibrary; 

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        public Task<Product> AddProduct(Product product);
        public Task<Product> GetProduct(int id);
        public Task<ICollection<Product>> GetAllProducts();
        public Task<Product> UpdateProduct(Product product);
        public Task<Product> DeleteProduct(int id);
    }
}
