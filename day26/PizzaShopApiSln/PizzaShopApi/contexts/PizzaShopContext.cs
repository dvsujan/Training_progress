using Microsoft.EntityFrameworkCore;
using PizzaShopApi.Models;

namespace PizzaShopApi.contexts
{
    public class PizzaShopContext:DbContext
    {
        public PizzaShopContext(DbContextOptions<PizzaShopContext> options):base(options)
        {
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 101,
                    Name = "Margherita",
                    Description = "Cheese and Tomato",
                    stock = 10,
                    PizzaSize = Pizza.Size.Small,
                    PizzaCrust = Pizza.Crust.Thin,
                    PizzaTopping = [Pizza.Topping.Cheese]
                },
                new Pizza
                {
                    Id = 102,
                    Name = "Pepperoni",
                    Description = "Pepperoni and Cheese",
                    stock = 10,
                    PizzaSize = Pizza.Size.Medium,
                    PizzaCrust = Pizza.Crust.Thick,
                    PizzaTopping = [Pizza.Topping.Cheese, Pizza.Topping.sausage]
                },
                new Pizza
                {
                    Id = 103,
                    Name = "Vegetarian",
                    Description = "Mushroom, Onion, Capsicum, Tomato, Jalapeno",
                    stock = 10,
                    PizzaSize = Pizza.Size.Large,
                    PizzaCrust = Pizza.Crust.Thin,
                    PizzaTopping = [Pizza.Topping.mushroom, Pizza.Topping.onion, Pizza.Topping.capsicum, Pizza.Topping.tomato, Pizza.Topping.jalapeno]
                },
                new Pizza
                {
                    Id = 104,
                    Name = "Paneer Pataka",
                    Description = "Paneer , Cheese , Jalapeno , Tomato",
                    stock = 10,
                    PizzaSize = Pizza.Size.Large,
                    PizzaCrust = Pizza.Crust.Thin,
                    PizzaTopping = [Pizza.Topping.paneer,Pizza.Topping.Cheese,Pizza.Topping.jalapeno,Pizza.Topping.tomato]
                }
            ); 
        }
    }
}
