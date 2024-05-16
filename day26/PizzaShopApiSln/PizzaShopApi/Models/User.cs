using System.ComponentModel.DataAnnotations;

namespace PizzaShopApi.Models
{
    public class User
    {
        public enum status  
        {
            Active,
            Inactive
        }
        
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set;  }
        public byte[] HashKey { get; set; }
        public status Status { get; set; }
    }
}
