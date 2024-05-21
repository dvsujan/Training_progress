using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Interfaces; 

namespace EmployeeRequestTrackerAPI.Repositories 
{
    public class RequestRepository : IReposiroty<int, Request>
    {
        protected readonly RequestTrackerContext _context;
        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
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

        public async Task<IEnumerable<Request>> Get()
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
