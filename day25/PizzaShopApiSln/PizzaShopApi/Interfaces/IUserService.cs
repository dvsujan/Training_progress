using PizzaShopApi.Models;
using PizzaShopApi.Models.DTOs;

namespace PizzaShopApi.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(userRegisterDTO user);
        Task<User> Login(UserLoginDTO user);
    }
}
