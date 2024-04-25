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
        public Product AddProduct(Product product);
        public Product GetProduct(int id);
        public ICollection<Product> GetAllProducts();
        public Product UpdateProduct(Product product);
        public Product DeleteProduct(int id);
    }
}
