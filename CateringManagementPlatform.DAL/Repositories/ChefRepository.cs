using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class ChefRepository : IRepository<Chef>
    {
        private ApplicationContext db;

        public ChefRepository(ApplicationContext context)
        {
            db = context;
        }
       
        public void Create(Chef item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Chef> Find(Func<Chef, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Chef GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Chef> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Chef item)
        {
            throw new NotImplementedException();
        }
    }
}
