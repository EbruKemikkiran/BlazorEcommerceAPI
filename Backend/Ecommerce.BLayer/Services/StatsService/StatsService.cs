

using Ecommerce.BLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLayer.Services
{
    public class StatsService : IStatsService
    {
        private readonly DataDbContext _context;

        public StatsService(DataDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetVisits()
        {
            var stats = await _context.Stats.FirstOrDefaultAsync();
            if (stats == null)
            {
                return 0;
            }
            return stats.Visits;
        }

        public async Task IncrementVisits()
        {
            var stats = await _context.Stats.FirstOrDefaultAsync();
            if (stats == null)
            {
                _context.Stats.Add(new Stats { Visits = 1, LastVisit = DateTime.Now });
            }
            else
            {
                stats.Visits++;
                stats.LastVisit = DateTime.Now;
            }

            await _context.SaveChangesAsync();
        }
    }
}