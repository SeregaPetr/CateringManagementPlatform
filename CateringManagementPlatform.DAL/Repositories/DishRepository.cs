using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class DishRepository : IRepository<Dish>
    {
        private ApplicationContext db;

        public DishRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(Dish item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dish> Find(Func<Dish, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Dish GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dish> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Dish item)
        {
            throw new NotImplementedException();
        }
    }
}
