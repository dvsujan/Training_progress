using PizzaShopApi.Interfaces;
using PizzaShopApi.Models;

namespace PizzaShopApi.services
{
    public class PizzaBl : IPizzaService
    {
        private readonly IRepo<int, Pizza> _repo;
        public PizzaBl(IRepo<int, Pizza> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Pizza>> GetAllPizzasInStock()
        {
            IEnumerable<Pizza> pizzas = await _repo.GetAll();
            pizzas = pizzas.Where(p => p.stock>0);
            foreach (var pizza in pizzas)
            {
                pizza.Price = pizza.GetPrice();
            }
            return pizzas;
        }
        public async Task<Pizza> OrderPizzaById(int id)
        {
            Pizza pizza = await _repo.GetById(id);
            if(pizza == null)
            {
                throw new Exception("Pizza not found");
            }
            if (pizza.stock > 0)
            {
                pizza.stock--;
                await _repo.Update(pizza);
                return pizza;
            }
            throw new Exception("Pizza not in stock");
        }
    }
}
