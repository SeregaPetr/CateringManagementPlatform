using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class MenuCategoryRepository : IRepository<MenuCategory>
    {
        private ApplicationContext db;

        public MenuCategoryRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(MenuCategory item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuCategory> Find(Func<MenuCategory, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public MenuCategory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(MenuCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
