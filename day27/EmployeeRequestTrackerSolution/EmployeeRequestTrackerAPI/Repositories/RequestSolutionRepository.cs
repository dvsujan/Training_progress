using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class RequestSolutionRepository : IReposiroty<int, RequestSolution>
    {
        protected readonly RequestTrackerContext _context; 
        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<RequestSolution> Add(RequestSolution item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item; 
        }
        public async Task<RequestSolution> Delete(int key)
        {
            var requestSolution = await Get(key);
            if (requestSolution != null)
            {
                _context.RequestSolutions.Remove(requestSolution);
                await _context.SaveChangesAsync();
            }
            return requestSolution;
        }

        public async Task<RequestSolution> Get(int key)
        {
            var requestSolution = await _context.RequestSolutions.SingleOrDefaultAsync(r => r.SolutionId == key);
            return requestSolution;
        }
        
        public async Task<IEnumerable<RequestSolution>> Get()
        {
            var requestSolutions = await _context.RequestSolutions.ToListAsync();
            return requestSolutions;
        }
        public async Task<RequestSolution> Update(RequestSolution item)
        {
            var requestSolution = await Get(item.SolutionId);
            if (requestSolution != null)
            {
                _context.Entry<RequestSolution>(requestSolution).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return requestSolution;
        }
    }
}
