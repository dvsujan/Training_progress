using System.ComponentModel.DataAnnotations;

namespace PizzaShopApi.Models
{
    public class Pizza
    {
        public enum Size
        {
            Small = 10,
            Medium = 12,
            Large = 15
        }
        public enum Crust
        {
            Thin,
            Thick
        }

        public enum Topping
        {
            Cheese,
            sausage,
            paneer , 
            mushroom,
            onion,
            capsicum,
            tomato,
            jalapeno
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int stock { get; set; } = 0;
        public double? Price { get; set; }
        public Size PizzaSize { get; set; } = Size.Small;
        public Crust PizzaCrust { get; set; } = Crust.Thick;
        public Topping[]? PizzaTopping { get; set; }
        
        public double GetPrice()
        {
            double price = (double)PizzaSize;
            if(PizzaTopping == null)
            {
                return price;
            }
            foreach (Topping topping in PizzaTopping)
            {
                price += 1.5;
            }
            return price;
        }
    }
}
