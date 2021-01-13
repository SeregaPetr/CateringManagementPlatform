using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class WaiterRepository : IRepository<Waiter>
    {
        private readonly ApplicationContext _context;

        public WaiterRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Waiter waiter)
        {
            _context.Waiters.Add(waiter);
        }

        public void Delete(Waiter waiter)
        {
            _context.Waiters.Remove(waiter);
        }

        public async Task<IEnumerable<Waiter>> GetAllAsync()
        {
            return await _context.Waiters
                .Include(w => w.Department)
                .Include(w => w.Tables)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Waiter> GetByIdAsync(int id)
        {
            return await _context.Waiters
                .Include(w => w.Department)
                .Include(w => w.Tables)
                .AsNoTracking().FirstOrDefaultAsync(w => w.Id == id);
        }

        public void Update(Waiter waiter)
        {
            _context.Waiters.Update(waiter);
        }
    }
}
