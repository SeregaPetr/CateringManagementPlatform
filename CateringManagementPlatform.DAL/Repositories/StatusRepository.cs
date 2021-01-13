using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class StatusRepository : IRepository<Status>
    {
        private readonly ApplicationContext _context;

        public StatusRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Status status)
        {
            _context.Statuses.Add(status);
        }

        public void Delete(Status status)
        {
            _context.Statuses.Remove(status);
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await _context.Statuses
                 .Include(s => s.OrderLines)
                 .Include(s => s.Orders)
                 .AsNoTracking().ToListAsync();
        }

        public async Task<Status> GetByIdAsync(int id)
        {
            return await _context.Statuses
                 .Include(s => s.OrderLines)
                 .Include(s => s.Orders)
                 .AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public void Update(Status status)
        {
            _context.Statuses.Update(status);
        }
    }
}
