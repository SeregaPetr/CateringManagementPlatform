using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class RoleRepository : IRepository<UserRole>
    {
        private readonly ApplicationContext _context;

        public RoleRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
        }

        public void Delete(UserRole userRole)
        {
            _context.UserRoles.Remove(userRole);
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _context.UserRoles
                .Include(r=>r.Accounts)
                .AsNoTracking().ToListAsync();
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await _context.UserRoles
                .Include(r => r.Accounts)
                .AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Update(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
        }
    }
}