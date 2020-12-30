using System;
using System.Collections.Generic;
using System.Text;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.DAL.Repositories
{
    public class WaiterRepository : IRepository<Waiter>
    {
        private ApplicationContext db;

        public WaiterRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(Waiter item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Waiter> Find(Func<Waiter, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Waiter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Waiter> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Waiter item)
        {
            throw new NotImplementedException();
        }
    }
}
