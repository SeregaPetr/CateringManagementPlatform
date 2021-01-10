using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class BarmanRepository : IRepository<Barman>
    {
        private readonly ApplicationContext _context;

        public BarmanRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Barman barman)
        {
            if (barman == null)
            {
                throw new ArgumentNullException(nameof(barman));
            }
            _context.Barmen.Add(barman);
        }

        public void Delete(Barman barman)
        {
            if (barman == null)
            {
                throw new ArgumentNullException(nameof(barman));
            }
            _context.Barmen.Remove(barman);
        }

        public async Task<Barman> GetByIdAsync(int id)
        {
            return await _context.Barmen.Include(b => b.Department).AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Barman>> GetAllAsync()
        {
            return await _context.Barmen.Include(b => b.Department).AsNoTracking().ToListAsync();
        }

        public void Update(Barman barman)
        {
            if (barman == null)
            {
                throw new ArgumentNullException(nameof(barman));
            }
            _context.Barmen.Update(barman);
        }
    }
}
