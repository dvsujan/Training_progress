using EmployeeRequestTrackerAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Contexts;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class SolutionFeedbackRepository : IReposiroty<int, SolutionFeedback>
    {
        protected readonly RequestTrackerContext _context;
        public SolutionFeedbackRepository (RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<SolutionFeedback> Delete(int key)
        {
            SolutionFeedback sf = await Get(key);
            if (sf != null)
            {
                _context.Feedbacks.Remove(sf);
                await _context.SaveChangesAsync();
            }
            return sf;  
        }

        public async Task<SolutionFeedback> Get(int key)
        {
            var solutionFeedback = await _context.Feedbacks.SingleOrDefaultAsync(r => r.SolutionId == key);
            return solutionFeedback;
        }

        public async Task<IEnumerable<SolutionFeedback>> Get()
        {
            var solutionFeedbacks = await _context.Feedbacks.ToListAsync();
            return solutionFeedbacks;
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback item)
        {
            var solutionFeedback = await Get(item.SolutionId);
            if (solutionFeedback != null)
            {
                _context.Entry<SolutionFeedback>(solutionFeedback).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return solutionFeedback;
        }
    }
}
