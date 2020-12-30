using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class ManagerRepository : IRepository<Manager>
    {
        private ApplicationContext db;

        public ManagerRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(Manager item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manager> Find(Func<Manager, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Manager GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manager> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Manager item)
        {
            throw new NotImplementedException();
        }
    }
}
