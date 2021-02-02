using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class MenuCategoryRepository : IRepository<MenuCategory>
    {
        private readonly ApplicationContext _context;

        public MenuCategoryRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(MenuCategory menuCategory)
        {
            _context.MenuCategories.Add(menuCategory);
        }

        public void Delete(MenuCategory menuCategory)
        {
            _context.MenuCategories.Remove(menuCategory);
        }

        public async Task<IEnumerable<MenuCategory>> GetAllAsync()
        {
            return await _context.MenuCategories
                //.Include(m => m.Menu)
                .AsNoTracking().ToListAsync();
        }

        public async Task<MenuCategory> GetByIdAsync(int id)
        {
            return await _context.MenuCategories
               // .Include(m => m.Menu)
                .AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Update(MenuCategory menuCategory)
        {
            _context.MenuCategories.Update(menuCategory);
        }
    }
}
