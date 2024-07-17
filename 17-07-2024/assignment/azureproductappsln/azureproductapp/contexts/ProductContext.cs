using azureproductapp.Models;
using Microsoft.EntityFrameworkCore;

namespace azureproductapp.contexts
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product {
                Id = 1,
                Name = "Gaming Pc" , 
                Price = 100000.00, 
                Piclink = "https://dvsujanstorage.blob.core.windows.net/products/gamingpc.jpeg"
            } , 
            new Product {  
                Id=2 ,
                Name = "PlayStation 5" , 
                Price = 50000 , 
                Piclink = "https://dvsujanstorage.blob.core.windows.net/products/ps5.jpeg"
            }, 
            new Product
            {
                Id=3 ,
                Name = "Mechanical Keyboard" , 
                Price = 10000 , 
                Piclink = "https://dvsujanstorage.blob.core.windows.net/products/keyboard.jpg"
            }, 
            new Product
            {
                Id = 4 ,
                Name = "Gaming Mouse" , 
                Price = 6000 , 
                Piclink = "https://dvsujanstorage.blob.core.windows.net/products/mouse.jpeg"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
