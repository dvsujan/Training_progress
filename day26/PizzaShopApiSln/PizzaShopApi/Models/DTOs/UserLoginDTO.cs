﻿namespace PizzaShopApi.Models.DTOs
{
    public class UserLoginDTO
    {
        public int Id { get; set; }
        public string Password { get; set; } = string.Empty; 
    }
}
