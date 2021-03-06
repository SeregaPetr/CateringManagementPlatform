using System;
using System.Collections.Generic;
using System.Linq;
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
            var dishDB = _context.Dishes.Include(x => x.MenuCategoryMenus).First(x => x.Id == dish.Id);

            var menuCategoryMenusForRemove = new List<MenuCategoryMenu>();

            foreach (var menuCategoryMenu in dishDB.MenuCategoryMenus)
            {
                var menuCategoryMenuDB = _context.MenuCategoryMenus.FirstOrDefault(x =>
                   x.MenuId == menuCategoryMenu.MenuId && x.MenuCategoryId == menuCategoryMenu.MenuCategoryId);

                menuCategoryMenusForRemove.Add(menuCategoryMenuDB);
            }

            foreach (var menuCategoryMenuForRemove in menuCategoryMenusForRemove)
            {
                dishDB.MenuCategoryMenus.Remove(menuCategoryMenuForRemove);
            }

            dishDB.IsArchive = true;
        }

        public async Task<IEnumerable<Dish>> GetAllAsync()
        {
            return await _context.Dishes
                .Include(d => d.Department)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Dish> GetByIdAsync(int id)
        {
            return await _context.Dishes
                .Include(d => d.Department)
                .AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
        }

        public void Update(Dish dish)
        {
            _context.Dishes.Update(dish);
        }
    }
}
