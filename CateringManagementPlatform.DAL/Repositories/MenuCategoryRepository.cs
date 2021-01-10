using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class MenuCategoryRepository : IRepository<MenuCategory>
    {
        private readonly ApplicationContext _context;

        public MenuCategoryRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(MenuCategory item)
        {
            throw new NotImplementedException();
        }

        public void Delete(MenuCategory item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MenuCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MenuCategory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MenuCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
