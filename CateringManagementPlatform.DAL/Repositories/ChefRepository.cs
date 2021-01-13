using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class ChefRepository : IRepository<Chef>
    {
        private readonly ApplicationContext _context;

        public ChefRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Chef chef)
        {
            _context.Chefs.Add(chef);
        }

        public void Delete(Chef chef)
        {
            _context.Chefs.Remove(chef);
        }

        public async Task<IEnumerable<Chef>> GetAllAsync()
        {
            return await _context.Chefs
                .Include(c => c.Department)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Chef> GetByIdAsync(int id)
        {
            return await _context.Chefs
               .Include(c => c.Department)
               .AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Update(Chef chef)
        {
            _context.Chefs.Update(chef);
        }
    }
}
