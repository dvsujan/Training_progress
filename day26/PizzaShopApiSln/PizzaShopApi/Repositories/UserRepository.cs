using Microsoft.EntityFrameworkCore;
using PizzaShopApi.contexts;
using PizzaShopApi.Interfaces;
using PizzaShopApi.Models;

namespace PizzaShopApi.Repositories
{
    public class UserRepository : IRepo<int, User>
    {
        private readonly PizzaShopContext _context;
        public UserRepository(PizzaShopContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Delete(int id)
        {
            User? user = await GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> GetById(int id)
        {
            User? user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Update(User entity)
        {
            User? user = await GetById(entity.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
