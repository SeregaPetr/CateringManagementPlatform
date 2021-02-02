using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class MenuRepository : IRepository<Menu>
    {
        private readonly ApplicationContext _context;

        public MenuRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Menu menu)
        {
            _context.Menus.Add(menu);
        }

        public void Delete(Menu menu)
        {
            _context.Menus.Remove(menu);
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await _context.Menus
                .Include(m=>m.MenuCategories)
                    .ThenInclude(mc=>mc.Dishes)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            return await _context.Menus.AsNoTracking()
                .Include(m => m.MenuCategories)
                    .ThenInclude(mc => mc.Dishes)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Update(Menu menu)
        {
            _context.Menus.Remove(menu);
        }
    }
}
