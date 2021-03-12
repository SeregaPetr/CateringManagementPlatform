using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringManagementPlatform.DAL.Repositories
{
    internal class DishRepository : IRepository<Dish>
    {
        private readonly ApplicationContext _context;

        public DishRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Dish dish)
        {
            _context.Dishes.Add(dish);
        }

        public void Delete(Dish dish)
        {
            _context.Dishes.Remove(dish);
        }

        public async Task<IEnumerable<Dish>> GetAllAsync()
        {
            return await _context.Dishes
                .Include(d => d.Department)
                .Include(d => d.MenuCategoryMenus)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Dish> GetByIdAsync(int id)
        {
            return await _context.Dishes
                .Include(d => d.Department)
                .Include(d => d.MenuCategoryMenus)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public void Update(Dish dish)
        {
            _context.Dishes.Update(dish);
        }
    }
}
