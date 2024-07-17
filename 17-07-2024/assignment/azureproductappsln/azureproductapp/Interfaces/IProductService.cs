using azureproductapp.Models;

namespace azureproductapp.Interfaces
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllProducts(); 
    }
}
