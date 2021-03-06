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
            var menuDB = _context.Menus.Include(x => x.MenuCategoryMenus).First(x => x.Id == menu.Id);
            var menuCategoryMenus = _context.MenuCategoryMenus.Where(x => x.MenuId == menu.Id);

            foreach (var menuCategoryMenu in menuCategoryMenus)
            {
                menuDB.MenuCategoryMenus.Remove(menuCategoryMenu);
            }

            _context.Menus.Remove(menuDB);
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await _context.Menus
                .Include(m => m.MenuCategories)
                    .ThenInclude(mcm => mcm.MenuCategoryMenus)
                .Include(m => m.MenuCategoryMenus)
                    .ThenInclude(mcm => mcm.Dishes)
                    .ThenInclude(d => d.Department)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            return await _context.Menus
                .Include(m => m.MenuCategories)
                    .ThenInclude(mcm => mcm.MenuCategoryMenus)
                .Include(m => m.MenuCategoryMenus)
                    .ThenInclude(mcm => mcm.Dishes)
                    .ThenInclude(d => d.Department)
                .AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Update(Menu menuUpdate)
        {
            if (menuUpdate.MenuCategories?.Count > 0)
            {
                var menuDB = _context.Menus
                    .Include(x => x.MenuCategories)
                    .Include(x => x.MenuCategoryMenus)
                        .ThenInclude(mcm => mcm.Dishes)
                    .First(x => x.Id == menuUpdate.Id);

                RemoveMenuCategory(menuUpdate, menuDB);
                AddMenuCategory(menuUpdate, menuDB);

                RemoveDishesFromMenuCategory(menuUpdate, menuDB);
                AddDishesToMenuCategory(menuUpdate, menuDB);
            }
            else
            {
                _context.Menus.Update(menuUpdate);
            }
        }

        private void RemoveDishesFromMenuCategory(Menu menuUpdate, Menu menuDB)
        {
            for (int i = 0; i < menuUpdate.MenuCategoryMenus.Count; i++)
            {
                var dishesForRemove = new List<Dish>();
                foreach (var dish in menuDB.MenuCategoryMenus[i].Dishes)
                {
                    var dishDB = menuUpdate.MenuCategoryMenus[i].Dishes.FirstOrDefault(x => x.Id == dish.Id);

                    if (dishDB is null)
                    {
                        var dishRemove = _context.Dishes.First(x => x.Id == dish.Id);
                        dishesForRemove.Add(dishRemove);
                    }
                    else
                    {
                        menuUpdate.MenuCategoryMenus[i].Dishes.Remove(dishDB);
                    }
                }

                foreach (var dish in dishesForRemove)
                {
                    menuDB.MenuCategoryMenus[i].Dishes.Remove(dish);
                }
            }

        }

        private void AddDishesToMenuCategory(Menu menuUpdate, Menu menuDB)
        {
            for (int i = 0; i < menuUpdate.MenuCategoryMenus.Count; i++)
            {
                foreach (var dish in menuUpdate.MenuCategoryMenus[i].Dishes)
                {
                    var dishDB = _context.Dishes.Find(dish.Id);
                    menuDB.MenuCategoryMenus[i].Dishes.Add(dishDB);
                }
            }
        }

        private void AddMenuCategory(Menu menuUpdate, Menu menuDB)
        {
            foreach (var menuCategory in menuUpdate.MenuCategories)
            {
                var menuCategoryDB = _context.MenuCategories.Find(menuCategory.Id);
                menuDB.MenuCategories.Add(menuCategoryDB);
            }
        }

        private void RemoveMenuCategory(Menu menuUpdate, Menu menuDB)
        {
            var menuCategoriesForRemove = new List<MenuCategory>();
            foreach (var menuCategory in menuDB.MenuCategories)
            {
                var menuCategoryDB = menuUpdate.MenuCategories.FirstOrDefault(x => x.Id == menuCategory.Id);

                if (menuCategoryDB is null)
                {
                    var menuCategoryRemove = _context.MenuCategories.First(x => x.Id == menuCategory.Id);
                    menuCategoriesForRemove.Add(menuCategoryRemove);
                }
                else
                {
                    menuUpdate.MenuCategories.Remove(menuCategoryDB);
                }
            }

            foreach (var menuCategoy in menuCategoriesForRemove)
            {
                menuDB.MenuCategories.Remove(menuCategoy);
            }
        }
    }
}
