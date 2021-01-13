using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class GuestRepository : IRepository<Guest>
    {
        private readonly ApplicationContext _context;

        public GuestRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Guest guest)
        {
            _context.Guests.Add(guest);
        }

        public void Delete(Guest guest)
        {
            _context.Guests.Remove(guest);
        }

        public async Task<IEnumerable<Guest>> GetAllAsync()
        {
            return await _context.Guests
                .Include(g => g.Tables)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Guest> GetByIdAsync(int id)
        {
            return await _context.Guests
                .Include(g => g.Tables)
                .AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
        }

        public void Update(Guest guest)
        {
            _context.Guests.Update(guest);
        }
    }
}
