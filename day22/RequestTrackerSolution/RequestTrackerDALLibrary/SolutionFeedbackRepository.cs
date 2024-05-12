using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class SolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        protected readonly RequestTrackerContext _context;
        public SolutionFeedbackRepository (RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
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

        public async Task<IList<SolutionFeedback>> GetAll()
        {
            var solutionFeedbacks = await _context.Feedbacks.ToListAsync();
            return solutionFeedbacks;
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            var solutionFeedback = await Get(entity.SolutionId);
            if (solutionFeedback != null)
            {
                _context.Entry<SolutionFeedback>(solutionFeedback).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return solutionFeedback;
        }
    }
}
