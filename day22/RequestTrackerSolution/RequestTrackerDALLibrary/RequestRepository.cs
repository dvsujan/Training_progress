using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>
    {
        protected readonly RequestTrackerContext _context;
        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request> Delete(int key)
        {
            Request re = await Get(key);
            if (re != null)
            {
                _context.Requests.Remove(re);
                await _context.SaveChangesAsync();
            }
            return re;
        }

        public async Task<Request> Get(int key)
        {
            var request = await _context.Requests.SingleOrDefaultAsync(r => r.RequestNumber == key);
            return request;
        }

        public async Task<IList<Request>> GetAll()
        {
            var requests = await _context.Requests.ToListAsync();
            return requests;
        }

        public async Task<Request> Update(Request entity)
        {
            var request = await Get(entity.RequestNumber);
            if (request != null)
            {
                _context.Entry<Request>(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return request;
        }
    }
}
