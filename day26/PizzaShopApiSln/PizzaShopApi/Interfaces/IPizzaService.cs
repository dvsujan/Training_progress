using PizzaShopApi.Models;

namespace PizzaShopApi.Interfaces
{
    public interface IPizzaService
    {
        Task<IEnumerable<Pizza>> GetAllPizzasInStock();
        Task<Pizza> OrderPizzaById(int id);
    }
}
