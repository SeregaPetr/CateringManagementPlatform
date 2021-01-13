using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class ManagerRepository : IRepository<Manager>
    {
        private readonly ApplicationContext _context;

        public ManagerRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Manager manager)
        {
            _context.Managers.Add(manager);
        }

        public void Delete(Manager manager)
        {
            _context.Managers.Remove(manager);
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _context.Managers
                .Include(m => m.Department)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Manager> GetByIdAsync(int id)
        {
            return await _context.Managers
                .Include(m => m.Department)
                .AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Update(Manager manager)
        {
            _context.Managers.Update(manager);
        }
    }
}
