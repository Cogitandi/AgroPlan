using AgroPlan.Core.Domain;
using AgroPlan.Core.Repositories;
using AgroPlan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroPlan.Infrastructure.Repositories
{
    class YearPlanRepository : IYearPlanRepository
    {
        private readonly DatabaseContext _context;

        public YearPlanRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(YearPlan obj)
        {
            _context.YearPlans.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(YearPlan obj)
        {
            _context.YearPlans.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<YearPlan>> GetAll()
        {
            return await _context.YearPlans.ToListAsync();
        }

        public async Task<YearPlan> GetById(Guid id)
        {
            return await _context.YearPlans
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(YearPlan obj)
        {
            _context.YearPlans.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
