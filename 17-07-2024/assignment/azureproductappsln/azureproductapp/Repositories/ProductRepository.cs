using azureproductapp.contexts;
using azureproductapp.Interfaces;
using azureproductapp.Models;
using Microsoft.EntityFrameworkCore;

namespace azureproductapp.Repositories
{
    public class ProductRepository : IRepo<int, Product>
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.products.ToListAsync(); 
        }
    }
}
