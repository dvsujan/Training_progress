
using PizzaShopApi.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
