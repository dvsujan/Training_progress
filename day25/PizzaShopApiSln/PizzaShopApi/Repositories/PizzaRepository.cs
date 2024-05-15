using Microsoft.EntityFrameworkCore;
using PizzaShopApi.contexts;
using PizzaShopApi.Interfaces;
using PizzaShopApi.Models;

namespace PizzaShopApi.Repositories
{
    public class PizzaRepository:IRepo<int, Pizza>
    {
private readonly PizzaShopContext _context;
        public PizzaRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza entity)
        {
            _context.Pizzas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Pizza> Delete(int id)
        {
            Pizza? pizza = await GetById(id);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                await _context.SaveChangesAsync();
            }
            return pizza;
        }

        public async Task<Pizza> GetById(int id)
        {
            Pizza? pizza = await _context.Pizzas.SingleOrDefaultAsync(p => p.Id == id);
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza> Update(Pizza entity)
        {
            Pizza? pizza = await GetById(entity.Id);
            if (pizza == null)
            {
                throw new Exception("Pizza not found");
            }
            _context.Pizzas.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
